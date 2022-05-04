using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opt3000.Entidades;

namespace Opt3000.Vista.Utilitarios.Reportes
{
    public partial class Reporteador : Form
    {
        string orden = "";
        OrdenGeneral obj = new OrdenGeneral();
        Entidades.Garantias objGar = new Entidades.Garantias();
        Certificado cer = new Certificado();
        AnticipoRecibo ant = new AnticipoRecibo();
        public Reporteador()
        {
            InitializeComponent();
        }
        public Reporteador(OrdenGeneral _obj = null, string _orden = "", Certificado _cer = null, AnticipoRecibo _ant = null, Entidades.Garantias _gar = null)
        {
            InitializeComponent();
            obj = _obj;
            orden = _orden;
            cer = _cer;
            ant = _ant;
            objGar = _gar;
            Imprime();
        }
       
        public void Imprime()
        {
            try
            {
                #region Orden General
                if (orden == "OrdenGeneral")
                {
                    OrdenBifocalDatos ord = new OrdenBifocalDatos();
                    DataRow drOrden;
                    drOrden = ord.Tables["Orden1"].NewRow();
                    drOrden["Imagen"] = obj.imagen.ToString();
                    drOrden["Laboratorio"] = obj.laboratorio.ToString();
                    drOrden["Paciente"] = obj.paciente.ToString();
                    drOrden["FechaPedido"] = obj.fechaPedido.ToString();
                    drOrden["FechaEntrega"] = obj.fechaEntrega.ToString();
                    drOrden["EsferaDer"] = obj.esferaDer.ToString();
                    drOrden["CilindroDer"] = obj.cilindroDer.ToString();
                    drOrden["EjeDer"] = obj.ejeDer.ToString();
                    drOrden["AddDer"] = obj.addDer.ToString();
                    drOrden["AltDer"] = obj.altDer.ToString();
                    drOrden["DnpDer"] = obj.dnpDer.ToString();
                    drOrden["EsferaIz"] = obj.esferaIz.ToString();
                    drOrden["CilindroIz"] = obj.cilindroIz.ToString();
                    drOrden["EjeIz"] = obj.ejeIz.ToString();
                    drOrden["AddIz"] = obj.addIz.ToString();
                    drOrden["AltIz"] = obj.altIz.ToString();
                    drOrden["DnpIz"] = obj.dnpIz.ToString();
                    drOrden["Metrica"] = obj.metrica.ToString();
                    drOrden["Mayor"] = obj.mayor.ToString();
                    drOrden["Horizontal"] = obj.horizontal.ToString();
                    drOrden["Vertical"] = obj.vertical.ToString();
                    drOrden["Puente"] = obj.puente.ToString();
                    drOrden["Armazon"] = obj.armazon.ToString();
                    drOrden["Material"] = obj.material.ToString();
                    drOrden["Filtro"] = obj.filtros.ToString();
                    drOrden["Tinturado"] = obj.tinturado.ToString();
                    drOrden["Observacion"] = obj.observaciones.ToString();
                    drOrden["PedidoPor"] = obj.pedidoPor.ToString();
                    drOrden["Numerador"] = obj.numOrden.ToString();
                    ord.Tables["Orden1"].Rows.Add(drOrden);

                    OrdenBifocal myReport = new OrdenBifocal();
                    myReport.Refresh();
                    myReport.SetDataSource(ord);
                    crystalReportViewer1.ReportSource = myReport;
                    crystalReportViewer1.RefreshReport();
                }
                #endregion

                #region Orden Visión de Cerca
                if (orden == "VisionCerca")
                {
                    OrdenVisionCercanaDatos ord = new OrdenVisionCercanaDatos();
                    DataRow drOrden;
                    drOrden = ord.Tables["OrdenVC"].NewRow();
                    drOrden["Imagen"] = obj.imagen.ToString();
                    drOrden["Laboratorio"] = obj.laboratorio.ToString();
                    drOrden["Paciente"] = obj.paciente.ToString();
                    drOrden["FechaPedido"] = obj.fechaPedido.ToString();
                    drOrden["FechaEntrega"] = obj.fechaEntrega.ToString();
                    drOrden["EsferaDer"] = obj.esferaDer.ToString();
                    drOrden["CilindroDer"] = obj.cilindroDer.ToString();
                    drOrden["EjeDer"] = obj.ejeDer.ToString();
                    drOrden["AltDer"] = obj.altDer.ToString();
                    drOrden["DnpDer"] = obj.dnpDer.ToString();
                    drOrden["EsferaIz"] = obj.esferaIz.ToString();
                    drOrden["CilindroIz"] = obj.cilindroIz.ToString();
                    drOrden["EjeIz"] = obj.ejeIz.ToString();
                    drOrden["AltIz"] = obj.altIz.ToString();
                    drOrden["DnpIz"] = obj.dnpIz.ToString();
                    drOrden["Metrica"] = obj.metrica.ToString();
                    drOrden["Mayor"] = obj.mayor.ToString();
                    drOrden["Horizontal"] = obj.horizontal.ToString();
                    drOrden["Vertical"] = obj.vertical.ToString();
                    drOrden["Puente"] = obj.puente.ToString();
                    drOrden["Armazon"] = obj.armazon.ToString();
                    drOrden["Material"] = obj.material.ToString();
                    drOrden["Filtro"] = obj.filtros.ToString();
                    drOrden["Tinturado"] = obj.tinturado.ToString();
                    drOrden["Observacion"] = obj.observaciones.ToString();
                    drOrden["Usuario"] = obj.pedidoPor.ToString();
                    drOrden["Numerador"] = obj.numOrden.ToString();
                    ord.Tables["OrdenVC"].Rows.Add(drOrden);

                    OrdenVisonCercana myReport = new OrdenVisonCercana();
                    myReport.Refresh();
                    myReport.SetDataSource(ord);
                    crystalReportViewer1.ReportSource = myReport;
                    crystalReportViewer1.RefreshReport();
                }
                #endregion

                #region Orden Visión Lejana
                if (orden == "VisionLejana")
                {
                    OrdenVisionLejanaDatos ord = new OrdenVisionLejanaDatos();
                    DataRow drOrden;
                    drOrden = ord.Tables["OrdenVL"].NewRow();
                    drOrden["Imagen"] = obj.imagen.ToString();
                    drOrden["Laboratorio"] = obj.laboratorio.ToString();
                    drOrden["Paciente"] = obj.paciente.ToString();
                    drOrden["FechaPedido"] = obj.fechaPedido.ToString();
                    drOrden["FechaEntrega"] = obj.fechaEntrega.ToString();
                    drOrden["EsferaDer"] = obj.esferaDer.ToString();
                    drOrden["CilindroDer"] = obj.cilindroDer.ToString();
                    drOrden["EjeDer"] = obj.ejeDer.ToString();
                    drOrden["DnpDer"] = obj.dnpDer.ToString();
                    drOrden["EsferaIz"] = obj.esferaIz.ToString();
                    drOrden["CilindroIz"] = obj.cilindroIz.ToString();
                    drOrden["EjeIz"] = obj.ejeIz.ToString();
                    drOrden["DnpIz"] = obj.dnpIz.ToString();
                    drOrden["Metrica"] = obj.metrica.ToString();
                    drOrden["Mayor"] = obj.mayor.ToString();
                    drOrden["Horizontal"] = obj.horizontal.ToString();
                    drOrden["Vertical"] = obj.vertical.ToString();
                    drOrden["Puente"] = obj.puente.ToString();
                    drOrden["Armazon"] = obj.armazon.ToString();
                    drOrden["Material"] = obj.material.ToString();
                    drOrden["Filtro"] = obj.filtros.ToString();
                    drOrden["Tinturado"] = obj.tinturado.ToString();
                    drOrden["Observacion"] = obj.observaciones.ToString();
                    drOrden["Usuario"] = obj.pedidoPor.ToString();
                    drOrden["Numerador"] = obj.numOrden.ToString();
                    ord.Tables["OrdenVL"].Rows.Add(drOrden);

                    OrdenVisionLejana myReport = new OrdenVisionLejana();
                    myReport.Refresh();
                    myReport.SetDataSource(ord);
                    crystalReportViewer1.ReportSource = myReport;
                    crystalReportViewer1.RefreshReport();
                }
                #endregion

                #region Orden VisionLentesBlandos
                if (orden == "VisionLentesBlandos")
                {
                    OrdenVisionLejanaDatos ord = new OrdenVisionLejanaDatos();
                    DataRow drOrden;
                    drOrden = ord.Tables["OrdenVL"].NewRow();
                    drOrden["Imagen"] = obj.imagen.ToString();
                    drOrden["Laboratorio"] = obj.laboratorio.ToString();
                    drOrden["Paciente"] = obj.paciente.ToString();
                    drOrden["FechaPedido"] = obj.fechaPedido.ToString();
                    drOrden["FechaEntrega"] = obj.fechaEntrega.ToString();
                    drOrden["EsferaDer"] = obj.esferaDer.ToString();
                    drOrden["CilindroDer"] = obj.cilindroDer.ToString();
                    drOrden["EjeDer"] = obj.ejeDer.ToString();
                    drOrden["DnpDer"] = obj.dnpDer.ToString();
                    drOrden["EsferaIz"] = obj.esferaIz.ToString();
                    drOrden["CilindroIz"] = obj.cilindroIz.ToString();
                    drOrden["EjeIz"] = obj.ejeIz.ToString();
                    drOrden["DnpIz"] = obj.dnpIz.ToString();
                    
                    drOrden["Material"] = obj.material.ToString();
                    drOrden["Filtro"] = obj.filtros.ToString();
                    
                    drOrden["Observacion"] = obj.observaciones.ToString();
                    drOrden["Usuario"] = obj.pedidoPor.ToString();
                    drOrden["Numerador"] = obj.numOrden.ToString();
                    ord.Tables["OrdenVL"].Rows.Add(drOrden);

                    OrdenVisionLentesBlandos myReport = new OrdenVisionLentesBlandos();
                    myReport.Refresh();
                    myReport.SetDataSource(ord);
                    crystalReportViewer1.ReportSource = myReport;
                    crystalReportViewer1.RefreshReport();
                }
                #endregion


                #region Orden Lentes Contacto Especiales
                if (orden == "LentesEspeciales")
                {
                    OrdenContactoEspecialesDatos ord = new OrdenContactoEspecialesDatos();
                    DataRow drOrden;
                    drOrden = ord.Tables["OrdenContactoEspeciales"].NewRow();
                    drOrden["Imagen"] = obj.imagen.ToString();
                    drOrden["Laboratorio"] = obj.laboratorio.ToString();
                    drOrden["Paciente"] = obj.paciente.ToString();
                    drOrden["FechaPedido"] = obj.fechaPedido.ToString();
                    drOrden["FechaEntrega"] = obj.fechaEntrega.ToString();
                    drOrden["CurvaBaseDer"] = obj.esferaDer.ToString();
                    drOrden["PoderDer"] = obj.cilindroDer.ToString();
                    drOrden["DiametroDer"] = obj.ejeDer.ToString();
                    drOrden["ColorDer"] = obj.dnpDer.ToString();
                    drOrden["CurvaBaseIz"] = obj.esferaIz.ToString();
                    drOrden["PoderIz"] = obj.cilindroIz.ToString();
                    drOrden["DiametroIz"] = obj.ejeIz.ToString();
                    drOrden["ColorIz"] = obj.dnpIz.ToString();
                    drOrden["Material"] = obj.material.ToString();
                    drOrden["Observacion"] = obj.observaciones.ToString();
                    drOrden["Usuario"] = obj.pedidoPor.ToString();
                    drOrden["Numerador"] = obj.numOrden.ToString();
                    ord.Tables["OrdenContactoEspeciales"].Rows.Add(drOrden);

                    OrdenVisionLejana myReport = new OrdenVisionLejana();
                    myReport.Refresh();
                    myReport.SetDataSource(ord);
                    crystalReportViewer1.ReportSource = myReport;
                    crystalReportViewer1.RefreshReport();
                }
                #endregion

                #region Certificado
                if (orden == "Certificado")
                {
                    CertificadoDatos cert = new CertificadoDatos();
                    DataRow drCertificado;
                    drCertificado = cert.Tables["Certificado"].NewRow();
                    drCertificado["Paciente"] = cer.paciente.ToString();
                    drCertificado["Edad"] = cer.edad.ToString();
                    drCertificado["ODLejosEsfera"] = cer.ODLejosEsfera.ToString();
                    drCertificado["OILejosesfera"] = cer.OILejosesfera.ToString();
                    drCertificado["ODLejosCilindro"] = cer.ODLejosCilindro.ToString();
                    drCertificado["OILejosCilindro"] = cer.OILejosCilindro.ToString();
                    drCertificado["ODLejosEje"] = cer.ODLejosEje.ToString();
                    drCertificado["OILejosEje"] = cer.OILejosEje.ToString();
                    drCertificado["ODLecturaEsfera"] = cer.ODLecturaEsfera.ToString();
                    drCertificado["OILecturaEsfera"] = cer.OILecturaEsfera.ToString();
                    drCertificado["ODLecturaCilindro"] = cer.ODLecturaCilindro.ToString();
                    drCertificado["OILecturaCilindro"] = cer.OILecturaCilindro.ToString();
                    drCertificado["Cie10OD"] = cer.Cie10OD.ToString();
                    drCertificado["Cie10OI"] = cer.Cie10OI.ToString();
                    drCertificado["Recomendaciones"] = cer.Recomendaciones.ToString();
                    drCertificado["ODavlsc"] = cer.ODavlsc.ToString();
                    drCertificado["OIavlsc"] = cer.OIavlsc.ToString();
                    drCertificado["ODavlcc"] = cer.ODavlcc.ToString();
                    drCertificado["OIavlcc"] = cer.OIavlcc.ToString();
                    drCertificado["ODavcsc"] = cer.ODavcsc.ToString();
                    drCertificado["OIavcsc"] = cer.OIavcsc.ToString();
                    drCertificado["ODavccc"] = cer.ODavccc.ToString();
                    drCertificado["OIavccc"] = cer.OIavccc.ToString();
                    drCertificado["Oftalmoscopia"] = cer.oftalmica.ToString();
                    drCertificado["VisionColor"] = cer.visionColor.ToString();
                    drCertificado["ODAddEsfera"] = cer.ODAddEsfera.ToString();
                    drCertificado["OIAddEsfera"] = cer.OIAddEsfera.ToString();
                    cert.Tables["Certificado"].Rows.Add(drCertificado);

                    CertificadoReporte myReport = new CertificadoReporte();
                    myReport.Refresh();
                    myReport.SetDataSource(cert);
                    crystalReportViewer1.ReportSource = myReport;
                    crystalReportViewer1.RefreshReport();
                }
                if (orden == "Anticipos")
                {
                    ReciboAnticipo anti = new ReciboAnticipo();
                    DataRow drAnticipo;
                    drAnticipo = anti.Tables["Anticipo"].NewRow();
                    drAnticipo["Paciente"] = ant.paciente.ToString();
                    drAnticipo["Responsable"] = ant.responsable.ToString();
                    drAnticipo["Valor"] = ant.valor.ToString();
                    drAnticipo["Atencion"] = ant.atencion.ToString();
                    drAnticipo["Cedula"] = ant.cedula.ToString();
                    drAnticipo["FormaPago"] = ant.formaPago.ToString();
                    drAnticipo["Numero"] = ant.numero.ToString();
                    drAnticipo["Detalle"] = ant.detalle.ToString();
                    drAnticipo["Fecha"] = ant.fecha.ToString();

                    anti.Tables["Anticipo"].Rows.Add(drAnticipo);

                    RecivoAnticipoReporte myReport = new RecivoAnticipoReporte();
                    myReport.Refresh();
                    myReport.SetDataSource(anti);
                    crystalReportViewer1.ReportSource = myReport;
                    crystalReportViewer1.RefreshReport();

                }
                if( orden == "Garantias")
                {
                    GarantiaDatos garan = new GarantiaDatos();
                    DataRow drGarantia;
                    drGarantia = garan.Tables["GarantiaTable"].NewRow();
                    drGarantia["numFactura"] = objGar.numFactura.ToString();
                    drGarantia["fechaFactura"] = objGar.fechaFactura.ToString();
                    drGarantia["identificacion"] = objGar.identificacion.ToString();
                    drGarantia["atePac"] = objGar.atePac.ToString();
                    drGarantia["paciente"] = objGar.paciente.ToString();
                    drGarantia["detalle"] = objGar.detalle.ToString();
                    drGarantia["codigo"] = objGar.codigo.ToString();
                    drGarantia["cantidad"] = objGar.cantidad.ToString();
                    drGarantia["pvp"] = objGar.pvp.ToString();
                    drGarantia["comentario"] = objGar.comentario.ToString();

                    garan.Tables["GarantiaTable"].Rows.Add(drGarantia);

                    GarantiaReporte myReport = new GarantiaReporte();
                    myReport.Refresh();
                    myReport.SetDataSource(garan);
                    crystalReportViewer1.ReportSource = myReport;
                    crystalReportViewer1.RefreshReport();
                }
                #endregion
            }
            catch (Exception )
            {
                throw;
            }
        }


    }
}
