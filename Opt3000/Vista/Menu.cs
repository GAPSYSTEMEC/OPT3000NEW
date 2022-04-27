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
using System.Diagnostics;

namespace Opt3000.Vista
{
    public partial class Menu : Form
    {
        //COLOR DE BOTONES
        Color oColor1 = System.Drawing.ColorTranslator.FromHtml("#71b58a");
        public Menu()
        {
            this.Location = new Point(0, 0);
            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            InitializeComponent();
            lblUsuario.Text = Cesion.usuario;
            lblFecha.Text = "Fecha: " + DateTime.Now.Date.ToString("dd/MM/yyyy");
        }
        #region Variables
        public static bool pacientes = false; //Para abrir del submenu de Explorador
        #endregion
        #region Botones 

        private void btnSalirAplicacion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿La aplicación se va a cerrar en su totalidad?", "OPT3000", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                Application.Exit();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿El sistema va a cambiar de usuario?", "OPT3000", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Cesion.codUsuario = 0;
                Cesion.usuario = "";
                frmLogin from = new frmLogin();
                this.Close();
                from.Show();
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (p_Menu.Width == 260)
            {
                p_Menu.Width = 50;
                imagen1.Visible = false;
            }
            else
            {
                p_Menu.Width = 260;
                imagen1.Visible = true;
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {

            btnCliente.BackColor = oColor1;
            btnClienteImg.BackColor = oColor1;
            AbrirFormulario<Clientes.Cliente>();
        }
        private void btnClienteImg_Click(object sender, EventArgs e)
        {
            btnCliente.BackColor = oColor1;
            btnClienteImg.BackColor = oColor1;
            AbrirFormulario<Clientes.Cliente>();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            AccedeConsultaGeneral();
        }
        private void btnConsultaImg_Click(object sender, EventArgs e)
        {
            AccedeConsultaGeneral();
        }
        private void btnOftalmica_Click(object sender, EventArgs e)
        {
            AccederConsultaOftalmica();
        }
        private void btnOftalmicaImg_Click(object sender, EventArgs e)
        {
            AccederConsultaOftalmica();
        }
        private void btnLentes_Click(object sender, EventArgs e)
        {
            AccederLentes();
        }
        private void btnLentesImg_Click(object sender, EventArgs e)
        {
            AccederLentes();
        }
        private void btnAgenda_Click(object sender, EventArgs e)
        {
            AccederAgenda();
        }
        private void btnAgendaImg_Click(object sender, EventArgs e)
        {
            AccederAgenda();
        }
        private void btnCaja_Click(object sender, EventArgs e)
        {
            AccederCaja();
        }
        private void btnCajaImg_Click(object sender, EventArgs e)
        {
            AccederCaja();
        }

        #endregion


        #region Funciones y abrir y cerrar formularios

        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            //BUSCA EN LA COLECCION EL FORMULARIO
            formulario = p_contenedor.Controls.OfType<MiForm>().FirstOrDefault();
            //VERIFICO SI EL FORMULARIO EXISTE O NO EXISTE PARA NO VOLVER ABRIRLO SI NO SOLO LLAMARLO
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                p_contenedor.Controls.Add(formulario);
                p_contenedor.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForm);
            }
            else
            {
                formulario.BringToFront();
            }
        }

        private void CloseForm(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["Cliente"] == null)
            {
                btnCliente.BackColor = Color.CornflowerBlue;
                btnClienteImg.BackColor = Color.CornflowerBlue;
            }
            if (Application.OpenForms["NuevaConsulta"] == null)
            {
                btnConsulta.BackColor = Color.CornflowerBlue;
                btnConsultaImg.BackColor = Color.CornflowerBlue;
            }
            if (Application.OpenForms["Oftalmica"] == null)
            {
                btnOftalmica.BackColor = Color.CornflowerBlue;
                btnOftalmicaImg.BackColor = Color.CornflowerBlue;
            }
            if (Application.OpenForms["LentesContacto"] == null)
            {
                btnLentes.BackColor = Color.CornflowerBlue;
                btnLentesImg.BackColor = Color.CornflowerBlue;
            }
            if (Application.OpenForms["Factura"] == null)
            {
                btnCaja1.BackColor = Color.CornflowerBlue;
                btnCajaImg.BackColor = Color.CornflowerBlue;
            }
            if (Application.OpenForms["Agendamiento"] == null)
            {
                btnAgenda.BackColor = Color.CornflowerBlue;
                btnAgendaImg.BackColor = Color.CornflowerBlue;
            }
            if (Application.OpenForms["frmSubExplorador"] == null)
            {
                if (pacientes)
                {
                    AbrirFormulario<frmBienvenida>();
                    pacientes = false;
                }
                else
                {
                    btnExplorador.BackColor = Color.CornflowerBlue;
                    btnExploradorImg.BackColor = Color.CornflowerBlue;
                }
            }
            if (Application.OpenForms["MenuUtilitario"] == null)
            {
                btnUtilitarios.BackColor = Color.CornflowerBlue;
                btnUtilitariosImg.BackColor = Color.CornflowerBlue;
            }
            if (Application.OpenForms["OrdenPedido"] == null)
            {
                btnOrden.BackColor = Color.CornflowerBlue;
                btnOrdenImg.BackColor = Color.CornflowerBlue;
            }
            //if (Application.OpenForms["His.Formulario.frm_Receta"] == null)
            //{
            //    button1.BackColor = Color.FromArgb(31, 195, 216);
            //}
            //if (Application.OpenForms["His.Formulario.frm_Certificados"] == null)
            //{
            //    button2.BackColor = Color.FromArgb(31, 195, 216);
            //}

        }


        public void AccedeConsultaGeneral()
        {
            if (Cesion.Nivel != 3)
            {
                btnConsulta.BackColor = oColor1;
                btnConsultaImg.BackColor = oColor1;
                AbrirFormulario<Consultas.NuevaConsulta>();
            }
            else
            {
                MessageBox.Show("No tienes acceso :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void AccederConsultaOftalmica()
        {
            if (Cesion.Nivel != 3)
            {
                btnOftalmica.BackColor = oColor1;
                btnOftalmicaImg.BackColor = oColor1;
                AbrirFormulario<Consultas.Oftalmica>();
            }
            else
            {
                MessageBox.Show("No tienes acceso :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void AccederCaja()
        {
            btnCaja1.BackColor = oColor1;
            btnCajaImg.BackColor = oColor1;
            AbrirFormulario < Caja.Factura>();
        }

        public void AccederLentes()
        {
            if (Cesion.Nivel != 3)
            {
                btnLentes.BackColor = oColor1;
                btnLentesImg.BackColor = oColor1;
                AbrirFormulario<Consultas.LentesContacto>();
            }
            else
            {
                MessageBox.Show("No tienes acceso :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void AccederAgenda()
        {
            btnAgenda.BackColor = oColor1;
            btnAgendaImg.BackColor = oColor1;
            AbrirFormulario<Vista.Clientes.Agendamiento>();
        }



        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            AccederExplorador();
        }
        public void AccederExplorador()
        {
            btnExplorador.BackColor = oColor1;
            btnExploradorImg.BackColor = oColor1;
            AbrirFormulario<Vista.Exploradores.frmMenuExploradopres>();
        }

        private void btnExploradorImg_Click(object sender, EventArgs e)
        {
            AccederExplorador();
        }

        private void btnUtilitarios_Click(object sender, EventArgs e)
        {
            AccederUtilitarios();
        }

        public void AccederUtilitarios()
        {
            btnUtilitarios.BackColor = oColor1;
            btnUtilitariosImg.BackColor = oColor1;
            AbrirFormulario<Vista.Utilitarios.MenuUtilitario>();
        }

        private void btnOrden_Click(object sender, EventArgs e)
        {
            btnOrden.BackColor = oColor1;
            btnOrdenImg.BackColor = oColor1;
            AbrirFormulario<Vista.Utilitarios.OrdenPedido>();
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            Process.Start("http://pichincha.gapsystem.net:10042/login.aspx");
        }

        private void btnFacturasImg_Click(object sender, EventArgs e)
        {
            Process.Start("http://pichincha.gapsystem.net:10042/login.aspx");
        }
    }
}

