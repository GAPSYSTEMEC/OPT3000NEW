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

namespace Opt3000.Vista.Utilitarios
{
    public partial class Anticipo : Form
    {
        public Int64 codPac = 0;
        public Int32 codForPag = 0;
        public string formaPago = "";
        public string atencion = "";
        public Anticipo(Int64 _codPac, string _atencion = "")
        {
            InitializeComponent();
            codPac = _codPac;
            atencion = _atencion;
            CargaAnticipos();
        }

        private void CargaAnticipos()
        {
            DataTable datos = new DataTable();
            List<ANTICIPOS> anticipo = new List<ANTICIPOS>();
            anticipo = NegConsultas.getInstance().CargaAnticipos(codPac);
            datos.Columns.Add("ID").ReadOnly = true;
            datos.Columns.Add("VALOR").ReadOnly = true;
            foreach (var item in anticipo)
            {
                datos.Rows.Add(new object[] { item.ID_ANTICIPOS, item.Saldo });
            }
            dgv_Anticipos.DataSource = datos;
            dgv_Anticipos.Columns["ID"].Width = 30;
            dgv_Anticipos.Columns["VALOR"].Width = 100;
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


        private void txtFormaPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                FormasPago frm = new FormasPago(codPac);
                frm.ShowDialog();
                codForPag = Convert.ToInt32(frm.codigo);
                formaPago = frm.detalle;
                txtFormaPago.Text = formaPago;
                if (codForPag == 5)
                {
                    MessageBox.Show("No puedes generar un anticipo con forma de pago ANTICIPO :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (codForPag != 1)
                {
                    txtDiferido.ReadOnly = false;
                    txtLote.ReadOnly = false;
                    txtAutorizacion.ReadOnly = false;
                    txtTotal.ReadOnly = false;
                }
                else
                {
                    txtTotal.ReadOnly = false;
                }
            }
            else
            {
                if (e.KeyValue == (char)Keys.Enter)
                {
                    FuncionesBasicas.getInstance().SaltarConEnter(e);
                    return;
                }
                else
                {
                    txtFormaPago.Text = "";
                }
            }
        }

        private void txtFormaPago_Leave(object sender, EventArgs e)
        {
            if (codForPag == 0)
            {
                txtFormaPago.Focus();
            }
            else
                txtFormaPago.Text = formaPago;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtFormaPago.ReadOnly = false;
            txtDiferido.ReadOnly = true;
            txtLote.ReadOnly = true;
            txtAutorizacion.ReadOnly = true;
            txtTotal.ReadOnly = true;
            txtFormaPago.Text = "";
            txtDiferido.Text = "";
            txtLote.Text = "";
            txtAutorizacion.Text = "";
            txtTotal.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidaFormulario())
            {
                ANTICIPOS anticipo = new ANTICIPOS();
                anticipo.ID_PACIENTE = codPac;
                anticipo.Detalle = txtFormaPago.Text + " / " + txtLote.Text + " / " + txtAutorizacion.Text;
                anticipo.Valor = Convert.ToDecimal(txtTotal.Text);
                anticipo.Saldo = Convert.ToDecimal(txtTotal.Text);
                anticipo.Fecha_Registro = DateTime.Now.Date;
                if (NegGuarda.getInstance().GuardaAnticipo(anticipo))
                {
                    MessageBox.Show("Anticipo guardado con exito :)", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargaAnticipos();
                }
                else
                {
                    MessageBox.Show("Anticipo no se pudo guardar pide soporte :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Complete los datos para guardar el Anticipo :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool ValidaFormulario()
        {
            error.Clear();
            bool valido = true;
            if (txtFormaPago.Text == "")
            {
                AgregarError(txtFormaPago, "Eliga una forma de pago con F1");
                return valido = false;
            }
            if (codForPag == 1)
            {
                if (txtTotal.Text == "")
                {
                    AgregarError(txtTotal, "No tengo el valor del Anticipo");
                    return valido = false;
                }
            }
            else
            {
                if (txtLote.Text == "")
                {
                    AgregarError(txtLote, "No tengo el lote del Voucher");
                    return valido = false;
                }
                if (txtAutorizacion.Text == "")
                {
                    AgregarError(txtAutorizacion, "No tengo la autorización del Voucher");
                    return valido = false;
                }
                if (txtTotal.Text == "")
                {
                    AgregarError(txtTotal, "No tengo el valor del Anticipo");
                    return valido = false;
                }
            }
            return valido;
        }

        private void AgregarError(Control control, string texto)
        {
            error.SetError(control, texto);
        }

        private void txtFormaPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().OnlyNumberDecimal(e);
        }

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().OnlyNumberDecimal(e);
        }

        private void bntImprime_Click(object sender, EventArgs e)
        {
            int fila = dgv_Anticipos.CurrentRow.Index;
            PACIENTE pac = new PACIENTE();
            pac = NegConsultas.getInstance().RecuperaPaciente(codPac);
            ANTICIPOS ant = new ANTICIPOS();
            ant = NegConsultas.getInstance().RecuperaAnticipo(Convert.ToInt64(dgv_Anticipos.Rows[fila].Cells["ID"].Value.ToString()));
            AnticipoRecibo obj = new AnticipoRecibo();
            string[] cadena = ant.Detalle.Split('/');
            obj.paciente = pac.Apellidos + " " + pac.Nombres;
            obj.responsable = Cesion.usuario;
            obj.valor = Convert.ToString(ant.Saldo);
            obj.atencion = atencion;
            obj.formaPago = cadena[0];
            obj.numero = Convert.ToString(ant.ID_ANTICIPOS);
            obj.detalle = ant.Detalle + " **NOTA: SI NO RETIRA SU TRABAJO EN 90 DÍAS PIERDE SU ANTICIPO Y TRABAJO. ";
            obj.fecha = Convert.ToString(ant.Fecha_Registro);
            obj.cedula = pac.Identificacion;
            Reportes.Reporteador frm = new Reportes.Reporteador(null, "Anticipos", null, obj);
            frm.ShowDialog();
            this.Close();

        }
    }
}
