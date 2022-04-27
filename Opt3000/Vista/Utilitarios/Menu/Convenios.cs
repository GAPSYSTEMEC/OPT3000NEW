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

namespace Opt3000.Vista.Utilitarios.Menu
{
    public partial class Convenios : Form
    {
        public Convenios()
        {
            InitializeComponent();
            RecuperaConvenios();
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

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void txtDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                btnGuardar.Focus();
        }

        private void RecuperaConvenios()
        {
            DataTable datos = new DataTable();
            List<CONVENIO> convenio = new List<CONVENIO>();
            convenio = NegConsultas.getInstance().ConsultaConvenios();
            datos.Columns.Add("ID").ReadOnly = true;
            datos.Columns.Add("NOMBRE").ReadOnly = true;
            datos.Columns.Add("DETALLE").ReadOnly = true;
            foreach (var item in convenio)
            {
                datos.Rows.Add(new object[] { item.ID_TIPO, item.Detalle, item.Observaciones });
            }
            dgv_Convenios.DataSource = datos;
            dgv_Convenios.Columns["ID"].Width = 30;
            dgv_Convenios.Columns["NOMBRE"].Width = 100;
            dgv_Convenios.Columns["DETALLE"].Width = 200;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidaFormulario())
            {
                CONVENIO convenio = new CONVENIO();
                convenio.Detalle = txtNombre.Text;
                convenio.Observaciones = txtDetalle.Text;
                if (NegGuarda.getInstance().GuardaConvenio(convenio))
                {
                    MessageBox.Show("Convenio Guardado con exito :)", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Algo salio mal convenio no se pudo Guardar :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void AgregarError(Control control, string texto)
        {
            error.SetError(control, texto);
        }

        public bool ValidaFormulario()
        {
            error.Clear();
            bool valido = true;
            if (txtNombre.Text == "")
            {
                AgregarError(txtNombre, "Convenio es requerido");
                valido = false;
            }
            if (txtDetalle.Text == "")
            {
                AgregarError(txtDetalle, "Detalle es requerido");
                valido = false;
            }

            return valido;
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (NegConsultas.getInstance().RecuperaConvenio(txtNombre.Text))
            {
                MessageBox.Show("Convenio ya existe :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Text = "";
            }
        }
    }
}
