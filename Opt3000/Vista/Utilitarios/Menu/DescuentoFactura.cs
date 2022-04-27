using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opt3000.Negocio;

namespace Opt3000.Vista.Utilitarios.Menu
{
    public partial class DescuentoFactura : Form
    {
        public decimal total = 0;
        public DescuentoFactura(string valor)
        {
            InitializeComponent();
            txtValor.Text = valor;
        }

        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().SoloNumeros(e);
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

        private void txtPorcentaje_Leave(object sender, EventArgs e)
        {
            decimal valor = Convert.ToDecimal(txtValor.Text);
            int porcentaje = Convert.ToInt16(txtPorcentaje.Text);
            total = (valor * porcentaje) / 100;
            txtDescuento.Text = total.ToString();
        }

        private void btnGenera_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
