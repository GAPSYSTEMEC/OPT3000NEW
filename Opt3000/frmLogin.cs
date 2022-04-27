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

namespace Opt3000
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
            {
                e.SuppressKeyPress = true;
                txtClave.Focus();
            }
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
            {
                e.SuppressKeyPress = true;
                btnAceptar.Focus();
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtClave.Enabled = true;
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnAceptar.Enabled = true;
            txtClave.PasswordChar = '*';
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            USUARIO objUsuario = new USUARIO();
            objUsuario = NegConsultas.getInstance().ConsultaUsuario(txtUsuario.Text, txtClave.Text);
            if (objUsuario != null)
            {
                if (txtUsuario.Text == objUsuario.Usuario && txtClave.Text == objUsuario.Clave)
                {
                    Cesion.Nivel = objUsuario.ID_NIVEL;
                    Cesion.codUsuario = objUsuario.ID_USUARIO;
                    Cesion.usuario = objUsuario.Nombres + " " + objUsuario.Apellidos;
                    this.Hide();
                    Vista.frmBienvenida frm = new Vista.frmBienvenida();
                    frm.ShowDialog();
                    Vista.Menu frmMenu = new Vista.Menu();
                    frmMenu.Show();
                }
                else
                {
                    MessageBox.Show("Usuario y/o Clave incorrecto", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Text = "USUARIO";
                    txtClave.Text = "PASSWORD";
                    txtUsuario.Focus();
                }
            }
            else
            {
                MessageBox.Show("Usuario y/o Clave incorrecto", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Text = "USUARIO";
                txtClave.Text = "PASSWORD";
                txtUsuario.Focus();
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
            }
        }

        private void txtClave_Leave(object sender, EventArgs e)
        {
            if (txtClave.Text == "")
            {
                txtClave.Text = "PASSWORD";
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
