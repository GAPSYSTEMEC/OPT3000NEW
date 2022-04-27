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
    public partial class Anticipos : Form
    {
        public string valor;
        public string codigo;
        public Anticipos(Int64 codPac)
        {
            InitializeComponent();
            DataTable datos = new DataTable();
            List<ANTICIPOS> anticipo = new List<ANTICIPOS>();
            anticipo = NegConsultas.getInstance().CargaAnticipos(codPac);
            datos.Columns.Add("ID").ReadOnly = true;
            datos.Columns.Add("VALOR").ReadOnly = true;
            foreach (var item in anticipo)
            {
                datos.Rows.Add(new object[] { item.ID_ANTICIPOS, item.Saldo });
            }
            dgv_Anticipos.DataSource = datos;
            dgv_Anticipos.Columns["ID"].Width = 30;
            dgv_Anticipos.Columns["VALOR"].Width = 100;

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

        private void dgv_Anticipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CargaAnticipo();
        }

        public void CargaAnticipo()
        {
            int fila = dgv_Anticipos.CurrentRow.Index;
            codigo = dgv_Anticipos.Rows[fila].Cells[0].Value.ToString();
            valor = dgv_Anticipos.Rows[fila].Cells[1].Value.ToString();
            this.Close();
        }

        private void dgv_Anticipos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                CargaAnticipo();
            }
        }
    }
}
