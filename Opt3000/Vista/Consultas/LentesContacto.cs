using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Opt3000.Negocio;
using Opt3000.Vista.Utilitarios;
using Opt3000.BaseDatos;
namespace Opt3000.Vista.Consultas
{
    public partial class LentesContacto : Form
    {
        bool calculador = false;
        public LentesContacto()
        {
            InitializeComponent();
        }

        #region botones

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (FuncionesBasicas.getInstance().CerrarFormulario("LA ATENCIÓN"))
                this.Close();
        }

        //public void RX_EN_USO()
        //{
        //    Int64 atencionAnterior = NegConsultas.getInstance().AtencionMaximaPaciente(Convert.ToInt64(lblHc.Text));
        //    RX_FINAL objRx = new RX_FINAL();
        //    objRx = NegConsultas.getInstance().CargaRxFinal(atencionAnterior, "D");
        //    if (objRx != null)
        //    {
        //        if (objRx != null)
        //        {
        //            if (objRx.Esfera == "")
        //            {
        //                txtEsferaRXusoOD.Text = objRx.Esfera;
        //            }
        //            else
        //                if (objRx.A_D_D != "")
        //                txtEsferaRXusoOD.Text = objRx.Esfera.ToString();
        //            //txtEsferaRXusoOD.Text = (Convert.ToDecimal(objRx.Esfera) + Convert.ToDecimal(objRx.A_D_D)).ToString();
        //            txtCilindroRXusoOD.Text = objRx.Cilindro;
        //            txtEjeRXusoOD.Text = objRx.Eje;
        //            txtAVLRXusoOD.Text = objRx.AVL;
        //            txtAVCRXusoOD.Text = objRx.AVC;
        //            txtAddRXusoOD.Text = objRx.A_D_D;
        //        }
        //        //txtAltRXod.Text = objRx.ALT;
        //        //txtDnpRXod.Text = objRx.DNP_DP;
        //        objRx = new RX_FINAL();
        //        objRx = NegConsultas.getInstance().CargaRxFinal(atencionAnterior, "I");
        //        if (objRx != null)
        //        {
        //            if (objRx.Esfera == "")
        //            {
        //                txtEsferaRXusoOI.Text = "";
        //            }
        //            else
        //                if (objRx.A_D_D != "")
        //                txtEsferaRXusoOI.Text = objRx.Esfera.ToString();
        //            txtCilindroRXusoOI.Text = objRx.Cilindro;
        //            txtEjeRXusoOI.Text = objRx.Eje;
        //            txtAVLRXusoOI.Text = objRx.AVL;
        //            txtAVCRXusoOI.Text = objRx.AVC;
        //            txtAddRXusoOI.Text = objRx.A_D_D;
        //        }
        //        txtCilindroRXusoOD.Enabled = false;
        //        txtEjeRXusoOD.Enabled = false;
        //        txtEsferaRXusoOD.Enabled = false;
        //        txtAVCRXusoOD.Enabled = false;
        //        txtAddRXusoOD.Enabled = false;
        //        txtCilindroRXusoOI.Enabled = false;
        //        txtEjeRXusoOI.Enabled = false;
        //        txtEsferaRXusoOI.Enabled = false;
        //        txtAVCRXusoOI.Enabled = false;
        //        txtAddRXusoOI.Enabled = false;
        //    }
        //}

        public void RX_EN_USO()
        {
            Int64 atencionAnterior = NegConsultas.getInstance().AtencionMaximaPaciente(Convert.ToInt64(lblHc.Text));
            RX_FINAL objRx = new RX_FINAL();
            objRx = NegConsultas.getInstance().CargaRxFinal(atencionAnterior, "D");
            if (objRx != null)
            {
                if (objRx != null)
                {
                    if (objRx.Esfera != "")
                    {
                        txtEsferaRXusoOD.Text = objRx.Esfera;
                        txtCilindroRXusoOD.Text = objRx.Cilindro;
                        txtEjeRXusoOD.Text = objRx.Eje;
                        txtAVLRXusoOD.Text = objRx.AVL;
                        txtAVCRXusoOD.Text = objRx.AVC;
                        txtAddRXusoOD.Text = objRx.A_D_D;
                    }

                }
                //txtAltRXod.Text = objRx.ALT;
                //txtDnpRXod.Text = objRx.DNP_DP;
                objRx = new RX_FINAL();
                objRx = NegConsultas.getInstance().CargaRxFinal(atencionAnterior, "I");
                if (objRx != null)
                {
                    if (objRx.Esfera != "")
                    {
                        txtEsferaRXusoOI.Text = objRx.Esfera;
                        txtCilindroRXusoOI.Text = objRx.Cilindro;
                        txtEjeRXusoOI.Text = objRx.Eje;
                        txtAVLRXusoOI.Text = objRx.AVL;
                        txtAVCRXusoOI.Text = objRx.AVC;
                        txtAddRXusoOI.Text = objRx.A_D_D;
                    }
                }
                txtCilindroRXusoOD.Enabled = false;
                txtEjeRXusoOD.Enabled = false;
                txtEsferaRXusoOD.Enabled = false;
                txtAVCRXusoOD.Enabled = false;
                txtAddRXusoOD.Enabled = false;
                txtCilindroRXusoOI.Enabled = false;
                txtEjeRXusoOI.Enabled = false;
                txtEsferaRXusoOI.Enabled = false;
                txtAVCRXusoOI.Enabled = false;
                txtAddRXusoOI.Enabled = false;
            }
        }


        PACIENTE objPaciente = new PACIENTE();
        private void btnBusca_Click(object sender, EventArgs e)
        {
            BuscadorPacientes frmBuscador = new BuscadorPacientes();
            frmBuscador.ShowDialog();
            objPaciente = NegConsultas.getInstance().CargaPaciente(frmBuscador.cedula);
            if (objPaciente != null)
            {
                Int64 maximo = NegConsultas.getInstance().MaxAtencion() + 1;
                lblAtencion.Text = maximo.ToString();
                lblNombrePaciente.Text = objPaciente.Apellidos + " " + objPaciente.Nombres;
                lblIdentificacion.Text = objPaciente.Identificacion;
                lblOcupacion.Text = objPaciente.Ocupacion;
                lblHc.Text = objPaciente.ID_PACIENTE.ToString();
                lblEdad.Text = FuncionesBasicas.getInstance().CalculaEdad(objPaciente.F_Nacimiento).ToString();
                lblFecha.Text = DateTime.Now.ToString();
                CONVENIO objConvenio = new CONVENIO();
                objConvenio = NegConsultas.getInstance().ConsultaConvenio(objPaciente.ID_TIPO);
                lblTipo.Text = objConvenio.Detalle;
                p_PacienteDatos.Visible = true;
                p_Atencion.Enabled = true;
                btnBusca.Visible = false;
                btnGuardar.Visible = true;
                btnCancelar.Visible = true;
                List<ATENCION> lista = new List<ATENCION>();
                lista = NegConsultas.getInstance().CargaAtenciones(objPaciente.ID_PACIENTE, "LENTES");
                if (lista.Count > 0)
                {
                    AbrirAtenciones(objPaciente.ID_PACIENTE);
                    calculador = true;
                }
                else
                {
                    txtRecomendaciones.Text = "USO PERMANENTE. \r\nLUBRICACIÓN OCULAR.\r\nCONTROL EN UN AÑO.";
                    RX_EN_USO();
                }

            }
            else
            {
                RX_EN_USO();
            }

        }

        public void AbrirAtenciones(Int64 idPac)
        {
            BuscadorAtencion frmBuscaAtencion = new BuscadorAtencion(idPac, "LENTES");
            frmBuscaAtencion.ShowDialog();
            ATENCION objAtencion = new ATENCION();
            objAtencion = NegConsultas.getInstance().CargaAtencion(Convert.ToInt64(frmBuscaAtencion.ateCodigo));
            if (objAtencion != null)
            {
                lblAtencion.Text = objAtencion.ID_ATENCION.ToString();
                txtObservaciones.Text = objAtencion.Observaciones;
                txtDiagnosticoOjoDer.Text = objAtencion.DiagnosticoOD;
                txtDiagnosticoOjoIz.Text = objAtencion.DiagnosticoOI;
                txtRecomendaciones.Text = objAtencion.Recomendaciones;
                lblFecha.Text = objAtencion.Fecha_Creacion.ToString();
                ADAPTACION_LENTES objAdaptacion = new ADAPTACION_LENTES();
                objAdaptacion = NegConsultas.getInstance().ConsultaAdaptacion(objAtencion.ID_ATENCION);
                txtPupilarOD.Text = objAdaptacion.PupilarOD;
                txtPupilarOI.Text = objAdaptacion.PupilarOI;
                txtCornealOD.Text = objAdaptacion.CornealOD;
                txtCornealOI.Text = objAdaptacion.CornealOI;
                txtPaipebralOD.Text = objAdaptacion.PaipebralOD;
                txtPaipebralOI.Text = objAdaptacion.PaipebralOI;
                txtBut.Text = objAdaptacion.But;
                txtShirmer.Text = objAdaptacion.Shirmer;

                RX_FINAL objRx = new RX_FINAL();
                objRx = NegConsultas.getInstance().CargaRxFinal(objAtencion.ID_ATENCION, "D");
                txtEsferaRXod.Text = objRx.Esfera;
                txtCilindroRXod.Text = objRx.Cilindro;
                txtEjeRXod.Text = objRx.Eje;
                txtAddRXod.Text = objRx.A_D_D;
                txtAvlRXod.Text = objRx.AVL;
                txtAvcRXod.Text = objRx.AVC;
                txtAltRXod.Text = objRx.ALT;
                txtDnpRXod.Text = objRx.DNP_DP;
                objRx = new RX_FINAL();
                objRx = NegConsultas.getInstance().CargaRxFinal(objAtencion.ID_ATENCION, "I");
                txtEsferaRXoi.Text = objRx.Esfera;
                txtCilindroRXoi.Text = objRx.Cilindro;
                txtEjeRXoi.Text = objRx.Eje;
                txtAddRXoi.Text = objRx.A_D_D;
                txtAvlRXoi.Text = objRx.AVL;
                txtAvcRXoi.Text = objRx.AVC;
                txtAltRXoi.Text = objRx.ALT;
                txtDnpRXoi.Text = objRx.DNP_DP;

                LENTE_PRUEBA objLentePrueba = new LENTE_PRUEBA();
                objLentePrueba = NegConsultas.getInstance().ConsultaLentesPrueba(objAtencion.ID_ATENCION);
                txtCurvaBaseOD.Text = objLentePrueba.BaseOD;
                txtCurvaBaseOI.Text = objLentePrueba.BaseOI;
                txtPoderOD.Text = objLentePrueba.PoderOD;
                txtPoderOI.Text = objLentePrueba.PoderOI;
                txtMaterialOD.Text = objLentePrueba.MaterialOD;
                txtMaterialOI.Text = objLentePrueba.MaterialOI;
                txtDiametroOD.Text = objLentePrueba.DiametroOD;
                txtDiametroOI.Text = objLentePrueba.DiametroOI;
                txtRefraccionOD.Text = objLentePrueba.RefraccionOD;
                txtRefraccionOI.Text = objLentePrueba.RefraccionOI;
                txtAgudezaOD.Text = objLentePrueba.VisualOD;
                txtAgudezaOI.Text = objLentePrueba.VisualOI;

                LENTE_DEFINITIVO objLenteDef = new LENTE_DEFINITIVO();
                objLenteDef = NegConsultas.getInstance().ConsultaLentesDefinitivo(objAtencion.ID_ATENCION);
                txtCurvaODd.Text = objLenteDef.BaseOD;
                txtCurvaOId.Text = objLenteDef.BaseOI;
                txtPoderODd.Text = objLenteDef.PoderOD;
                txtPoderOId.Text = objLenteDef.PoderOI;
                txtDiametroODd.Text = objLenteDef.DiametroOD;
                txtDiametroOId.Text = objLenteDef.DiametroOI;
                txtMaterialODd.Text = objLenteDef.MaterialOD;
                txtMaterialOId.Text = objLenteDef.MaterialOI;

                LENTE_DEFINITIVO objLenteDefinitivo = new LENTE_DEFINITIVO();


                CalcularValores();
                RX_EN_USO();
                p_Atencion.Enabled = false;
                btnGuardar.Visible = false;
                btnAbiriAtenciones.Visible = true;
                btnCancelar.Visible = true;
                btnNuevo.Visible = true;
            }
        }

        private void btnCalculadora_Click(object sender, EventArgs e)
        {
            calculador = true;
            Calculadora frm = new Calculadora();
            frm.ShowDialog();
            if (txtEsferaRXod.Text == "")
            {
                txtEsferaRXod.Text = frm.esfera;
                txtCilindroRXod.Text = frm.cilindro;
                txtEjeRXod.Text = frm.eje;
            }
            else
            {
                txtEsferaRXoi.Text = frm.esfera;
                txtCilindroRXoi.Text = frm.cilindro;
                txtEjeRXoi.Text = frm.eje;
            }
            //CalcularValores();

            //if (ValidaControles())
            //{
            //BloquearControles();
            //}
        }
        public void CalcularValores()
        {
            decimal valorEsfera = Convert.ToDecimal(txtEsferaRXod.Text);
            decimal valorAdd = Convert.ToDecimal(txtAddRXod.Text);
            if ((valorEsfera + valorAdd) > 0)
            {
                txtEsferaVCod.Text = "+" + (valorEsfera + valorAdd).ToString();
            }
            else
            {
                txtEsferaVCod.Text = (valorEsfera + valorAdd).ToString();
            }
            txtCilindroVCod.Text = txtCilindroRXod.Text;
            txtEjeVCod.Text = txtEjeRXod.Text;
            txtDnpVCod.Text = txtDnpRXod.Text;
            txtAvcVCod.Text = txtAvcRXod.Text;

            valorEsfera = Convert.ToDecimal(txtEsferaRXoi.Text);
            valorAdd = Convert.ToDecimal(txtAddRXoi.Text);
            if ((valorEsfera + valorAdd) > 0)
            {
                txtEsferaVCoi.Text = "+" + (valorEsfera + valorAdd).ToString();
            }
            else
            {
                txtEsferaVCoi.Text = (valorEsfera + valorAdd).ToString();
            }
            txtCilindroVCoi.Text = txtCilindroRXoi.Text;
            txtEjeVCoi.Text = txtEjeRXoi.Text;
            txtDnpVCoi.Text = txtDnpRXoi.Text;
            txtAvcVCoi.Text = txtAvcRXoi.Text;
        }

        #endregion

        #region Funciones

        private bool ValidaControles()
        {
            bool ok = false;
            string error = "";
            int correcto = 0;
            if (FuncionesBasicas.getInstance().FormatoControles(txtEsferaRXod.Text))
            {
                txtEsferaRXod.BackColor = Color.White;
                correcto++;
            }
            else
            {
                txtEsferaRXod.BackColor = Color.LightPink;
                error += "> El valor de ESFERA del ojo derecho no cumple con la estructura requerida\r\n\t";
                correcto--;
            }
            if (FuncionesBasicas.getInstance().FormatoControles(txtCilindroRXod.Text))
            {
                txtCilindroRXod.BackColor = Color.White;
                correcto++;
            }
            else
            {
                txtCilindroRXod.BackColor = Color.LightPink;
                error += "> El valor de CILINDRO del ojo derecho no cumple con la estructura requerida\r\n\t";
                correcto--;
            }
            if (txtEjeRXod.Text != "")
            {
                txtEjeRXod.BackColor = Color.White;
                correcto++;
            }
            else
            {
                txtEjeRXod.BackColor = Color.LightPink;
                error += "> El valor de EJE del ojo derecho no cumple con la estructura requerida\r\n\t";
                correcto--;
            }
            if (FuncionesBasicas.getInstance().FormatoControles(txtAddRXod.Text))
            {
                txtAddRXod.BackColor = Color.White;
                correcto++;
            }
            else
            {
                txtAddRXod.BackColor = Color.LightPink;
                error += "> El valor de ADD del ojo derecho no cumple con la estructura requerida\r\n\t";
                correcto--;
            }
            if (txtAvlRXod.Text != "")
            {
                txtAvlRXod.BackColor = Color.White;
                correcto++;
            }
            else
            {
                txtAvlRXod.BackColor = Color.LightPink;
                error += "> El valor de AVL.cc del ojo derecho no cumple con la estructura requerida\r\n\t";
                correcto--;
            }
            if (txtAvcRXod.Text != "")
            {
                txtAvcRXod.BackColor = Color.White;
                correcto++;
            }
            else
            {
                txtAvcRXod.BackColor = Color.LightPink;
                error += "> El valor de AVC.cc del ojo derecho no cumple con la estructura requerida\r\n\t";
                correcto--;
            }
            if (txtAltRXod.Text != "")
            {
                txtAltRXod.BackColor = Color.White;
                correcto++;
            }
            else
            {
                txtAltRXod.BackColor = Color.LightPink;
                error += "> El valor de ALT del ojo derecho no cumple con la estructura requerida\r\n\t";
                correcto--;
            }
            if (txtDnpRXod.Text != "")
            {
                txtDnpRXod.BackColor = Color.White;
                correcto++;
            }
            else
            {
                txtDnpRXod.BackColor = Color.LightPink;
                error += "> El valor de DNP/DP del ojo derecho no cumple con la estructura requerida\r\n\t";
                correcto--;
            }


            //if (correcto==8)
            //{
            //    ok = true;
            //}
            //else
            //{
            //    MessageBox.Show("Los siguientes datos no cumplen con la estructura!!! :( \r\n\r\n\t" + error, "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    ok = false;
            //}
            ////////////////////////
            if (FuncionesBasicas.getInstance().FormatoControles(txtEsferaRXoi.Text))
            {
                txtEsferaRXoi.BackColor = Color.White;
                correcto++;
            }
            else
            {
                txtEsferaRXoi.BackColor = Color.LightPink;
                error += "> El valor de ESFERA del ojo izquierdo no cumple con la estructura requerida\r\n\t";
                correcto--;
            }
            if (FuncionesBasicas.getInstance().FormatoControles(txtCilindroRXoi.Text))
            {
                txtCilindroRXoi.BackColor = Color.White;
                correcto++;
            }
            else
            {
                txtCilindroRXoi.BackColor = Color.LightPink;
                error += "> El valor de CILINDRO del ojo izquierdo no cumple con la estructura requerida\r\n\t";
                correcto--;
            }
            if (txtEjeRXoi.Text != "")
            {
                txtEjeRXoi.BackColor = Color.White;
                correcto++;
            }
            else
            {
                txtEjeRXoi.BackColor = Color.LightPink;
                error += "> El valor de EJE del ojo izquierdo no cumple con la estructura requerida\r\n\t";
                correcto--;
            }
            if (FuncionesBasicas.getInstance().FormatoControles(txtAddRXoi.Text))
            {
                txtAddRXoi.BackColor = Color.White;
                correcto++;
            }
            else
            {
                txtAddRXoi.BackColor = Color.LightPink;
                error += "> El valor de ADD del ojo izquierdo no cumple con la estructura requerida\r\n\t";
                correcto--;
            }
            if (txtAvlRXoi.Text != "")
            {
                txtAvlRXoi.BackColor = Color.White;
                correcto++;
            }
            else
            {
                txtAvlRXoi.BackColor = Color.LightPink;
                error += "> El valor de AVL.cc del ojo izquierdo no cumple con la estructura requerida\r\n\t";
                correcto--;
            }
            if (txtAvcRXoi.Text != "")
            {
                txtAvcRXoi.BackColor = Color.White;
                correcto++;
            }
            else
            {
                txtAvcRXoi.BackColor = Color.LightPink;
                error += "> El valor de AVC.cc del ojo izquierdo no cumple con la estructura requerida\r\n\t";
                correcto--;
            }
            if (txtAltRXoi.Text != "")
            {
                txtAltRXoi.BackColor = Color.White;
                correcto++;
            }
            else
            {
                txtAltRXoi.BackColor = Color.LightPink;
                error += "> El valor de ALT del ojo izquierdo no cumple con la estructura requerida\r\n\t";
                correcto--;
            }
            if (txtDnpRXoi.Text != "")
            {
                txtDnpRXoi.BackColor = Color.White;
                correcto++;
            }
            else
            {
                txtDnpRXoi.BackColor = Color.LightPink;
                error += "> El valor de DNP/DP del ojo izquierdo no cumple con la estructura requerida\r\n\t";
                correcto--;
            }


            if (correcto == 16)
            {
                ok = true;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Los siguientes datos no cumplen con la estructura!!! :( \r\n\r\n\t" + error, "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }
            return ok;
        }

        private void BloquearControles()
        {

        }

        #endregion

        private void LentesContacto_Load(object sender, EventArgs e)
        {

        }

        #region validaciones textos

        private void txtEsferaRXod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtEsferaRXod.Text != "")
            {
                FuncionesBasicas.getInstance().ValidaCaracterEsfera(e);
            }
        }

        private void txtEsferaRXod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                bool ok = txtEsferaRXod.Text.Contains("+");
                bool ok2 = txtEsferaRXod.Text.Contains("-");
                if (!ok && !ok2 && txtEsferaRXod.Text != "N")
                {
                    txtEsferaRXod.Text = "+" + txtEsferaRXod.Text;
                }
                FuncionesBasicas.getInstance().SaltarConEnter(e);
            }
        }
        private void txtCilindroRXod_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().ValidaCaracter(e);
            if (txtEsferaRXod.Text == "N")
            {
                FuncionesBasicas.getInstance().ValidaN(e);
            }
        }

        private void txtCilindroRXod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                bool ok = txtCilindroRXod.Text.Contains("+");
                bool ok2 = txtCilindroRXod.Text.Contains("-");
                if (!ok && !ok2)
                {
                    txtCilindroRXod.Text = "+" + txtCilindroRXod.Text;
                }
                if (txtEsferaRXod.Text == "N")
                {
                    txtCilindroRXod.Text = txtCilindroRXod.Text.Replace('+', '-');
                    txtEsferaRXod.Text = txtCilindroRXod.Text.Replace('-', '+');
                }
                FuncionesBasicas.getInstance().SaltarConEnter(e);

            }
        }

        private void txtEjeRXod_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().SoloNumeros(e);
        }

        private void txtEjeRXod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                FuncionesBasicas.getInstance().SaltarConEnter(e);
                int eje = Convert.ToInt16(txtEjeRXod.Text);
                if (eje >= 0 && eje <= 180)
                {
                    int valor = Convert.ToInt16(txtEjeRXod.Text);
                    if (valor > 90)
                    {
                        valor -= 90;
                    }
                    else
                    {
                        valor += 90;
                    }
                    txtEjeRXod.Text = valor.ToString();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Los valores del eje deben estar entre 0 y 180 :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtAddRXod_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().ValidaCaracterEsfera(e);
        }
        private void txtAddRXod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                decimal valor = Convert.ToDecimal(txtAddRXod.Text);
                bool ok = txtAddRXod.Text.Contains("+");
                if (valor > 0 && !ok)
                {
                    txtAddRXod.Text = "+" + txtAddRXod.Text;
                }
                FuncionesBasicas.getInstance().SaltarConEnter(e);
            }
        }

        private void txtAltRXod_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().SoloNumeros(e);
        }
        private void txtAltRXod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void txtAvlRXod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }
        private void txtAvlRXod_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().ValidaSlach(e);
        }

        private void txtAvcRXod_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().ValidaCaracterEsfera(e);
        }
        private void txtAvcRXod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void txtDnpRXod_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().SoloNumeros(e);
        }

        private void txtDnpRXod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void txtEsferaRXoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtEsferaRXoi.Text != "")
                FuncionesBasicas.getInstance().ValidaCaracterEsfera(e);
        }

        private void txtEsferaRXoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                bool ok = txtEsferaRXoi.Text.Contains("+");
                bool ok2 = txtEsferaRXoi.Text.Contains("-");
                if (!ok && !ok2 && txtEsferaRXoi.Text != "N")
                {
                    txtEsferaRXoi.Text = "+" + txtEsferaRXoi.Text;
                }
                FuncionesBasicas.getInstance().SaltarConEnter(e);
            }
        }

        private void txtCilindroRXoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().ValidaCaracter(e);
            if (txtEsferaRXoi.Text == "N")
            {
                FuncionesBasicas.getInstance().ValidaN(e);
            }
        }

        private void txtCilindroRXoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                bool ok = txtCilindroRXoi.Text.Contains("+");
                bool ok2 = txtCilindroRXoi.Text.Contains("-");
                if (!ok && !ok2 && txtCilindroRXoi.Text != "N")
                {
                    txtCilindroRXoi.Text = "+" + txtCilindroRXoi.Text;
                }
                if (txtEsferaRXoi.Text == "N")
                {
                    txtCilindroRXoi.Text = txtCilindroRXoi.Text.Replace('+', '-');
                    txtEsferaRXoi.Text = txtCilindroRXoi.Text.Replace('-', '+');
                }
                FuncionesBasicas.getInstance().SaltarConEnter(e);

            }
        }

        private void txtEjeRXoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().SoloNumeros(e);
        }

        private void txtEjeRXoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                FuncionesBasicas.getInstance().SaltarConEnter(e);
                int eje = Convert.ToInt16(txtEjeRXoi.Text);
                if (eje >= 0 && eje <= 180)
                {
                    int valor = Convert.ToInt16(txtEjeRXoi.Text);
                    if (valor > 90)
                    {
                        valor -= 90;
                    }
                    else
                    {
                        valor += 90;
                    }
                    txtEjeRXoi.Text = valor.ToString();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Los valores del eje deben estar entre 0 y 180 :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtAddRXoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().ValidaCaracterEsfera(e);
        }

        private void txtAddRXoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                decimal valor = Convert.ToDecimal(txtAddRXoi.Text);
                bool ok = txtAddRXoi.Text.Contains("+");
                if (valor > 0 && !ok)
                {
                    txtAddRXoi.Text = "+" + txtAddRXoi.Text;
                }
                FuncionesBasicas.getInstance().SaltarConEnter(e);
            }
        }

        private void txtAvlRXoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().ValidaSlach(e);
        }

        private void txtAvlRXoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void txtAvcRXoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().ValidaCaracterEsfera(e);
        }

        private void txtAvcRXoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void txtAltRXoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().SoloNumeros(e);
        }

        private void txtAltRXoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void txtDnpRXoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().SoloNumeros(e);
        }

        private void txtDnpRXoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }


        #endregion

        private void btnCieDer_Click(object sender, EventArgs e)
        {
            Cie10 frm = new Cie10();
            frm.ShowDialog();
            var coma = "";
            var separador = " - ";
            if (txtDiagnosticoOjoDer.Text != "")
                coma = "; ";
            txtDiagnosticoOjoDer.Text += coma + frm.codigo + separador;
            txtDiagnosticoOjoDer.Text += frm.detalle;
        }

        private void btnCieIz_Click(object sender, EventArgs e)
        {
            Cie10 frm = new Cie10();
            frm.ShowDialog();
            var coma = "";
            var separador = " - ";
            if (txtDiagnosticoOjoIz.Text != "")
                coma = "; ";
            txtDiagnosticoOjoIz.Text += coma + frm.codigo + separador;
            txtDiagnosticoOjoIz.Text += frm.detalle;
        }






        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (btnGuardar.Visible)
            {
                if (System.Windows.Forms.MessageBox.Show("¿Esta seguro de borrar la información ingresada?", "OPT3000", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    LimpiarCampos();
                    return;
                }
            }
            LimpiarCampos();
            btnNuevo.Visible = false;
        }

        public void LimpiarCampos()
        {
            FuncionesBasicas.getInstance().BorrarCampos(p_Atencion);
            p_PacienteDatos.Visible = false;
            p_Atencion.Enabled = false;
            btnBusca.Visible = true;
            btnGuardar.Visible = false;
            btnCancelar.Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validacion())
            {
                ATENCION objAtencion = new ATENCION();
                RETINOSCOPIA_DILATADA objRetiniscopia = new RETINOSCOPIA_DILATADA();
                LENTES_CONTACTO objLentes = new LENTES_CONTACTO();
                OFTALMOLOGIA objOftalmica = null;
                RX_FINAL objRx = new RX_FINAL();
                List<RETINOSCOPIA_DILATADA> listaRetinoscopia = new List<RETINOSCOPIA_DILATADA>();
                List<LENTES_CONTACTO> listaLentes = new List<LENTES_CONTACTO>();
                List<RX_FINAL> listaRx = new List<RX_FINAL>();
                LENTE_DEFINITIVO objLenteDef = new LENTE_DEFINITIVO();
                ADAPTACION_LENTES objAdaptacion = new ADAPTACION_LENTES();
                LENTE_PRUEBA objLentePrueba = new LENTE_PRUEBA();

                objAtencion.ID_PACIENTE = Convert.ToInt64(lblHc.Text);
                objAtencion.Tipo_Consulta = "LENTES";
                objAtencion.Fecha_Creacion = DateTime.Now;
                objAtencion.Tipo_Seguro = lblTipo.Text;
                objAtencion.Observaciones = txtObservaciones.Text;
                objAtencion.DiagnosticoOD = txtDiagnosticoOjoDer.Text;
                objAtencion.DiagnosticoOI = txtDiagnosticoOjoIz.Text;
                objAtencion.Recomendaciones = txtRecomendaciones.Text;
                Password frm = new Password();
                frm.ShowDialog();
                if (frm.idUsuario == 0)
                {
                    return;
                }
                objAtencion.Usuario = frm.idUsuario;
                objAtencion.OPTOMETRA = "";
                objAtencion.Mpc = "";

                objAdaptacion.PupilarOD = txtPupilarOD.Text;
                objAdaptacion.PupilarOI = txtPupilarOI.Text;
                objAdaptacion.CornealOD = txtCornealOD.Text;
                objAdaptacion.CornealOI = txtCornealOI.Text;
                objAdaptacion.PaipebralOD = txtPaipebralOD.Text;
                objAdaptacion.PaipebralOI = txtPaipebralOI.Text;
                objAdaptacion.But = txtBut.Text;
                objAdaptacion.Shirmer = txtShirmer.Text;

                objLentePrueba.BaseOD = txtCurvaBaseOD.Text;
                objLentePrueba.BaseOI = txtCurvaBaseOI.Text;
                objLentePrueba.PoderOD = txtPoderOD.Text;
                objLentePrueba.PoderOI = txtPoderOI.Text;
                objLentePrueba.MaterialOD = txtMaterialOD.Text;
                objLentePrueba.MaterialOI = txtMaterialOI.Text;
                objLentePrueba.DiametroOD = txtDiametroOD.Text;
                objLentePrueba.DiametroOI = txtDiametroOI.Text;
                objLentePrueba.RefraccionOD = txtRefraccionOD.Text;
                objLentePrueba.RefraccionOI = txtRefraccionOI.Text;
                objLentePrueba.VisualOD = txtAgudezaOD.Text;
                objLentePrueba.VisualOI = txtAgudezaOI.Text;

                objLenteDef.BaseOD = txtCurvaODd.Text;
                objLenteDef.BaseOI = txtCurvaOId.Text;
                objLenteDef.PoderOD = txtPoderODd.Text;
                objLenteDef.PoderOI = txtPoderOId.Text;
                objLenteDef.DiametroOD = txtDiametroODd.Text;
                objLenteDef.DiametroOI = txtDiametroOId.Text;
                objLenteDef.MaterialOD = txtMaterialODd.Text;
                objLenteDef.MaterialOI = txtMaterialOId.Text;

                objRx.Esfera = txtEsferaRXod.Text;
                objRx.Cilindro = txtCilindroRXod.Text;
                objRx.Eje = txtEjeRXod.Text;
                objRx.A_D_D = txtAddRXod.Text;
                objRx.AVL = txtAvlRXod.Text;
                objRx.AVC = txtAvcRXod.Text;
                objRx.ALT = txtAltRXod.Text;
                objRx.DNP_DP = txtDnpRXod.Text;
                objRx.OJO = "D";
                listaRx.Add(objRx);
                objRx = new RX_FINAL();

                objRx.Esfera = txtEsferaRXoi.Text;
                objRx.Cilindro = txtCilindroRXoi.Text;
                objRx.Eje = txtEjeRXoi.Text;
                objRx.A_D_D = txtAddRXoi.Text;
                objRx.AVL = txtAvlRXoi.Text;
                objRx.AVC = txtAvcRXoi.Text;
                objRx.ALT = txtAltRXoi.Text;
                objRx.DNP_DP = txtDnpRXoi.Text;
                objRx.OJO = "I";
                listaRx.Add(objRx);

                if (NegGuarda.getInstance().GuardaAtencion(objAtencion, listaRetinoscopia, listaLentes, listaRx, objOftalmica, objAdaptacion, objLentePrueba, objLenteDef))
                {
                    System.Windows.Forms.MessageBox.Show("Atención Guardada con exito :)", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGuardar.Visible = false;
                    LimpiarCampos();
                    this.Close();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Algo salio mal!!!,\r\n Revise la información a guardar :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Debe ingresar los datos solicitados. :{", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void AgregarError(Control control, string Valor)
        {
            error.SetError(control, Valor);
        }

        public bool Validacion()
        {
            error.Clear();
            int i = 0;
            if (lblTipo.Text == string.Empty)
            {
                i++;
            }
            //if (txtObservaciones.Text == string.Empty)
            //{
            //    i++;
            //}
            if (txtDiagnosticoOjoDer.Text == string.Empty)
            {
                AgregarError(txtDiagnosticoOjoDer, "Este campor es requerido");
                i++;
            }
            if (txtDiagnosticoOjoIz.Text == string.Empty)
            {
                AgregarError(txtDiagnosticoOjoIz, "Este campor es requerido");
                i++;
            }

            if (txtPupilarOD.Text == string.Empty)
            {
                AgregarError(txtPupilarOD, "Este campor es requerido");
                i++;
            }
            if (txtCornealOD.Text == string.Empty)
            {
                AgregarError(txtCornealOD, "Este campor es requerido");
                i++;
            }
            if (txtCornealOD.Text == string.Empty)
            {
                AgregarError(txtCornealOD, "Este campor es requerido");
                i++;
            }
            if (txtPupilarOI.Text == string.Empty)
            {
                AgregarError(txtPupilarOI, "Este campor es requerido");
                i++;
            }
            if (txtCornealOI.Text == string.Empty)
            {
                AgregarError(txtCornealOI, "Este campor es requerido");
                i++; }
            if (txtCornealOI.Text == string.Empty)
            { AgregarError(txtCornealOI, "Este campor es requerido");
                i++; }
            if (txtEsferaRXod.Text == string.Empty)
            { AgregarError(txtEsferaRXod, "Este campor es requerido");
                i++; }
            if (txtCilindroRXod.Text == string.Empty)
            {
                AgregarError(txtCilindroRXod, "Este campor es requerido");
                i++; }
            if (txtEjeRXod.Text == string.Empty)
            {
                AgregarError(txtEjeRXod, "Este campor es requerido");
                i++; }
            if (txtAddRXod.Text == string.Empty)
            {
                AgregarError(txtAddRXod, "Este campor es requerido");
                i++; }
            if (txtAvlRXod.Text == string.Empty)
            {
                AgregarError(txtAvlRXod, "Este campor es requerido");
                i++; }
            if (txtAvcRXod.Text == string.Empty)
            { AgregarError(txtAvcRXod, "Este campor es requerido");
                i++; }
            if (txtAltRXod.Text == string.Empty)
            {
                AgregarError(txtAltRXod, "Este campor es requerido");
                i++; }
            if (txtDnpRXod.Text == string.Empty)
            {
                AgregarError(txtDnpRXod, "Este campor es requerido");
                i++; }
            if (txtEsferaRXoi.Text == string.Empty)
            {
                AgregarError(txtEsferaRXoi, "Este campor es requerido");
                i++; }
            if (txtCilindroRXoi.Text == string.Empty)
            {
                AgregarError(txtCilindroRXoi, "Este campor es requerido");
                i++; }
            if (txtEjeRXoi.Text == string.Empty)
            {
                AgregarError(txtEjeRXoi, "Este campor es requerido");
                i++; }
            if (txtAddRXoi.Text == string.Empty)
            {
                AgregarError(txtAddRXoi, "Este campor es requerido");
                i++; }
            if (txtAvlRXoi.Text == string.Empty)
            {
                AgregarError(txtAvlRXoi, "Este campor es requerido");
                i++; }
            if (txtAvcRXoi.Text == string.Empty)
            {
                AgregarError(txtAvcRXoi, "Este campor es requerido");
                i++; }
            if (txtAltRXoi.Text == string.Empty)
            {
                AgregarError(txtAltRXoi, "Este campor es requerido");
                i++; }
            if (txtDnpRXoi.Text == string.Empty)
            {
                AgregarError(txtDnpRXoi, "Este campor es requerido");
                i++; }
            if (i != 0)
                return false;
            return true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FuncionesBasicas.getInstance().BorrarCampos(p_Atencion);
            txtRecomendaciones.Text = "USO PERMANENTE. \r\nLUBRICACIÓN OCULAR.\r\nCONTROL EN UN AÑO.";
            p_Atencion.Enabled = true;
            btnBusca.Visible = false;
            btnGuardar.Visible = true;
            btnCancelar.Visible = true;
            Int64 maximo = NegConsultas.getInstance().MaxAtencion() + 1;
            lblAtencion.Text = maximo.ToString();
            btnNuevo.Visible = false;
            calculador = false;
            RX_EN_USO();
        }

        private void btnAbiriAtenciones_Click(object sender, EventArgs e)
        {
            AbrirAtenciones(objPaciente.ID_PACIENTE);
        }

        private void txtEjeRXod_Leave(object sender, EventArgs e)
        {
            try
            {
                int eje = Convert.ToInt16(txtEjeRXod.Text);
                decimal cilindro = Convert.ToDecimal(txtCilindroRXod.Text);
                if (cilindro < 0)
                {
                    return;
                }
                if (!calculador)
                {
                    if (txtEjeRXod.Text != "")
                    {
                        if (eje > 90)
                        {
                            eje -= 90;
                        }
                        else
                        {
                            eje += 90;
                        }
                        txtEjeRXod.Text = eje.ToString();
                    }
                    if (txtEjeRXod.Text != "" && txtAddRXod.Text != "")
                    {
                        txtEjeVCod.Text = txtEjeRXod.Text;
                    }
                }
            }
            catch
            {
            }
        }

        private void txtEjeRXoi_Leave(object sender, EventArgs e)
        {
            try
            {
                int eje = Convert.ToInt16(txtEjeRXoi.Text);
                decimal cilindro = Convert.ToDecimal(txtCilindroRXoi.Text);
                if (cilindro < 0)
                {
                    return;
                }
                if (!calculador)
                {
                    if (txtEjeRXoi.Text != "")
                    {
                        if (eje > 90)
                        {
                            eje -= 90;
                        }
                        else
                        {
                            eje += 90;
                        }
                        txtEjeRXoi.Text = eje.ToString();
                    }
                    if (txtEjeRXoi.Text != "" && txtAddRXoi.Text != "")
                    {
                        txtEjeVCoi.Text = txtEjeRXoi.Text;
                    }
                }
            }
            catch
            {
            }

        }

        private void txtAddRXod_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtAddRXod.Text != "")
                {
                    if (txtEsferaRXod.Text != "N")
                        txtEsferaVCod.Text = txtEsferaRXod.Text;
                    else
                        txtEsferaVCod.Text = "0.00";

                    txtCilindroVCod.Text = txtCilindroRXod.Text;

                    decimal valor2 = Convert.ToDecimal(txtCilindroRXod.Text);
                    if (valor2 < 0)
                    {
                        txtEjeVCod.Text = txtEjeRXod.Text;
                    }

                    if (txtAddRXod.Text == "0")
                    {
                        txtAddRXod.Text = "0.00";
                    }
                    if (Convert.ToDecimal(txtAddRXod.Text) > 0)
                    {
                        string add = txtAddRXod.Text;
                        bool b1 = add.Contains("+");
                        if (!b1)
                        {
                            txtAddRXod.Text = "+" + add;
                        }
                    }
                    else
                    {
                        string add = txtAddRXod.Text;
                        bool b1 = add.Contains("-");
                        if (b1)
                        {
                            add = add.Replace('-', '+');
                            txtAddRXod.Text = add;
                        }
                        else
                        {
                            txtAddRXod.Text = "+" + add;
                        }
                    }
                    txtEsferaVCod.Text = (Convert.ToDecimal(txtAddRXod.Text) + Convert.ToDecimal(txtEsferaVCod.Text)).ToString();
                    if (Convert.ToDecimal(txtEsferaVCod.Text) > 0)
                    {
                        txtEsferaVCod.Text = "+" + txtEsferaVCod.Text;
                    }
                }
                else
                {
                    txtEsferaVCod.Text = "";
                    txtCilindroVCod.Text = "";
                    txtEjeVCod.Text = "";
                    txtDnpVCod.Text = "";
                    txtAvcVCod.Text = "";
                }

            }
            catch
            {
            }
        }

        private void txtAddRXoi_Leave(object sender, EventArgs e)
        {
            if (txtAddRXoi.Text != "")
            {
                try
                {
                    if (txtEsferaRXoi.Text != "N")
                        txtEsferaVCoi.Text = txtEsferaRXoi.Text;
                    else
                        txtEsferaVCoi.Text = "0.00";

                    txtCilindroVCoi.Text = txtCilindroRXoi.Text;

                    decimal valor2 = Convert.ToDecimal(txtCilindroRXoi.Text);
                    if (valor2 < 0)
                    {
                        txtEjeVCoi.Text = txtEjeRXoi.Text;
                    }

                    if (txtAddRXoi.Text == "0")
                    {
                        txtAddRXoi.Text = "0.00";
                    }
                    if (Convert.ToDecimal(txtAddRXoi.Text) > 0)
                    {
                        string add = txtAddRXoi.Text;
                        bool b1 = add.Contains("+");
                        if (!b1)
                        {
                            txtAddRXoi.Text = "+" + add;
                        }
                    }
                    else
                    {
                        string add = txtAddRXoi.Text;
                        bool b1 = add.Contains("-");
                        if (b1)
                        {
                            add = add.Replace('-', '+');
                            txtAddRXoi.Text = add;
                        }
                        else
                        {
                            txtAddRXoi.Text = "+" + add;
                        }
                    }
                    txtEsferaVCoi.Text = (Convert.ToDecimal(txtAddRXoi.Text) + Convert.ToDecimal(txtEsferaVCoi.Text)).ToString();
                    if (Convert.ToDecimal(txtEsferaVCoi.Text) > 0)
                    {
                        txtEsferaVCoi.Text = "+" + txtEsferaVCoi.Text;
                    }
                }
                catch
                {

                }
            }
            else
            {
                txtEsferaVCoi.Text = "";
                txtCilindroVCoi.Text = "";
                txtEjeVCoi.Text = "";
                txtDnpVCoi.Text = "";
                txtAvcVCoi.Text = "";
            }
        }

        private void txtDnpRXod_Leave(object sender, EventArgs e)
        {
            if (txtAddRXod.Text != "")
                txtDnpVCod.Text = txtDnpRXod.Text;
        }

        private void txtDnpRXoi_Leave(object sender, EventArgs e)
        {
            if (txtAddRXoi.Text != "")
                txtDnpVCoi.Text = txtDnpRXoi.Text;
        }

        private void txtAvcRXod_Leave(object sender, EventArgs e)
        {
            if (txtAvcRXod.Text != "" && txtAddRXod.Text != "")
            {
                txtAvcVCod.Text = txtAvcRXod.Text;
            }
        }

        private void txtAvcRXoi_Leave(object sender, EventArgs e)
        {
            if (txtAvcRXoi.Text != "" && txtAddRXod.Text != "")
            {
                txtAvcVCoi.Text = txtAvcRXoi.Text;
            }
        }

        private void txtEsferaRXod_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtEsferaRXod.Text == "N" || txtEsferaRXod.Text == "0.00")
                {
                    txtEsferaRXod.Text = "0.00";
                    return;
                }
                //    txtEsferaVCod.Text = txtEsferaRXod.Text;
                //else
                string esfera = txtEsferaRXod.Text;
                bool b1 = esfera.Contains("+");
                bool b2 = esfera.Contains("-");
                if (Convert.ToDecimal(esfera) > 0)
                {
                    if (!b1)
                    {
                        MessageBox.Show("Debe ingresar un signo (+), (-)", " OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtEsferaRXod.Focus();
                        return;
                    }
                }
                else
                {
                    if (!b2)
                    {
                        MessageBox.Show("Debe ingresar un signo (+), (-)", " OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtEsferaRXod.Focus();
                    }
                }
            }
            catch
            {
            }
        }

        private void txtEsferaRXoi_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtEsferaRXoi.Text == "N" || txtEsferaRXoi.Text == "0.00")
                {
                    txtEsferaRXoi.Text = "0.00";
                    return;
                }
                //    txtEsferaVCoi.Text = txtEsferaRXoi.Text;
                //else
                string esfera = txtEsferaRXoi.Text;
                bool b1 = esfera.Contains("+");
                bool b2 = esfera.Contains("-");
                if (Convert.ToDecimal(esfera) > 0)
                {
                    if (!b1)
                    {
                        MessageBox.Show("Debe ingresar un signo (+), (-)", " OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtEsferaRXoi.Focus();
                        return;
                    }
                }
                else
                {
                    if (!b2)
                    {
                        MessageBox.Show("Debe ingresar un signo (+), (-)", " OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtEsferaRXoi.Focus();
                    }
                }
            }
            catch
            {
            }
        }

        private void txtCilindroRXod_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtCilindroRXod.Text != "" && txtAddRXod.Text != "")
                {
                    txtCilindroVCod.Text = txtCilindroRXod.Text;
                }
                string cilindro = txtCilindroRXod.Text;
                bool b1 = cilindro.Contains("+");
                if (Convert.ToDecimal(cilindro) > 0)
                {
                    if (b1 && !calculador)
                    {
                        calculador = true;
                        txtAddRXod.Focus();
                        MessageBox.Show("El cilindro Debe ser negativo (-)", " OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtEsferaRXod.Text = "";
                        txtCilindroRXod.Text = "";
                        Calculadora frm = new Calculadora();
                        frm.ShowDialog();
                        if (txtEsferaRXod.Text == "")
                        {
                            txtEsferaRXod.Text = frm.esfera;
                            txtCilindroRXod.Text = frm.cilindro;
                            txtEjeRXod.Text = frm.eje;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void txtCilindroRXoi_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtCilindroRXoi.Text != "" && txtAddRXoi.Text != "")
                {
                    txtCilindroVCoi.Text = txtCilindroRXoi.Text;

                }
                string cilindro = txtCilindroRXoi.Text;
                bool b1 = cilindro.Contains("+");
                if (Convert.ToDecimal(cilindro) > 0)
                {
                    if (b1 && !calculador)
                    {
                        calculador = true;
                        txtAddRXoi.Focus();
                        MessageBox.Show("El cilindro Debe ser negativo (-)", " OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtEsferaRXoi.Text = "";
                        txtCilindroRXoi.Text = "";
                        Calculadora frm = new Calculadora();
                        frm.ShowDialog();
                        if (txtEsferaRXoi.Text == "")
                        {
                            txtEsferaRXoi.Text = frm.esfera;
                            txtCilindroRXoi.Text = frm.cilindro;
                            txtEjeRXoi.Text = frm.eje;
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}

