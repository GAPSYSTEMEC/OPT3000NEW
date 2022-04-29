using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opt3000.Datos;
using Opt3000.BaseDatos;

namespace Opt3000.Negocio
{
    public class NegGuarda
    {
        #region PATRON SINGLENTON

        private static NegGuarda generico = null;
        private NegGuarda() { }

        public static NegGuarda getInstance()
        {
            if (generico == null)
            {
                generico = new NegGuarda();
            }
            return generico;
        }

        #endregion

        public int GuardaPaciente(PACIENTE objPaciente)
        {
            try
            {
                return DatGuarda.getInstance().GuardaPaciente(objPaciente);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool GuardaOrdenNormal(Orden1 orden, Int64 atencion)
        {
            try
            {
                return DatGuarda.getInstance().GuardaOrdenNormal(orden, atencion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardaOrdenVC(ORDEN_VISION_CERCA orden, Int64 atencion)
        {
            try
            {
                return DatGuarda.getInstance().GuardaOrdenVC(orden, atencion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardaOrdenLejana(ORDEN_LEJANA orden, Int64 atencion)
        {
            try
            {
                return DatGuarda.getInstance().GuardaOrdenLejana(orden, atencion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardaOrdenLentesBlandos(ORDEN_LENTESBLANDOS orden, Int64 atencion)
        {
            try
            {
                return DatGuarda.getInstance().GuardaOrdenLentesBlandos(orden, atencion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardaAtencion(ATENCION objAtencion, List<RETINOSCOPIA_DILATADA> objRetinoscopia, List<LENTES_CONTACTO> objLentes, List<RX_FINAL> objRx, OFTALMOLOGIA objOftalmica, ADAPTACION_LENTES objAdaptacion, LENTE_PRUEBA objPrueba, LENTE_DEFINITIVO objDefinitivo, Orden1 objOrdenNormal = null)
        {
            try
            {
                return DatGuarda.getInstance().GuardaAtencion(objAtencion, objRetinoscopia, objLentes, objRx, objOftalmica, objAdaptacion, objPrueba, objDefinitivo, objOrdenNormal);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int GuardaAgenda(int medico, int dia, AGENDA objAgenda)
        {
            try
            {
                return DatGuarda.getInstance().GuardaAgenda(medico, dia, objAgenda);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Int64 GuardaCliente(CLIENTE obj)
        {
            try
            {
                return DatGuarda.getInstance().GuardaCliente(obj);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Int64 GuardaCuentaPaciente(CUENTA_PACIENTE obj)
        {
            try
            {
                return DatGuarda.getInstance().GuardaCuentaPaciente(obj);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Int64 GuardaCuentaPacienteAgrupada(CUENTA_PACIENTE obj)
        {
            try
            {
                return DatGuarda.getInstance().GuardaCuentaPacienteAgrupada(obj);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool GuardaDetalle(DETALLE det)
        {
            try
            {
                return DatGuarda.getInstance().GuardaDetalle(det);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool GuardaFactura(CLIENTE cliente, List<ANTICIPOS> anticipo, List<FACTURA_PAGO> facturaPago, FACTURA factura, CAJA caja)
        {
            try
            {
                return DatGuarda.getInstance().GuardaFactura(cliente, anticipo, facturaPago, factura, caja);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardaAnticipo(ANTICIPOS anticipo)
        {
            try
            {
                return DatGuarda.getInstance().GuardaAnticipo(anticipo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardaUsuario(MEDICO med, USUARIO usu)
        {
            try
            {
                return DatGuarda.getInstance().GuardaUsuario(med, usu);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardaConvenio(CONVENIO convenio)
        {
            try
            {
                return DatGuarda.getInstance().GuardaConvenio(convenio);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardaHorarios(HONRARIOATENCION horario)
        {
            try
            {
                return DatGuarda.getInstance().GuardaHorarios(horario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardaOrden(ORDEN_PEDIDO orden, List<DETALLE_ORDEN> lista, Int64[,] matris)
        {
            try
            {
                return DatGuarda.getInstance().GuardaOrden(orden, lista, matris);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardaBanco(BANCOS obj)
        {
            try
            {
                return DatGuarda.getInstance().GuardaBanco(obj);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool GuardaDiferido(TIEMPODIFERIDO obj)
        {
            try
            {
                return DatGuarda.getInstance().GuardaDiferido(obj);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardaProducto(PRODUCTO obj)
        {
            try
            {
                return DatGuarda.getInstance().GuardaProducto(obj);
            }
            catch (Exception err)
            {

                throw err;
            }
        }

        public bool GuardaGarantia(GARANTIA garantia)
        {
            try
            {
                return DatGuarda.getInstance().GuardaGarantia(garantia);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DivideCuenta(Int64 ateCodigo, decimal valor1, decimal valor2, decimal iva)
        {
            try
            {
                return DatGuarda.getInstance().DivideCuenta(ateCodigo, valor1, valor2, iva);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
