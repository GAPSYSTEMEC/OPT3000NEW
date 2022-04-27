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
using Opt3000.Vista.Exploradores;

namespace Opt3000.Vista.Utilitarios
{
    public partial class OrdenPedido : Form
    {
        public OrdenPedido()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (FuncionesBasicas.getInstance().CerrarFormulario("ORDEN DE PEDIOS"))
                this.Close();
        }


        private void btnGeneral_Click(object sender, EventArgs e)
        {
            //Orden_Normal frm = new Orden_Normal();
            frmOrdenTrabaj frm = new frmOrdenTrabaj();
            frm.ShowDialog();
        }

        private void btnOrdenCercana_Click(object sender, EventArgs e)
        {
            //OrdenVisionCerca frm = new OrdenVisionCerca();
            frmOrdenCercana frm = new frmOrdenCercana();
            frm.ShowDialog();
        }

        private void btnVisionLejana_Click(object sender, EventArgs e)
        {
            //OrdenVisionLejana frm = new OrdenVisionLejana();
            frmOrdenLejana frm = new frmOrdenLejana();
            frm.ShowDialog();
        }

        private void btnLentesBlandos_Click(object sender, EventArgs e)
        {
            //OrdenLentesBlandos frm = new OrdenLentesBlandos();
            frmOrdenBlandos frm = new frmOrdenBlandos();
            frm.ShowDialog();
        }

        private void btnLentesEspeciales_Click(object sender, EventArgs e)
        {
            OrdenLentesEspeciales frm = new OrdenLentesEspeciales();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Consultas.NuevaConsulta frm = new Consultas.NuevaConsulta();
            frm.ShowDialog();
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            RevisionEstadoOrdenes frm = new RevisionEstadoOrdenes();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu.Productos frm = new Menu.Productos();
            frm.ShowDialog();
        }
    }
}
