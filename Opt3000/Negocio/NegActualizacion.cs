using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opt3000.Datos;
using Opt3000.BaseDatos;

namespace Opt3000.Negocio
{
    class NegActualizacion
    {

        #region PATRON SINGLENTON

        private static NegActualizacion generico = null;
        private NegActualizacion() { }

        public static NegActualizacion getInstance()
        {
            if (generico == null)
            {
                generico = new NegActualizacion();
            }
            return generico;
        }

        #endregion

        public bool ModificaStock(Int64 codPro, Int32 cantidad)
        {
            try
            {
                return DatActualizacion.getInstance().ModificaStock(codPro, cantidad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ModificaHorarios(HONRARIOATENCION horario)
        {
            try
            {
                return DatActualizacion.getInstance().ModificaHorarios(horario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ActualizaDetallePedidos(List<DETALLE_ORDEN> lista, Int64 orden, bool estado)
        {
            try
            {
                return DatActualizacion.getInstance().ActualizaDetallePedidos(lista, orden, estado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ActualizaCodigo(CONTADOR_PRODUCTOS obj)
        {
            try
            {
                return DatActualizacion.getInstance().ActualizaCodigo(obj);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ActualizaAgrupacion(Int64 ateCodigo, Int64 ateCodigoActual)
        {
            try
            {
                return DatActualizacion.getInstance().ActualizaAgrupacion(ateCodigo, ateCodigoActual);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DevuelveProducto(Int64 idProducto, Int64 idDetalle, decimal cantidad)
        {
            try
            {
                return DatActualizacion.getInstance().DevuelveProducto(idProducto, idDetalle, cantidad);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}