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
using Opt3000.BaseDatos;
using Opt3000.Vista.Utilitarios.Menu;


namespace Opt3000.Vista.Utilitarios.Menu
{

    public partial class Usuarios : Form
    {

        MEDICO med = new MEDICO();
        public Usuarios()
        {
            InitializeComponent();
            CargaNivelUsuario();
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

        private void CargaNivelUsuario()
        {
            List<NIVEL_USUARIO> lista = NegConsultas.getInstance().RecuperaNivelUsuario();
            cmbTipoUsuario.DataSource = lista;
            cmbTipoUsuario.ValueMember = "ID_NIVEL";
            cmbTipoUsuario.DisplayMember = "Detalle";
            cmbTipoUsuario.SelectedText = "";
            cmbTipoUsuario.SelectedIndex = -1;
        }

        private void txtCelular_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void cmbTipoUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void txtApellidos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void tstUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void txtPasword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void txtConfirma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                btnGuardar.Focus();
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().SoloNumeros(e);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtPasword.Text == txtConfirma.Text)
            {
                if (VerificaFormulario())
                {
                    USUARIO usu = new USUARIO();
                    usu.ID_NIVEL = Convert.ToInt16(cmbTipoUsuario.SelectedValue.ToString());
                    usu.Nombres = txtNombre.Text;
                    usu.Apellidos = txtApellidos.Text;
                    usu.Celular = txtCelular.Text;
                    usu.Usuario = txtUsuario.Text;
                    usu.Clave = txtPasword.Text;
                    if (NegGuarda.getInstance().GuardaUsuario(med, usu))
                    {
                        MessageBox.Show("Usuario Grabado con exito :)", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuario ya se ecuentra registrado verifique en el explorador de usuarios y/o médicos :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("El PASSWORD no coincide con la confrimación  :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtConfirma.Text = "";
                txtPasword.Text = "";
            }
        }

        private bool VerificaFormulario()
        {
            error.Clear();
            bool valido = true;
            if (txtCelular.Text.Length < 9)
            {
                AgregarError(txtCelular, "Este no es un número telefónico");
                valido = false;
            }
            if (txtCelular.Text == "")
            {
                AgregarError(txtCelular, "Este campor es requerido");
                valido = false;
            }
            if (txtNombre.Text == "")
            {
                AgregarError(txtNombre, "Este campor es requerido");
                valido = false;
            }
            if (txtApellidos.Text == "")
            {
                AgregarError(txtApellidos, "Este campor es requerido");
                valido = false;
            }
            if (txtUsuario.Text == "")
            {
                AgregarError(txtUsuario, "Este campor es requerido");
                valido = false;
            }
            if (txtPasword.Text == "")
            {
                AgregarError(txtPasword, "Este campor es requerido");
                valido = false;
            }
            if (txtConfirma.Text == "")
            {
                AgregarError(txtConfirma, "Este campor es requerido");
                valido = false;
            }
            return valido;
        }

        private void AgregarError(Control control, string texto)
        {
            error.SetError(control, texto);
        }

        private void btnDatosMedico_Click(object sender, EventArgs e)
        {
            CreaMedico frm = new CreaMedico(med);
            frm.ShowDialog();
            med = frm.med;
        }

        private void cmbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoUsuario.SelectedValue != null)
                if (cmbTipoUsuario.SelectedValue.ToString() == "2")
                {
                    CreaMedico frm = new CreaMedico(med);
                    frm.ShowDialog();
                    med = frm.med;
                    btnDatosMedico.Visible = true;
                }
                else
                {
                    btnDatosMedico.Visible = false;
                }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (!NegConsultas.getInstance().RecuperaUsuarioRepetido(txtUsuario.Text))
            {
                MessageBox.Show("Usuario no cumple con la estructura necesaria :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsuario.Text = "";
            }
        }

        private void txtPasword_Leave(object sender, EventArgs e)
        {

            if (!NegConsultas.getInstance().RecuperaPasswordRepetido(txtPasword.Text))
            {
                MessageBox.Show("Password no cumple con la estructura necesaria :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPasword.Text = "";
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscaUsuarios frm = new BuscaUsuarios();
            frm.ShowDialog();

            if (frm.usuario != "")
            {
                USUARIO objUsuario = new USUARIO();
                objUsuario = NegConsultas.getInstance().RecuperaUsuario(Convert.ToInt16(frm.usuario));
                cmbTipoUsuario.SelectedValue = objUsuario.ID_NIVEL;
                txtCelular.Text = objUsuario.Celular;
                txtNombre.Text = objUsuario.Nombres;
                txtApellidos.Text = objUsuario.Apellidos;
                txtUsuario.Text = objUsuario.Usuario;
                txtPasword.Text = objUsuario.Clave;
                txtConfirma.Text = objUsuario.Clave;
            }
        }
    }
}
