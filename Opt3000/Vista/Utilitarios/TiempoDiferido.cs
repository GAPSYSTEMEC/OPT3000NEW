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

namespace Opt3000.Vista.Utilitarios
{
    public partial class TiempoDiferido : Form
    {
        DataTable tiempo = new DataTable();
        public TiempoDiferido()
        {
            InitializeComponent();
            tiempo.Columns.Add("ID").ReadOnly = true;
            tiempo.Columns.Add("DETALLE").ReadOnly = true;
            CargaDiferido();
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

        public void CargaDiferido()
        {
            List<TIEMPODIFERIDO> lista = new List<TIEMPODIFERIDO>();
            lista = NegConsultas.getInstance().RecuperaDiferidos();

            foreach (var item in lista)
            {
                tiempo.Rows.Add(new object[] { item.ID_TIEMPODIFERIDO, item.Detalle });
            }
            g_Banco.DataSource = tiempo;
            g_Banco.Columns["ID"].Width = 75;
            g_Banco.Columns["DETALLE"].Width = 150;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (txtBanco.Text == "")
            {
                MessageBox.Show("Ingresa el nombre de un banco", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            TIEMPODIFERIDO obj = new TIEMPODIFERIDO();
            obj.Detalle = txtBanco.Text;

            if (lblCodigo.Text == "CODIGO")
                obj.ID_TIEMPODIFERIDO = 0;
            else
                obj.ID_TIEMPODIFERIDO = Convert.ToInt16(lblCodigo.Text);
            if (NegGuarda.getInstance().GuardaDiferido(obj))
            {
                MessageBox.Show("Tiempo Diferido Guardado con exito", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            tiempo = new DataTable();
            tiempo.Columns.Add("ID").ReadOnly = true;
            tiempo.Columns.Add("DETALLE").ReadOnly = true;
            g_Banco.DataSource = tiempo;
            CargaDiferido();
            txtBanco.Text = "";
            lblCodigo.Text = "CODIGO";
        }

        private void g_Banco_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblCodigo.Text = (string)g_Banco.Rows[e.RowIndex].Cells[0].Value;
            txtBanco.Text = (string)g_Banco.Rows[e.RowIndex].Cells[1].Value;
        }
    }
}
