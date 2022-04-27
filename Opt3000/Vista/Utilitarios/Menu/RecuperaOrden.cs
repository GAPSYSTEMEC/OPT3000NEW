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

namespace Opt3000.Vista.Utilitarios.Menu
{

    public partial class RecuperaOrden : Form
    {
        DataTable facturas = new DataTable();
        public string factura = "";
        public RecuperaOrden()
        {
            InitializeComponent();
            facturas.Columns.Add("FACTURA").ReadOnly = true;
            facturas.Columns.Add("PROVEEDOR").ReadOnly = true;
            List<ORDEN_PEDIDO> obj = new List<ORDEN_PEDIDO>();
            obj = NegConsultas.getInstance().CargaOrdenes();


            foreach (var item in obj)
            {
                facturas.Rows.Add(new object[] { item.NumeroFactura, item.Proveedor });
            }
            dgv_Ordenes.DataSource = facturas;
            dgv_Ordenes.Columns["FACTURA"].Width = 100;
            dgv_Ordenes.Columns["PROVEEDOR"].Width = 250;
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string parametro = "FACTURA";
            var filtro = parametro + " like '%" + txtBuscar.Text + "%'";
            facturas.DefaultView.RowFilter = filtro;
        }

        private void dgv_Ordenes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dgv_Ordenes.CurrentRow.Index;
            factura = dgv_Ordenes.Rows[fila].Cells[0].Value.ToString();
            this.Close();
        }

        private void RecuperaOrden_Load(object sender, EventArgs e)
        {

        }
    }
}
