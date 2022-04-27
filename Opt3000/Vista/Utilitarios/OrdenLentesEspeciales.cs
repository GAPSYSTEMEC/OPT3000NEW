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
using Opt3000.Entidades;
using Opt3000.Vista.Utilitarios.Reportes;

namespace Opt3000.Vista.Utilitarios
{
    public partial class OrdenLentesEspeciales : Form
    {
        public OrdenLentesEspeciales()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            OrdenGeneral obj = new OrdenGeneral();
            obj.numOrden = lblNumeroOrden.Text;
            obj.imagen = "";
            obj.laboratorio = txtLaboratorio.Text;
            obj.paciente = txtNombrePaciente.Text;
            obj.fechaPedido = dt_FechaPedido.Value.Date.ToString("dd-MM-yyyy");
            obj.fechaEntrega = dt_FechaEntrega.Value.Date.ToString("dd-MM-yyyy");
            obj.esferaDer = txtCurvaODd.Text;
            obj.ejeDer = txtPoderODd.Text;
            obj.cilindroDer = txtDiametroODd.Text;
            obj.dnpDer = txtColorOD.Text;
            obj.esferaIz = txtCurvaOId.Text;
            obj.ejeIz = txtPoderOId.Text;
            obj.cilindroIz = txtDiametroOId.Text;
            obj.dnpIz = txtColorOI.Text;
            obj.material = txtMaterial.Text;
            obj.observaciones = txtObservacion.Text;
            obj.pedidoPor = Cesion.usuario;
            Reporteador frm = new Reporteador(obj, "LentesEspeciales");
            frm.Show();
        }
    }
}
