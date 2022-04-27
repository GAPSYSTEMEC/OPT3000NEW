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
    public partial class Agenda : Form
    {
        public Agenda()
        {
            InitializeComponent();
            LlenaComboConsultorio();
            LlenaComboMedico();
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

        public void LlenaComboMedico()
        {
            DataTable medico = new DataTable();
            medico.Columns.Add("NOMBRE");
            medico.Columns.Add("ID");
            List<USUARIO> objMedico = new List<USUARIO>();
            objMedico = NegConsultas.getInstance().CargaComboMedico();
            foreach (var item in objMedico)
            {
                medico.Rows.Add(new object[] { item.Apellidos + " " + item.Nombres, item.ID_USUARIO });
            }
            cmbMedico.DataSource = medico;
            cmbMedico.ValueMember = "ID";
            cmbMedico.DisplayMember = "NOMBRE";
            cmbMedico.SelectedIndex = -1;
            cmbMedico.Text = "";
        }

        public void LlenaComboConsultorio()
        {
            List<CONSULTORIO> lista = new List<CONSULTORIO>();
            lista = NegConsultas.getInstance().ConsultaConsultorio();
            cmbConsultorio.DataSource = lista;
            cmbConsultorio.ValueMember = "ID_CONSULTORIO";
            cmbConsultorio.DisplayMember = "Nombre";
            cmbConsultorio.SelectedIndex = -1;
            cmbConsultorio.Text = "";
        }

        private void txtHoraIni_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().SoloNumeros(e);
        }

        private void txtHoraFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().SoloNumeros(e);
        }

        private void txtAlmuerzo_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().SoloNumeros(e);
        }

        private void txtPausa_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().SoloNumeros(e);
        }

        private void txtHoraIni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                txtHoraFin.Focus();
            }
        }

        private void txtHoraFin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                txtAlmuerzo.Focus();
            }
        }

        private void txtAlmuerzo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                txtPausa.Focus();
            }
        }

        private void txtPausa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnGuardar.Focus();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidaFormulario())
                GuardaCita();
            this.Close();
        }

        private void GuardaCita()
        {
            int medico = Convert.ToInt16(cmbMedico.SelectedValue.ToString());
            int dia = 0;
            string d = "";
            if (cbDomingo.Checked)
            {
                dia = 1;
                d = "DOMINGO";
                if (!GeneraAgenda(dia, medico, d))
                {
                    cbDomingo.Checked = false;
                    ActualizaAgenda(dia, medico, d);
                }
            }
            if (cbLunes.Checked)
            {
                dia = 2;
                d = "LUNES";
                if (!GeneraAgenda(dia, medico, d))
                {
                    cbLunes.Checked = false;
                    ActualizaAgenda(dia, medico, d);
                }
            }
            if (cbMartes.Checked)
            {
                dia = 3;
                d = "MARTES";
                if (!GeneraAgenda(dia, medico, d))
                {
                    cbMartes.Checked = false;
                    ActualizaAgenda(dia, medico, d);
                }
            }
            if (cbMiercoles.Checked)
            {
                dia = 4;
                d = "MIERCOLES";
                if (!GeneraAgenda(dia, medico, d))
                {
                    cbMiercoles.Checked = false;
                    ActualizaAgenda(dia, medico, d);
                }
            }
            if (cbJueves.Checked)
            {
                dia = 5;
                d = "JUEVES";
                if (!GeneraAgenda(dia, medico, d))
                {
                    cbJueves.Checked = false;
                    ActualizaAgenda(dia, medico, d);
                }
            }
            if (cbViernes.Checked)
            {
                dia = 6;
                d = "VIERNES";
                if (!GeneraAgenda(dia, medico, d))
                {
                    cbViernes.Checked = false;
                    ActualizaAgenda(dia, medico, d);
                }
            }
            if (cbSabado.Checked)
            {
                dia = 7;
                d = "SÁBADO";
                if (!GeneraAgenda(dia, medico, d))
                {
                    cbSabado.Checked = false;
                    ActualizaAgenda(dia, medico, d);
                }
            }

        }

        private bool GeneraAgenda(int dia, int medico, string d)
        {
            HONRARIOATENCION objHorario = new HONRARIOATENCION();
            objHorario = NegConsultas.getInstance().ConsultaHorarios(dia, medico);
            if (objHorario == null)
            {
                MEDICO med = new MEDICO();
                med = NegConsultas.getInstance().ConsultaMedico(Convert.ToInt16(cmbMedico.SelectedValue.ToString()));
                HONRARIOATENCION horario = new HONRARIOATENCION();
                horario.ID_MEDICO = med.ID_MEDICO;
                horario.ID_DIA = Convert.ToInt16(dia);
                horario.ID_CONSULTORIO = Convert.ToInt16(cmbConsultorio.SelectedValue.ToString());
                horario.HoraInicio = Convert.ToInt16(txtHoraIni.Text);
                horario.HoraFin = Convert.ToInt16(txtHoraFin.Text);
                horario.HoraAlmuerzo = Convert.ToInt16(txtAlmuerzo.Text);
                horario.Intervalo = Convert.ToInt16(txtPausa.Text);
                NegGuarda.getInstance().GuardaHorarios(horario);
                MessageBox.Show("Información Guardada con exito :)", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Medico ya tiene agenda para el Día: " + d + ". :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private void ActualizaAgenda(int dia, int medico, string d)
        {
            if (MessageBox.Show("Deseas remplazar la agenda existente con los nuevos horarios para el día: " + d, "OPT3000", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                HONRARIOATENCION objHorario = new HONRARIOATENCION();
                objHorario = NegConsultas.getInstance().ConsultaHorarios(dia, medico);
                HONRARIOATENCION horario = new HONRARIOATENCION();
                horario.ID_DIASATENCION = objHorario.ID_DIASATENCION;
                horario.ID_MEDICO = objHorario.ID_MEDICO;
                horario.ID_DIA = Convert.ToInt16(dia);
                horario.ID_CONSULTORIO = Convert.ToInt16(cmbConsultorio.SelectedValue.ToString());
                horario.HoraInicio = Convert.ToInt16(txtHoraIni.Text);
                horario.HoraFin = Convert.ToInt16(txtHoraFin.Text);
                horario.HoraAlmuerzo = Convert.ToInt16(txtAlmuerzo.Text);
                horario.Intervalo = Convert.ToInt16(txtPausa.Text);
                NegActualizacion.getInstance().ModificaHorarios(horario);
                MessageBox.Show("Información Actualizada con exito :)", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private bool ValidaFormulario()
        {
            error.Clear();
            bool valido = true;
            if (cmbMedico.Text == "")
            {
                AgregarError(cmbMedico, "Se necesita el médico para agendar");
                valido = false;
            }
            if (cmbConsultorio.Text == "")
            {
                AgregarError(cmbConsultorio, "Se necesita el consultorio para agendar");
                valido = false;
            }
            if (txtHoraIni.Text == "")
            {
                AgregarError(txtHoraIni, "Se necesita la hora de inicio para agendar");
                valido = false;
            }
            if (txtHoraFin.Text == "")
            {
                AgregarError(txtHoraFin, "Se necesita la hora que va terminar el medico para agendar");
                valido = false;
            }
            if (txtAlmuerzo.Text == "")
            {
                AgregarError(txtAlmuerzo, "Se necesita la hora de almuerzo para agendar");
                valido = false;
            }
            if (txtPausa.Text == "")
            {
                AgregarError(txtPausa, "Se necesita el tiempo que el médico descansa entre citas para agendar");
                valido = false;
            }
            return valido;
        }
        private void AgregarError(Control control, string texto)
        {
            error.SetError(control, texto);
        }
    }
}
