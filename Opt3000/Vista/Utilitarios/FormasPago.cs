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
    public partial class FormasPago : Form
    {
        public string codigo;
        public string detalle;
        public string codAnti;
        public string saldo;
        public Int64 codPac;
        public FormasPago(Int64 pacCod_)
        {
            InitializeComponent();
            codPac = pacCod_;
            List<FORMA_PAGO> formaPago = new List<FORMA_PAGO>();
            formaPago = NegConsultas.getInstance().CargaFormasPago();
            DataTable datos = new DataTable();
            datos.Columns.Add("ID").ReadOnly = true;
            datos.Columns.Add("DETALLE").ReadOnly = true;
            foreach (var item in formaPago)
            {
                datos.Rows.Add(new object[] { item.ID_FORMAPAGO, item.Detalle });
            }

            dgv_FormasPago.DataSource = datos;
            dgv_FormasPago.Columns["ID"].Width = 50;
            dgv_FormasPago.Columns["DETALLE"].Width = 190;

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

        private void dgv_FormasPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                CargaForma();
            }
        }

        public void CargaForma()
        {
            int fila = dgv_FormasPago.CurrentRow.Index;
            codigo = dgv_FormasPago.Rows[fila].Cells[0].Value.ToString();
            detalle = dgv_FormasPago.Rows[fila].Cells[1].Value.ToString();
            if (codigo == "5")
            {
                List<ANTICIPOS> anticipos = new List<ANTICIPOS>();
                anticipos = NegConsultas.getInstance().CargaAnticipos(codPac);
                if (anticipos.Count > 0)
                {
                    Anticipos frmAnt = new Anticipos(codPac);
                    frmAnt.ShowDialog();
                    saldo = frmAnt.valor;
                    codAnti = frmAnt.codigo;
                }
                else
                {
                    MessageBox.Show("Paciente no tiene Anticipos :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
            this.Close();
        }

        private void dgv_FormasPago_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CargaForma();
        }
    }
}
