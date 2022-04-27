using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using Opt3000.Datos;

namespace Opt3000.Vista.Utilitarios
{
    public partial class frmOrdenesTrab : Form
    {
        public string identificacion = "";
        public frmOrdenesTrab(string _identificacion = "")
        {
            InitializeComponent();
            identificacion = _identificacion;
            cargarConsulta();
        }
        public void cargarConsulta()
        {
            gridControl1.DataSource = ExploradorController.OrdenTrabajoBuscar(identificacion);
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
    }
}
