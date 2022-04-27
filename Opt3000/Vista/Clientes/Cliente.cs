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
using System.IO;
using Opt3000.Vista.Utilitarios;

namespace Opt3000.Vista.Clientes
{
    public partial class Cliente : Form
    {

        #region variables globales

        //variable para saber si el formulario va a ser modificado o se va guardar un nuevo cliente
        int estado = 0;

        #endregion

        public Cliente()
        {
            InitializeComponent();
            CargaConvenios();
        }

        #region Botones Principales      



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardaPaciente();
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiaCampos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (FuncionesBasicas.getInstance().CerrarFormulario("EL FORMULARIO"))
                this.Close();
        }

        #endregion

        #region Validaciones de text box
        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().SoloNumeros(e);
        }
        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().SoloNumeros(e);
        }

        private void txtCasa_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().SoloNumeros(e);
        }

        private void txtCedula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {

                if (FuncionesBasicas.getInstance().ValidaIdentificacion(txtCedula.Text) || rbExtrangero.Checked || rbPasaporte.Checked || rbRefigiado.Checked || rbSinID.Checked)
                {
                    PACIENTE objPaciente = new PACIENTE();
                    objPaciente = NegConsultas.getInstance().CargaPaciente(txtCedula.Text);
                    if (objPaciente != null)
                    {
                        cmbTipo.SelectedIndex = objPaciente.ID_TIPO - 1;
                        txtCedula.Text = objPaciente.Identificacion;
                        txtNombre.Text = objPaciente.Nombres;
                        textBox1.Text = objPaciente.Apellidos;
                        txtDireccion.Text = objPaciente.Direccion;
                        txtCelular.Text = objPaciente.Celular;
                        txtCasa.Text = objPaciente.Convencional;
                        txtEmail.Text = objPaciente.Email;
                        dtpFechaNacimiento.Value = objPaciente.F_Nacimiento;
                        txtOcupacion.Text = objPaciente.Ocupacion;
                    }
                    FuncionesBasicas.getInstance().SaltarConEnter(e);
                }
                else
                {
                    MessageBox.Show("Cédula incorrecta!!! :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void txtCelular_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void txtCasa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (FuncionesBasicas.getInstance().ValidaEmail(txtEmail.Text))
                {
                    FuncionesBasicas.getInstance().SaltarConEnter(e);
                }
                else
                {
                    MessageBox.Show("Email incorrecto!!! :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void dtpFechaNacimiento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                GuardaPaciente();
        }

        private void txtOcupacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }


        #endregion



        #region funciones

        public void LimpiaCampos()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox text = ctrl as TextBox;
                    text.Clear();
                }
            }
            cmbTipo.Text = "";
            cmbTipo.SelectedIndex = -1;
            dtpFechaNacimiento.Value = DateTime.Now;
        }

        public void CargaConvenios()
        {
            List<CONVENIO> lista = NegConsultas.getInstance().ConsultaConvenios();
            cmbTipo.DataSource = lista;
            cmbTipo.ValueMember = "ID_TIPO";
            cmbTipo.DisplayMember = "Detalle";
            cmbTipo.SelectedText = "";
            cmbTipo.SelectedIndex = -1;
        }
        private void AgregarError(Control control)
        {
            error.SetError(control, "Campo Requerido");
        }

        public bool ValidaCampos()
        {
            error.Clear();
            bool valido = true;
            if (cmbTipo.Text == string.Empty)
            {
                AgregarError(cmbTipo);
                valido = false;
            }
            if (!rbSinID.Checked)
                if (txtCedula.Text == string.Empty)
                {
                    AgregarError(txtCedula);
                    valido = false;
                }
            if (txtNombre.Text == string.Empty)
            {
                AgregarError(txtNombre);
                valido = false;
            }
            if (textBox1.Text == string.Empty)
            {
                AgregarError(textBox1);
                valido = false;
            }
            if (txtDireccion.Text == string.Empty)
            {
                AgregarError(txtDireccion);
                valido = false;
            }
            if (txtCelular.Text == string.Empty)
            {
                AgregarError(txtCelular);
                valido = false;
            }
            if (txtEmail.Text == string.Empty)
            {
                AgregarError(txtEmail);
                valido = false;
            }
            if (txtOcupacion.Text == string.Empty)
            {
                AgregarError(txtOcupacion);
                valido = false;
            }

            return valido;
        }

        public void GuardaPaciente()
        {
            if (ValidaCampos())
            {
                PACIENTE objPaciente = new PACIENTE();
                objPaciente.ID_TIPO = Convert.ToInt16(cmbTipo.SelectedValue.ToString());
                objPaciente.Identificacion = txtCedula.Text;
                objPaciente.Nombres = txtNombre.Text;
                objPaciente.Apellidos = textBox1.Text;
                objPaciente.Direccion = txtDireccion.Text;
                objPaciente.Celular = txtCelular.Text;
                objPaciente.Convencional = txtCasa.Text;
                objPaciente.Email = txtEmail.Text;
                objPaciente.F_Nacimiento = dtpFechaNacimiento.Value;
                objPaciente.Ocupacion = txtOcupacion.Text;
                objPaciente.Usuario = Cesion.codUsuario;
                int ok = NegGuarda.getInstance().GuardaPaciente(objPaciente);
                if (ok == 1)
                {
                    MessageBox.Show("Nuevo cliente guardado con exito!!! ;)", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiaCampos();
                    txtCedula.Focus();
                    this.Close();
                }
                else if (ok == 2)
                {
                    MessageBox.Show("Cliente modificado con exito!!! ;)", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiaCampos();
                    txtCedula.Focus();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cliente no se guardado!!! :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOcupacion.Focus();
                }
            }
        }


        #endregion

        private void btnVerDoc_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text != "")
            {
                PACIENTE objPaciente = new PACIENTE();
                objPaciente = NegConsultas.getInstance().CargaPaciente(txtCedula.Text);
                if (objPaciente != null)
                {
                    string path = @"E:\PruebasGuardado\HC-" + objPaciente.ID_PACIENTE;
                    if (Directory.Exists(path))
                        System.Diagnostics.Process.Start(path);
                    else
                        MessageBox.Show("Paciente aun no tiene MicroFile", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Paciente aun no tiene MicroFile", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Debe ingresar una identificación :[", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCargaDoc_Click(object sender, EventArgs e)
        {
            PACIENTE objPaciente = new PACIENTE();
            objPaciente = NegConsultas.getInstance().CargaPaciente(txtCedula.Text);
            if (objPaciente != null)
            {
                MoverArchivo frmMover = new MoverArchivo(Convert.ToInt64(objPaciente.ID_PACIENTE));
                frmMover.ShowDialog();
            }
            else
                MessageBox.Show("Paciente aun no tiene MicroFile", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void rbSinID_CheckedChanged(object sender, EventArgs e)
        {
            txtCedula.Text = "";
            if (rbSinID.Checked)
                txtCedula.Enabled = false;
            else
                txtCedula.Enabled = true;
        }

        private void chk_sinCorreo_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_sinCorreo.Checked)
            {
                txtEmail.Text = "opticajimenezec@gmail.com";
            }
            else
            {
                txtEmail.Text = "";
            }
        }
    }
}

