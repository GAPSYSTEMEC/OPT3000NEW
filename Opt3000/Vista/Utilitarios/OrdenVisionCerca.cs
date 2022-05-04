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
using Opt3000.Vista.Utilitarios.Reportes;

namespace Opt3000.Vista.Utilitarios
{
    public partial class OrdenVisionCerca : Form
    {
        string lblAtencion = "";
        CLIENTE cli = new CLIENTE();
        PRODUCTO producto = new PRODUCTO();
        PACIENTE paciente = new PACIENTE();
        bool nuevo = false;
        public Int64 ateCodigo = 0;
        public string nombre = "";
        public string identificacion = "";
        bool mensaje = true;
        public OrdenVisionCerca(Int64 _ateCodigo = 0, string _identificacion = "", bool _mensaje = false, string _lblAtencion = "")
        {
            InitializeComponent();
            txtLaboratorio.Text = "GENERICOS";
            ateCodigo = _ateCodigo;
            identificacion = _identificacion;
            mensaje = _mensaje;
            lblAtencion = _lblAtencion;
            if (ateCodigo != 0)
            {
                CargaPaciente();
                CargaDatos();
                CargaSecuencial();
                btnBusca.Visible = false;
                btnGuardar.Visible = true;
                btnCancelar.Visible = true;
            }
        }

        public void CargaSecuencial()
        {
            Int64 secuencial = 0;
            try
            {
                secuencial = NegConsultas.getInstance().RecuperaSecuencialVC();
            }
            catch
            {
            }
            if (nuevo)
            {
                secuencial += 1;
                lblNumeroOrden.Text = "N°: " + secuencial.ToString();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (FuncionesBasicas.getInstance().CerrarFormulario("LA ORDEN DE MEDIDAS PROGRESIVO O BIFOCAL"))
                this.Close();
        }

        public void CargaPaciente()
        {
            paciente = NegConsultas.getInstance().CargaPaciente(identificacion);
            txtNombrePaciente.Text = paciente.Nombres + " " + paciente.Apellidos;
            cli.Nombre = paciente.Nombres;
            cli.Apellidos = paciente.Apellidos;
            cli.Identificacion = paciente.Identificacion;
            cli.Direccion = paciente.Direccion;
            cli.Telefono = paciente.Celular;
            cli.Email = paciente.Email;
        }



        public void CargaDatos()
        {
            Int64 ordenN = NegConsultas.getInstance().MaxOrdenVC();
            lblNumeroOrden.Text = "N°: " + (ordenN + 1);
            if (mensaje == false)
            {
                RX_FINAL orden = new RX_FINAL();
                if (orden != null)
                {
                    orden = NegConsultas.getInstance().CargaRxFinal(Convert.ToInt64(lblAtencion), "D");
                    txtEsferaVCod.Text = orden.Esfera;
                    txtCilindroVCod.Text = orden.Cilindro;
                    txtEjeVCod.Text = orden.Eje;
                    txtAvcVCod.Text = orden.A_D_D;
                    txtDnpVCod.Text = orden.DNP_DP;


                    if (orden.A_D_D != "")
                    {
                        txtEsferaVCod.Text = (Convert.ToDecimal(orden.Esfera) + Convert.ToDecimal(orden.A_D_D)).ToString();
                        if (Convert.ToDecimal(txtEsferaVCod.Text) > 0)
                        {
                            txtEsferaVCod.Text = "+" + txtEsferaVCod.Text;
                        }
                    }


                    orden = NegConsultas.getInstance().CargaRxFinal(Convert.ToInt64(lblAtencion), "I");
                    txtEsferaVCoi.Text = orden.Esfera;
                    txtCilindroVCoi.Text = orden.Cilindro;
                    txtEjeVCoi.Text = orden.Eje;
                    txtAvcVCoi.Text = orden.A_D_D;
                    txtDnpVCoi.Text = orden.DNP_DP;

                    if (orden.A_D_D != "")
                    {
                        txtEsferaVCoi.Text = (Convert.ToDecimal(orden.Esfera) + Convert.ToDecimal(orden.A_D_D)).ToString();
                        if (Convert.ToDecimal(txtEsferaVCoi.Text) > 0)
                        {
                            txtEsferaVCoi.Text = "+" + txtEsferaVCoi.Text;
                        }
                    }
                }
                nuevo = true;
            }
            else
            {
                ORDEN_VISION_CERCA orden = new ORDEN_VISION_CERCA();
                orden = NegConsultas.getInstance().RecuperaOrdenVC(ateCodigo);
                if (orden != null)
                {
                    lblNumeroOrden.Text = "N°: " + orden.ID_ORDEN2;
                    txtEsferaVCod.Text = orden.EsferaDer;
                    txtCilindroVCod.Text = orden.CilindroDer;
                    txtEjeVCod.Text = orden.EjeDer;
                    txtAvcVCod.Text = orden.AvccDer;
                    txtDnpVCod.Text = orden.DnpDer;

                    txtEsferaVCoi.Text = orden.EsferaIz;
                    txtCilindroVCoi.Text = orden.CilindroIz;
                    txtEjeVCoi.Text = orden.EjeIz;
                    txtAvcVCoi.Text = orden.AvccIz;
                    txtDnpVCoi.Text = orden.DnpIz;
                    if (mensaje == true)
                    {
                        if (MessageBox.Show("Desea Generar una nueva orden de trabajo???", "OPT3000", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        {

                            dt_FechaPedido.Value = orden.FechaPedio;
                            dt_FechaEntrega.Value = orden.FechaEntrega;
                            txtMetrica.Text = orden.Metrica;
                            txtMayor.Text = orden.Mayor;
                            txtHorizontal.Text = orden.Horizontal;
                            txtVertical.Text = orden.Vertical;
                            txtPuente.Text = orden.Puente;

                            PRODUCTO producto = new PRODUCTO();
                            producto = NegConsultas.getInstance().RecuperaProducto(orden.CodArmazon);
                            txtArmazon.Text = producto.Detalle;
                            producto = NegConsultas.getInstance().RecuperaProducto(orden.Material);
                            txtMaterial.Text = producto.Detalle;
                            producto = NegConsultas.getInstance().RecuperaProducto(orden.Filtros);
                            txtFiltro.Text = producto.Detalle;
                            txtTinturada.Text = orden.Tinturado;
                            txtObservacion.Text = orden.Observaciones;
                        }
                        else
                        {
                            nuevo = true;
                        }
                    }
                    else
                    {
                        dt_FechaPedido.Value = orden.FechaPedio;
                        dt_FechaEntrega.Value = orden.FechaEntrega;
                        txtMetrica.Text = orden.Metrica;
                        txtMayor.Text = orden.Mayor;
                        txtHorizontal.Text = orden.Horizontal;
                        txtVertical.Text = orden.Vertical;
                        txtPuente.Text = orden.Puente;

                        PRODUCTO producto = new PRODUCTO();
                        producto = NegConsultas.getInstance().RecuperaProducto(orden.CodArmazon);
                        txtArmazon.Text = producto.Detalle;
                        producto = NegConsultas.getInstance().RecuperaProducto(orden.Material);
                        txtMaterial.Text = producto.Detalle;
                        producto = NegConsultas.getInstance().RecuperaProducto(orden.Filtros);
                        txtFiltro.Text = producto.Detalle;
                        txtTinturada.Text = orden.Tinturado;
                        txtObservacion.Text = orden.Observaciones;
                    }
                }
                else
                {
                    nuevo = true;
                }
            }
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            BuscadorPacientes frmBuscador = new BuscadorPacientes();
            frmBuscador.ShowDialog();
            identificacion = frmBuscador.cedula;
            CargaPaciente();
            PACIENTE objPaciente = new PACIENTE();
            objPaciente = NegConsultas.getInstance().CargaPaciente(frmBuscador.cedula);
            List<ATENCION> lista = new List<ATENCION>();
            lista = NegConsultas.getInstance().CargaAtenciones(objPaciente.ID_PACIENTE, "NORMAL");
            if (lista.Count > 0)
            {
                BuscadorAtencion frmBuscaAtencion = new BuscadorAtencion(objPaciente.ID_PACIENTE, "NORMAL");
                frmBuscaAtencion.ShowDialog();
                ateCodigo = Convert.ToInt64(frmBuscaAtencion.ateCodigo);
                CargaDatos();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Password frm1 = new Password();
            frm1.ShowDialog();
            if (frm1.idUsuario == 0)
            {
                return;
            }
            if (nuevo)
            {
                ORDEN_VISION_CERCA objOrdenNormal = new ORDEN_VISION_CERCA();
                objOrdenNormal.FechaPedio = dt_FechaPedido.Value;
                objOrdenNormal.FechaEntrega = dt_FechaEntrega.Value;
                objOrdenNormal.FechaRegistro = DateTime.Now;
                objOrdenNormal.Id_Usuario = frm1.idUsuario;
                objOrdenNormal.CodPaciente = paciente.ID_PACIENTE;
                objOrdenNormal.EsferaDer = txtEsferaVCod.Text;
                objOrdenNormal.EsferaIz = txtEsferaVCoi.Text;
                objOrdenNormal.CilindroDer = txtCilindroVCod.Text;
                objOrdenNormal.CilindroIz = txtCilindroVCoi.Text;
                objOrdenNormal.EjeDer = txtEjeVCod.Text;
                objOrdenNormal.EjeIz = txtEjeVCoi.Text;
                objOrdenNormal.DnpDer = txtDnpVCod.Text;
                objOrdenNormal.DnpIz = txtDnpVCoi.Text;
                objOrdenNormal.AvccDer = txtAvcVCod.Text;
                objOrdenNormal.AvccIz = txtAvcVCod.Text;
                objOrdenNormal.Metrica = txtMetrica.Text;
                objOrdenNormal.Mayor = txtMayor.Text;
                objOrdenNormal.Horizontal = txtHorizontal.Text;
                objOrdenNormal.Vertical = txtVertical.Text;
                objOrdenNormal.Puente = txtPuente.Text;
                objOrdenNormal.CodArmazon = armazon;
                objOrdenNormal.Material = lunas;
                objOrdenNormal.Filtros = filtro;
                objOrdenNormal.Tinturado = txtTinturada.Text;
                objOrdenNormal.Observaciones = txtObservacion.Text;

                if (!NegGuarda.getInstance().GuardaOrdenVC(objOrdenNormal, ateCodigo))
                {
                    MessageBox.Show("La orden no se pudo generar vuelva a intentar", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            OrdenGeneral obj = new OrdenGeneral();
            obj.numOrden = lblNumeroOrden.Text;
            obj.imagen = "";
            obj.laboratorio = txtLaboratorio.Text;
            obj.paciente = txtNombrePaciente.Text;
            obj.fechaPedido = dt_FechaPedido.Value.Date.ToString("dd-MM-yyyy");
            obj.fechaEntrega = dt_FechaEntrega.Value.Date.ToString("dd-MM-yyyy");
            obj.esferaDer = txtEsferaVCod.Text;
            obj.ejeDer = txtEjeVCod.Text;
            obj.cilindroDer = txtCilindroVCod.Text;

            obj.dnpDer = txtDnpVCod.Text;
            obj.altDer = txtAvcVCod.Text;
            obj.esferaIz = txtEsferaVCoi.Text;
            obj.ejeIz = txtEjeVCoi.Text;
            obj.cilindroIz = txtCilindroVCoi.Text;

            obj.altIz = txtAvcVCoi.Text;
            obj.dnpIz = txtDnpVCoi.Text;
            obj.metrica = txtMetrica.Text;
            obj.mayor = txtMayor.Text;
            obj.horizontal = txtHorizontal.Text;
            obj.vertical = txtVertical.Text;
            obj.puente = txtPuente.Text;
            obj.armazon = txtArmazon.Text;
            obj.material = txtMaterial.Text;
            obj.filtros = txtFiltro.Text;
            obj.tinturado = txtTinturada.Text;
            obj.observaciones = txtObservacion.Text;
            obj.pedidoPor = frm1.usuario;
            Reporteador frm = new Reporteador(obj, "VisionCerca");
            frm.Show();
        }

        private void OrdenVisionCerca_Load(object sender, EventArgs e)
        {

        }
        string armazon = "";
        string lunas = "";
        string filtro = "";

        private void btnInventario_Click(object sender, EventArgs e)
        {
            try
            {
                Vista.Utilitarios.BuscarInventario buscador = new Vista.Utilitarios.BuscarInventario(cli, Convert.ToInt64(lblAtencion));
                buscador.ShowDialog();
                producto = NegConsultas.getInstance().RecuperaDetalleOrden(Convert.ToInt64(lblAtencion));
                txtArmazon.Text = producto.Detalle;
                armazon = producto.CodProducto;
            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Vista.Utilitarios.BuscarInventario buscador = new Vista.Utilitarios.BuscarInventario(cli, Convert.ToInt64(lblAtencion), false, "LU");
                buscador.ShowDialog();
                producto = NegConsultas.getInstance().RecuperaDetalleOrden(Convert.ToInt64(lblAtencion));
                txtMaterial.Text = producto.Detalle;
                lunas = producto.CodProducto;
            }
            catch
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Vista.Utilitarios.BuscarInventario buscador = new Vista.Utilitarios.BuscarInventario(cli, Convert.ToInt64(lblAtencion), false, "FI");
                buscador.ShowDialog();
                producto = NegConsultas.getInstance().RecuperaDetalleOrden(Convert.ToInt64(lblAtencion));
                txtFiltro.Text = producto.Detalle;
                filtro = producto.CodProducto;
            }
            catch
            {
            }
        }
    }
}
