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

namespace Opt3000.Vista.Utilitarios
{
    public partial class MoverArchivo : Form
    {
        string nombreArchivo = "";
        public Int64 HC = 0;
        public MoverArchivo(Int64 hc)
        {
            InitializeComponent();
            HC = hc;
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

        private void btnVerDoc_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string str_RutaArchivo = openFileDialog1.FileName;
                    txtSeleccionar.Text = str_RutaArchivo;
                    nombreArchivo = openFileDialog1.SafeFileName;
                }
                catch (Exception)
                {

                    throw;
                }

            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSeleccionar.Text != "")
                {
                    string path = @"E:\PruebasGuardado\HC-" + HC;
                    string pathOriginal = txtSeleccionar.Text;

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    if (File.Exists(path + "\\" + openFileDialog1.SafeFileName))
                        File.Delete(path + "\\" + openFileDialog1.SafeFileName);

                    File.Move(pathOriginal, path + "\\" + openFileDialog1.SafeFileName);
                    MessageBox.Show("MicroFile actualizado con exito :)", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Algo salio mal revice MicroFile :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
