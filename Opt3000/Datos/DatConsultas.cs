using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opt3000.BaseDatos;
using Opt3000.Entidades;

namespace Opt3000.Datos
{
    public class DatConsultas
    {
        #region PATRON SINGLENTON

        private static DatConsultas generico = null;
        private DatConsultas() { }

        public static DatConsultas getInstance()
        {
            if (generico == null)
            {
                generico = new DatConsultas();
            }
            return generico;
        }

        #endregion

        public List<CIE_10> ConsultaCie10()
        {
            List<CIE_10> lista = new List<CIE_10>();
            lista = null;
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    lista = (from d in contexto.CIE_10
                             select d).ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                lista = null;
                throw ex;
            }
        }

        public List<CONVENIO> ConsultaConvenios()
        {
            List<CONVENIO> lista = new List<CONVENIO>();
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    lista = (from d in contexto.CONVENIO
                             select d).ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                lista = null;
                throw ex;
            }
        }

        public List<TIPO_LENTECONTACTO> ConsultaTipo()
        {
            List<TIPO_LENTECONTACTO> lista = new List<TIPO_LENTECONTACTO>();
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    lista = (from d in contexto.TIPO_LENTECONTACTO
                             select d).ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                lista = null;
                throw ex;
            }
        }


        public List<PRODUCTO> CargaProductos(string esp = "")
        {
            List<PRODUCTO> lista = new List<PRODUCTO>();
            try
            {
                if (esp == "")
                    using (var contexto = new Opt3000Entities())
                    {
                        lista = (from p in contexto.PRODUCTO
                                 where p.STOCK > 0
                                 select p).ToList();
                        return lista;
                    }
                else
                {
                    if (esp == "S")
                        using (var contexto = new Opt3000Entities())
                        {
                            lista = (from p in contexto.PRODUCTO
                                     where p.Especificaciones == esp
                                     select p).ToList();
                            return lista;
                        }
                    else
                    {
                        using (var contexto = new Opt3000Entities())
                        {
                            lista = (from p in contexto.PRODUCTO
                                     where p.Especificaciones == esp && p.STOCK > 0
                                     select p).ToList();
                            return lista;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lista = null;
                throw ex;
            }
        }

        public CONVENIO ConsultaConvenio(int idConvenio)
        {
            CONVENIO objConvenio = new CONVENIO();
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    objConvenio = (from d in contexto.CONVENIO
                                   where d.ID_TIPO == idConvenio
                                   select d).FirstOrDefault();
                    return objConvenio;
                }
            }
            catch (Exception ex)
            {
                objConvenio = null;
                throw ex;
            }
        }

        public PACIENTE CargaPaciente(string cedula)
        {
            PACIENTE objPaciente = new PACIENTE();

            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    objPaciente = (from d in contexto.PACIENTE
                                   where d.Identificacion == cedula
                                   
                                   select d).FirstOrDefault();
                    return objPaciente;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<PACIENTE> CargaListaPaciente()
        {
            List<PACIENTE> lista = new List<PACIENTE>();
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    lista = (from d in contexto.PACIENTE
                             orderby d.ID_PACIENTE descending
                             select d).ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<ATENCION> CargaAtenciones(Int64 hc, string tipoConsulta = "", int factura = 0)
        {
            List<ATENCION> lista = new List<ATENCION>();
            try
            {
                if (factura == 0)
                    if (tipoConsulta != "")
                        using (var contexto = new Opt3000Entities())
                        {
                            return lista = (from a in contexto.ATENCION
                                                //join c in contexto.CUENTA_PACIENTE on a.ID_ATENCION equals c.ID_ATENCION
                                            where a.ID_PACIENTE == hc && a.Tipo_Consulta == tipoConsulta //&& c.ID_ATENCION == c.AGRUPACION
                                            && a.FACTURAR==true
                                            orderby a.ID_ATENCION descending
                                            select a).ToList();
                        }
                    else
                        using (var contexto = new Opt3000Entities())
                        {
                            return lista = (from a in contexto.ATENCION
                                                //join c in contexto.CUENTA_PACIENTE on a.ID_ATENCION equals c.ID_ATENCION
                                            where a.ID_PACIENTE == hc && a.Ate_Facturada == false //&& c.ID_ATENCION == c.AGRUPACION
                                            && a.FACTURAR == true
                                            select a).ToList();
                        }

                else
                    using (var contexto = new Opt3000Entities())
                    {
                        return lista = (from a in contexto.ATENCION
                                            //join c in contexto.CUENTA_PACIENTE on a.ID_ATENCION equals c.ID_ATENCION
                                        where a.ID_PACIENTE == hc && a.Ate_Facturada == false //&& c.ID_ATENCION == c.AGRUPACION
                                        && a.FACTURAR == true
                                        select a).ToList();
                    }
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
                Int64 max = 0;
                using (var contexto = new Opt3000Entities())
                {
                    return max = (from a in contexto.ATENCION
                                  select a.ID_ATENCION).Max();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ATENCION CargaAtencion(Int64 ateCodigo)
        {
            ATENCION objAtencion = new ATENCION();
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    //return objAtencion = (from a in contexto.ATENCION
                    //                      join o in contexto.Orden1 on a.ID_ATENCION equals o.AteCodigo
                    //                      where o.ID_ORDEN1 == ateCodigo
                    //                      orderby a.ID_ATENCION descending
                    //                      select a).FirstOrDefault();
                    return objAtencion = (from a in contexto.ATENCION
                                          where a.ID_ATENCION == ateCodigo
                                          select a).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RETINOSCOPIA_DILATADA CargaRetinoscopia(Int64 ateCodigo, string ojo)
        {
            RETINOSCOPIA_DILATADA obj = new RETINOSCOPIA_DILATADA();
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    return obj = (from r in contexto.RETINOSCOPIA_DILATADA
                                  where r.ID_ATENCION == ateCodigo && r.OJO == ojo
                                  select r).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public LENTES_CONTACTO CargaLentes(Int64 ateCodigo, string ojo)
        {
            LENTES_CONTACTO obj = new LENTES_CONTACTO();
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    return obj = (from l in contexto.LENTES_CONTACTO
                                  where l.ID_ATENCION == ateCodigo && l.OJO == ojo
                                  orderby l.ID_LENTES descending
                                  select l).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public RX_FINAL CargaRxFinal(Int64 ateCodigo, string ojo)
        {
            RX_FINAL obj = new RX_FINAL();
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    return obj = (from r in contexto.RX_FINAL
                                  where r.ID_ATENCION == ateCodigo && r.OJO == ojo
                                  select r).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public USUARIO ConsultaUsuario(string usuario, string pass)
        {
            USUARIO obj = new USUARIO();
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    return obj = (from u in contexto.USUARIO
                                  where u.Usuario == usuario && u.Clave == pass
                                  select u).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public OFTALMOLOGIA ConsultaOftalmologica(Int64 AteCodigo)
        {
            OFTALMOLOGIA obj = new OFTALMOLOGIA();
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    return obj = (from o in contexto.OFTALMOLOGIA
                                  where o.ID_ATENCION == AteCodigo
                                  select o).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ADAPTACION_LENTES ConsultaAdaptacion(Int64 ateCodigo)
        {
            ADAPTACION_LENTES obj = new ADAPTACION_LENTES();
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    return obj = (from a in contexto.ADAPTACION_LENTES
                                  where a.ID_ATENCION == ateCodigo
                                  select a).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public LENTE_PRUEBA ConsultaLentesPrueba(Int64 ateCodigo)
        {
            LENTE_PRUEBA obj = new LENTE_PRUEBA();
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    return obj = (from l in contexto.LENTE_PRUEBA
                                  where l.ID_ATENCION == ateCodigo
                                  select l).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public LENTE_DEFINITIVO ConsultaLentesDefinitivo(Int64 ateCodigo)
        {
            LENTE_DEFINITIVO obj = new LENTE_DEFINITIVO();
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    return obj = (from l in contexto.LENTE_DEFINITIVO
                                  where l.ID_ATENCION == ateCodigo
                                  select l).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<USUARIO> CargaComboMedico()
        {
            List<USUARIO> lista = new List<USUARIO>();
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    return lista = (from u in contexto.USUARIO
                                    where u.ID_NIVEL == 2
                                    select u).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public HONRARIOATENCION ConsultaHorarios(int dia, int medico)
        {
            MEDICO objMedico = new MEDICO();
            HONRARIOATENCION obj = new HONRARIOATENCION();
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    objMedico = (from m in contexto.MEDICO
                                 where m.ID_USUARIO == medico
                                 select m).FirstOrDefault();

                    return obj = (from h in contexto.HONRARIOATENCION
                                  where h.ID_DIA == dia && h.ID_MEDICO == objMedico.ID_MEDICO
                                  select h).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<CONSULTORIO> ConsultaConsultorio()
        {
            List<CONSULTORIO> lista = new List<CONSULTORIO>();
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    return lista = (from c in contexto.CONSULTORIO
                                    select c).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public MEDICO ConsultaMedico(int medico)
        {
            MEDICO obj = new MEDICO();
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    return obj = (from m in contexto.MEDICO
                                  where m.ID_USUARIO == medico
                                  select m).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public AGENDA ConsultaAgenda(int medico, DateTime fecha, int hora, int minutos, int dia)
        {
            AGENDA obj = new AGENDA();
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    Int64 diasAtencion = (from d in contexto.HONRARIOATENCION
                                          where d.ID_MEDICO == medico && d.ID_DIA == dia
                                          select d.ID_DIASATENCION).FirstOrDefault();
                    return obj = (from a in contexto.AGENDA
                                  where a.ID_DIASATENCION == diasAtencion && a.FachaCita == fecha && a.Hora == hora && a.Minutos == minutos
                                  select a).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ConsultaStock(string codProducto, int cantidad)
        {
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    PRODUCTO pro = (from d in contexto.PRODUCTO
                                    where d.CodProducto == codProducto
                                    select d).FirstOrDefault();
                    if (pro.STOCK >= cantidad || pro.Especificaciones == "S")
                        return true;
                    else
                        return false;
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    PRODUCTO esp = (from p in contexto.PRODUCTO
                                    where p.CodProducto == codProducto
                                    select p).FirstOrDefault();
                    return esp;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public PRODUCTO Producto(Int64 codPro)
        {
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    PRODUCTO esp = (from p in contexto.PRODUCTO
                                    where p.ID_PRODUCTO == codPro
                                    select p).FirstOrDefault();
                    return esp;
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    string valor = (from p in contexto.PARAMETRO
                                    where p.Descripciones == detalle
                                    select p.Valor).FirstOrDefault();
                    return valor;
                }
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
                List<DETALLE> detalle = new List<DETALLE>();
                using (var contexto = new Opt3000Entities())
                {

                    detalle = (from d in contexto.DETALLE
                               where d.ID_CUENTA_PACIENTE == idCuenta && d.Cantidad > 0
                               select d).ToList();

                    return detalle;
                }
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
                CLIENTE cliente = new CLIENTE();
                using (var contexto = new Opt3000Entities())
                {
                    return cliente = (from c in contexto.CLIENTE
                                      where c.Identificacion == identificacion
                                      select c).FirstOrDefault();
                }

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
                List<ANTICIPOS> anticipo = new List<ANTICIPOS>();
                using (var context = new Opt3000Entities())
                {
                    return anticipo = (from a in context.ANTICIPOS
                                       where a.ID_PACIENTE == codPac
                                       select a).ToList();

                }
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
                using (var contexto = new Opt3000Entities())
                {
                    List<FORMA_PAGO> lista = (from fp in contexto.FORMA_PAGO
                                              where fp.Estado == true
                                              select fp).ToList();
                    return lista;
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    ANTICIPOS anti = (from a in contexto.ANTICIPOS
                                      where a.ID_ANTICIPOS == cod
                                      select a).FirstOrDefault();
                    return anti;
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    TIEMPODIFERIDO tiempo = (from t in contexto.TIEMPODIFERIDO
                                             where t.ID_TIEMPODIFERIDO == cod
                                             select t).FirstOrDefault();
                    return tiempo;
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    EMPRESA emp = (from e in contexto.EMPRESA
                                   select e).FirstOrDefault();
                    return emp;
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    SUCURSAL suc = (from s in contexto.SUCURSAL
                                    where s.ID_SUCURSAL == idSuc
                                    select s).FirstOrDefault();
                    return suc;
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    CAJA caj = (from c in contexto.CAJA
                                where c.ID_SUCURSAL == idSuc
                                select c).FirstOrDefault();
                    return caj;
                }
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
                List<MEDICO> medico = new List<MEDICO>();
                using (var contexto = new Opt3000Entities())
                {
                    return medico = (from m in contexto.MEDICO
                                     select m).ToList();
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    List<USUARIO> med = (from u in contexto.USUARIO
                                         where u.ID_NIVEL == 2
                                         select u).ToList();
                    return med;
                }
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
                USUARIO usu = new USUARIO();
                using (var contexto = new Opt3000Entities())
                {
                    return usu = (from u in contexto.USUARIO
                                  where u.ID_USUARIO == usuario
                                  select u).FirstOrDefault();
                }
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
                List<NIVEL_USUARIO> lista = new List<NIVEL_USUARIO>();
                using (var contexto = new Opt3000Entities())
                {
                    return lista = (from n in contexto.NIVEL_USUARIO
                                    select n).ToList();
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    List<ESPECIALIDAD> lista = new List<ESPECIALIDAD>();
                    return lista = (from e in contexto.ESPECIALIDAD
                                    select e).ToList();
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    int valida = 0;
                    valida = (from u in contexto.USUARIO
                              where u.Usuario == usuario
                              select u.ID_USUARIO).FirstOrDefault();
                    if (valida != 0)
                    {
                        return false;
                    }
                    else
                        return true;
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    int valida = 0;
                    valida = (from u in contexto.USUARIO
                              where u.Clave == password
                              select u.ID_USUARIO).FirstOrDefault();
                    if (valida == 0)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public USUARIO RecuperaUsuarioPassword(string pass)
        {
            using (var contexto = new Opt3000Entities())
            {

                USUARIO obj = (from u in contexto.USUARIO
                               where u.Clave == pass
                               select u).FirstOrDefault();

                return obj;
            }
        }

        public bool RecuperaConvenio(string nombre)
        {
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    CONVENIO datos = new CONVENIO();
                    datos = (from l in contexto.CONVENIO
                             where l.Detalle == nombre
                             select l).FirstOrDefault();
                    if (datos == null)
                        return false;
                    else
                        return true;
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    ORDEN_PEDIDO obj = new ORDEN_PEDIDO();
                    return obj = (from o in contexto.ORDEN_PEDIDO
                                  where o.NumeroFactura == factura
                                  select o).FirstOrDefault();
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    List<ORDEN_PEDIDO> lista = new List<ORDEN_PEDIDO>();
                    return lista = (from o in contexto.ORDEN_PEDIDO
                                    where o.CargaInventario == false
                                    select o).ToList();
                }
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
                using (var context = new Opt3000Entities())
                {
                    List<DETALLE_ORDEN> lista = new List<DETALLE_ORDEN>();
                    return lista = (from o in context.DETALLE_ORDEN
                                    where o.ID_ORDEN == idOrden
                                    select o).ToList();
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    List<USUARIO> lista = (from u in contexto.USUARIO
                                           select u).ToList();
                    return lista;
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    Int64 ate = (from a in contexto.ATENCION
                                 where a.ID_PACIENTE == hc
                                 orderby a.ID_ATENCION descending
                                 select a.ID_ATENCION).FirstOrDefault();
                    return ate;
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    List<TIPO_PRODUCTO> lista = (from t in contexto.TIPO_PRODUCTO
                                                 select t).ToList();
                    return lista;
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    CONTADOR_PRODUCTOS obj = (from c in contexto.CONTADOR_PRODUCTOS
                                              where c.ID_TIPOPRODUCTO == id
                                              select c).FirstOrDefault();
                    return obj;
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    return (from p in contexto.PACIENTE
                            join a in contexto.ATENCION on p.ID_PACIENTE equals a.ID_PACIENTE
                            join c in contexto.CUENTA_PACIENTE on a.ID_ATENCION equals c.AGRUPACION
                            where c.ID_ATENCION == codAtencionAgtupada
                            select new CuentasAgrupadas
                            {
                                NOMBRE = p.Apellidos + " " + p.Nombres,
                                HC = p.ID_PACIENTE,
                                CEDULA = p.Identificacion,
                                ATENCION = c.AGRUPACION
                            }).ToList();
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public List<CUENTA_PACIENTE> RetornaCuentasAgrupadas(Int64 idAtencion)
        {
            using (var contexto = new Opt3000Entities())
            {
                List<CUENTA_PACIENTE> lista = (from c in contexto.CUENTA_PACIENTE
                                               where c.ID_ATENCION == idAtencion
                                               select c).ToList();
                return lista;
            }
        }

        public PRODUCTO RecuperaDetalleOrden(Int64 ateCodigo)
        {
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    return (from c in contexto.CUENTA_PACIENTE
                            join d in contexto.DETALLE on c.ID_CUENTA_PACIENTE equals d.ID_CUENTA_PACIENTE
                            join p in contexto.PRODUCTO on d.ID_PRODUCTO equals p.ID_PRODUCTO
                            where c.ID_ATENCION == ateCodigo
                            orderby d.ID_DETALLE descending
                            select p).FirstOrDefault();
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    return (from c in contexto.CUENTA_PACIENTE
                            join d in contexto.DETALLE on c.ID_CUENTA_PACIENTE equals d.ID_CUENTA_PACIENTE
                            join p in contexto.PRODUCTO on d.ID_PRODUCTO equals p.ID_PRODUCTO
                            where c.ID_ATENCION == ateCodigo && d.Cantidad > 0
                            select new DevolucionLista
                            {
                                ID = d.ID_PRODUCTO,
                                ID_DETALLE = d.ID_DETALLE,
                                CANTIDAD = d.Cantidad,
                                DETALLE = p.Detalle
                            }).ToList();
                }
            }
            catch (Exception err)
            {

                throw err;
            }
        }

        public List<BANCOS> RecuperaBancos()
        {
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    return (from b in contexto.BANCOS
                            select b).ToList();
                }
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
                using (var constexto = new Opt3000Entities())
                {
                    return (from t in constexto.TIEMPODIFERIDO
                            select t).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        

        public Int64 RecuperaSecuencial()
        {
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    return (from o in contexto.Orden1
                            orderby o.ID_ORDEN1 descending
                            select o.ID_ORDEN1).FirstOrDefault();
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    return (from o in contexto.ORDEN_LEJANA
                            orderby o.ID_ORDEN3 descending
                            select o.ID_ORDEN3).FirstOrDefault();
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    return (from o in contexto.ORDEN_VISION_CERCA
                            orderby o.ID_ORDEN2 descending
                            select o.ID_ORDEN2).FirstOrDefault();
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    return (from o in contexto.ORDEN_LENTESBLANDOS
                            orderby o.ID_ORDEN4 descending
                            select o.ID_ORDEN4).FirstOrDefault();
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    return (from p in contexto.PACIENTE
                            where p.ID_PACIENTE == codPac
                            select p).FirstOrDefault();
                }
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
                int caja = Convert.ToInt16(factura.Substring(0, 3));
                using (var contexto = new Opt3000Entities())
                {
                    return (from f in contexto.FACTURA
                            where f.ID_CAJA == caja && f.Numero_Factura == factura.Substring(3, 9)
                            select f).FirstOrDefault();
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    return (from o in contexto.Orden1
                            join a in contexto.ATENCION on o.AteCodigo equals a.ID_ATENCION
                            join p in contexto.PACIENTE on o.CodPaciente equals p.ID_PACIENTE
                            join u in contexto.USUARIO on o.ID_Usuario equals u.ID_USUARIO
                            select new OrdenPendiente
                            {
                                Generado = (bool)o.GENERADO,
                                Enviado = (bool)o.enviado,
                                Recibido = (bool)o.RECIBIDO,
                                Entregado = (bool)o.ENTREGADO,
                                Atencion = a.ID_ATENCION,
                                Orden = o.ID_ORDEN1,
                                Paciente = p.Nombres + " " + p.Apellidos,
                                FechaPedido = o.FechaPedido,
                                FechaEntrega = o.FechaEntrega,
                                Usuario = u.Nombres + " " + u.Apellidos
                            }).ToList();
                }
            }
            catch (Exception )
            {

                throw;
            }
        }

        public void ordenes1modificar(bool generado,bool enviado,bool recibido,bool entregado,int codigo)
        {
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    Orden1 paises = contexto.Orden1.FirstOrDefault(p => p.ID_ORDEN1 == codigo);
                    paises.GENERADO = generado; paises.enviado = enviado;paises.RECIBIDO = recibido;paises.ENTREGADO = entregado;
                    contexto.SaveChanges();
                }
            }
            catch (Exception error)
            {
                Console.Write(error);
            }
        }


        public void ordenesparamodificar(bool generado, bool enviado, bool recibido, bool entregado, int codigo)
        {
                using (var contexto = new Opt3000Entities())
                {
                    Orden1 paises = contexto.Orden1.FirstOrDefault(p => p.ID_ORDEN1 == codigo);
                    paises.GENERADO = generado; paises.enviado = enviado; paises.RECIBIDO = recibido; paises.ENTREGADO = entregado;
                    contexto.SaveChanges();
                }
        }


        public List<Orden1> RecuperaOrden1Paciente(Int64 ateCodigo)
        {
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    return (from o in contexto.Orden1
                            where o.CodPaciente == ateCodigo
                            orderby o.FechaRegistro descending
                            select o).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Orden1 RecuperaOrden1(Int64 ateCodigo)
        {
            try
            {
                using (var contexto = new Opt3000Entities())
                {
                    return (from o in contexto.Orden1
                            where o.ID_ORDEN1 == ateCodigo
                            select o).FirstOrDefault();
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    return (from o in contexto.ORDEN_LEJANA
                            where o.ID_ORDEN3 == ateCodigo
                            select o).FirstOrDefault();
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    return (from o in contexto.ORDEN_LENTESBLANDOS
                            where o.ID_ORDEN4 == ateCodigo
                            select o).FirstOrDefault();
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    return (from o in contexto.ORDEN_VISION_CERCA
                            where o.ID_ORDEN2 == ateCodigo
                            select o).FirstOrDefault();
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    return (from o in contexto.ORDEN_VISION_CERCA
                            where o.AteCodigo == ateCodigo
                            orderby o.ID_ORDEN2 descending
                            select o).FirstOrDefault();
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    return (from o in contexto.ORDEN_LEJANA
                            where o.AteCodigo == ateCodigo
                            orderby o.ID_ORDEN3 descending
                            select o).FirstOrDefault();
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    return (from o in contexto.ORDEN_LENTESBLANDOS
                            where o.AteCodigo == ateCodigo
                            orderby o.ID_ORDEN4 descending
                            select o).FirstOrDefault();
                }
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
                using (var contexto = new Opt3000Entities())
                {
                    return (from o in contexto.Orden1
                            where o.AteCodigo == ateCodigo
                            orderby o.ID_ORDEN1 descending
                            select o).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
