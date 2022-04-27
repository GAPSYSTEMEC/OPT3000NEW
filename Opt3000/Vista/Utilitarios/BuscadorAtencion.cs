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
    public partial class BuscadorAtencion : Form
    {
        DataTable atencion = new DataTable();
        public string ateCodigo = "";
        public BuscadorAtencion(Int64 hc, string tipoConsulta = "")
        {
            InitializeComponent();
            atencion.Columns.Add("FECHA ATENCIÓN");
            atencion.Columns.Add("ID");
            if (tipoConsulta == "NORMAL")
            {

                //List<ATENCION> lista = NegConsultas.getInstance().RecuperaOrden1Paciente(hc);
                List<ATENCION> lista = NegConsultas.getInstance().CargaAtenciones(hc);
                foreach (var item in lista)
                {
                    atencion.Rows.Add(new object[] { item.Fecha_Creacion, item.ID_ATENCION });
                    break;
                }
            }
            else
            {
                List<ATENCION> lista = NegConsultas.getInstance().CargaAtenciones(hc, tipoConsulta);
                foreach (var item in lista)
                {
                    atencion.Rows.Add(new object[] { item.Fecha_Creacion, item.ID_ATENCION });
                }
            }
            g_Atenciones.DataSource = atencion;
            g_Atenciones.Columns["FECHA ATENCIÓN"].Width = 180;
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

        private void g_Atenciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ateCodigo = (string)g_Atenciones.Rows[e.RowIndex].Cells[1].Value;
            this.Close();
        }
    }
}
