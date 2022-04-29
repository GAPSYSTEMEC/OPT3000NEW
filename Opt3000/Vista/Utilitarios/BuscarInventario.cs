using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opt3000.BaseDatos;
using Opt3000.Negocio;

namespace Opt3000.Vista.Utilitarios
{
    public partial class BuscarInventario : Form
    {
        Int64 ateCodigo = 0;
        CLIENTE cli = new CLIENTE();
        DataTable porCargar = new DataTable();
        DataTable productos = new DataTable();
        bool agrupado = false;
        public BuscarInventario(CLIENTE obj = null, Int64 ateCod = 0, bool _agrupado = false)
        {
            InitializeComponent();
            agrupado = _agrupado;
            cli = obj;
            ateCodigo = ateCod;
            //productos.Columns.Add("ID");
            productos.Columns.Add("ID").ReadOnly = true;
            productos.Columns.Add("DETALLE").ReadOnly = true;
            productos.Columns.Add("PRECIO").ReadOnly = true;
            productos.Columns.Add("STOCK").ReadOnly = true;
            productos.Columns.Add("ESP").ReadOnly = true;
            Buscador("");
            porCargar.Columns.Add("ID").ReadOnly = true;
            porCargar.Columns.Add("DETALLE").ReadOnly = true;
            porCargar.Columns.Add("CANTIDAD").ReadOnly = true;
            porCargar.Columns.Add("PRECIO").ReadOnly = false;
        }

        private void Buscador(string esp)
        {
            try
            {
                List<PRODUCTO> producto = new List<PRODUCTO>();
                producto = NegConsultas.getInstance().CargaProductos(esp);


                foreach (var item in producto)
                {
                    productos.Rows.Add(new object[] { item.CodProducto, item.Detalle, item.Precio, item.STOCK, item.Especificaciones });
                }
                dgv_Inventario.DataSource = productos;
                dgv_Inventario.Columns["ID"].Width = 50;
                dgv_Inventario.Columns["DETALLE"].Width = 550;
                dgv_Inventario.Columns["PRECIO"].Width = 75;
                dgv_Inventario.Columns["STOCK"].Width = 85;
                dgv_Inventario.Columns["ESP"].Width = 50;


            }
            catch (Exception)
            {
                throw;
            }

        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string parametro = "DETALLE";
            var filtro = parametro + " like '%" + txtBuscar.Text + "%'";
            productos.DefaultView.RowFilter = filtro;
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().SoloNumeros(e);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Guarda();
        }

        private void Guarda()
        {
            int fila = dgv_Inventario.CurrentRow.Index;
            if (fila >= 0)
            {
                if (NegConsultas.getInstance().ConsultaStock(dgv_Inventario.Rows[fila].Cells[0].Value.ToString(), Convert.ToInt32(txtCantidad.Text)))
                {
                    porCargar.Rows.Add(new object[] {
                        dgv_Inventario.Rows[fila].Cells[0].Value.ToString(),
                        dgv_Inventario.Rows[fila].Cells[1].Value.ToString(),
                        Convert.ToInt16(txtCantidad.Text),
                        Convert.ToInt16(txtCantidad.Text) * Convert.ToDouble(dgv_Inventario.Rows[fila].Cells[2].Value.ToString())
                    });

                    dgv_Pendientes.DataSource = porCargar;
                    txtBuscar.Focus();
                }
                else
                {
                    MessageBox.Show("Cantidad en Stock insuficiente", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Debe seleccionar un item para poder agregar :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void dgv_Inventario_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            if (e.KeyCode.Equals(Keys.Enter))
            {
                DataGridViewRow row = ((DataGridView)sender).CurrentRow;
                string valorPrimerCelda = Convert.ToString(row.Cells[0].Value);
                e.Handled = true;
                txtCantidad.Focus();
            }
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            //e.SuppressKeyPress = true;
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnAgregar.Focus();
            }
        }

        private void btnAgregar_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            if (e.KeyCode.Equals(Keys.Enter))
            {
                Guarda();
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                dgv_Inventario.Focus();
                dgv_Inventario.Rows[0].Selected = true;
                dgv_Inventario.CurrentCell = dgv_Inventario.Rows[0].Cells[0];
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_Pendientes.Rows.Count - 1; i++)
            {
                if (!NegConsultas.getInstance().ConsultaStock(dgv_Inventario.Rows[i].Cells[0].Value.ToString(), Convert.ToInt32(txtCantidad.Text)))
                {
                    MessageBox.Show("El Producto " + dgv_Pendientes.Rows[i].Cells[1].Value.ToString() + ", no cuenta con Stock suficiente", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            GenerarCuenta();
        }

        private void GenerarCuenta()
        {
            try
            {
                Int64 codCli = NegGuarda.getInstance().GuardaCliente(cli);
                CUENTA_PACIENTE cue = new CUENTA_PACIENTE();
                cue.ID_CLIENTE = codCli;
                cue.ID_ATENCION = ateCodigo;
                Int64 codCuenta = 0;
                if (!agrupado)
                    codCuenta = NegGuarda.getInstance().GuardaCuentaPaciente(cue);
                else
                    codCuenta = NegGuarda.getInstance().GuardaCuentaPacienteAgrupada(cue);

                DETALLE deta = new DETALLE();
                for (int i = 0; i < dgv_Pendientes.Rows.Count - 1; i++)
                {
                    deta.Cantidad = Convert.ToInt32(dgv_Pendientes.Rows[i].Cells[2].Value.ToString());
                    if (NegConsultas.getInstance().ConsultaStock(dgv_Pendientes.Rows[i].Cells[0].Value.ToString(), Convert.ToInt16(dgv_Pendientes.Rows[i].Cells[2].Value.ToString())))
                    {
                        PRODUCTO obj = new PRODUCTO();
                        obj = NegConsultas.getInstance().RecuperaProducto(dgv_Pendientes.Rows[i].Cells[0].Value.ToString());
                        PRODUCTO pro = NegConsultas.getInstance().Producto(obj.ID_PRODUCTO);
                        if (pro.Especificaciones == "B")
                        {
                            NegActualizacion.getInstance().ModificaStock(obj.ID_PRODUCTO, Convert.ToInt32(dgv_Pendientes.Rows[i].Cells[2].Value.ToString()));
                            deta.Iva = Convert.ToDecimal(dgv_Pendientes.Rows[i].Cells[3].Value.ToString()) * Convert.ToDecimal(NegConsultas.getInstance().RecuperaParametro("iva"));
                        }
                        else
                            deta.Iva = 0;

                        try
                        {
                            Convert.ToDecimal(dgv_Pendientes.Rows[i].Cells[3].Value.ToString());
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Esto no es un número :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgv_Pendientes.Rows[i].Cells[3].Value = "";
                            dgv_Pendientes.Rows[i].Cells[3].Style.BackColor = Color.Red;
                            return;

                        }
                        deta.ID_CUENTA_PACIENTE = codCuenta;
                        deta.ID_PRODUCTO = obj.ID_PRODUCTO;
                        deta.Cantidad = Convert.ToInt32(dgv_Pendientes.Rows[i].Cells[2].Value.ToString());
                        deta.Total = Convert.ToDecimal(dgv_Pendientes.Rows[i].Cells[3].Value.ToString());
                        deta.Sub_total = Convert.ToDecimal(dgv_Pendientes.Rows[i].Cells[3].Value.ToString()) / Convert.ToInt32(dgv_Pendientes.Rows[i].Cells[2].Value.ToString());
                        deta.Descuento = 0;
                        NegGuarda.getInstance().GuardaDetalle(deta);
                    }
                }
                MessageBox.Show("Items Agregados a la cuenta del Paciente. :)", "HIS3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Existe problemas de conectividad con la Base de Datos", "HIS3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BuscarInventario_Load(object sender, EventArgs e)
        {


        }

        private void dgv_Pendientes_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int columna = dgv_Pendientes.SelectedCells[0].ColumnIndex;
            if (columna == 3)
            {
                DataGridViewTextBoxEditingControl dText = (DataGridViewTextBoxEditingControl)e.Control;

                dText.KeyPress -= new KeyPressEventHandler(dText_KeyPress);
                dText.KeyPress += new KeyPressEventHandler(dText_KeyPress);
            }
        }

        void dText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
