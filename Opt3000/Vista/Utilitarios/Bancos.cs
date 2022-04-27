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
    public partial class Bancos : Form
    {
        public string banc = "";
        DataTable banco = new DataTable();
        bool factura = false;
        public Bancos(bool _factura = false)
        {
            InitializeComponent();
            factura = _factura;
            banco.Columns.Add("ID").ReadOnly = true;
            banco.Columns.Add("BANCO").ReadOnly = true;
            banco.Columns.Add("COMENTARIO").ReadOnly = true;
            CargaBanco();
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

        public void CargaBanco()
        {
            List<BANCOS> lista = new List<BANCOS>();
            lista = NegConsultas.getInstance().RecuperaBancos();

            foreach (var item in lista)
            {
                banco.Rows.Add(new object[] { item.ID_BANCO, item.Nombre, item.Detalle });
            }
            g_Banco.DataSource = banco;
            g_Banco.Columns["ID"].Width = 75;
            g_Banco.Columns["BANCO"].Width = 150;
            g_Banco.Columns["COMENTARIO"].Width = 150;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (txtBanco.Text == "")
            {
                MessageBox.Show("Ingresa el nombre de un banco", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            BANCOS obj = new BANCOS();
            obj.Nombre = txtBanco.Text;
            obj.Detalle = txtComentario.Text;
            if (lblCodigo.Text == "CODIGO")
                obj.ID_BANCO = 0;
            else
                obj.ID_BANCO = Convert.ToInt16(lblCodigo.Text);
            if (NegGuarda.getInstance().GuardaBanco(obj))
            {
                MessageBox.Show("Banco Guardado con exito", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            banco = new DataTable();
            banco.Columns.Add("ID").ReadOnly = true;
            banco.Columns.Add("BANCO").ReadOnly = true;
            banco.Columns.Add("COMENTARIO").ReadOnly = true;
            g_Banco.DataSource = banco;
            CargaBanco();

            lblCodigo.Text = "CODIGO";
            txtBanco.Text = "";
            txtComentario.Text = "";
        }

        private void g_Banco_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!factura)
            {
                lblCodigo.Text = (string)g_Banco.Rows[e.RowIndex].Cells[0].Value;
                txtBanco.Text = (string)g_Banco.Rows[e.RowIndex].Cells[1].Value;
                txtComentario.Text = (string)g_Banco.Rows[e.RowIndex].Cells[2].Value;
            }
            else
            {
                banc = (string)g_Banco.Rows[e.RowIndex].Cells[1].Value;
                this.Close();
            }
        }
    }
}
