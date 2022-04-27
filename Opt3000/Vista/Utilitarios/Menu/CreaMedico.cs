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

namespace Opt3000.Vista.Utilitarios.Menu
{
    public partial class CreaMedico : Form
    {
        public MEDICO med = new MEDICO();
        public CreaMedico(MEDICO medico)
        {
            InitializeComponent();
            CargaEspecialidad();
            med = medico;
            if (med.Identificacion != null)
            {
                txtIdentificacion.Text = med.Identificacion;
                cmbEspecialidad.Text = med.Especialidad;
                txtEmail.Text = med.Email;
                dt_FechaNacimiento.Value = med.FechaNacimiento;
                txtTiempo.Text = med.TiempoConsulta.ToString();
            }
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

        private void CargaEspecialidad()
        {
            List<ESPECIALIDAD> lista = NegConsultas.getInstance().RecuperaEspecialidad();
            cmbEspecialidad.DataSource = lista;
            cmbEspecialidad.ValueMember = "ID_ESPECIALIDAD";
            cmbEspecialidad.DisplayMember = "Detalle";
            cmbEspecialidad.SelectedText = "";
            cmbEspecialidad.SelectedIndex = -1;
        }

        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().SoloNumeros(e);
        }

        private void txtTiempo_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().SoloNumeros(e);
        }

        private void txtIdentificacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void cmbEspecialidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void dt_FechaNacimiento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void txtTiempo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                btnGuardar.Focus();
        }

        public bool ValidaFormulario()
        {
            error.Clear();
            bool valido = true;
            if (txtIdentificacion.Text == "")
            {
                AgregarError(txtIdentificacion, "Identificación es requerido");
                valido = false;
            }
            if (cmbEspecialidad.Text == "")
            {
                AgregarError(cmbEspecialidad, "Especialidad es requerido");
                valido = false;
            }
            if (txtEmail.Text == "")
            {
                AgregarError(txtEmail, "E-mail es requerido");
                valido = false;
            }
            if (txtTiempo.Text == "")
            {
                AgregarError(txtTiempo, "Tiempo es requerido");
                valido = false;
            }
            return valido;
        }

        private void AgregarError(Control control, string texto)
        {
            error.SetError(control, texto);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (FuncionesBasicas.getInstance().CalculaEdad(dt_FechaNacimiento.Value) > 22)
            {
                if (ValidaFormulario())
                {
                    med.Identificacion = txtIdentificacion.Text;
                    med.Email = txtEmail.Text;
                    med.Especialidad = cmbEspecialidad.Text;
                    med.FechaNacimiento = dt_FechaNacimiento.Value;
                    med.TiempoConsulta = Convert.ToInt16(txtTiempo.Text);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("El médico no puede tener menos de 22 años de edad :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void txtTiempo_Leave(object sender, EventArgs e)
        {
            if (txtTiempo.Text.Trim().Length > 0)
            {
                int tiempo = Convert.ToInt16(txtTiempo.Text);
                if (tiempo > 90)
                {
                    MessageBox.Show("El Timempo limite es de 90 min  :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTiempo.Text = "";
                }
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (!FuncionesBasicas.getInstance().ValidaEmail(txtEmail.Text))
            {
                MessageBox.Show("Esto no parece un E-mail :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Text = "";
            }
        }

        private void txtIdentificacion_Leave(object sender, EventArgs e)
        {
            if (!FuncionesBasicas.getInstance().ValidaIdentificacion(txtIdentificacion.Text))
            {
                MessageBox.Show("Esto no parece una cédula valida :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIdentificacion.Text = "";
            }
        }
    }
}
