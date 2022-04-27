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

namespace Opt3000.Vista.Utilitarios.Menu
{
    public partial class Productos : Form
    {
        DataTable porCargar = new DataTable();
        List<TIPO_PRODUCTO> lista = new List<TIPO_PRODUCTO>();
        Int64[,] matris = new long[10, 2];
        int fila = 0;
        string nombreArchivo = "";
        decimal ivaActual = Convert.ToDecimal(NegConsultas.getInstance().RecuperaParametro("iva"));
        public Productos()
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

        private void cmb_TipoProduc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
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


        private void btnCarga_Click(object sender, EventArgs e)
        {
            if (ValidaDatos())
            {
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
                PRODUCTO obj = new PRODUCTO();
                obj.Detalle = txtDetalle.Text;
                obj.Precio = Convert.ToDecimal(txtCosto.Text);
                if (iva == 0)
                    obj.PagaIva = true;
                else
                    obj.PagaIva = false;
                obj.Especificaciones = tipo;
                obj.STOCK = Convert.ToInt16(txtCantidad.Text);
                obj.ID_DETALLE = 0;
                obj.CodProducto = txtCodigo.Text;
                if (NegGuarda.getInstance().GuardaProducto(obj))
                {
                    MessageBox.Show("Producto almacenado con exito.", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Producto no almacenado vuelva a intentarlo.", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void AgregarError(Control control, string texto)
        {
            error.SetError(control, texto);
        }


        public bool ValidaDatos()
        {
            error.Clear();
            bool valido = true;

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
    }
}
