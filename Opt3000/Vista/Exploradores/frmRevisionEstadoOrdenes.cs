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
using DevExpress.XtraGrid.Views.Grid;

namespace Opt3000.Vista.Exploradores
{
    public partial class frmRevisionEstadoOrdenes : Form
    {
        bool generado = false;
        bool enviado = false;
        bool recibido = false;
        bool entregado = false;
        string orden = "";
        public frmRevisionEstadoOrdenes()
        {
            InitializeComponent();
            cargar();
            Ancho(gridView1);
            Edicion(gridView1);
        }

        private void nbtActualizar_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            try
            {
                NegConsultas.actualizaOrdenes(chkGenerado.Checked, chkEnviado.Checked, chkRecibido.Checked, chkEntregado.Checked, Convert.ToUInt16(txtcodigo.Text));
                MessageBox.Show("Datos Almacenados Correctamente.", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                cargar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void nbtSalir_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            this.Close();
        }
        public void cargar()
        {
            gridControl1.DataSource = NegConsultas.getInstance().CargaOrdenNormal();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                object recordObject = view.GetRow(view.FocusedRowHandle);
                generado = Convert.ToBoolean(view.GetRowCellValue(view.FocusedRowHandle, "Generado").ToString().Trim());
                enviado = Convert.ToBoolean(view.GetRowCellValue(view.FocusedRowHandle, "Enviado").ToString().Trim());
                recibido = Convert.ToBoolean(view.GetRowCellValue(view.FocusedRowHandle, "Recibido").ToString().Trim());
                entregado = Convert.ToBoolean(view.GetRowCellValue(view.FocusedRowHandle, "Entregado").ToString().Trim());
                orden = view.GetRowCellValue(view.FocusedRowHandle, "Orden").ToString().Trim();
                chkGenerado.Checked = generado;
                chkEnviado.Checked = enviado;
                chkRecibido.Checked = recibido;
                chkEntregado.Checked = entregado;
                txtcodigo.Text = orden;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Error");
            }
        }
        public void Limpiar()
        {
            chkGenerado.Checked = false;
            chkEntregado.Checked = false;
            chkEnviado.Checked = false;
            chkRecibido.Checked = false;
            txtcodigo.Text = "";
        }
        private void Ancho(DevExpress.XtraGrid.Views.Grid.GridView x)
        {
            gridView1.BestFitColumns(); //Para que automatice
            gridView1.Columns[6].Width = 300;
        }
        private void Edicion(DevExpress.XtraGrid.Views.Grid.GridView x)
        {
            gridView1.BestFitColumns(); //Para que automatice
            gridView1.Columns[0].OptionsColumn.AllowEdit = false;
            gridView1.Columns[1].OptionsColumn.AllowEdit = false;
            gridView1.Columns[2].OptionsColumn.AllowEdit = false;
            gridView1.Columns[3].OptionsColumn.AllowEdit = false;
            gridView1.Columns[4].OptionsColumn.AllowEdit = false;
            gridView1.Columns[5].OptionsColumn.AllowEdit = false;
            gridView1.Columns[6].OptionsColumn.AllowEdit = false;
            gridView1.Columns[7].OptionsColumn.AllowEdit = false;
            gridView1.Columns[8].OptionsColumn.AllowEdit = false;
            gridView1.Columns[9].OptionsColumn.AllowEdit = false;
        }
    }
}
