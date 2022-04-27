using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Opt3000.Negocio;
using Opt3000.Vista.Utilitarios;
using Opt3000.BaseDatos;
using System.IO;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Opt3000.Vista.Clientes
{
    public partial class Agendamiento : Form
    {
        DataTable horaCombo = new DataTable();
        PACIENTE objPaciente = new PACIENTE();
        MEDICO objMedico = new MEDICO();
        public Agendamiento()
        {
            InitializeComponent();
            horaCombo.Columns.Add("Hora");
            horaCombo.Columns.Add("Id");
            LlenaComboMedico();
            LlenaComboConsultorio();
            dtp_FechaConsulta.MinDate = DateTime.Now;
            dtp_FechaConsulta.Value = DateTime.Now.AddDays(+1);

        }


        #region botones

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (FuncionesBasicas.getInstance().CerrarFormulario("EL AGENDAMIENTO"))
                this.Close();
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            BuscadorPacientes frmBuscador = new BuscadorPacientes();
            frmBuscador.ShowDialog();

            objPaciente = NegConsultas.getInstance().CargaPaciente(frmBuscador.cedula);
            if (objPaciente != null)
            {
                Int64 maximo = NegConsultas.getInstance().MaxAtencion() + 1;
                lblAtencion.Text = maximo.ToString();
                lblNombrePaciente.Text = objPaciente.Apellidos + " " + objPaciente.Nombres;
                lblIdentificacion.Text = objPaciente.Identificacion;
                lblOcupacion.Text = objPaciente.Ocupacion;
                lblHc.Text = objPaciente.ID_PACIENTE.ToString();
                lblEdad.Text = FuncionesBasicas.getInstance().CalculaEdad(objPaciente.F_Nacimiento).ToString();
                p_PacienteDatos.Visible = true;
                p_Atencion.Enabled = true;
                btnBusca.Visible = false;
                btnGuardar.Visible = true;
                btnCancelar.Visible = true;
            }
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




        #endregion

        #region Funciones





        #endregion

        private void Agendamiento_Load(object sender, EventArgs e)
        {

        }

        #region validaciones textos





        #endregion


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (btnGuardar.Visible)
            {
                if (System.Windows.Forms.MessageBox.Show("¿Esta seguro de borrar la información ingresada?", "OPT3000", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    LimpiarCampos();
                    return;
                }
            }
            LimpiarCampos();
            btnNuevo.Visible = false;
        }

        public void LimpiarCampos()
        {
            FuncionesBasicas.getInstance().BorrarCampos(p_Atencion);
            p_PacienteDatos.Visible = false;
            p_Atencion.Enabled = false;
            btnBusca.Visible = true;
            btnGuardar.Visible = false;
            btnCancelar.Visible = false;
            cmbHora.DataSource = null;
            cmbMedico.Text = "";
            cmbConsultorio.Text = "";
            cmbMedico.SelectedIndex = -1;
            cmbConsultorio.SelectedIndex = -1;
            dtp_FechaConsulta.MinDate = DateTime.Now;
            dtp_FechaConsulta.Value = DateTime.Now.AddDays(+1);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Valida())
            {
                if (System.Windows.Forms.MessageBox.Show("Si continua se va modificar la agenda del médico!!!", "OPT3000", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (GuardaConsulta() == 1)
                    {
                        System.Windows.Forms.MessageBox.Show("Agenda actualizada con exito :)", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EnviaCorreoElectronico();
                        LimpiarCampos();
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Agenda no se actualizo revise información :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void EnviaCorreoElectronico()
        {
            Outlook._Application olApp = new Outlook.Application();
            Outlook.NameSpace mapiNS = olApp.GetNamespace("MAPI");
            string profile = "";
            mapiNS.Logon(profile, null, null, null);
            string[] horas = cmbHora.Text.Split('-');
            string[] horafinal = horas[0].Split(':');
            int hora = Convert.ToInt16(horafinal[0]);
            int minutos = Convert.ToInt16(horafinal[1]);
            string cuerpoCorreo;
            cuerpoCorreo = "Paciente: " + lblNombrePaciente.Text;
            cuerpoCorreo += "<br>" + "Cita Medica Agendada para el: " + dtp_FechaConsulta.Value.Date.ToString("dd/MM/yyyy") + " a las " + cmbHora.Text;
            cuerpoCorreo += "<br>" + "Cita Medica con el/la Dr./Dra. " + cmbMedico.Text;
            cuerpoCorreo += "<br>" + "Motivo: " + txtCie10.Text;
            cuerpoCorreo += "<br>" + "Observación: " + txtObservaciones.Text;
            cuerpoCorreo += "<br>" + "Consultorio: " + cmbConsultorio.Text;
            cuerpoCorreo += "<br>" + "Cita Generada por: " + Cesion.usuario;
            try
            {
                string fechaHora = dtp_FechaConsulta.Value.Date.ToString("dd/MM/yyyy");
                fechaHora += " " + cmbHora.Text + ":00";
                if (!FuncionesBasicas.getInstance().EnviaEmailOutlook(objPaciente.Email, objMedico.Email, "Cita Medica Agendada para el: " + dtp_FechaConsulta.Value.Date.ToString("dd/MM/yyyy") + " a las " + cmbHora.Text, cuerpoCorreo))
                    //if (!EnviaEmailOutlook(txtEmail.Text, "", "Cita Medica Agendada para el: " + año + "/" + mes + "/" + dia + " a las " + horas[0], cuerpoCorreo))
                    System.Windows.Forms.MessageBox.Show("Enviar Mensaje Manualmente Y Solicite Soporte Tecnico Outlook Fuera de Línea", "HIS3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!FuncionesBasicas.getInstance().creaCitaOutlook(olApp, "Cita Medica Dr./Dra. " + cmbMedico.Text + "\r\nMotivo: " + txtCie10.Text + "\r\nCita Generada por: " + Cesion.usuario, "\r\nConsultorio: " + cmbConsultorio.Text, "Consultorio: " + cmbConsultorio.Text + ", Paciente: " + lblNombrePaciente.Text, Convert.ToDateTime(fechaHora)))
                    System.Windows.Forms.MessageBox.Show("Verifique Su Outlook La Cita No Se Almaceno En Su Calendario", "HIS3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Enviar Mensaje Manualmente Y Solicite Soporte Técnico, Outlook Fuera de Línea", "HIS3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw ex;
            }


        }

        public int GuardaConsulta()
        {
            AGENDA objAgenda = new AGENDA();
            byte dia1 = (byte)dtp_FechaConsulta.Value.DayOfWeek;
            int dia = Convert.ToInt16(dia1) + 1;
            int medico = Convert.ToInt16(cmbMedico.SelectedValue.ToString());
            string hora = cmbHora.Text;
            string[] horario = hora.Split(':');
            objAgenda.FachaCita = dtp_FechaConsulta.Value.Date;
            objAgenda.Hora = Convert.ToInt16(horario[0]);
            objAgenda.Minutos = Convert.ToInt16(horario[1]);
            objAgenda.FechaCreacion = DateTime.Now;
            objAgenda.Usuario = Cesion.usuario;
            objAgenda.ID_PACIENTE = Convert.ToInt64(lblHc.Text);
            objAgenda.Cie10 = txtCie10.Text;
            objAgenda.Observaciones = txtObservaciones.Text;
            objAgenda.CONSULTORIO = cmbConsultorio.Text;
            int retorna = NegGuarda.getInstance().GuardaAgenda(medico, dia, objAgenda);
            return retorna;
        }

        private void AgregarError(Control control)
        {
            error.SetError(control, "Campo Requerido");
        }

        public bool Valida()
        {
            error.Clear();
            bool valido = true;
            if (cmbMedico.Text == string.Empty)
            {
                AgregarError(cmbMedico);
                valido = false;
            }
            if (cmbHora.Text == string.Empty)
            {
                AgregarError(cmbHora);
                valido = false;
            }
            if (cmbConsultorio.Text == string.Empty)
            {
                AgregarError(cmbConsultorio);
                valido = false;
            }
            if (txtCie10.Text == string.Empty)
            {
                AgregarError(txtCie10);
                valido = false;
            }
            if (txtObservaciones.Text == string.Empty)
            {
                AgregarError(txtObservaciones);
                valido = false;
            }
            return valido;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FuncionesBasicas.getInstance().BorrarCampos(p_Atencion);
            p_Atencion.Enabled = true;
            btnBusca.Visible = false;
            btnGuardar.Visible = true;
            btnCancelar.Visible = true;
            Int64 maximo = NegConsultas.getInstance().MaxAtencion() + 1;
            lblAtencion.Text = maximo.ToString();
            btnNuevo.Visible = false;
        }

        private void btnVerDoc_Click(object sender, EventArgs e)
        {
            string path = @"E:\PruebasGuardado\HC-" + lblHc.Text;
            if (Directory.Exists(path))
                System.Diagnostics.Process.Start(path);
            else
                System.Windows.Forms.MessageBox.Show("Paciente aun no tiene MicroFile", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCargaDoc_Click(object sender, EventArgs e)
        {
            MoverArchivo frmMover = new MoverArchivo(Convert.ToInt64(lblHc.Text));
            frmMover.ShowDialog();
        }

        private void cmbMedico_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DateTime fecha = dtp_FechaConsulta.Value;
            byte dia1 = (byte)fecha.DayOfWeek;
            int dia = Convert.ToInt16(dia1) + 1;
            int medico = Convert.ToInt16(cmbMedico.SelectedValue.ToString());

            objMedico = NegConsultas.getInstance().ConsultaMedico(medico);
            HONRARIOATENCION objHorario = new HONRARIOATENCION();
            objHorario = NegConsultas.getInstance().ConsultaHorarios(dia, medico);
            if (objHorario != null)
            {
                cmbConsultorio.SelectedValue = objHorario.ID_CONSULTORIO;
                int contador = 0;
                int horaAlmuerzo = objHorario.HoraAlmuerzo;
                int intervaloMin = objHorario.Intervalo;
                int duracionConMin = objMedico.TiempoConsulta;

                if (dtp_FechaConsulta.Value > DateTime.Now.Date)
                {
                    if (dtp_FechaConsulta.Value.Date == DateTime.Now.Date)
                    {
                        for (int i = DateTime.Now.Hour + 1; i < objHorario.HoraFin; i++)
                        {
                            if (i > objHorario.HoraInicio)
                            {
                                if (horaAlmuerzo != i)
                                {
                                    for (int a = duracionConMin; a < 60; a += duracionConMin + intervaloMin)
                                    {
                                        contador++;
                                        CargaHoras(Convert.ToString(i), Convert.ToString(a), contador, objMedico.ID_MEDICO, dia);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = objHorario.HoraInicio; i < objHorario.HoraFin; i++)
                        {
                            if (i > objHorario.HoraInicio)
                            {
                                if (horaAlmuerzo != i)
                                {
                                    for (int a = 0; a < 60; a += duracionConMin + intervaloMin)
                                    {
                                        contador++;
                                        CargaHoras(Convert.ToString(i), Convert.ToString(a), contador, objMedico.ID_MEDICO, dia);
                                    }
                                }
                            }
                        }
                    }
                    cmbHora.DataSource = horaCombo;
                    cmbHora.ValueMember = "Id";
                    cmbHora.DisplayMember = "Hora";
                    cmbHora.SelectedIndex = -1;
                    cmbHora.Text = "";
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Fecha de agenda erronea :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtp_FechaConsulta.Value = DateTime.Now.AddDays(+1);
                    dtp_FechaConsulta.Focus();
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Médico no registra horarios disponibles en esa fecha :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbMedico.Text = "";
                cmbMedico.SelectedIndex = -1;
            }
        }

        public void CargaHoras(string hora, string minutos, int contador, int medico, int dia)
        {
            if (minutos == "0")
                minutos = "00";
            else if (Convert.ToInt16(minutos) < 10)
                minutos = "0" + minutos;
            if (Convert.ToInt16(hora) < 10)
                hora = "0" + hora;
            AGENDA objAgenda = new AGENDA();
            objAgenda = NegConsultas.getInstance().ConsultaAgenda(medico, dtp_FechaConsulta.Value.Date, Convert.ToInt16(hora), Convert.ToInt16(minutos), dia);
            if (objAgenda == null)
            {
                horaCombo.Rows.Add(new object[] { hora + ":" + minutos, contador });
            }
        }

        private void dtp_FechaConsulta_ValueChanged(object sender, EventArgs e)
        {
            cmbHora.DataSource = null;
            cmbMedico.Text = "";
            cmbMedico.SelectedIndex = -1;
            cmbConsultorio.Text = "";
            cmbConsultorio.SelectedIndex = -1;
        }

        private void btnCie_Click(object sender, EventArgs e)
        {
            Cie10 frm = new Cie10();
            frm.ShowDialog();
            var coma = "";
            var separador = " - ";
            if (txtCie10.Text != "")
                coma = "; ";
            txtCie10.Text += coma + frm.codigo + separador;
            txtCie10.Text += frm.detalle;
        }

        private void btnNuevoPaciente_Click(object sender, EventArgs e)
        {
            Cliente frm = new Cliente();
            frm.ShowDialog();
        }

        private void btn_Agenda_Click(object sender, EventArgs e)
        {
            Exploradores.frmAgenda frm = new Exploradores.frmAgenda();
            frm.Show();
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            Vista.Utilitarios.Menu.Agenda frm = new Vista.Utilitarios.Menu.Agenda();
            frm.ShowDialog();
        }

        private void btnNuevoPaciente_Click_1(object sender, EventArgs e)
        {
            Clientes.Cliente frm = new Clientes.Cliente();
            frm.ShowDialog();
        }
    }
}

