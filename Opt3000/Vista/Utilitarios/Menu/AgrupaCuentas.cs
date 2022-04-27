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

namespace Opt3000.Vista.Utilitarios.Menu
{
    public partial class AgrupaCuentas : Form
    {
        DataTable pacientes = new DataTable();
        Int64 ateCodigo = 0;
        public AgrupaCuentas(Int64 _ateCodigo)
        {
            InitializeComponent();
            ateCodigo = _ateCodigo;
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

        private void g_Pacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PACIENTE objPaciente = new PACIENTE();
            objPaciente = NegConsultas.getInstance().CargaPaciente((string)g_Pacientes.Rows[e.RowIndex].Cells[2].Value);
            BuscadorAtencion frmBuscaAtencion = new BuscadorAtencion(objPaciente.ID_PACIENTE);
            frmBuscaAtencion.ShowDialog();
            int columna = g_Pacientes.SelectedCells[0].ColumnIndex;
            int fila = g_Pacientes.CurrentRow.Index;

            for (int i = 0; i < g_Pacientes2.Rows.Count; i++)
            {
                if (frmBuscaAtencion.ateCodigo == ateCodigo.ToString())
                {
                    MessageBox.Show("No puedes agrupar la misma cuenta :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (frmBuscaAtencion.ateCodigo == (string)g_Pacientes2.Rows[i].Cells[0].Value)
                {
                    MessageBox.Show("Ya se agrego la cuenta :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (frmBuscaAtencion.ateCodigo != "")
            {
                DataGridViewRow dt = new DataGridViewRow();
                dt.CreateCells(g_Pacientes2);
                dt.Cells[0].Value = "";
                dt.Cells[1].Value = "";
                g_Pacientes2.Rows.Add(dt);
            }
            else
                return;
            fila = g_Pacientes2.Rows.Count - 2;
            g_Pacientes2.Rows[fila].Cells[columna].Value = frmBuscaAtencion.ateCodigo;
            g_Pacientes2.Rows[fila].Cells[1].Value = (string)g_Pacientes.Rows[e.RowIndex].Cells[0].Value;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se van a unificar las cuentas seleccionadas ¿Estas seguro de continuar? :o", "OPT3000", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                for (int i = 0; i < g_Pacientes2.Rows.Count - 1; i++)
                {
                    NegActualizacion.getInstance().ActualizaAgrupacion(Convert.ToInt64(g_Pacientes2.Rows[i].Cells[0].Value), ateCodigo);

                }
                MessageBox.Show("Cuentas agrupadas con exito. ¿Estas seguro de continuar? :)", "OPT3000", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
