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
    public partial class BuscadorPacientes : Form
    {
        #region Variables

        DataTable pacientes = new DataTable();
        public string cedula = "";

        #endregion

        public BuscadorPacientes()
        {
            InitializeComponent();
            pacientes.Columns.Add("NOMBRES");
            pacientes.Columns.Add("HC");
            pacientes.Columns.Add("CÉDULA");
            List<PACIENTE> lista = NegConsultas.getInstance().CargaListaPaciente();
            foreach (var item in lista)
            {
                pacientes.Rows.Add(new object[] { item.Apellidos + " " + item.Nombres, item.ID_PACIENTE, item.Identificacion });                
            }
            g_Pacientes.DataSource = pacientes;
            g_Pacientes.Columns["NOMBRES"].Width = 350;
            g_Pacientes.Columns["HC"].Width = 75;
            g_Pacientes.Columns["CÉDULA"].Width = 85;
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
            else if (r_Hc.Checked)
                parametro = "HC";
            else
                parametro = "CÉDULA";
            var filtro = parametro + " like '%" + txtBuscador.Text + "%'";
            pacientes.DefaultView.RowFilter = filtro;
        }

        private void txtBuscador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                g_Pacientes.Focus();
        }

        private void BuscadorPacientes_Click(object sender, EventArgs e)
        {

        }

        private void g_Pacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cedula = (string)g_Pacientes.Rows[e.RowIndex].Cells[2].Value;
            this.Close();
        }
    }
}
