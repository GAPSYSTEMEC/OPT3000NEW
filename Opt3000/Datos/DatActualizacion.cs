using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Opt3000.BaseDatos;


namespace Opt3000.Datos
{
    class DatActualizacion
    {

        #region PATRON SINGLENTON

        private static DatActualizacion generico = null;
        private DatActualizacion() { }

        public static DatActualizacion getInstance()
        {
            if (generico == null)
            {
                generico = new DatActualizacion();
            }
            return generico;
        }

        #endregion

        public bool ModificaStock(Int64 codPro, Int32 cantidad)
        {
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    PRODUCTO pro = contexto.PRODUCTO.FirstOrDefault(p => p.ID_PRODUCTO == codPro);
                    pro.STOCK -= cantidad;
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ModificaCliente(CLIENTE cliente)
        {
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    CLIENTE cli = contexto.CLIENTE.FirstOrDefault(c => c.Identificacion == cliente.Identificacion);
                    cli.Nombre = cliente.Nombre;
                    cli.Apellidos = cliente.Apellidos;
                    cli.Direccion = cliente.Direccion;
                    cli.Telefono = cliente.Telefono;
                    cli.Email = cliente.Email;
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ModificaAnticipo(ANTICIPOS anticipo)
        {
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    ANTICIPOS anti = contexto.ANTICIPOS.FirstOrDefault(a => a.ID_PACIENTE == anticipo.ID_PACIENTE);
                    anti.ID_PACIENTE = anticipo.ID_PACIENTE;
                    anti.Detalle = anticipo.Detalle;
                    anti.Valor = anticipo.Valor;
                    anti.Saldo = anticipo.Saldo;
                    contexto.SaveChanges();
                    return true;
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    HONRARIOATENCION hora = contexto.HONRARIOATENCION.FirstOrDefault(h => h.ID_DIASATENCION == horario.ID_DIASATENCION);
                    hora.ID_CONSULTORIO = horario.ID_CONSULTORIO;
                    hora.ID_DIA = horario.ID_DIA;
                    hora.HoraInicio = horario.HoraInicio;
                    hora.HoraFin = horario.HoraFin;
                    hora.HoraAlmuerzo = horario.HoraAlmuerzo;
                    hora.Intervalo = horario.Intervalo;
                    contexto.SaveChanges();
                    return true;
                }
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
                using (TransactionScope tranScope = new TransactionScope())
                {
                    using (var contexto = new Opt3000Entities())
                    {
                        var elimina = contexto.DETALLE_ORDEN.SingleOrDefault(o => o.ID_ORDEN == orden);
                        if (elimina != null)
                        {
                            contexto.DETALLE_ORDEN.Remove(elimina);
                            contexto.SaveChanges();
                        }
                        foreach (var item in lista)
                        {
                            contexto.DETALLE_ORDEN.Add(item);
                            contexto.SaveChanges();

                            if (estado)
                            {
                                PRODUCTO objProducto = new PRODUCTO();
                                objProducto.Detalle = item.Nombre;
                                objProducto.Precio = item.Costo + ((item.Costo * item.Ganacia) / 100);
                                objProducto.PagaIva = item.PagaIva;
                                objProducto.Especificaciones = item.Tipo;
                                objProducto.STOCK = item.Cantidad;

                                contexto.PRODUCTO.Add(objProducto);
                                contexto.SaveChanges();
                            }
                        }
                        tranScope.Complete();
                        return true;
                    }
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    CONTADOR_PRODUCTOS conta = contexto.CONTADOR_PRODUCTOS.FirstOrDefault(c => c.ID_TIPOPRODUCTO == obj.ID_TIPOPRODUCTO);
                    conta.Contador = obj.Contador;
                    contexto.SaveChanges();
                    return true;
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    CUENTA_PACIENTE cuenta = contexto.CUENTA_PACIENTE.FirstOrDefault(c => c.ID_ATENCION == ateCodigo);
                    cuenta.ID_ATENCION = ateCodigoActual;
                    contexto.SaveChanges();
                    return true;
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    DETALLE detalle = contexto.DETALLE.FirstOrDefault(d => d.ID_DETALLE == idDetalle);
                    detalle.Cantidad -= cantidad;
                    contexto.SaveChanges();
                    PRODUCTO producto = contexto.PRODUCTO.FirstOrDefault(p => p.ID_PRODUCTO == idProducto);
                    if (producto.Especificaciones == "B")
                    {
                        producto.STOCK += Convert.ToInt16(cantidad);
                        contexto.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
