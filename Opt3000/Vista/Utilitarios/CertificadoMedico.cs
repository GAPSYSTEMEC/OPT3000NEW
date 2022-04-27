using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Opt3000.Vista.Utilitarios
{
    public partial class CertificadoMedico : Form
    {
        public string oftal = "";
        public string vision = "";
        public string recom = "";
        string lblAtencion = "";
        public CertificadoMedico(string _lblAtencion = "")
        {
            InitializeComponent();
            txtRecomendaciones.Text = _lblAtencion;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (txtOftal.Text == "")
            {
                MessageBox.Show("Debe ingresar la OFTALMOSCOPIA", "HIS3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtVision.Text == "")
            {
                MessageBox.Show("Debe ingresar la VISIÓN DE COLORES", "HIS3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtRecomendaciones.Text == "")
            {
                MessageBox.Show("Debe ingresar RECOMEDACIONES", "HIS3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                oftal = txtOftal.Text;
                vision = txtVision.Text;
                recom = txtRecomendaciones.Text;
                this.Close();
            }
        }
    }
}
