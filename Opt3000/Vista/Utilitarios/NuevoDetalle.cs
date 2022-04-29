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
    public partial class NuevoDetalle : Form
    {
        public string detalle = "";
        public NuevoDetalle()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            detalle = txtDetalle.Text;
            if (detalle != "")
            {
                this.Close();
                return;
            }
            MessageBox.Show("Para aceptar debe ingresar un detalle, caso contrario CANCELE", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seuro de cancelar la acción???", "OPT3000", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                detalle = "";
                this.Close();

            }
        }
    }
}
