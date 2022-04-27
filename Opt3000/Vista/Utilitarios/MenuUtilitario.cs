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

namespace Opt3000.Vista.Utilitarios
{
    public partial class MenuUtilitario : Form
    {
        public MenuUtilitario()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (FuncionesBasicas.getInstance().CerrarFormulario("UTILITARIOS"))
                this.Close();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            Usuarios frm = new Usuarios();
            frm.ShowDialog();
        }

        private void btnConvenios_Click(object sender, EventArgs e)
        {
            Convenios frm = new Convenios();
            frm.ShowDialog();
        }
        

        private void btnInventario_Click(object sender, EventArgs e)
        {
            Pedidos frm = new Pedidos();
            frm.ShowDialog();

        }

        private void btnContadores_Click(object sender, EventArgs e)
        {
            Contadores frm = new Contadores();
            frm.ShowDialog();
        }

        private void btnOrdenTrabajo_Click(object sender, EventArgs e)
        {
            Orden_Normal frm = new Orden_Normal();
            frm.ShowDialog();
        }

        private void btnBanco_Click(object sender, EventArgs e)
        {
            Bancos frm = new Bancos();
            frm.ShowDialog();
        }

        private void btnDiferidos_Click(object sender, EventArgs e)
        {
            TiempoDiferido frm = new TiempoDiferido();
            frm.ShowDialog();
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            Productos frm = new Productos();
            frm.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Garantias frm = new Garantias();
            frm.ShowDialog();
        }
    }
}
