using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opt3000.Negocio;
using Opt3000.BaseDatos;

namespace Opt3000.Vista.Utilitarios
{
    public partial class Password : Form
    {
        public int idUsuario = 0;
        public string usuario;
        public Password()
        {
            InitializeComponent();
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

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            USUARIO obj = new USUARIO();
            obj = NegConsultas.getInstance().RecuperaUsuarioPassword(txtPasword.Text);
            idUsuario = obj.ID_USUARIO;
            usuario = obj.Apellidos + " " + obj.Nombres;
            this.Close();
        }
    }
}
