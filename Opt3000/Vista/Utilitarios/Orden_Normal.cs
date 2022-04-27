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
using Opt3000.Entidades;
using Opt3000.Vista.Utilitarios.Reportes;

namespace Opt3000.Vista.Utilitarios
{
    public partial class Orden_Normal : Form
    {
        bool nuevo = false;
        public Int64 ateCodigo = 0;
        public string nombre = "";
        CLIENTE cli = new CLIENTE();
        PACIENTE paciente = new PACIENTE();
        PRODUCTO producto = new PRODUCTO();
        public string identificacion = "";
        bool mensaje = true;
        public Orden_Normal(Int64 _ateCodigo = 0, string _identificacion = "", bool _mensaje = false)
        {
            InitializeComponent();
            txtLaboratorio.Text = "GENERICOS";
            ateCodigo = _ateCodigo;
            identificacion = _identificacion;
            mensaje = _mensaje;
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
                secuencial = NegConsultas.getInstance().RecuperaSecuencial();
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
            if (mensaje == false)
            {
                Orden1 orden = new Orden1();
                orden = NegConsultas.getInstance().RecuperaOrden1(ateCodigo);
                if (orden != null)
                {
                    lblNumeroOrden.Text = "N°: " + orden.ID_ORDEN1;
                    txtEsferaRXod.Text = orden.EsferaDer;
                    txtCilindroRXod.Text = orden.CilindroDer;
                    txtEjeRXod.Text = orden.EjeDer;
                    txtAddRXod.Text = orden.AddDer;
                    txtAltRXod.Text = orden.AltDer;
                    txtDnpRXod.Text = orden.DnpDer;

                    txtEsferaRXoi.Text = orden.EsferaIz;
                    txtCilindroRXoi.Text = orden.CilindroIz;
                    txtEjeRXoi.Text = orden.EjeIz;
                    txtAddRXoi.Text = orden.AddIz;
                    txtAltRXoi.Text = orden.AltIz;
                    txtDnpRXoi.Text = orden.DnpIz;

                    txtMetrica.Text = orden.Mecanica;
                    txtMayor.Text = orden.Mayor;
                    txtHorizontal.Text = orden.Horinzotal;
                    txtVertical.Text = orden.Verical;
                    txtPuente.Text = orden.Puente;

                    txtArmazon.Text = orden.CodArmazon;
                    txtMaterial.Text = orden.Material;
                    txtFiltro.Text = orden.Filtros;
                    txtTinturada.Text = orden.Tinturado;
                    txtObservacion.Text = orden.Observaciones;
                }
                nuevo = true;
                nuevo = true;
            }
            else
            {
                Orden1 orden = new Orden1();
                orden = NegConsultas.getInstance().RecuperaOrden1(ateCodigo);
                if (orden != null)
                {
                    lblNumeroOrden.Text = "N°: " + orden.ID_ORDEN1;
                    txtEsferaRXod.Text = orden.EsferaDer;
                    txtCilindroRXod.Text = orden.CilindroDer;
                    txtEjeRXod.Text = orden.EjeDer;
                    txtAddRXod.Text = orden.AddDer;
                    txtAltRXod.Text = orden.AltDer;
                    txtDnpRXod.Text = orden.DnpDer;

                    txtEsferaRXoi.Text = orden.EsferaIz;
                    txtCilindroRXoi.Text = orden.CilindroIz;
                    txtEjeRXoi.Text = orden.EjeIz;
                    txtAddRXoi.Text = orden.AddIz;
                    txtAltRXoi.Text = orden.AltIz;
                    txtDnpRXoi.Text = orden.DnpIz;
                    if (mensaje == true)
                    {
                        if (MessageBox.Show("Desea Generar una nueva orden de trabajo???", "OPT3000", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        {

                            dt_FechaPedido.Value = orden.FechaPedido;
                            dt_FechaEntrega.Value = orden.FechaEntrega;
                            txtMetrica.Text = orden.Mecanica;
                            txtMayor.Text = orden.Mayor;
                            txtHorizontal.Text = orden.Horinzotal;
                            txtVertical.Text = orden.Verical;
                            txtPuente.Text = orden.Puente;

                            PRODUCTO producto = new PRODUCTO();
                            producto = NegConsultas.getInstance().RecuperaProducto(orden.CodArmazon);
                            txtArmazon.Text = producto.Detalle;
                            txtMaterial.Text = orden.Material;
                            txtFiltro.Text = orden.Filtros;
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
                        dt_FechaPedido.Value = orden.FechaPedido;
                        dt_FechaEntrega.Value = orden.FechaEntrega;
                        txtMetrica.Text = orden.Mecanica;
                        txtMayor.Text = orden.Mayor;
                        txtHorizontal.Text = orden.Horinzotal;
                        txtVertical.Text = orden.Verical;
                        txtPuente.Text = orden.Puente;

                        PRODUCTO producto = new PRODUCTO();
                        producto = NegConsultas.getInstance().RecuperaProducto(orden.CodArmazon);
                        txtArmazon.Text = producto.Detalle;
                        txtMaterial.Text = orden.Material;
                        txtFiltro.Text = orden.Filtros;
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
                Orden1 objOrdenNormal = new Orden1();
                objOrdenNormal.FechaPedido = dt_FechaPedido.Value;
                objOrdenNormal.FechaEntrega = dt_FechaEntrega.Value;
                objOrdenNormal.FechaRegistro = DateTime.Now;
                objOrdenNormal.ID_Usuario = frm1.idUsuario;
                objOrdenNormal.CodPaciente = paciente.ID_PACIENTE;
                objOrdenNormal.EsferaDer = txtEsferaRXod.Text;
                objOrdenNormal.EsferaIz = txtEsferaRXoi.Text;
                objOrdenNormal.CilindroDer = txtCilindroRXod.Text;
                objOrdenNormal.CilindroIz = txtCilindroRXoi.Text;
                objOrdenNormal.EjeDer = txtEjeRXod.Text;
                objOrdenNormal.EjeIz = txtEjeRXoi.Text;
                objOrdenNormal.AddDer = txtAddRXod.Text;
                objOrdenNormal.AddIz = txtAddRXoi.Text;
                objOrdenNormal.AltDer = txtAltRXod.Text;
                objOrdenNormal.AltIz = txtAltRXoi.Text;
                objOrdenNormal.DnpDer = txtDnpRXod.Text;
                objOrdenNormal.DnpIz = txtDnpRXoi.Text;
                objOrdenNormal.Mecanica = txtMetrica.Text;
                objOrdenNormal.Mayor = txtMayor.Text;
                objOrdenNormal.Horinzotal = txtHorizontal.Text;
                objOrdenNormal.Verical = txtVertical.Text;
                objOrdenNormal.Puente = txtPuente.Text;
                objOrdenNormal.CodArmazon = producto.CodProducto;
                objOrdenNormal.Material = txtMaterial.Text;
                objOrdenNormal.Filtros = txtFiltro.Text;
                objOrdenNormal.Tinturado = txtTinturada.Text;
                objOrdenNormal.Observaciones = txtObservacion.Text;

                if (!NegGuarda.getInstance().GuardaOrdenNormal(objOrdenNormal, ateCodigo))
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
            obj.esferaDer = txtEsferaRXod.Text;
            obj.ejeDer = txtEjeRXod.Text;
            obj.cilindroDer = txtCilindroRXod.Text;
            obj.addDer = txtAddRXod.Text;
            obj.altDer = txtAltRXod.Text;
            obj.dnpDer = txtDnpRXod.Text;
            obj.esferaIz = txtEsferaRXoi.Text;
            obj.ejeIz = txtEjeRXoi.Text;
            obj.cilindroIz = txtCilindroRXoi.Text;
            obj.addIz = txtAddRXoi.Text;
            obj.altIz = txtAltRXoi.Text;
            obj.dnpIz = txtDnpRXoi.Text;
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
            Reporteador frm = new Reporteador(obj, "OrdenGeneral");
            frm.Show();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            Vista.Utilitarios.BuscarInventario buscador = new Vista.Utilitarios.BuscarInventario(cli, ateCodigo);
            buscador.ShowDialog();
            producto = NegConsultas.getInstance().RecuperaDetalleOrden(ateCodigo);
            txtArmazon.Text = producto.Detalle;
        }
    }
}
