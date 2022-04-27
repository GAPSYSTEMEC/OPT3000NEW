using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opt3000.BaseDatos;
using Opt3000.Entidades;

namespace Opt3000.Datos
{
    public class ExploradorController
    {
        public static IEnumerable<object> Pacientes()
        {
            List<DTOPacientes> pa = new List<DTOPacientes>();
            using (var db = new Opt3000Entities())
            {
                var pacientes = (from p in db.PACIENTE
                                 select new
                                 {
                                     p
                                 }).OrderByDescending(x => x.p.Nombres).ToList();
                foreach (var item in pacientes)
                {
                    DTOPacientes paciente = new DTOPacientes();
                    DateTime actual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    DateTime nacido = DateTime.Now.Date;
                    nacido = Convert.ToDateTime(item.p.F_Nacimiento);
                    int edadAnos = actual.Year - nacido.Year;
                    if (actual.Month < nacido.Month || (actual.Month == nacido.Month && actual.Day < nacido.Day))
                        edadAnos--;
                    int edadMeses = actual.Month - nacido.Month;
                    if (actual.Day < nacido.Day)
                        edadMeses--;
                    if (edadMeses < 0)
                        edadMeses += 12;
                    int edaddias;
                    if (actual.Day < nacido.Day)
                        edaddias = nacido.Day - actual.Day;
                    else
                        edaddias = actual.Day - nacido.Day;
                    paciente.Identificacion = item.p.Identificacion;
                    paciente.Paciente = item.p.Apellidos + " " + item.p.Nombres;
                    paciente.Ocupacion = item.p.Ocupacion;
                    paciente.Direccion = item.p.Direccion;
                    paciente.Celular = item.p.Celular;
                    paciente.Correo = item.p.Email;
                    paciente.Fecha_Nacimiento = item.p.F_Nacimiento;
                    paciente.ActualAños = Convert.ToString(edadAnos);
                    paciente.ActualMeses = Convert.ToString(edadMeses);
                    paciente.ActualDias = Convert.ToString(edaddias);
                    pa.Add(paciente);
                }
                return pa;
            }
        }

        public static IEnumerable<object> Consulta(DateTime desde, DateTime hasta)
        {
            List<DTOConsulta> pa = new List<DTOConsulta>();
            using (var db = new Opt3000Entities())
            {
                var conuslta = (from p in db.PACIENTE
                                join a in db.ATENCION on p.ID_PACIENTE equals a.ID_PACIENTE
                                join u in db.RX_FINAL on a.ID_ATENCION equals u.ID_ATENCION
                                join r in db.RETINOSCOPIA_DILATADA on new {u.ID_ATENCION ,u.OJO} equals new {r.ID_ATENCION, r.OJO} 
                                where a.Fecha_Creacion > desde && a.Fecha_Creacion < hasta
                                select new
                                {
                                    p,
                                    a,
                                    u,r
                                }).OrderByDescending(x => x.a.Fecha_Creacion).ToList();
                foreach (var item in conuslta)
                {
                    DTOConsulta paciente = new DTOConsulta();
                    DateTime actual = DateTime.Now.Date;
                    DateTime nacido = DateTime.Now.Date;
                    actual = Convert.ToDateTime(item.a.Fecha_Creacion);
                    nacido = Convert.ToDateTime(item.p.F_Nacimiento);
                    int edadAnos = actual.Year - nacido.Year;
                    if (actual.Month < nacido.Month || (actual.Month == nacido.Month && actual.Day < nacido.Day))
                        edadAnos--;
                    int edadMeses = actual.Month - nacido.Month;
                    if (actual.Day < nacido.Day)
                        edadMeses--;
                    if (edadMeses < 0)
                        edadMeses += 12;
                    paciente.MPC = item.a.Mpc;
                    paciente.Paciente = item.p.Apellidos + " " + item.p.Nombres;
                    paciente.Esfera = item.u.Esfera;
                    paciente.Cilindro = item.u.Cilindro;
                    paciente.Eje = item.u.Eje;
                    paciente.A_D_D = item.u.A_D_D;
                    paciente.AVL = item.u.AVL;
                    paciente.AVC = item.u.AVC;
                    paciente.ALT = item.u.ALT;
                    paciente.DNP_DP = item.u.DNP_DP;
                    paciente.OJO = item.u.OJO;
                    paciente.DiagnosticoOD = item.a.DiagnosticoOD;
                    paciente.DiagnosticoOI = item.a.DiagnosticoOI;
                    paciente.Observacion = item.a.Observaciones;
                    paciente.R_Esfera = item.r.Esfera;
                    paciente.R_Cilindro = item.r.Cilindro;
                    paciente.R_Eje = item.r.Eje;
                    paciente.R_AVC = item.r.Avl;
                    //paciente.R_Ojo = item.r.OJO;
                    paciente.Alencion = item.a.ID_ATENCION;
                    paciente.HistorialClinico = item.p.ID_PACIENTE;
                    paciente.FechaIngreso = item.a.Fecha_Creacion;
                    paciente.TipoAtencion = item.a.Tipo_Consulta;
                    paciente.ConsultaAños = Convert.ToString(edadAnos);
                    paciente.ConsultaMeses = Convert.ToString(edadMeses);
                    pa.Add(paciente);
                }
                return pa;
            }
        }

        public static IEnumerable<object> Oftalmologia(DateTime desde, DateTime hasta)
        {
            List<DTOOftalmologia> pa = new List<DTOOftalmologia>();
            using (var db = new Opt3000Entities())
            {
                var conuslta = (from p in db.PACIENTE
                                join a in db.ATENCION on p.ID_PACIENTE equals a.ID_PACIENTE
                                join o in db.OFTALMOLOGIA on a.ID_ATENCION equals o.ID_ATENCION
                                join u in db.RX_FINAL on a.ID_ATENCION equals u.ID_ATENCION
                                where a.Fecha_Creacion > desde && a.Fecha_Creacion < hasta
                                select new
                                {
                                    p,a,u,o
                                }).ToList();
                foreach (var item in conuslta)
                {
                    DTOOftalmologia paciente = new DTOOftalmologia();
                    paciente.Cedula = item.p.Identificacion;
                    paciente.Paciente = item.p.Apellidos + " " + item.p.Nombres;
                    paciente.Consulta = item.a.Tipo_Consulta;
                    paciente.Observaciones = item.a.Observaciones;
                    paciente.Anamnemesis = item.o.Anamnesis;
                    paciente.ExamenFiscico = item.o.Examen_Fisico;
                    paciente.Biomicroscopia = item.o.Biomicroscopia;
                    paciente.ButOD = item.o.ButOD;
                    paciente.ButOI = item.o.ButOI;
                    paciente.PioOD = item.o.PioOD;
                    paciente.PioID = item.o.PioID;
                    paciente.Esfera = item.u.Esfera;
                    paciente.Cilindro = item.u.Cilindro;
                    paciente.Eje = item.u.Eje;
                    paciente.A_D_D = item.u.A_D_D;
                    paciente.AVL = item.u.AVL;
                    paciente.AVC = item.u.AVC;
                    paciente.ALT = item.u.ALT;
                    paciente.DNP_DP = item.u.DNP_DP;
                    paciente.OJO = item.u.OJO;
                    pa.Add(paciente);
                }
                return pa;
            }
        }

        public static IEnumerable<object> Agenda (DateTime desde, DateTime hasta)
        {
            List<DTOCitas> pa = new List<DTOCitas>();
            using (var db = new Opt3000Entities())
            {
                var conuslta = (from h in db.HONRARIOATENCION
                                join a in db.AGENDA on h.ID_DIASATENCION equals a.ID_DIASATENCION
                                join p in db.PACIENTE on a.ID_PACIENTE equals p.ID_PACIENTE
                                join m in db.MEDICO on h.ID_MEDICO equals m.ID_MEDICO
                                join u in db.USUARIO on m.ID_USUARIO equals u.ID_USUARIO
                                //join c in db.CONSULTORIO on h.ID_CONSULTORIO equals c.ID_CONSULTORIO
                                where a.FachaCita > desde && a.FachaCita < hasta
                                select new
                                {
                                    h,a,p,m,u
                                }).OrderByDescending(x => x.a.FachaCita).ToList();
                foreach (var item in conuslta)
                {
                    DTOCitas paciente = new DTOCitas();
                    paciente.Identificacion = item.p.Identificacion;
                    paciente.Paciente = item.p.Apellidos + " " + item.p.Nombres;
                    paciente.FechaCita = item.a.FachaCita;
                    paciente.Hora = item.a.Hora + ":" + item.a.Minutos; 
                    paciente.Consultorio = item.a.CONSULTORIO;
                    paciente.Medico = item.u.Nombres+" "+item.u.Apellidos;
                    paciente.Especialidad = item.m.Especialidad;
                    paciente.Observacion = item.a.Observaciones;
                    paciente.Cie10 = item.a.Cie10;
                    pa.Add(paciente);
                }
                return pa;
            }
        }

        //public static DSConsulta Consulta1(DateTime desde, DateTime hasta)
        //{
        //    DSConsulta con = new DSConsulta();
        //    using (var db = new Opt3000Entities())
        //    {
        //        var lcab = (from p in db.PACIENTE
        //                    join a in db.ATENCION on p.ID_PACIENTE equals a.ID_PACIENTE
        //                    join u in db.RX_FINAL on a.ID_ATENCION equals u.ID_ATENCION
        //                    where a.Fecha_Creacion > desde && a.Fecha_Creacion < hasta
        //                    select new
        //                    {
        //                        p,
        //                        a,
        //                        u
        //                    }).ToList();
        //        foreach (var item in lcab)
        //        {
        //            var ldet = (from r in db.RETINOSCOPIA_DILATADA
        //                        select new
        //                        {
        //                            r
        //                        }).ToList();
        //            object[] Cabecera = new object[]
        //            {
        //                item.a.ID_ATENCION,
        //                item.p.Apellidos + " " + item.p.Nombres,
        //                item.a.Mpc,
        //                item.u.Esfera,
        //                item.u.Cilindro,
        //                item.u.Eje,
        //                item.u.A_D_D,
        //                item.u.AVL,
        //                item.u.AVC,
        //                item.u.ALT,
        //                item.u.DNP_DP,
        //                item.u.OJO,
        //                item.a.DiagnosticoOD,
        //                item.a.DiagnosticoOI,
        //                //item.a.Observaciones
        //            };
        //            con.CONSULTA.Rows.Add(Cabecera);
        //            foreach (var i in ldet)
        //            {
        //                object[] Detalle = new object[]
        //                {
        //                i.r.ID_ATENCION,
        //                i.r.Esfera,
        //                i.r.Cilindro,
        //                i.r.Eje,
        //                i.r.Avl,
        //                i.r.OJO
        //                };
        //                con.RETINOSCOPIA_DILATADA.Rows.Add(Detalle);

        //            }
        //        }
        //        return con;
        //    }

        //}
        public static IEnumerable<object> Factura(DateTime desde, DateTime hasta)
        {
            List<DTOFactura> fa = new List<DTOFactura>();
            using(var db = new Opt3000Entities())
            {
                var consulta = (from f in db.FACTURA
                                join fp in db.FACTURA_PAGO on f.ID_FACTURA equals fp.ID_FACTURA
                                join p in db.FORMA_PAGO on fp.ID_FORMAPAGO equals p.ID_FORMAPAGO
                                join t in db.TIEMPODIFERIDO on fp.Tiempo_Diferido equals t.ID_TIEMPODIFERIDO
                                join c in db.CAJA on f.ID_CAJA equals c.ID_CAJA
                                join s in db.SUCURSAL on c.ID_SUCURSAL equals s.ID_SUCURSAL
                                join a in db.ATENCION on f.ID_ATENCION equals a.ID_ATENCION
                                join r in db.PACIENTE on a.ID_PACIENTE equals r.ID_PACIENTE
                                where f.Fecha_Emision > desde && f.Fecha_Emision < hasta
                                select new
                                {
                                    f,fp,p,t,c,s,a,r
                                }).OrderByDescending(x => x.f.Fecha_Emision).ToList();
                foreach (var item in consulta)
                {
                    DTOFactura paciente = new DTOFactura();
                    paciente.Atencion = (int)item.a.ID_ATENCION;
                    paciente.Factura = item.f.Numero_Factura;
                    paciente.Fecha = item.f.Fecha_Emision;
                    paciente.FormaPago = item.p.Detalle;
                    paciente.TiempoDiferido = item.t.Detalle;
                    paciente.Caja = item.c.Caja;
                    paciente.Direccion = item.s.Direccion;
                    paciente.Paciente = item.r.Apellidos + " " + item.r.Nombres;
                    //paciente.FechaArqueo = item.f.Fecha_Arqueo;
                    //paciente.Direccion = item.s.Direccion;
                    fa.Add(paciente);
                }
                return fa;
            }
        }

        public static IEnumerable<object> Anticipo(DateTime desde, DateTime hasta)
        {
            List<DTOAnticipos> at = new List<DTOAnticipos>();
            using (var db = new Opt3000Entities())
            {
                var pacientes = (from p in db.PACIENTE
                                 join a in db.ANTICIPOS on p.ID_PACIENTE equals a.ID_PACIENTE
                                 where a.Fecha_Registro > desde && a.Fecha_Registro < hasta
                                 select new
                                 {
                                     p,
                                     a
                                 }).OrderByDescending(x => x.a.Fecha_Registro).ToList();
                foreach (var item in pacientes)
                {
                    DTOAnticipos paciente = new DTOAnticipos();
                    paciente.Paciente = item.p.Apellidos + " " + item.p.Nombres;
                    paciente.Identificacion = item.p.Identificacion;
                    paciente.FechaAnticipo = item.a.Fecha_Registro;
                    paciente.Detalle = item.a.Detalle;
                    paciente.Valor = (double)item.a.Valor;
                    paciente.Saldo = (double)item.a.Saldo;                  
                    //paciente.FechaArqueo = item.f.Fecha_Arqueo;
                    //paciente.Direccion = item.s.Direccion;
                    at.Add(paciente);
                }
                return at;
            }
        }
        public static IEnumerable<object> NotaVenta(DateTime desde, DateTime hasta)
        {
            List<DTONota> at = new List<DTONota>();
            using (var db = new Opt3000Entities())
            {
                var pacientes = (from c in db.CLIENTE
                                 join p in db.CUENTA_PACIENTE on c.ID_CLIENTE equals p.ID_CLIENTE
                                 join d in db.DETALLE on p.ID_CUENTA_PACIENTE equals d.ID_CUENTA_PACIENTE
                                 join a in db.ATENCION on p.ID_ATENCION equals a.ID_ATENCION
                                 where a.Fecha_Creacion > desde && a.Fecha_Creacion < hasta
                                 select new
                                 {
                                     c,
                                     p,
                                     d,
                                     a
                                 }).OrderByDescending(x => x.a.Fecha_Creacion).ToList();
                foreach (var item in pacientes)
                {
                    DTONota paciente = new DTONota();
                    double iva = Convert.ToDouble(item.d.Iva);
                    double sub = Convert.ToDouble(item.d.Total);
                    double total = sub + iva;
                    paciente.Paciente = item.c.Nombre+""+item.c.Apellidos;
                    paciente.Identificacion = item.c.Identificacion;
                    paciente.Cuenta = item.p.ID_CUENTA_PACIENTE;
                    paciente.Movimiento = item.d.ID_DETALLE;
                    paciente.IVA = (double)item.d.Iva;
                    paciente.Subtotal = (double)item.d.Total;
                    paciente.Total = total;
                    paciente.Detalle = item.a.Observaciones;
                    paciente.Atencion = item.a.ID_ATENCION;
                    paciente.FechaAtencion = item.a.Fecha_Creacion; 
                    at.Add(paciente);
                }
                return at;
            }
        }
        public static IEnumerable<object> OrdenTrabajo(DateTime desde, DateTime hasta)
        {
            List<DTOOrden> at = new List<DTOOrden>();
            using (var db = new Opt3000Entities())
            {
                var orden = (from o in db.Orden1
                             join p in db.PACIENTE on o.CodPaciente equals p.ID_PACIENTE
                             join u in db.USUARIO on o.ID_Usuario equals u.ID_USUARIO
                             where o.FechaRegistro > desde && o.FechaRegistro < hasta
                                 select new
                                 {
                                     o,p,u
                                 }).OrderByDescending(x => x.o.FechaRegistro).ToList();
                foreach (var item in orden)
                {
                    DTOOrden ordenes = new DTOOrden();
                    ordenes.CodigoOrden = item.o.ID_ORDEN1;
                    ordenes.CodigoPaciente = (long)item.o.CodPaciente;
                    ordenes.Paciente = item.p.Nombres + " " + item.p.Apellidos;
                    ordenes.Cedula = item.p.Identificacion;
                    ordenes.FechaRegistro = item.o.FechaRegistro;
                    ordenes.EsferaDer = item.o.EsferaDer;
                    ordenes.CilindroDer = item.o.CilindroDer;
                    ordenes.EjeDer = item.o.EjeDer;
                    ordenes.AddDer = item.o.AddDer;
                    ordenes.AltDer = item.o.AltDer;
                    ordenes.DnpDer = item.o.DnpDer;
                    ordenes.EsferaIz = item.o.EsferaIz;
                    ordenes.CilindroIz = item.o.CilindroIz;
                    ordenes.EjeIz = item.o.EjeIz;
                    ordenes.AddIz = item.o.AddIz;
                    ordenes.AltIz = item.o.AltIz;
                    ordenes.DnpIz = item.o.DnpIz;
                    ordenes.Mecanica = item.o.Mecanica;
                    ordenes.Mayor = item.o.Mayor;
                    ordenes.Horizontal = item.o.Horinzotal;
                    ordenes.Vertical = item.o.Verical;
                    ordenes.Puente = item.o.Puente;
                    ordenes.Armazon = item.o.CodArmazon;
                    ordenes.Material = item.o.Material;
                    ordenes.Filtros = item.o.Filtros;
                    ordenes.Tinturado = item.o.Tinturado;
                    ordenes.Observacionea = item.o.Observaciones;
                    ordenes.Usuario = item.u.Nombres + " " + item.u.Apellidos;
                    ordenes.FechaPedido = item.o.FechaPedido;
                    ordenes.FechaEntrega = item.o.FechaEntrega;
                    at.Add(ordenes);
                }
                return at;
            }
        }
        public static IEnumerable<object> OrdenTrabajoBuscar(String paciente)
        {
            List<DTOOrden> at = new List<DTOOrden>();
            using (var db = new Opt3000Entities())
            {
                var orden = (from o in db.Orden1
                             join p in db.PACIENTE on o.CodPaciente equals p.ID_PACIENTE
                             where p.Identificacion == paciente
                             select new
                             {
                                 o,
                                 p
                             }).OrderByDescending(x => x.o.FechaRegistro).ToList();
                foreach (var item in orden)
                {
                    DTOOrden ordenes = new DTOOrden();
                    ordenes.CodigoOrden = item.o.ID_ORDEN1;
                    ordenes.CodigoPaciente = (long)item.o.CodPaciente;
                    ordenes.Paciente = item.p.Nombres + " " + item.p.Apellidos;
                    ordenes.Cedula = item.p.Identificacion;
                    ordenes.FechaRegistro = item.o.FechaRegistro;
                    ordenes.EsferaDer = item.o.EsferaDer;
                    ordenes.CilindroDer = item.o.CilindroDer;
                    ordenes.EjeDer = item.o.EjeDer;
                    ordenes.AddDer = item.o.AddDer;
                    ordenes.AltDer = item.o.AltDer;
                    ordenes.DnpDer = item.o.DnpDer;
                    ordenes.EsferaIz = item.o.EsferaIz;
                    ordenes.CilindroIz = item.o.CilindroIz;
                    ordenes.EjeIz = item.o.EjeIz;
                    ordenes.AddIz = item.o.AddIz;
                    ordenes.AltIz = item.o.AltIz;
                    ordenes.DnpIz = item.o.DnpIz;
                    ordenes.Mecanica = item.o.Mecanica;
                    ordenes.Mayor = item.o.Mayor;
                    ordenes.Horizontal = item.o.Horinzotal;
                    ordenes.Vertical = item.o.Verical;
                    ordenes.Puente = item.o.Puente;
                    ordenes.Armazon = item.o.CodArmazon;
                    ordenes.Material = item.o.Material;
                    ordenes.Filtros = item.o.Filtros;
                    ordenes.Tinturado = item.o.Tinturado;
                    ordenes.Observacionea = item.o.Observaciones;
                    ordenes.FechaPedido = item.o.FechaPedido;
                    ordenes.FechaEntrega = item.o.FechaEntrega;
                    at.Add(ordenes);
                }
                return at;
            }
        }
        public static List<vAtenciones> vistaAuditoria(DateTime desde, DateTime hasta)
        {
            using (var db = new Opt3000Entities())
            {
                List<vAtenciones> x = (from c in db.vAtenciones
                                               where c.Fecha >= desde && c.Fecha <= hasta
                                               select c).ToList();
                return x;
            }
        }
        public static List<vAtenciones1> vistaAuditoria1(DateTime desde, DateTime hasta)
        {
            using (var db = new Opt3000Entities())
            {
                List<vAtenciones1> x = (from c in db.vAtenciones1
                                       where c.Fecha >= desde && c.Fecha <= hasta
                                       select c).ToList();
                return x;
            }
        }
        public static List<visFactura> vistaFactura(DateTime desde, DateTime hasta)
        {
            using (var db = new Opt3000Entities())
            {
                List<visFactura> x = (from c in db.visFactura
                                        where c.Fecha >= desde && c.Fecha <= hasta
                                        select c).ToList();
                return x;
            }
        }
        public static IEnumerable<object> OrdenLejana(DateTime desde, DateTime hasta)
        {
            List<DTOLejana> at = new List<DTOLejana>();
            using (var db = new Opt3000Entities())
            {
                var orden = (from o in db.ORDEN_LEJANA
                             join p in db.PACIENTE on o.CodPaciente equals p.ID_PACIENTE
                             join u in db.USUARIO on o.Id_Usuario equals u.ID_USUARIO
                             where o.FechaRegistro > desde && o.FechaRegistro < hasta
                             select new
                             {
                                 o,
                                 p,u
                             }).OrderByDescending(x => x.o.FechaRegistro).ToList();
                foreach (var item in orden)
                {
                    DTOLejana ordenes = new DTOLejana();
                    ordenes.CodigoOrden = item.o.ID_ORDEN3;
                    ordenes.CodigoPaciente = (long)item.o.CodPaciente;
                    ordenes.Paciente = item.p.Nombres + " " + item.p.Apellidos;
                    ordenes.Cedula = item.p.Identificacion;
                    ordenes.FechaRegistro = item.o.FechaRegistro;
                    ordenes.EsferaDer = item.o.EsferaDer;
                    ordenes.CilindroDer = item.o.CilindroDer;
                    ordenes.EjeDer = item.o.EjeDer;
                    ordenes.DnpDer = item.o.DnpDer;
                    ordenes.EsferaIz = item.o.EsferaIz;
                    ordenes.CilindroIz = item.o.CilindroIz;
                    ordenes.EjeIz = item.o.EjeIz;
                    ordenes.DnpIz = item.o.DnpIz;
                    ordenes.Metrica = item.o.Metrica;
                    ordenes.Mayor = item.o.Mayor;
                    ordenes.Horizontal = item.o.Horizontal;
                    ordenes.Vertical = item.o.Vertical;
                    ordenes.Puente = item.o.Puente;
                    ordenes.Armazon = item.o.CodArmazon;
                    ordenes.Material = item.o.Material;
                    ordenes.Filtros = item.o.Filtros;
                    ordenes.Tinturado = item.o.Tinturado;
                    ordenes.Observacionea = item.o.Observaciones;
                    ordenes.Usuario = item.u.Nombres + " " + item.u.Apellidos;
                    ordenes.CreacionOrden = item.o.FechaRegistro;
                    ordenes.Generado = item.o.Generado;
                    ordenes.Enviado = item.o.Enviado;
                    ordenes.Recibido = item.o.Recibido;
                    ordenes.Entregado = item.o.Entregado;
                    at.Add(ordenes);
                }
                return at;
            }
        }
        public static IEnumerable<object> OrdenCerca(DateTime desde, DateTime hasta)
        {
            List<DTOCerca> at = new List<DTOCerca>();
            using (var db = new Opt3000Entities())
            {
                var orden = (from o in db.ORDEN_VISION_CERCA
                             join p in db.PACIENTE on o.CodPaciente equals p.ID_PACIENTE
                             join u in db.USUARIO on o.Id_Usuario equals u.ID_USUARIO
                             where o.FechaRegistro > desde && o.FechaRegistro < hasta
                             select new
                             {
                                 o,
                                 p,u
                             }).OrderByDescending(x => x.o.FechaRegistro).ToList();
                foreach (var item in orden)
                {
                    DTOCerca ordenes = new DTOCerca();
                    ordenes.CodigoOrden = item.o.ID_ORDEN2;
                    ordenes.CodigoPaciente = (long)item.o.CodPaciente;
                    ordenes.Paciente = item.p.Nombres + " " + item.p.Apellidos;
                    ordenes.Cedula = item.p.Identificacion;
                    ordenes.FechaRegistro = item.o.FechaRegistro;
                    ordenes.EsferaDer = item.o.EsferaDer;
                    ordenes.CilindroDer = item.o.CilindroDer;
                    ordenes.EjeDer = item.o.EjeDer;
                    ordenes.DnpDer = item.o.DnpDer;
                    ordenes.AvccDer = item.o.AvccDer;
                    ordenes.EsferaIz = item.o.EsferaIz;
                    ordenes.CilindroIz = item.o.CilindroIz;
                    ordenes.EjeIz = item.o.EjeIz;
                    ordenes.DnpIz = item.o.DnpIz;
                    ordenes.AvccIz = item.o.AvccIz;
                    ordenes.Metrica = item.o.Metrica;
                    ordenes.Mayor = item.o.Mayor;
                    ordenes.Horizontal = item.o.Horizontal;
                    ordenes.Vertical = item.o.Vertical;
                    ordenes.Puente = item.o.Puente;
                    ordenes.Armazon = item.o.CodArmazon;
                    ordenes.Material = item.o.Material;
                    ordenes.Filtros = item.o.Filtros;
                    ordenes.Tinturado = item.o.Tinturado;
                    ordenes.Observacionea = item.o.Observaciones;
                    ordenes.Usuario = item.u.Nombres + " " + item.u.Apellidos;
                    ordenes.CreacionOrden = item.o.FechaRegistro;
                    ordenes.Generado = item.o.Generado;
                    ordenes.Enviado = item.o.Enviado;
                    ordenes.Recibido = item.o.Recibido;
                    ordenes.Entregado = item.o.Entregado;
                    at.Add(ordenes);
                }
                return at;
            }
        }
        public static IEnumerable<object> OrdenBlandos(DateTime desde, DateTime hasta)
        {
            List<DTOBlandos> at = new List<DTOBlandos>();
            using (var db = new Opt3000Entities())
            {
                var orden = (from o in db.ORDEN_LENTESBLANDOS
                             join p in db.PACIENTE on o.CodPaciente equals p.ID_PACIENTE
                             join u in db.USUARIO on o.Id_Usuario equals u.ID_USUARIO
                             where o.FechaRegistro > desde && o.FechaRegistro < hasta
                             select new
                             {
                                 o,
                                 p,u
                             }).OrderByDescending(x => x.o.FechaRegistro).ToList();
                foreach (var item in orden)
                {
                    DTOBlandos ordenes = new DTOBlandos();
                    ordenes.CodigoOrden = item.o.ID_ORDEN4;
                    ordenes.CodigoPaciente = (long)item.o.CodPaciente;
                    ordenes.Paciente = item.p.Nombres + " " + item.p.Apellidos;
                    ordenes.Cedula = item.p.Identificacion;
                    ordenes.FechaRegistro = item.o.FechaRegistro;
                    ordenes.EsferaDer = item.o.EsferaDer;
                    ordenes.CilindroDer = item.o.CilindroDer;
                    ordenes.EjeDer = item.o.EjeDer;
                    ordenes.EsferaIz = item.o.EsferaIz;
                    ordenes.CilindroIz = item.o.CilindroIz;
                    ordenes.EjeIz = item.o.EjeIz;
                    ordenes.Material = item.o.Material;
                    ordenes.Filtros = item.o.Filtros;
                    ordenes.Observacionea = item.o.Observaciones;
                    ordenes.Usuario = item.u.Nombres+" "+item.u.Apellidos;
                    ordenes.CreacionOrden = item.o.FechaRegistro;
                    ordenes.Generado = item.o.Generado;
                    ordenes.Enviado = item.o.Enviado;
                    ordenes.Recibido = item.o.Recibido;
                    ordenes.Entregado = item.o.Entregado;
                    at.Add(ordenes);
                }
                return at;
            }
        }
    }
}
