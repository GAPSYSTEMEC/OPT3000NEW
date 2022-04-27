using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opt3000.Vista.Exploradores;
using Opt3000.Datos;
using System.IO;
using DevExpress.XtraPrinting;

namespace Opt3000.Vista.Exploradores
{
    public partial class frmPaciente : Form
    {
        public frmPaciente()
        {
            InitializeComponent();
            DateTime oPrimerDiaDelMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime oUltimoDiaDelMes = oPrimerDiaDelMes.AddMonths(1).AddDays(-1);
            dtpDesde.EditValue = oPrimerDiaDelMes;
            dtpHasta.EditValue = oUltimoDiaDelMes;
            cargarConsulta();
            CreaSummaries(gridView1);
            Edicion(gridView1);
        }

        private void nbtActualizar_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            if (dtpDesde.DateTime > dtpHasta.DateTime)
            {
                XtraMessageBox.Show("La fecha \"DESDE\" no puede ser mayor que \"HASTA\"", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                cargarConsulta();
                SplashScreenManager.CloseForm(false);
            }
        }
        public void cargarConsulta()
        {
            gridControl1.DataSource = ExploradorController.Pacientes();
            gridView1.BestFitColumns();
        }

        private void nbtExportar_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            ExportToExcel();
        }

        private void nbtSalir_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            this.Close();
        }
        private void ExportToExcel(bool includeDetail = false)
        {
            //if (includeDetail)
            //{
            //    gridView1.OptionsPrint.PrintDetails = true;
            //    gridView1.OptionsPrint.ExpandAllDetails = true;

            //    XlsxExportOptionsEx opt = new XlsxExportOptionsEx();


            //    opt.ExportType = DevExpress.Export.ExportType.WYSIWYG;
            //    //XlsxExportOptions optt = new XlsxExportOptions();
            //    //optt.TextExportMode = DevExpress.;
            //    //gridControl1.ExportToHtml("tempSWYS.xlsx", opt);
            //}
            //else
            //{
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                gridView1.OptionsPrint.PrintDetails = includeDetail;
                gridView1.OptionsPrint.ExpandAllDetails = includeDetail;

                XlsxExportOptionsEx opt = new XlsxExportOptionsEx();
                opt.DocumentOptions.Title = this.Text + " " + DateTime.Now.ToString();
                DocxExportOptions optdoc = new DocxExportOptions();
                optdoc.DocumentOptions.Title = this.Text + " " + DateTime.Now.ToString();
                if (includeDetail)
                {
                    opt.ExportType = DevExpress.Export.ExportType.WYSIWYG;    ///con detail
                    //saveDialog.Filter = "Excel (2010) (.xlsx)|*.xlsx";
                    saveDialog.Filter = "Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html |MsWord File (.docx)|*.docx ";
                }
                else
                {
                    opt.ExportType = DevExpress.Export.ExportType.DataAware;   ///solo master        
                    saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html |MsWord File (.docx)|*.docx ";
                }



                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".xls":
                            gridControl1.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            gridControl1.ExportToXlsx(exportFilePath, opt);
                            break;
                        case ".rtf":
                            gridControl1.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            gridControl1.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            gridControl1.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            gridControl1.ExportToMht(exportFilePath);
                            break;
                        case ".docx":
                            gridControl1.ExportToDocx(exportFilePath, optdoc);
                            break;
                        default:
                            break;
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            //Try to open the file and let windows decide how to open it.
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch
                        {
                            String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


        }

        private void CreaSummaries(DevExpress.XtraGrid.Views.Grid.GridView x)
        {

            gridView1.Columns["Identificacion"].Summary.Add(DevExpress.Data.SummaryItemType.Count, "Identificacion", "Nº: {0}");
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
