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
    public partial class Medicos : Form
    {
        public string _medico = "";
        DataTable med = new DataTable();
        public Medicos()
        {
            InitializeComponent();
            med.Columns.Add("ID").ReadOnly = true;
            med.Columns.Add("NOMBRE").ReadOnly = true;
            Buscador();
        }
        private void Buscador()
        {
            try
            {
                List<MEDICO> medico = new List<MEDICO>();
                medico = NegConsultas.getInstance().CargaMedicos();
                foreach (var item in medico)
                {
                    USUARIO usu = new USUARIO();
                    usu = NegConsultas.getInstance().RecuperaUsuario(item.ID_USUARIO);
                    med.Rows.Add(new object[] { item.ID_MEDICO, usu.Nombres + " " + usu.Apellidos });
                }
                g_Medico.DataSource = med;
                g_Medico.Columns["ID"].Width = 50;
                g_Medico.Columns["NOMBRE"].Width = 350;

            }
            catch (Exception)
            {
                throw;
            }

        }

        private void g_Medico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CargaMedico();
        }

        private void g_Medico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                CargaMedico();
            }
        }

        private void CargaMedico()
        {
            int fila = g_Medico.CurrentRow.Index;
            _medico = g_Medico.Rows[fila].Cells[1].Value.ToString();
            this.Close();
        }
    }
}
