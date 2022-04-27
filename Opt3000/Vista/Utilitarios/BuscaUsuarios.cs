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
    public partial class BuscaUsuarios : Form
    {

        DataTable usuarios = new DataTable();
        public string usuario = "";
        public BuscaUsuarios()
        {
            InitializeComponent();
            usuarios.Columns.Add("ID");
            usuarios.Columns.Add("NOMBRES");
            usuarios.Columns.Add("USUARIO");
            List<USUARIO> lista = NegConsultas.getInstance().CargaListaUsuario();
            foreach (var item in lista)
            {
                usuarios.Rows.Add(new object[] { item.ID_USUARIO, item.Apellidos + " " + item.Nombres, item.Usuario });
            }
            g_Pacientes.DataSource = usuarios;
            g_Pacientes.Columns["ID"].Width = 50;
            g_Pacientes.Columns["NOMBRES"].Width = 350;
            g_Pacientes.Columns["USUARIO"].Width = 100;
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

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            string parametro = "";
            if (r_Nombre.Checked)
                parametro = "NOMBRES";
            else
                parametro = "USUARIO";
            var filtro = parametro + " like '%" + txtBuscador.Text + "%'";
            usuarios.DefaultView.RowFilter = filtro;
        }

        private void g_Pacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            usuario = (string)g_Pacientes.Rows[e.RowIndex].Cells[0].Value;
            this.Close();
        }
    }
}
