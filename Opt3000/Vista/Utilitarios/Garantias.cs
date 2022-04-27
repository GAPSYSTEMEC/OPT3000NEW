using Opt3000.BaseDatos;
using Opt3000.Negocio;
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
    public partial class Garantias : Form
    {
        FACTURA factura = new FACTURA();
        ATENCION atencion = new ATENCION();
        PACIENTE paciente = new PACIENTE();
        DataTable porCargar = new DataTable();
        List<TIPO_PRODUCTO> lista = new List<TIPO_PRODUCTO>();
        Int64[,] matris = new long[10, 2];
        public Garantias()
        {
            InitializeComponent();
            CargaTipoProducto();
            int conta = 0;
            foreach (var item in lista)
            {
                CONTADOR_PRODUCTOS obj = new CONTADOR_PRODUCTOS();
                obj = NegConsultas.getInstance().Contador(item.ID_TIPOPRODUCTO);
                matris[conta, 0] = item.ID_TIPOPRODUCTO;
                matris[conta, 1] = obj.Contador;
                conta++;
            }
        }
        public void CargaTipoProducto()
        {
            lista = NegConsultas.getInstance().TipoProducto();

            cmb_TipoProduc.DataSource = lista;
            cmb_TipoProduc.ValueMember = "ID_TIPOPRODUCTO";
            cmb_TipoProduc.DisplayMember = "Detalle";
            cmb_TipoProduc.SelectedText = "";
            cmb_TipoProduc.SelectedIndex = -1;
        }

        private void cmb_TipoProduc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_TipoProduc.SelectedValue != null && cmb_TipoProduc.Text != "Opt3000.BaseDatos.TIPO_PRODUCTO")
            {
                int conta = 0;
                foreach (var item in lista)
                {
                    if (item.ID_TIPOPRODUCTO == Convert.ToInt16(cmb_TipoProduc.SelectedValue.ToString()))
                    {
                        string inicio = cmb_TipoProduc.Text.Substring(0, 2);
                        int max = Convert.ToInt16(matris[conta, 1]);
                        txtCodigo.Text = inicio + max;
                    }
                    conta++;
                }
            }
        }

        private void txtFactura_Leave(object sender, EventArgs e)
        {
            if (txtFactura.Text.Length == 12)
            {
                factura = NegConsultas.getInstance().RecuperaFacturas(txtFactura.Text);
                atencion = NegConsultas.getInstance().CargaAtencion(factura.ID_ATENCION);
                paciente = NegConsultas.getInstance().RecuperaPaciente(atencion.ID_PACIENTE);

                txtFecha.Text = Convert.ToString(factura.Fecha_Emision);
                txtCedulaPaciente.Text = paciente.Identificacion;
                txtAtencion.Text = atencion.ID_ATENCION.ToString();
                txtPaciente.Text = paciente.Nombres + " " + paciente.Apellidos;
            }
            else
            {
                MessageBox.Show("El número de factura no es el correcto", "Opt3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCarga_Click(object sender, EventArgs e)
        {
            if (ValidaCampos())
            {
                GARANTIA garantia = new GARANTIA();
                garantia.ID_ATENCION = atencion.ID_ATENCION;
                garantia.ID_FACTURA = factura.ID_FACTURA;
                garantia.DetalleGarantia = txtComentario.Text;
                garantia.Cod_Producto = txtCodigo.Text;
                garantia.Detalle_Producto = txtDetalle.Text;
                garantia.Valor_Producto = Convert.ToDecimal(txtCosto.Text);
                garantia.Cantidad_Producto = Convert.ToInt16(txtCantidad.Text);
                if (NegGuarda.getInstance().GuardaGarantia(garantia))
                {
                    MessageBox.Show("Garantia GENERADA con exito", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Entidades.Garantias gar = new Entidades.Garantias();
                    gar.numFactura = txtFactura.Text;
                    gar.fechaFactura = txtFecha.Text;
                    gar.identificacion = txtCedulaPaciente.Text;
                    gar.atePac = Convert.ToString(atencion.ID_ATENCION);
                    gar.paciente = txtPaciente.Text;
                    gar.detalle = txtDetalle.Text;
                    gar.codigo = txtCodigo.Text;
                    gar.cantidad = txtCantidad.Text;
                    gar.pvp = txtCosto.Text;
                    gar.comentario = txtComentario.Text + "\n GARANTIA 100% CUBIERTA NO HAY OPCIÓN A NUEVA GARANTIA";

                    Utilitarios.Reportes.Reporteador frm = new Utilitarios.Reportes.Reporteador(null, "Garantias", null, null, gar);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Base de datos sin acceso revise información y vuelva a intentar", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ValidaCampos()
        {
            bool ok = true;


            return ok;
        }
    }
}
