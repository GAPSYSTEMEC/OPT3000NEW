using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opt3000.Negocio;

namespace Opt3000.Vista.Utilitarios
{
    public partial class Calculadora : Form
    {
        public string esfera = "";
        public string cilindro = "";
        public string eje = "";
        public Calculadora()
        {
            InitializeComponent();
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

        private void txtEsfera_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                FuncionesBasicas.getInstance().SaltarConEnter(e);
            }
        }

        private void txtEsfera_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().ValidaCaracterEsfera(e);
        }

        private void txtEsfera_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal valor = 0;
                if (txtEsfera.Text == "N")
                {
                    txtEsferaR.Text = "0.00";
                    return;
                }
                string[] valores = txtEsfera.Text.Split('.');
                if (Convert.ToInt16(valores[1]) % 25 == 0 || Convert.ToInt16(valores[1]) % 50 == 0 || Convert.ToInt16(valores[1]) % 75 == 0 || Convert.ToInt16(valores[1]) % 0 == 0)
                {
                    valor = Convert.ToDecimal(txtEsfera.Text);
                }
                else
                {
                    MessageBox.Show("Valor incorrecto :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEsfera.Text = "";
                    txtEsfera.Focus();
                    return;
                }
                if (txtEsfera.Text.Length <= 5)
                {
                    if (valor > 0)
                        txtEsfera.Text = "+" + valor.ToString("0.00", CultureInfo.InvariantCulture);
                    else
                        txtEsfera.Text = valor.ToString("0.00", CultureInfo.InvariantCulture);
                    txtEsferaR.Text = txtEsfera.Text;
                }

            }
            catch
            {
                MessageBox.Show("Esto no parece un VALOR ACEPTADO :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEsfera.Focus();
                txtEsfera.Text = "";
            }
        }

        private void txtCilindro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                FuncionesBasicas.getInstance().SaltarConEnter(e);
            }
        }

        private void txtCilindro_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().ValidaCaracterEsfera(e);
        }

        private void txtCilindro_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtCilindro.Text == "N")
                {
                    txtCilindroR.Text = "0.00";
                    return;
                }
                decimal cilindro = 0;
                string[] valores = txtCilindro.Text.Split('.');
                if (Convert.ToInt16(valores[1]) % 25 == 0 || Convert.ToInt16(valores[1]) % 50 == 0 || Convert.ToInt16(valores[1]) % 75 == 0 || Convert.ToInt16(valores[1]) % 0 == 0)
                {
                    cilindro = Convert.ToDecimal(txtCilindro.Text);
                }
                else
                {
                    MessageBox.Show("Valor incorrecto :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCilindro.Text = "";
                    txtCilindro.Focus();
                    return;
                }

                decimal esfera = Convert.ToDecimal(txtEsferaR.Text);
                if (txtCilindro.Text.Length <= 5)
                {
                    if (cilindro > 0)
                        txtCilindro.Text = "+" + cilindro.ToString("0.00", CultureInfo.InvariantCulture);
                    else
                        txtCilindro.Text = cilindro.ToString("0.00", CultureInfo.InvariantCulture);
                    if (cilindro < 0)
                    {
                        txtCilindroR.Text = cilindro.ToString("0.00", CultureInfo.InvariantCulture);
                        return;
                    }
                    if ((esfera + cilindro) > 0)
                        txtEsferaR.Text = "+" + (esfera + cilindro).ToString();
                    else
                        txtEsferaR.Text = (esfera + cilindro).ToString();

                    txtCilindroR.Text = "-" + cilindro.ToString("0.00", CultureInfo.InvariantCulture);
                }

            }
            catch
            {
                MessageBox.Show("Esto no parece un valor permitido :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCilindro.Focus();
                txtCilindro.Text = "";
            }
        }

        private void txtEje_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                FuncionesBasicas.getInstance().SaltarConEnter(e);
            }
        }

        private void txtEje_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().SoloNumeros(e);
        }

        private void txtEje_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtEje.Text) > 180)
                {
                    MessageBox.Show("El valor máximo permitido es 180° :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEje.Text = "";
                    txtEje.Focus();
                    return;
                }

                decimal cilindro = 0;
                if (txtCilindro.Text != "N")
                    cilindro = Convert.ToDecimal(txtCilindro.Text);
                if (cilindro < 0)
                {
                    txtEjeR.Text = txtEje.Text;
                    return;
                }
                decimal valor = Convert.ToDecimal(txtEje.Text);
                if (valor > 90)
                {
                    txtEjeR.Text = (valor - 90).ToString();
                }
                else
                {
                    txtEjeR.Text = (valor + 90).ToString();
                }
                btnGuardar.Focus();

            }
            catch
            {
                MessageBox.Show("Esto no parece un número :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEje.Focus();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtEsfera.Text != "")
                if (txtCilindro.Text != "")
                    if (txtEje.Text != "")
                    {
                        esfera = txtEsferaR.Text;
                        cilindro = txtCilindroR.Text;
                        eje = txtEjeR.Text;
                        this.Close();
                    }
                    else
                        MessageBox.Show("Ingrese un valor para EJE :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Ingrese un valor para CILINDRO :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Ingrese un valor para ESFERA :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void Calculadora_Load(object sender, EventArgs e)
        {

        }
    }
}
