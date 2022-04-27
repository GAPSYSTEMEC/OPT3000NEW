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
    public partial class Cie10 : Form
    {
        #region Variables

        DataTable cie10 = new DataTable();
        public string codigo = "";
        public string detalle = "";

        #endregion
        public Cie10()
        {
            InitializeComponent();
            cie10.Columns.Add("CÓDIGO");
            cie10.Columns.Add("DESCRIPCIÓN");
            List<CIE_10> lista = NegConsultas.getInstance().ConsultaCie10();
            foreach (var item in lista)
            {
                cie10.Rows.Add(new object[] { item.Codigo, item.Descripcion });
            }
            g_Cie10.DataSource = cie10;
            g_Cie10.Columns["CÓDIGO"].Width = 50;
            g_Cie10.Columns["DESCRIPCIÓN"].Width = 315;
            txtBuscador.Focus();
            txtBuscador.Text = "52";
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

        private void txtEsferaVCod_TextChanged(object sender, EventArgs e)
        {
            string parametro = "";
            if (r_Codigo.Checked)
                parametro = "CÓDIGO";
            else
                parametro = "DESCRIPCIÓN";
            var filtro = parametro + " like '%" + txtBuscador.Text + "%'";
            cie10.DefaultView.RowFilter = filtro;
        }

        private void Cie10_Load(object sender, EventArgs e)
        {
            txtBuscador.Focus();
        }

        private void txtBuscador_KeyDown(object sender, KeyEventArgs e)
        {
            //e.SuppressKeyPress = true;
            if (e.KeyCode.Equals(Keys.Enter))
                g_Cie10.Focus();
        }

        private void r_Codigo_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscador.Text = "";
        }

        private void r_Descripcion_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscador.Text = "";
        }

        private void g_Cie10_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            codigo = (string)g_Cie10.Rows[e.RowIndex].Cells[0].Value;
            detalle = (string)g_Cie10.Rows[e.RowIndex].Cells[1].Value;
            this.Close();
        }

        private void g_Cie10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {

                int fila = g_Cie10.CurrentRow.Index;
                codigo = (string)g_Cie10.Rows[fila].Cells[0].Value;
                detalle = (string)g_Cie10.Rows[fila].Cells[1].Value;
                this.Close();
            }
        }
    }
}
