using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opt3000.Vista.Exploradores;
using Opt3000.Negocio;

namespace Opt3000.Vista.Exploradores
{
    public partial class frmMenuExploradopres : Form
    {
        public frmMenuExploradopres()
        {
            InitializeComponent();
        }

        private void btnPaciente_Click(object sender, EventArgs e)
        {
            frmPaciente frm = new frmPaciente();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (FuncionesBasicas.getInstance().CerrarFormulario("EXPLORADORES"))
                this.Close();
        }

        private void btnCconsulta_Click(object sender, EventArgs e)
        {
            frmConsulta frm = new frmConsulta();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }

        private void btnOftalmologia_Click(object sender, EventArgs e)
        {
            frmAnticipos frm = new frmAnticipos();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }

        private void btn_Agenda_Click(object sender, EventArgs e)
        {
            frmAgenda frm = new frmAgenda();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmFacturta frm = new frmFacturta();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }

        private void btnOrdenes_Click(object sender, EventArgs e)
        {
            frmOrdenTrabaj frm = new frmOrdenTrabaj();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmRevisionEstadoOrdenes frm = new frmRevisionEstadoOrdenes();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }
    }
}
