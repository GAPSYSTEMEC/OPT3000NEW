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

namespace Opt3000.Vista.Utilitarios.Menu
{
    public partial class Pedidos : Form
    {
        DataTable porCargar = new DataTable();
        List<TIPO_PRODUCTO> lista = new List<TIPO_PRODUCTO>();
        Int64[,] matris = new long[10, 2];
        int fila = 0;
        string nombreArchivo = "";
        decimal ivaActual = Convert.ToDecimal(NegConsultas.getInstance().RecuperaParametro("iva"));
        public Pedidos()
        {
            InitializeComponent();
            CargaTipoProducto();
            int conta = 0;
            foreach (var item in lista)
            {
                CONTADOR_PRODUCTOS obj = new CONTADOR_PRODUCTOS();
                obj = NegConsultas.getInstance().Contador(item.ID_TIPOPRODUCTO);
                matris[conta, 0] = item.ID_TIPOPRODUCTO;
                matris[conta, 1] = obj.Contador;
                conta++;
            }
        }

        public void CargaTipoProducto()
        {
            lista = NegConsultas.getInstance().TipoProducto();

            cmb_TipoProduc.DataSource = lista;
            cmb_TipoProduc.ValueMember = "ID_TIPOPRODUCTO";
            cmb_TipoProduc.DisplayMember = "Detalle";
            cmb_TipoProduc.SelectedText = "";
            cmb_TipoProduc.SelectedIndex = -1;
        }

        private void txtFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().SoloNumeros(e);
        }

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().OnlyNumberDecimal(e);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().SoloNumeros(e);
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().OnlyNumberDecimal(e);
        }

        private void btnCarga_Click(object sender, EventArgs e)
        {
            if (ValidaDatos())
            {
                BloqueaControles();
                if (ConfirmaRepetidos())
                {
                    MessageBox.Show("El Producto ya fue registrado :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                decimal iva = 0;
                string tipo = "";
                if (chIva.Checked)
                    iva = (Convert.ToDecimal(txtCantidad.Text) * Convert.ToDecimal(txtCosto.Text)) * ivaActual;
                else
                    iva = 0;
                if (rbBien.Checked)
                {
                    tipo = "B";
                }
                else
                    tipo = "S";
                DataGridViewRow dt = new DataGridViewRow();
                dt.CreateCells(dgv_Pendientes);
                dt.Cells[0].Value = "";
                dt.Cells[1].Value = "";
                dt.Cells[2].Value = "";
                dt.Cells[3].Value = "";
                dt.Cells[4].Value = "";
                dt.Cells[5].Value = "";
                dt.Cells[6].Value = "";
                dt.Cells[7].Value = "";
                dgv_Pendientes.Rows.Add(dt);

                dgv_Pendientes.Rows[fila].Cells["Codigo"].Value = txtCodigo.Text;
                dgv_Pendientes.Rows[fila].Cells["Detalle"].Value = txtDetalle.Text;
                dgv_Pendientes.Rows[fila].Cells["Costo"].Value = txtCosto.Text;
                dgv_Pendientes.Rows[fila].Cells["Cantidad"].Value = txtCantidad.Text;
                dgv_Pendientes.Rows[fila].Cells[4].Value = txtGanancia.Text;
                dgv_Pendientes.Rows[fila].Cells["PagaIva"].Value = iva.ToString();
                dgv_Pendientes.Rows[fila].Cells["Tipo"].Value = tipo;
                dgv_Pendientes.Rows[fila].Cells[7].Value = txtSeleccionar.Text;
                LimpiaControlesProducto();
                Sumar();
                fila++;
                txtCodigo.Focus();
                int conta = 0;
                foreach (var item in lista)
                {
                    if (item.ID_TIPOPRODUCTO == Convert.ToInt16(cmb_TipoProduc.SelectedValue.ToString()))
                    {
                        string inicio = cmb_TipoProduc.Text.Substring(0, 2);
                        int max = Convert.ToInt16(matris[conta, 1]);
                        max++;
                        txtCodigo.Text = inicio + max;
                        matris[conta, 1] = max;
                    }
                    conta++;
                }

            }
        }

        private void BloqueaControles()
        {
            txtFactura.ReadOnly = true;
            dt_FechaFactura.Enabled = false;
            txtProveedor.ReadOnly = true;
            txtTotal.ReadOnly = true;
            //txtObservacion.ReadOnly = true;
        }
        public void LimpiaControlesProducto()
        {
            txtCodigo.Text = "";
            txtDetalle.Text = "";
            txtCantidad.Text = "";
            txtCosto.Text = "";
            if (!chIva.Checked)
                chIva.Checked = true;
            if (rbServicio.Checked)
            {
                rbServicio.Checked = false;
                rbBien.Checked = true;
            }
        }
        private void Sumar()
        {
            decimal suma = 0;
            for (int i = 0; i < dgv_Pendientes.Rows.Count - 1; i++)
            {
                suma += (Convert.ToDecimal(dgv_Pendientes.Rows[i].Cells[2].Value.ToString()) * Convert.ToDecimal(dgv_Pendientes.Rows[i].Cells[3].Value.ToString())) + Convert.ToDecimal(dgv_Pendientes.Rows[i].Cells[5].Value.ToString());
            }
            txtTotalCargar.Text = Math.Round(suma, 2).ToString("0.##");
        }

        private bool ConfirmaRepetidos()
        {
            for (int i = 0; i < dgv_Pendientes.Rows.Count - 1; i++)
            {
                if (txtCodigo.Text == dgv_Pendientes.Rows[i].Cells[0].Value.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        private void txtFactura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void dt_FechaFactura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void txtProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void txtTotal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void txtObservacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void txtDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void txtCosto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
                txtGanancia.Focus();
        }

        public bool ValidaDatos()
        {
            error.Clear();
            bool valido = true;
            if (txtFactura.Text == "")
            {
                AgregarError(txtFactura, "Se necesita Número de factura para Cargar");
                valido = false;
            }
            if (txtProveedor.Text == "")
            {
                AgregarError(txtProveedor, "Se necesita nombre de proveedor para Cargar");
                valido = false;
            }
            if (txtTotal.Text == "")
            {
                AgregarError(txtTotal, "Se necesita el total de la factura para Cargar");
                valido = false;
            }
            if (txtObservacion.Text == "")
            {
                AgregarError(txtObservacion, "Se necesita Observación de factura para Cargar");
                valido = false;
            }
            if (txtCodigo.Text == "")
            {
                AgregarError(txtCodigo, "Se necesita codigo de producto para Cargar");
                valido = false;
            }
            if (txtDetalle.Text == "")
            {
                AgregarError(txtDetalle, "Se necesita detalle de producto para Cargar");
                valido = false;
            }
            if (txtCantidad.Text == "")
            {
                AgregarError(txtCantidad, "Se necesita cantidad de producto para Cargar");
                valido = false;
            }
            if (txtCosto.Text == "")
            {
                AgregarError(txtCosto, "Se necesita costo de producto para Cargar");
                valido = false;
            }

            return valido;
        }

        private void AgregarError(Control control, string texto)
        {
            error.SetError(control, texto);
        }

        private void txtFactura_Leave(object sender, EventArgs e)
        {
            if (txtFactura.Text.Length != 15 && txtFactura.Text != "")
            {
                MessageBox.Show("Esto no es un número de factura :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFactura.Text = "";
                txtFactura.Focus();
            }
        }

        private void btnGuarda_Click(object sender, EventArgs e)
        {
            if (dgv_Pendientes.Rows.Count != 0)
            {
                ORDEN_PEDIDO ordenPed = new ORDEN_PEDIDO();
                if (txtTotal.Text == txtTotalCargar.Text)
                {
                    ordenPed = NegConsultas.getInstance().RecuperaOrden(txtFactura.Text);
                    if (ordenPed == null)
                    {
                        if (MessageBox.Show("La orden esta completa y la misma se cargara al inventario :)", "OPT3000", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            GuardaInfo(true);
                        }
                        else
                        {
                            GuardaInfo(false);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La orden esta completa y la misma se cargara al inventario :)", "OPT3000", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        ActualizaOrdenPedido(true, ordenPed.ID_ORDEN);
                    }
                }
                else
                {
                    if (MessageBox.Show("Orden Incompleta desea guardar parcial??", "OPT3000", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ordenPed = NegConsultas.getInstance().RecuperaOrden(txtFactura.Text);
                        if (ordenPed == null)
                        {
                            GuardaInfo(false);
                        }
                        else
                        {
                            ActualizaOrdenPedido(false, ordenPed.ID_ORDEN);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Ingrese Productos Para Guardar :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void GuardaInfo(bool estado)
        {
            List<DETALLE_ORDEN> lista = new List<DETALLE_ORDEN>();
            ORDEN_PEDIDO orden = new ORDEN_PEDIDO();
            orden.FechaFactura = dt_FechaFactura.Value;
            orden.NumeroFactura = txtFactura.Text;
            orden.Proveedor = txtProveedor.Text;
            orden.TotalFactura = Convert.ToDecimal(txtTotal.Text);
            orden.CargaInventario = estado;
            orden.Detalle = txtDetalle.Text;
            orden.IMAGEN = txtSeleccionar.Text;
            for (int i = 0; i < dgv_Pendientes.Rows.Count - 1; i++)
            {
                DETALLE_ORDEN obj = new DETALLE_ORDEN();
                obj.CodProducto = dgv_Pendientes.Rows[i].Cells[0].Value.ToString();
                obj.Nombre = dgv_Pendientes.Rows[i].Cells[1].Value.ToString();
                obj.Costo = Convert.ToDecimal(dgv_Pendientes.Rows[i].Cells[2].Value.ToString());
                obj.Cantidad = Convert.ToInt16(dgv_Pendientes.Rows[i].Cells[3].Value.ToString());
                obj.Ganacia = Convert.ToDecimal(dgv_Pendientes.Rows[i].Cells[4].Value.ToString());
                obj.Imagen = dgv_Pendientes.Rows[i].Cells[4].Value.ToString();
                if (dgv_Pendientes.Rows[i].Cells[5].Value.ToString() == "0")
                    obj.PagaIva = false;
                else
                    obj.PagaIva = true;
                obj.Tipo = dgv_Pendientes.Rows[i].Cells[6].Value.ToString();
                lista.Add(obj);
            }
            Password frm = new Password();
            frm.ShowDialog();
            if (frm.idUsuario == 0)
            {
                return;
            }
            orden.ID_USUARIO = frm.idUsuario;
            NegGuarda.getInstance().GuardaOrden(orden, lista, matris);
            MessageBox.Show("Orden almacenada con exito :)", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        public void ActualizaOrdenPedido(bool estado, Int64 orden)
        {
            List<DETALLE_ORDEN> lista = new List<DETALLE_ORDEN>();
            for (int i = 0; i < dgv_Pendientes.Rows.Count - 1; i++)
            {
                DETALLE_ORDEN obj = new DETALLE_ORDEN();
                obj.ID_ORDEN = orden;
                obj.CodProducto = dgv_Pendientes.Rows[i].Cells[0].Value.ToString();
                obj.Nombre = dgv_Pendientes.Rows[i].Cells[1].Value.ToString();
                obj.Costo = Convert.ToDecimal(dgv_Pendientes.Rows[i].Cells[2].Value.ToString());
                obj.Cantidad = Convert.ToInt16(dgv_Pendientes.Rows[i].Cells[3].Value.ToString());
                obj.Ganacia = Convert.ToDecimal(dgv_Pendientes.Rows[i].Cells[4].Value.ToString());
                if (dgv_Pendientes.Rows[i].Cells[5].Value.ToString() == "0")
                    obj.PagaIva = false;
                else
                    obj.PagaIva = true;
                obj.Tipo = dgv_Pendientes.Rows[i].Cells[6].Value.ToString();
                lista.Add(obj);
            }
            NegActualizacion.getInstance().ActualizaDetallePedidos(lista, orden, estado);
            MessageBox.Show("Orden almacenada con exito :)", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void txtGanancia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
                btnCarga.Focus();
        }

        private void txtGanancia_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().OnlyNumberDecimal(e);
        }

        private void txtTotal_Leave(object sender, EventArgs e)
        {
            try
            {
                txtTotal.Text = Math.Round(Convert.ToDecimal(txtTotal.Text), 2).ToString("0.##");

            }
            catch
            {


            }
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            RecuperaOrden frm = new RecuperaOrden();
            frm.ShowDialog();
            ORDEN_PEDIDO orden = new ORDEN_PEDIDO();
            orden = NegConsultas.getInstance().RecuperaOrden(frm.factura);

            txtFactura.Text = orden.NumeroFactura;
            dt_FechaFactura.Value = orden.FechaFactura;
            txtProveedor.Text = orden.Proveedor;
            txtTotal.Text = orden.TotalFactura.ToString();
            txtObservacion.Text = orden.Detalle;

            List<DETALLE_ORDEN> lista = new List<DETALLE_ORDEN>();
            lista = NegConsultas.getInstance().RecuperaProductosOrden(orden.ID_ORDEN);
            foreach (var item in lista)
            {
                DataGridViewRow dt = new DataGridViewRow();
                dt.CreateCells(dgv_Pendientes);
                dt.Cells[0].Value = "";
                dt.Cells[1].Value = "";
                dt.Cells[2].Value = "";
                dt.Cells[3].Value = "";
                dt.Cells[4].Value = "";
                dt.Cells[5].Value = "";
                dt.Cells[6].Value = "";
                dgv_Pendientes.Rows.Add(dt);

                dgv_Pendientes.Rows[fila].Cells["Codigo"].Value = item.CodProducto;
                dgv_Pendientes.Rows[fila].Cells["Detalle"].Value = item.Nombre;
                dgv_Pendientes.Rows[fila].Cells["Costo"].Value = item.Costo;
                dgv_Pendientes.Rows[fila].Cells["Cantidad"].Value = item.Cantidad;
                dgv_Pendientes.Rows[fila].Cells[4].Value = item.Ganacia;
                if (item.PagaIva)
                    dgv_Pendientes.Rows[fila].Cells["PagaIva"].Value = item.Costo * ivaActual;
                else
                    dgv_Pendientes.Rows[fila].Cells["PagaIva"].Value = 0;
                dgv_Pendientes.Rows[fila].Cells["Tipo"].Value = item.Tipo;

                Sumar();
                fila++;
            }
            txtCodigo.Focus();
        }

        private void btnVerDoc_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string str_RutaArchivo = openFileDialog1.FileName;
                    txtSeleccionar.Text = str_RutaArchivo;
                    nombreArchivo = openFileDialog1.SafeFileName;
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        private void cmb_TipoProduc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_TipoProduc.SelectedValue != null && cmb_TipoProduc.Text != "Opt3000.BaseDatos.TIPO_PRODUCTO")
            {
                int conta = 0;
                foreach (var item in lista)
                {
                    if (item.ID_TIPOPRODUCTO == Convert.ToInt16(cmb_TipoProduc.SelectedValue.ToString()))
                    {
                        string inicio = cmb_TipoProduc.Text.Substring(0, 2);
                        int max = Convert.ToInt16(matris[conta, 1]);
                        txtCodigo.Text = inicio + max;
                    }
                    conta++;
                }
            }
        }

        private void cmb_TipoProduc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }
    }
}
