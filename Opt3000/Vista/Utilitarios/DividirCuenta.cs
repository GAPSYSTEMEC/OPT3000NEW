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

namespace Opt3000.Vista.Utilitarios
{
    public partial class DividirCuenta : Form
    {
        public bool dividida = false;
        Int64 ateCodigo;
        decimal iva;
        decimal valor;
        public DividirCuenta( Int64 _ateCodigo, string _total, string _iva )
        {
            InitializeComponent();
            ateCodigo = _ateCodigo;
            lblTotal.Text = _total;
            valor = Convert.ToDecimal(_total);
            string[] ivaValor = _iva.Split('%');
            iva = Convert.ToDecimal(ivaValor[0].ToString());
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().OnlyNumberDecimal(e);
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Ingrese el valor de la primera factura", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Ingrese el valor de la segunda factura", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if(NegGuarda.getInstance().DivideCuenta(ateCodigo, Convert.ToDecimal(textBox1.Text), Convert.ToDecimal(textBox2.Text), iva))
            {
                MessageBox.Show("Cuenta dividida con exito", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dividida = true;
                this.Close();
            }else
            {
                MessageBox.Show("Cuenta no se pudo dividir vuelva a intentar", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                textBox2.Text = (valor - Convert.ToDecimal(textBox1.Text)).ToString();
                if (Convert.ToDecimal(textBox2.Text) > 0)
                {
                    return;
                }
                MessageBox.Show("Valide los valores de las facturas antes de ingresarlos", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
                textBox2.Text = "";
            }
            catch 
            {

               
            }
            
        }
    }
}
