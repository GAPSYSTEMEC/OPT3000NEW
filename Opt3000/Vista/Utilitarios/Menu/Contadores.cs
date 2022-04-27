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
    public partial class Contadores : Form
    {
        public Contadores()
        {
            InitializeComponent();
            CargaTipoProducto();
        }

        public void CargaTipoProducto()
        {
            List<TIPO_PRODUCTO> lista = NegConsultas.getInstance().TipoProducto();
            cmb_TipoProduc.DataSource = lista;
            cmb_TipoProduc.ValueMember = "ID_TIPOPRODUCTO";
            cmb_TipoProduc.DisplayMember = "Detalle";
            cmb_TipoProduc.SelectedText = "";
            cmb_TipoProduc.SelectedIndex = -1;
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            if (txtNuevoCodigo.Text != "")
            {
                if (MessageBox.Show("¿Esta seguro de actualizar el contador de codigos? :[", "OPT3000", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    CONTADOR_PRODUCTOS obj = new CONTADOR_PRODUCTOS();
                    obj.ID_TIPOPRODUCTO = Convert.ToInt16(cmb_TipoProduc.SelectedValue.ToString());
                    obj.Contador = Convert.ToInt64(txtNuevoCodigo.Text);
                    NegActualizacion.getInstance().ActualizaCodigo(obj);
                    MessageBox.Show("Contador actualizado :)", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmb_TipoProduc.SelectedIndex = -1;
                    txtCodigoActual.Text = "0";
                    txtNuevoCodigo.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Ingresa el código nuevo :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmb_TipoProduc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CONTADOR_PRODUCTOS obj = new CONTADOR_PRODUCTOS();
            if (cmb_TipoProduc.SelectedValue != null && cmb_TipoProduc.Text != "Opt3000.BaseDatos.TIPO_PRODUCTO")
            {
                obj = NegConsultas.getInstance().Contador(Convert.ToInt16(cmb_TipoProduc.SelectedValue.ToString()));
                txtCodigoActual.Text = obj.Contador.ToString();
            }
        }

        private void txtNuevoCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().SoloNumeros(e);
        }
    }
}
