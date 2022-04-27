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
using Opt3000.Entidades;

namespace Opt3000.Vista.Utilitarios
{
    public partial class CuentaIndividual : Form
    {
        CLIENTE obj = new CLIENTE();
        public CuentaIndividual(CLIENTE _obj, Int64 codAtencion)
        {
            InitializeComponent();
            cargaAgrupados(codAtencion);
            obj = _obj;
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

        public void cargaAgrupados(Int64 codAgrupados)
        {
            List<CuentasAgrupadas> lista = new List<CuentasAgrupadas>();
            lista = NegConsultas.getInstance().CUENTAS_AGRUPADAS(codAgrupados);
            DataTable pacientes = new DataTable();
            pacientes.Columns.Add("NOMBRES");
            pacientes.Columns.Add("HC");
            pacientes.Columns.Add("CÉDULA");
            pacientes.Columns.Add("ATENCION");
            foreach (var item in lista)
            {
                pacientes.Rows.Add(new object[] { item.NOMBRE, item.HC, item.CEDULA, item.ATENCION });
            }
            g_Pacientes.DataSource = pacientes;
            g_Pacientes.Columns["NOMBRES"].Width = 350;
            g_Pacientes.Columns["HC"].Width = 75;
            g_Pacientes.Columns["CÉDULA"].Width = 85;
            g_Pacientes.Columns["ATENCION"].Width = 85;
        }

        private void g_Pacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = g_Pacientes.CurrentRow.Index;
            BuscarInventario buscador = new BuscarInventario(obj, Convert.ToInt64(g_Pacientes.Rows[fila].Cells[3].Value.ToString()), true);
            buscador.ShowDialog();
            this.Close();
        }
    }
}
