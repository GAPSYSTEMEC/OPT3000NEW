using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Opt3000.BaseDatos;

namespace Opt3000.Datos
{
    public class DatGuarda
    {
        #region PATRON SINGLENTON

        private static DatGuarda generico = null;
        private DatGuarda() { }

        public static DatGuarda getInstance()
        {
            if (generico == null)
            {
                generico = new DatGuarda();
            }
            return generico;
        }

        #endregion

        public int GuardaPaciente(PACIENTE objPaciente)
        {
            try
            {
                PACIENTE atencion = new PACIENTE();
                using (var contexto = new Opt3000Entities())
                {

                    if (objPaciente.Identificacion == "")
                    {
                        Int64 hc = (from p in contexto.PACIENTE
                                    select p.ID_PACIENTE).Max();
                        objPaciente.Identificacion = (hc + 1).ToString();
                    }
                    atencion = contexto.PACIENTE.FirstOrDefault(a => a.Identificacion == objPaciente.Identificacion);
                    if (atencion == null)
                    {
                        contexto.PACIENTE.Add(objPaciente);
                        contexto.SaveChanges();
                        return 1;
                    }
                    else
                    {
                        atencion.Nombres = objPaciente.Nombres;
                        atencion.Apellidos = objPaciente.Apellidos;
                        atencion.Direccion = objPaciente.Direccion;
                        atencion.Celular = objPaciente.Celular;
                        atencion.Convencional = objPaciente.Convencional;
                        atencion.Email = objPaciente.Email;
                        atencion.F_Nacimiento = objPaciente.F_Nacimiento;
                        atencion.Ocupacion = objPaciente.Ocupacion;
                        contexto.SaveChanges();
                        return 2;
                    }
                }
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }

        public bool GuardaOrdenNormal(Orden1 objOrdenNormal, Int64 atencion)
        {
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    objOrdenNormal.AteCodigo = atencion;
                    objOrdenNormal.GENERADO = true;
                    objOrdenNormal.enviado = false;
                    objOrdenNormal.RECIBIDO = false;
                    objOrdenNormal.ENTREGADO = false;
                    contexto.Orden1.Add(objOrdenNormal);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardaOrdenVC(ORDEN_VISION_CERCA objOrdenNormal, Int64 atencion)
        {
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    objOrdenNormal.AteCodigo = atencion;
                    objOrdenNormal.Generado = true;
                    objOrdenNormal.Enviado = false;
                    objOrdenNormal.Recibido = false;
                    objOrdenNormal.Entregado = false;
                    contexto.ORDEN_VISION_CERCA.Add(objOrdenNormal);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardaOrdenLejana(ORDEN_LEJANA objOrdenNormal, Int64 atencion)
        {
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    objOrdenNormal.AteCodigo = atencion;
                    objOrdenNormal.Generado = true;
                    objOrdenNormal.Enviado = false;
                    objOrdenNormal.Recibido = false;
                    objOrdenNormal.Entregado = false;
                    contexto.ORDEN_LEJANA.Add(objOrdenNormal);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardaOrdenLentesBlandos(ORDEN_LENTESBLANDOS objOrdenNormal, Int64 atencion)
        {
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    objOrdenNormal.AteCodigo = atencion;
                    objOrdenNormal.Generado = true;
                    objOrdenNormal.Enviado = false;
                    objOrdenNormal.Recibido = false;
                    objOrdenNormal.Entregado = false;
                    objOrdenNormal.TipoDer = "";
                    objOrdenNormal.TipoIz = "";
                    contexto.ORDEN_LENTESBLANDOS.Add(objOrdenNormal);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardaAtencion(ATENCION objAtencion, List<RETINOSCOPIA_DILATADA> objRetinoscopia, List<LENTES_CONTACTO> objLentes, List<RX_FINAL> objRx, OFTALMOLOGIA objOftalmologia, ADAPTACION_LENTES objAdaptacion, LENTE_PRUEBA objPrueba, LENTE_DEFINITIVO objDefinitivo, Orden1 objOrdenNormal = null)
        {
            try
            {
                using (TransactionScope tranScope = new TransactionScope())
                {
                    using (var contexto = new Opt3000Entities())
                    {
                        contexto.ATENCION.Add(objAtencion);
                        contexto.SaveChanges();

                        Int64 atencion = (from a in contexto.ATENCION
                                          where a.ID_PACIENTE == objAtencion.ID_PACIENTE
                                          select a.ID_ATENCION).Max();

                        if (objOftalmologia != null)
                        {
                            objOftalmologia.ID_ATENCION = atencion;
                            contexto.OFTALMOLOGIA.Add(objOftalmologia);
                            contexto.SaveChanges();
                        }
                        foreach (var item in objRetinoscopia)
                        {
                            item.ID_ATENCION = atencion;
                            contexto.RETINOSCOPIA_DILATADA.Add(item);
                            contexto.SaveChanges();
                        }
                        foreach (var item in objLentes)
                        {
                            item.ID_ATENCION = atencion;
                            contexto.LENTES_CONTACTO.Add(item);
                            contexto.SaveChanges();
                        }
                        foreach (var item in objRx)
                        {
                            item.ID_ATENCION = atencion;
                            contexto.RX_FINAL.Add(item);
                            contexto.SaveChanges();
                        }
                        if (objOrdenNormal != null)
                        {
                            objOrdenNormal.AteCodigo = atencion;
                            objOrdenNormal.GENERADO = true;
                            objOrdenNormal.enviado = false;
                            objOrdenNormal.RECIBIDO = false;
                            objOrdenNormal.ENTREGADO = false;
                            contexto.Orden1.Add(objOrdenNormal);
                            contexto.SaveChanges();
                        }
                        //if (objAdaptacion != null)
                        //{
                        //    objAdaptacion.ID_ATENCION = atencion;
                        //    contexto.ADAPTACION_LENTES.Add(objAdaptacion);
                        //    contexto.SaveChanges();
                        //}
                        //if (objPrueba != null)
                        //{
                        //    objPrueba.ID_ATENCION = atencion;
                        //    contexto.LENTE_PRUEBA.Add(objPrueba);
                        //    contexto.SaveChanges();
                        //}
                        //if (objDefinitivo != null)
                        //{
                        //    objDefinitivo.ID_ATENCION = atencion;
                        //    contexto.LENTE_DEFINITIVO.Add(objDefinitivo);
                        //    contexto.SaveChanges();
                        //}

                    }
                    tranScope.Complete();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public int GuardaAgenda(int medico, int dia, AGENDA objAgenda)
        {
            try
            {

                using (var contexto = new Opt3000Entities())
                {
                    int idMedico = (from m in contexto.MEDICO
                                    where m.ID_USUARIO == medico
                                    select m.ID_MEDICO).FirstOrDefault();
                    Int64 diaAtencion = (from d in contexto.HONRARIOATENCION
                                         where d.ID_MEDICO == idMedico && d.ID_DIA == dia
                                         select d.ID_DIASATENCION).FirstOrDefault();
                    objAgenda.ID_DIASATENCION = diaAtencion;
                    contexto.AGENDA.Add(objAgenda);
                    contexto.SaveChanges();
                    return 1;
                }
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
                Int64 idCliente = 0;
                using (var contexto = new Opt3000Entities())
                {
                    idCliente = (from c in contexto.CLIENTE
                                 where c.Identificacion == obj.Identificacion
                                 select c.ID_CLIENTE).FirstOrDefault();
                    if (idCliente == 0)
                    {
                        contexto.CLIENTE.Add(obj);
                        contexto.SaveChanges();
                        idCliente = (from c in contexto.CLIENTE
                                     where c.Identificacion == obj.Identificacion
                                     select c.ID_CLIENTE).FirstOrDefault();
                        return idCliente;
                    }
                    else
                    {
                        return idCliente;
                    }
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    CUENTA_PACIENTE objeto = (from c in contexto.CUENTA_PACIENTE
                                              where c.ID_ATENCION == obj.ID_ATENCION
                                              select c).FirstOrDefault();
                    if (objeto == null)
                    {
                        contexto.CUENTA_PACIENTE.Add(obj);
                        contexto.SaveChanges();
                        Int64 idCuenta = (from c in contexto.CUENTA_PACIENTE
                                          where c.ID_CLIENTE == obj.ID_CLIENTE && c.ID_ATENCION == obj.ID_ATENCION
                                          select c.ID_CUENTA_PACIENTE).FirstOrDefault();
                        return idCuenta;
                    }
                    else
                        return objeto.ID_CUENTA_PACIENTE;
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    CUENTA_PACIENTE objeto = (from c in contexto.CUENTA_PACIENTE
                                              where c.AGRUPACION == obj.ID_ATENCION
                                              select c).FirstOrDefault();
                    if (objeto == null)
                    {
                        contexto.CUENTA_PACIENTE.Add(obj);
                        contexto.SaveChanges();
                        Int64 idCuenta = (from c in contexto.CUENTA_PACIENTE
                                          where c.ID_CLIENTE == obj.ID_CLIENTE && c.ID_ATENCION == obj.ID_ATENCION
                                          select c.ID_CUENTA_PACIENTE).FirstOrDefault();
                        return idCuenta;
                    }
                    else
                        return objeto.ID_CUENTA_PACIENTE;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GuardaAnticipo(ANTICIPOS anticipo)
        {
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    contexto.ANTICIPOS.Add(anticipo);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardaDetalle(DETALLE det)
        {
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    contexto.DETALLE.Add(det);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GuardaFactura(CLIENTE cliente, List<ANTICIPOS> anticipo, List<FACTURA_PAGO> facturaPago, FACTURA factura, CAJA caja, string detalle)
        {
            try
            {
                using (TransactionScope tranScope = new TransactionScope())
                {
                    using (var contexto = new Opt3000Entities())
                    {
                        try
                        {
                            DatActualizacion.getInstance().ModificaCliente(cliente);

                            foreach (var item in anticipo)
                            {
                                ANTICIPOS ant = new ANTICIPOS();
                                ant.ID_PACIENTE = item.ID_PACIENTE;
                                ant.Detalle = item.Detalle;
                                ant.Valor = item.Valor;
                                ant.Saldo = item.Saldo;
                                DatActualizacion.getInstance().ModificaAnticipo(ant);
                            }

                            ATENCION ate = contexto.ATENCION.FirstOrDefault(a => a.ID_ATENCION == factura.ID_ATENCION);
                            ate.DETALLEFACTURA = detalle;
                            ate.Ate_Facturada = true;
                            contexto.SaveChanges();

                            CAJA objCaja = contexto.CAJA.FirstOrDefault(c => c.ID_CAJA == caja.ID_CAJA);
                            objCaja.Secuencial = caja.Secuencial + 1;
                            contexto.SaveChanges();

                            contexto.FACTURA.Add(factura);
                            contexto.SaveChanges();

                            Int64 idFac = (from f in contexto.FACTURA
                                           where f.ID_ATENCION == factura.ID_ATENCION
                                           select f.ID_FACTURA).FirstOrDefault();

                            foreach (var item in facturaPago)
                            {
                                item.ID_FACTURA = idFac;
                                contexto.FACTURA_PAGO.Add(item);
                                contexto.SaveChanges();
                            }


                            tranScope.Complete();
                            return true;
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                }
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
                using (TransactionScope tranScope = new TransactionScope())
                {
                    bool retorna = false;
                    using (var contexto = new Opt3000Entities())
                    {
                        int valida = 0;
                        valida = (from u in contexto.USUARIO
                                  where u.Usuario == usu.Usuario
                                  select u.ID_USUARIO).FirstOrDefault();
                        if (valida == 0)
                        {
                            contexto.USUARIO.Add(usu);
                            contexto.SaveChanges();
                        }
                        else
                            return retorna;
                        if (usu.ID_NIVEL == 2)
                        {
                            valida = 0;
                            valida = (from m in contexto.MEDICO
                                      where m.Identificacion == med.Identificacion
                                      select m.ID_MEDICO).FirstOrDefault();

                            if (valida == 0)
                            {
                                valida = (from u in contexto.USUARIO
                                          where u.Usuario == usu.Usuario
                                          select u.ID_USUARIO).FirstOrDefault();
                                med.ID_USUARIO = valida;
                                contexto.MEDICO.Add(med);
                                contexto.SaveChanges();
                                retorna = true;
                            }
                            else
                                return retorna;
                        }
                        else
                            retorna = true;
                        tranScope.Complete();
                        return retorna;

                    }
                }
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
                using (var context = new Opt3000Entities())
                {
                    context.CONVENIO.Add(convenio);
                    context.SaveChanges();
                    return true;
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    Int64 max = contexto.HONRARIOATENCION.Max(h => h.ID_DIASATENCION);
                    horario.ID_DIASATENCION = max + 1;
                    contexto.HONRARIOATENCION.Add(horario);
                    contexto.SaveChanges();
                    return true;
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    if (obj.ID_BANCO == 0)
                    {
                        contexto.BANCOS.Add(obj);
                        contexto.SaveChanges();
                    }
                    else
                    {
                        BANCOS banco = contexto.BANCOS.FirstOrDefault(b => b.ID_BANCO == obj.ID_BANCO);
                        banco.Nombre = obj.Nombre;
                        banco.Detalle = obj.Detalle;
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

        public bool GuardaDiferido(TIEMPODIFERIDO obj)
        {
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    if (obj.ID_TIEMPODIFERIDO == 0)
                    {
                        contexto.TIEMPODIFERIDO.Add(obj);
                        contexto.SaveChanges();
                    }
                    else
                    {
                        TIEMPODIFERIDO timepo = contexto.TIEMPODIFERIDO.FirstOrDefault(t => t.ID_TIEMPODIFERIDO == obj.ID_TIEMPODIFERIDO);
                        timepo.Detalle = obj.Detalle;
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

        public bool GuardaOrden(ORDEN_PEDIDO orden, List<DETALLE_ORDEN> lista, Int64[,] matris)
        {
            try
            {
                using (TransactionScope tranScope = new TransactionScope())
                {
                    using (var contexto = new Opt3000Entities())
                    {
                        orden.Fecha = DateTime.Now;
                        contexto.ORDEN_PEDIDO.Add(orden);
                        contexto.SaveChanges();

                        Int64 cod = (from o in contexto.ORDEN_PEDIDO
                                     where o.NumeroFactura == orden.NumeroFactura
                                     select o.ID_ORDEN).FirstOrDefault();

                        foreach (var item in lista)
                        {
                            item.ID_ORDEN = cod;
                            contexto.DETALLE_ORDEN.Add(item);
                            contexto.SaveChanges();

                            if (orden.CargaInventario)
                            {
                                PRODUCTO objProducto = new PRODUCTO();
                                objProducto.Detalle = item.Nombre;
                                objProducto.Precio = item.Costo + ((item.Costo * item.Ganacia) / 100);
                                objProducto.PagaIva = item.PagaIva;
                                objProducto.Especificaciones = item.Tipo;
                                objProducto.STOCK = item.Cantidad;
                                objProducto.CodProducto = item.CodProducto;
                                objProducto.ID_DETALLE = 0;

                                contexto.PRODUCTO.Add(objProducto);
                                contexto.SaveChanges();
                            }
                        }

                        for (int i = 0; i < 9; i++)
                        {
                            Int64 conta = matris[i, 0];
                            Int64 conta2 = matris[i, 1];
                            CONTADOR_PRODUCTOS pro = contexto.CONTADOR_PRODUCTOS.FirstOrDefault(p => p.ID_TIPOPRODUCTO == conta);
                            if (pro != null)
                            {
                                pro.Contador = conta2;
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

        public bool GuardaProducto(PRODUCTO obj)
        {
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    contexto.PRODUCTO.Add(obj);
                    contexto.SaveChanges();
                    return true;
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    garantia.Fecha = DateTime.Now;
                    contexto.GARANTIA.Add(garantia);
                    contexto.SaveChanges();
                    return true;
                }
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
                using (Opt3000Entities contexto = new Opt3000Entities())
                {
                    contexto.sp_DuplicaFactura(ateCodigo, valor1, valor2, iva);
                    return true;
                }
                //string sql = " sp_DuplicaFactura @atencion, @valor1, @valor2, @iva ";
                //SqlParameter ate = new SqlParameter("@atencion", ateCodigo);
                //SqlParameter val1 = new SqlParameter("@atencion", valor1);
                //SqlParameter val2 = new SqlParameter("@atencion", valor2);
                //SqlParameter i = new SqlParameter("@atencion", iva);
                //ExecuteSqlCommand(sql, ate, val1, val2, i);

                //using( var contexto = new Opt3000Entities())
                //{
                //    var divide = contexto.Database.SqlQuery<sp_DuplicaFactura>("sp_DuplicaFactura @atencion, @valor1, @valor2, @iva",
                //        new SqlParameter("@atencion",ateCodigo),)
                //}
            }
            catch (Exception )
            {

                throw;
            }
        }
    }
}
