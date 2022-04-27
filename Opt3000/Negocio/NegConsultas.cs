using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opt3000.BaseDatos;
using Opt3000.Datos;
using Opt3000.Entidades;

namespace Opt3000.Negocio
{
    public class NegConsultas
    {
        #region PATRON SINGLENTON

        private static NegConsultas generico = null;
        private NegConsultas() { }

        public static NegConsultas getInstance()
        {
            if (generico == null)
            {
                generico = new NegConsultas();
            }
            return generico;
        }

        #endregion

        public List<CIE_10> ConsultaCie10()
        {
            try
            {
                return DatConsultas.getInstance().ConsultaCie10();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CONVENIO> ConsultaConvenios()
        {
            try
            {
                return DatConsultas.getInstance().ConsultaConvenios();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Int64 RecuperaSecuencial()
        {
            try
            {
                return DatConsultas.getInstance().RecuperaSecuencial();
            }
            catch (Exception)
            {

               
                throw;
            }
        }

        public Int64 RecuperaSecuencialLejana()
        {
            try
            {
                return DatConsultas.getInstance().RecuperaSecuencialLejana();
            }
            catch (Exception)
            {


                throw;
            }
        }

        public Int64 RecuperaSecuencialVC()
        {
            try
            {
                return DatConsultas.getInstance().RecuperaSecuencialVC();
            }
            catch (Exception)
            {


                throw;
            }
        }

        public Int64 RecuperaSecuencialLentes()
        {
            try
            {
                return DatConsultas.getInstance().RecuperaSecuencialLentes();
            }
            catch (Exception)
            {


                throw;
            }
        }

        public PRODUCTO RecuperaDetalleOrden(Int64 ateCodigo)
        {
            try
            {
                return DatConsultas.getInstance().RecuperaDetalleOrden(ateCodigo);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<TIPO_LENTECONTACTO> ConsultaTipo()
        {
            try
            {
                return DatConsultas.getInstance().ConsultaTipo();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public CONVENIO ConsultaConvenio(int idConvenio)
        {
            try
            {
                return DatConsultas.getInstance().ConsultaConvenio(idConvenio);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PACIENTE CargaPaciente(string cedula)
        {
            try
            {
                return DatConsultas.getInstance().CargaPaciente(cedula);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<PACIENTE> CargaListaPaciente()
        {
            try
            {
                return DatConsultas.getInstance().CargaListaPaciente();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ATENCION> CargaAtenciones(Int64 hc, string tipoAtencion = "", int factura = 0)
        {
            try
            {
                return DatConsultas.getInstance().CargaAtenciones(hc, tipoAtencion, factura);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Int64 MaxAtencion()
        {
            try
            {
                return DatConsultas.getInstance().MaxAtencion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ATENCION CargaAtencion(Int64 ateCodigo)
        {
            try
            {
                return DatConsultas.getInstance().CargaAtencion(ateCodigo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public RETINOSCOPIA_DILATADA CargaRetinoscopia(Int64 ateCodigo, string ojo)
        {
            try
            {
                return DatConsultas.getInstance().CargaRetinoscopia(ateCodigo, ojo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public LENTES_CONTACTO CargaLentes(Int64 ateCodigo, string ojo)
        {
            try
            {
                return DatConsultas.getInstance().CargaLentes(ateCodigo, ojo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public RX_FINAL CargaRxFinal(Int64 ateCodigo, string ojo)
        {
            try
            {
                return DatConsultas.getInstance().CargaRxFinal(ateCodigo, ojo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public USUARIO ConsultaUsuario(string usuario, string pass)
        {
            try
            {
                return DatConsultas.getInstance().ConsultaUsuario(usuario, pass);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public OFTALMOLOGIA ConsultaOftalmologica(Int64 AteCodigo)
        {
            try
            {
                return DatConsultas.getInstance().ConsultaOftalmologica(AteCodigo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ADAPTACION_LENTES ConsultaAdaptacion(Int64 ateCodigo)
        {
            try
            {
                return DatConsultas.getInstance().ConsultaAdaptacion(ateCodigo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public LENTE_PRUEBA ConsultaLentesPrueba(Int64 ateCodigo)
        {
            try
            {
                return DatConsultas.getInstance().ConsultaLentesPrueba(ateCodigo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public LENTE_DEFINITIVO ConsultaLentesDefinitivo(Int64 ateCodigo)
        {
            try
            {
                return DatConsultas.getInstance().ConsultaLentesDefinitivo(ateCodigo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<USUARIO> CargaComboMedico()
        {
            try
            {
                return DatConsultas.getInstance().CargaComboMedico();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public HONRARIOATENCION ConsultaHorarios(int dia, int medico)
        {
            try
            {
                return DatConsultas.getInstance().ConsultaHorarios(dia, medico);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<CONSULTORIO> ConsultaConsultorio()
        {
            try
            {
                return DatConsultas.getInstance().ConsultaConsultorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public MEDICO ConsultaMedico(int medico)
        {
            try
            {
                return DatConsultas.getInstance().ConsultaMedico(medico);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public AGENDA ConsultaAgenda(int medico, DateTime fecha, int hora, int minutos, int dia)
        {
            try
            {
                return DatConsultas.getInstance().ConsultaAgenda(medico, fecha, hora, minutos, dia);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<PRODUCTO> CargaProductos(string esp = "")
        {
            try
            {
                return DatConsultas.getInstance().CargaProductos(esp);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool ConsultaStock(string codProducto, int cantidad)
        {
            try
            {
                return DatConsultas.getInstance().ConsultaStock(codProducto, cantidad);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PRODUCTO Producto(Int64 codPro)
        {
            try
            {
                return DatConsultas.getInstance().Producto(codPro);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public PRODUCTO RecuperaProducto(string codProducto)
        {
            try
            {
                return DatConsultas.getInstance().RecuperaProducto(codProducto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string RecuperaParametro(string detalle)
        {
            try
            {
                return DatConsultas.getInstance().RecuperaParametro(detalle);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<DETALLE> RecuperaCuentaPaciente(Int64 idCuenta)
        {
            try
            {
                return DatConsultas.getInstance().RecuperaCuentaPaciente(idCuenta);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CLIENTE RecuperaCliente(string identificacion)
        {
            try
            {
                return DatConsultas.getInstance().RecuperaCliente(identificacion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ANTICIPOS> CargaAnticipos(Int64 codPac)
        {
            try
            {
                return DatConsultas.getInstance().CargaAnticipos(codPac);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<FORMA_PAGO> CargaFormasPago()
        {
            try
            {
                return DatConsultas.getInstance().CargaFormasPago();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ANTICIPOS RecuperaAnticipo(Int64 cod)
        {
            try
            {
                return DatConsultas.getInstance().RecuperaAnticipo(cod);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TIEMPODIFERIDO RecuperaTiempo(int cod)
        {
            try
            {
                return DatConsultas.getInstance().RecuperaTiempo(cod);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public EMPRESA RecuperaEmpresa()
        {
            try
            {
                return DatConsultas.getInstance().RecuperaEmpresa();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public SUCURSAL RecuperaSucursal(int idSuc)
        {
            try
            {
                return DatConsultas.getInstance().RecuperaSucursal(idSuc);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public CAJA RecuperaCaja(int idSuc)
        {
            try
            {
                return DatConsultas.getInstance().RecuperaCaja(idSuc);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<MEDICO> CargaMedicos()
        {
            try
            {
                return DatConsultas.getInstance().CargaMedicos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<USUARIO> CargaMedicosCombo()
        {
            try
            {
                return DatConsultas.getInstance().CargaMedicosCombo();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public USUARIO RecuperaUsuario(Int32 usuario)
        {
            try
            {
                return DatConsultas.getInstance().RecuperaUsuario(usuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<NIVEL_USUARIO> RecuperaNivelUsuario()
        {
            try
            {
                return DatConsultas.getInstance().RecuperaNivelUsuario();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ESPECIALIDAD> RecuperaEspecialidad()
        {
            try
            {
                return DatConsultas.getInstance().RecuperaEspecialidad();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool RecuperaUsuarioRepetido(string usuario)
        {
            try
            {
                return DatConsultas.getInstance().RecuperaUsuarioRepetido(usuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool RecuperaPasswordRepetido(string password)
        {
            try
            {
                return DatConsultas.getInstance().RecuperaPasswordRepetido(password);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool RecuperaConvenio(string nombre)
        {
            try
            {
                return DatConsultas.getInstance().RecuperaConvenio(nombre);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public USUARIO RecuperaUsuarioPassword(string pass)
        {
            try
            {
                return DatConsultas.getInstance().RecuperaUsuarioPassword(pass);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ORDEN_PEDIDO RecuperaOrden(string factura)
        {
            try
            {
                return DatConsultas.getInstance().RecuperaOrden(factura);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ORDEN_PEDIDO> CargaOrdenes()
        {
            try
            {
                return DatConsultas.getInstance().CargaOrdenes();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<DETALLE_ORDEN> RecuperaProductosOrden(Int64 idOrden)
        {
            try
            {
                return DatConsultas.getInstance().RecuperaProductosOrden(idOrden);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<USUARIO> CargaListaUsuario()
        {
            try
            {
                return DatConsultas.getInstance().CargaListaUsuario();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Int64 AtencionMaximaPaciente(Int64 hc)
        {
            try
            {
                return DatConsultas.getInstance().AtencionMaximaPaciente(hc);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TIPO_PRODUCTO> TipoProducto()
        {
            try
            {
                return DatConsultas.getInstance().TipoProducto();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CONTADOR_PRODUCTOS Contador(int id)
        {
            try
            {
                return DatConsultas.getInstance().Contador(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CuentasAgrupadas> CUENTAS_AGRUPADAS(Int64 codAtencionAgtupada)
        {
            try
            {
                return DatConsultas.getInstance().CUENTAS_AGRUPADAS(codAtencionAgtupada);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CUENTA_PACIENTE> RetornaCuentasAgrupadas(Int64 idAtencion)
        {
            try
            {
                return DatConsultas.getInstance().RetornaCuentasAgrupadas(idAtencion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<DevolucionLista> RecuperaCuentaPacienteDevolucion(Int64 ateCodigo)
        {
            try
            {
                return DatConsultas.getInstance().RecuperaCuentaPacienteDevolucion(ateCodigo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<BANCOS> RecuperaBancos()
        {
            try
            {
                return DatConsultas.getInstance().RecuperaBancos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TIEMPODIFERIDO> RecuperaDiferidos()
        {
            try
            {
                return DatConsultas.getInstance().RecuperaDiferidos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public PACIENTE RecuperaPaciente(Int64 codPac)
        {
            try
            {
                return DatConsultas.getInstance().RecuperaPaciente(codPac);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public FACTURA RecuperaFacturas(string factura)
        {
            try
            {
                return DatConsultas.getInstance().RecuperaFacturas(factura);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<OrdenPendiente> CargaOrdenNormal()
        {
            try
            {
                return DatConsultas.getInstance().CargaOrdenNormal();
            }
            catch (Exception)
            {

                throw;
            }
        }
        //public static void actualizaOrdenes(bool generado, bool enviado, bool recibido, bool entregado,int codigo)
        //{
        //    try
        //    {
        //        new DatConsultas().ordenes1modificar(generado, enviado, recibido, entregado, codigo);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        public static void actualizaOrdenes(bool generado, bool enviado, bool recibido, bool entregado, int codigo) =>

            DatConsultas.getInstance().ordenes1modificar(generado, enviado, recibido, entregado, codigo);

        public List<Orden1> RecuperaOrden1Paciente(Int64 ateCodigo)
        {
            try
            {
                return DatConsultas.getInstance().RecuperaOrden1Paciente(ateCodigo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Orden1 RecuperaOrden1 (Int64 ateCodigo)
        {
            try
            {
                return DatConsultas.getInstance().RecuperaOrden1(ateCodigo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ORDEN_LEJANA RecuperaOrdenLejana(Int64 ateCodigo)
        {
            try
            {
                return DatConsultas.getInstance().RecuperaOrdenLejana(ateCodigo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ORDEN_LENTESBLANDOS RecuperaOrdenLentesBlandos(Int64 ateCodigo)
        {
            try
            {
                return DatConsultas.getInstance().RecuperaOrdenLentesBlandos(ateCodigo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ORDEN_VISION_CERCA RecuperaOrdenVC(Int64 ateCodigo)
        {
            try
            {
                return DatConsultas.getInstance().RecuperaOrdenVC(ateCodigo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ORDEN_VISION_CERCA RecuperaOrdenVC2(Int64 ateCodigo)
        {
            try
            {
                return DatConsultas.getInstance().RecuperaOrdenVC2(ateCodigo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ORDEN_LEJANA RecuperaOrdenLejana2(Int64 ateCodigo)
        {
            try
            {
                return DatConsultas.getInstance().RecuperaOrdenLejana2(ateCodigo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ORDEN_LENTESBLANDOS RecuperaOrdenLentesBlandos2(Int64 ateCodigo)
        {
            try
            {
                return DatConsultas.getInstance().RecuperaOrdenLentesBlandos2(ateCodigo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Orden1 RecuperaOrden2(Int64 ateCodigo)
        {
            try
            {
                return DatConsultas.getInstance().RecuperaOrden2(ateCodigo);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
