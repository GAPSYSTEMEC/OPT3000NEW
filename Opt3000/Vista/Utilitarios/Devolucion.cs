using Opt3000.BaseDatos;
using Opt3000.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opt3000.Entidades;

namespace Opt3000.Vista.Utilitarios
{
    public partial class Devolucion : Form
    {
        DataTable porCargar = new DataTable();
        DataTable productos = new DataTable();
        public Devolucion(Int64 ateCodigo)
        {
            InitializeComponent();
            productos.Columns.Add("ID").ReadOnly = true;
            productos.Columns.Add("ID DETALLE").ReadOnly = true;
            productos.Columns.Add("DETALLE").ReadOnly = true;
            productos.Columns.Add("CANTIDAD").ReadOnly = true;
            CargaDevolucion(ateCodigo);
            porCargar.Columns.Add("ID").ReadOnly = true;
            porCargar.Columns.Add("ID DETALLE").ReadOnly = true;
            porCargar.Columns.Add("DETALLE").ReadOnly = true;
            porCargar.Columns.Add("CANTIDAD").ReadOnly = true;
        }

        public void CargaDevolucion(Int64 ateCodigo)
        {
            List<DevolucionLista> lista = new List<DevolucionLista>();
            lista = NegConsultas.getInstance().RecuperaCuentaPacienteDevolucion(ateCodigo);

            foreach (var item in lista)
            {
                productos.Rows.Add(new object[] { item.ID, item.ID_DETALLE, item.DETALLE, item.CANTIDAD });
            }
            dgv_Inventario.DataSource = productos;
            dgv_Inventario.Columns["ID"].Width = 75;
            dgv_Inventario.Columns["ID DETALLE"].Width = 75;
            dgv_Inventario.Columns["DETALLE"].Width = 275;
            dgv_Inventario.Columns["CANTIDAD"].Width = 75;
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

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().SoloNumeros(e);
        }

        private void Guarda()
        {
            int fila = dgv_Inventario.CurrentRow.Index;
            if (fila >= 0)
            {
                if (Convert.ToDecimal(dgv_Inventario.Rows[fila].Cells[3].Value.ToString()) >= Convert.ToDecimal(txtCantidad.Text))
                {
                    porCargar.Rows.Add(new object[] {
                    Convert.ToInt64(dgv_Inventario.Rows[fila].Cells[0].Value.ToString()),
                    Convert.ToInt64(dgv_Inventario.Rows[fila].Cells[1].Value.ToString()),
                    dgv_Inventario.Rows[fila].Cells[2].Value.ToString(),
                    Convert.ToInt16(txtCantidad.Text)
                    });

                    dgv_Pendientes.DataSource = porCargar;
                    dgv_Pendientes.Columns["ID"].Width = 75;
                    dgv_Pendientes.Columns["ID DETALLE"].Width = 75;
                    dgv_Pendientes.Columns["DETALLE"].Width = 275;
                    dgv_Pendientes.Columns["CANTIDAD"].Width = 75;
                }
                else
                {
                    MessageBox.Show("No puedes devolver más de la cantidad solicitada", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Debe seleccionar un item para poder devolver :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Guarda();
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GenerarCuenta();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GenerarCuenta()
        {
            try
            {
                for (int i = 0; i < dgv_Pendientes.Rows.Count - 1; i++)
                {
                    NegActualizacion.getInstance().DevuelveProducto(Convert.ToInt64(dgv_Pendientes.Rows[i].Cells[0].Value.ToString()), Convert.ToInt64(dgv_Pendientes.Rows[i].Cells[1].Value.ToString()), Convert.ToInt64(dgv_Pendientes.Rows[i].Cells[3].Value.ToString()));
                }
                MessageBox.Show("Items devueltos con exito. :)", "HIS3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Existe problemas de conectividad con la Base de Datos", "HIS3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
