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
using System.IO;

namespace Opt3000.Vista.Consultas
{
    public partial class NuevaConsulta : Form
    {
        bool calculador = false;
        Int64 reimprimirOrden1;
        bool mensaje = true;
        public NuevaConsulta()
        {
            InitializeComponent();
        }

        public void LlenaCombo()
        {
            //List<TIPO_LENTECONTACTO> lista = new List<TIPO_LENTECONTACTO>();
            //lista = NegConsultas.getInstance().ConsultaTipo();
            //cmbTipoLente.DataSource = lista;
            //cmbTipoLente.ValueMember = "ID_TIPO";
            //cmbTipoLente.DisplayMember = "Detalle";
            //cmbTipoLente.SelectedIndex = -1;
            //cmbTipoLente.Text = "";
        }

        #region botones

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (FuncionesBasicas.getInstance().CerrarFormulario("LA ATENCIÓN"))
                this.Close();
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
                //p_PacienteDatos.Visible = true;
                p_Atencion.Enabled = true;
                btnBusca.Visible = false;
                btnGuardar.Visible = true;
                btnCancelar.Visible = true;
                //LlenaCombo();
                g_DatosPaciente.Visible = true;
                List<ATENCION> lista = new List<ATENCION>();
                lista = NegConsultas.getInstance().CargaAtenciones(objPaciente.ID_PACIENTE, "NORMAL");
                if (lista.Count > 0)
                {
                    AbrirAtenciones(objPaciente.ID_PACIENTE);
                    calculador = true;
                }
                else
                {
                    txtRecomendaciones.Text = "USO PERMANENTE.\r\nLUBRICACIÓN OCULAR.\r\nCONTROL EN UN AÑO.";
                }

            }

        }

        public void AbrirAtenciones(Int64 idPac)
        {
            BuscadorAtencion frmBuscaAtencion = new BuscadorAtencion(idPac, "NORMAL");
            frmBuscaAtencion.ShowDialog();
            if (frmBuscaAtencion.ateCodigo != "")
            {
                reimprimirOrden1 = Convert.ToInt64(frmBuscaAtencion.ateCodigo);
                ATENCION objAtencion = new ATENCION();
                objAtencion = NegConsultas.getInstance().CargaAtencion(Convert.ToInt64(frmBuscaAtencion.ateCodigo));
                lblAtencion.Text = objAtencion.ID_ATENCION.ToString();
                txtObservaciones.Text = objAtencion.Observaciones;
                txtDiagnosticoOjoDer.Text = objAtencion.DiagnosticoOD;
                txtDiagnosticoOjoIz.Text = objAtencion.DiagnosticoOI;
                txtRecomendaciones.Text = objAtencion.Recomendaciones;
                txtMedico.Text = objAtencion.OPTOMETRA;
                txtMpc.Text = objAtencion.Mpc;
                lblFecha.Text = objAtencion.Fecha_Creacion.ToString();
                RETINOSCOPIA_DILATADA objRetiniscopia = new RETINOSCOPIA_DILATADA();
                objRetiniscopia = NegConsultas.getInstance().CargaRetinoscopia(objAtencion.ID_ATENCION, "D");
                if (objRetiniscopia != null)
                {
                    txtEsferaRetinoOD.Text = objRetiniscopia.Esfera;
                    txtCilindroRetinoOD.Text = objRetiniscopia.Cilindro;
                    txtEjeRetinoOD.Text = objRetiniscopia.Eje;
                    txtAvlRetinoOD.Text = objRetiniscopia.Avl;
                    objRetiniscopia = new RETINOSCOPIA_DILATADA();
                    objRetiniscopia = NegConsultas.getInstance().CargaRetinoscopia(objAtencion.ID_ATENCION, "I");
                    txtEsperaRetinoOI.Text = objRetiniscopia.Esfera;
                    txtCilindroRetinoOI.Text = objRetiniscopia.Cilindro;
                    txtEjeRetinoOI.Text = objRetiniscopia.Eje;
                    txtAvlRetinoOI.Text = objRetiniscopia.Avl;
                }

                LENTES_CONTACTO objLentes = new LENTES_CONTACTO();
                objLentes = NegConsultas.getInstance().CargaLentes(objAtencion.ID_ATENCION, "D");
                if (objLentes != null)
                {
                    txtEsferaLenteOD.Text = objLentes.Esfera;
                    txtCilindroLenteOD.Text = objLentes.Cilindro;
                    txtEjeLenteOD.Text = objLentes.Eje;
                    txtTipoOD.Text = objLentes.Tipo;
                    objLentes = new LENTES_CONTACTO();
                    objLentes = NegConsultas.getInstance().CargaLentes(objAtencion.ID_ATENCION, "I");
                    txtEsferaLenteOI.Text = objLentes.Esfera;
                    txtCilindroLenteOI.Text = objLentes.Cilindro;
                    txtEjeLenteOI.Text = objLentes.Eje;
                    txtTipoOI.Text = objLentes.Tipo;
                }
                RX_FINAL objRx = new RX_FINAL();
                objRx = NegConsultas.getInstance().CargaRxFinal(objAtencion.ID_ATENCION, "D");
                if (objRx != null)
                {
                    txtEsferaRXod.Text = objRx.Esfera.ToString();
                    txtCilindroRXod.Text = objRx.Cilindro;
                    txtEjeRXod.Text = objRx.Eje;
                    txtAddRXod.Text = objRx.A_D_D;
                    txtAvscRXod.Text = objRx.AVSC;
                    txtAvlRXod.Text = objRx.AVL;
                    txtAvcRXod.Text = objRx.AVC;
                    txtAltRXod.Text = objRx.ALT;
                    txtDnpRXod.Text = objRx.DNP_DP;
                    txtAvcccRxod.Text = objRx.AVCC;
                    objRx = new RX_FINAL();
                    objRx = NegConsultas.getInstance().CargaRxFinal(objAtencion.ID_ATENCION, "I");
                    //if (objRx.Esfera != "")
                    //    if (objRx.A_D_D != "")
                    //        txtEsferaRXoi.Text = (Convert.ToDecimal(objRx.Esfera) + Convert.ToDecimal(objRx.A_D_D)).ToString();
                    //    else
                    //        txtEsferaRXoi.Text = objRx.Esfera;
                    txtEsferaRXoi.Text = objRx.Esfera.ToString();
                    txtCilindroRXoi.Text = objRx.Cilindro;
                    txtEjeRXoi.Text = objRx.Eje;
                    txtAddRXoi.Text = objRx.A_D_D;
                    txtAvscRXoi.Text = objRx.AVSC;
                    txtAvlRXoi.Text = objRx.AVL;
                    txtAvcRXoi.Text = objRx.AVC;
                    txtAltRXoi.Text = objRx.ALT;
                    txtDnpRXoi.Text = objRx.DNP_DP;
                    txtAvcccRxoi.Text = objRx.AVCC;
                    if (objRx.A_D_D != "")
                    {
                        txtAvcVCod.Text = txtAddRXod.Text;
                        txtAvcVCoi.Text = txtAddRXoi.Text;
                        txtDnpVCod.Text = txtDnpRXod.Text;
                        txtDnpVCoi.Text = txtDnpRXoi.Text;
                        txtAvcscVCod.Text = txtAvcccRxod.Text;
                        txtAvcscVCoi.Text = txtAvcccRxoi.Text;
                        CalcularValores();
                    }


                }

                p_Atencion.Enabled = false;
                btnGuardar.Visible = false;
                btnAbiriAtenciones.Visible = true;
                btnCancelar.Visible = true;
                btnNuevo.Visible = true;
                btnGeneral.Enabled = true;
                btnOrdenCercana.Enabled = true;
                btnLentesBlandos.Enabled = true;
                btnOrdenLejana.Enabled = true;
                btnCertificado.Visible = true;
                RX_EN_USO();
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
            if (txtAddRXod.Text != "")
            {
                txtEsferaVCod.Text = (Convert.ToDecimal(txtEsferaRXod.Text) + Convert.ToDecimal(txtAddRXod.Text)).ToString();
                if (Convert.ToDecimal(txtEsferaVCod.Text) > 0)
                {
                    txtEsferaVCod.Text = "+" + txtEsferaVCod.Text;
                }
            }
            else
            {
                txtEsferaVCod.Text = txtEsferaRXod.Text;
            }
            txtCilindroVCod.Text = txtCilindroRXod.Text;
            txtEjeVCod.Text = txtEjeRXod.Text;
            if (txtAddRXoi.Text != "")
            {
                txtEsferaVCoi.Text = (Convert.ToDecimal(txtEsferaRXoi.Text) + Convert.ToDecimal(txtAddRXoi.Text)).ToString();
                if (Convert.ToDecimal(txtEsferaVCoi.Text) > 0)
                {
                    txtEsferaVCoi.Text = "+" + txtEsferaVCoi.Text;
                }
            }
            else
            {
                txtEsferaVCoi.Text = txtEsferaRXoi.Text;
            }
            txtCilindroVCoi.Text = txtCilindroRXoi.Text;
            txtEjeVCoi.Text = txtEjeRXoi.Text;
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

        private void NuevaConsulta_Load(object sender, EventArgs e)
        {

        }

        #region validaciones textos

        private void txtEsferaRXod_KeyPress(object sender, KeyPressEventArgs e)
        {
            //FuncionesBasicas.getInstance().OnlyNumberDecimal(e);
            if (txtEsferaRXod.Text != "")
            {
                FuncionesBasicas.getInstance().ValidaCaracterEsfera(e);
            }
        }

        private void txtEsferaRXod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) && txtEsferaRXod.Text != "")
            {
                bool ok = txtEsferaRXod.Text.Contains("+");
                bool ok2 = txtEsferaRXod.Text.Contains("-");
                if (!ok && !ok2 && txtEsferaRXod.Text != "N")
                {
                    if (txtEsferaRXod.Text == "0.00")
                        txtEsferaRXod.Text = txtEsferaRXod.Text;
                    else
                        txtEsferaRXod.Text = "+" + txtEsferaRXod.Text;
                }
                FuncionesBasicas.getInstance().SaltarConEnter(e);
            }
        }
        private void txtCilindroRXod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCilindroRXod.Text != "")
            {
                FuncionesBasicas.getInstance().ValidaCaracter(e);
                if (txtEsferaRXod.Text == "N")
                {
                    FuncionesBasicas.getInstance().ValidaN(e);
                }
            }
        }

        private void txtCilindroRXod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) && txtCilindroRXod.Text != "")
            {
                bool ok = txtCilindroRXod.Text.Contains("+");
                bool ok2 = txtCilindroRXod.Text.Contains("-");
                if (!ok && !ok2)
                {
                    txtCilindroRXod.Text = "+" + txtCilindroRXod.Text;
                }
                //if (txtEsferaRXod.Text == "N")
                //{
                //    txtCilindroRXod.Text = txtCilindroRXod.Text.Replace('+', '-');
                //    txtEsferaRXod.Text = txtCilindroRXod.Text.Replace('-', '+');
                //}
                FuncionesBasicas.getInstance().SaltarConEnter(e);

            }
        }

        private void txtEjeRXod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtEjeRXod.Text != "")
                FuncionesBasicas.getInstance().SoloNumeros(e);
        }

        private void txtEjeRXod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) && txtEjeRXod.Text != "")
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
            if (txtAddRXod.Text != "")
                FuncionesBasicas.getInstance().ValidaCaracterEsfera(e);
        }
        private void txtAddRXod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) && txtAddRXod.Text != "")
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
            {
                if (txtAltRXod.Text == "0")
                {
                    txtAltRXod.Text = "0.00";
                }
                FuncionesBasicas.getInstance().SaltarConEnter(e);
            }
        }

        private void txtAvlRXod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (txtAvlRXod.Text == "0")
                {
                    txtAvlRXod.Text = "0.00";
                }
                FuncionesBasicas.getInstance().SaltarConEnter(e);
            }
        }
        private void txtAvlRXod_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().ValidaSlach(e);
        }

        private void txtAvcRXod_KeyPress(object sender, KeyPressEventArgs e)
        {
            //FuncionesBasicas.getInstance().ValidaCaracterEsfera(e);
        }
        private void txtAvcRXod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (txtAvcRXod.Text == "0")
                {
                    txtAvcRXod.Text = "0.00";
                }
                if (txtAddRXod.Text != "")
                    txtAvcVCod.Text = txtAvcRXod.Text;
                FuncionesBasicas.getInstance().SaltarConEnter(e);
            }
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
            if (e.KeyCode.Equals(Keys.Enter) && txtEsferaRXoi.Text != "")
            {
                bool ok = txtEsferaRXoi.Text.Contains("+");
                bool ok2 = txtEsferaRXoi.Text.Contains("-");
                if (!ok && !ok2 && txtEsferaRXoi.Text != "N")
                {
                    if (txtEsferaRXoi.Text == "0.00")
                        txtEsferaRXoi.Text = txtEsferaRXoi.Text;
                    else
                        txtEsferaRXoi.Text = "+" + txtEsferaRXoi.Text;
                }
                FuncionesBasicas.getInstance().SaltarConEnter(e);
            }
        }

        private void txtCilindroRXoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCilindroRXoi.Text != "")
            {
                FuncionesBasicas.getInstance().ValidaCaracter(e);
                if (txtEsferaRXoi.Text == "N")
                {
                    FuncionesBasicas.getInstance().ValidaN(e);
                }
            }
        }

        private void txtCilindroRXoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) && txtCilindroRXoi.Text != "")
            {
                bool ok = txtCilindroRXoi.Text.Contains("+");
                bool ok2 = txtCilindroRXoi.Text.Contains("-");
                if (!ok && !ok2 && txtCilindroRXoi.Text != "N")
                {
                    txtCilindroRXoi.Text = "+" + txtCilindroRXoi.Text;
                }
                //if (txtEsferaRXoi.Text == "N")
                //{
                //    txtCilindroRXoi.Text = txtCilindroRXoi.Text.Replace('+', '-');
                //    txtEsferaRXoi.Text = txtCilindroRXoi.Text.Replace('-', '+');
                //}
                FuncionesBasicas.getInstance().SaltarConEnter(e);

            }
        }

        private void txtEjeRXoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtEjeRXoi.Text != "")
                FuncionesBasicas.getInstance().SoloNumeros(e);
        }

        private void txtEjeRXoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) && txtEjeRXoi.Text != "")
            {
                decimal valor2 = Convert.ToDecimal(txtCilindroRXoi.Text);
                if (valor2 < 0)
                {
                    txtEjeVCoi.Text = txtEjeRXoi.Text;
                    FuncionesBasicas.getInstance().SaltarConEnter(e);
                    return;
                }
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
            if (txtAddRXoi.Text != "")
                FuncionesBasicas.getInstance().ValidaCaracterEsfera(e);
        }

        private void txtAddRXoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) && txtAddRXoi.Text != "")
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
            {
                if (txtAvlRXoi.Text == "0")
                {
                    txtAvlRXoi.Text = "0.00";
                }
                FuncionesBasicas.getInstance().SaltarConEnter(e);
            }
        }

        private void txtAvcRXoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            //FuncionesBasicas.getInstance().ValidaCaracterEsfera(e);
        }

        private void txtAvcRXoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (txtAvcRXoi.Text == "0")
                {
                    txtAvcRXoi.Text = "0.00";
                }
                if (txtAddRXoi.Text != "")
                    txtAvcVCoi.Text = txtAvcRXoi.Text;
                FuncionesBasicas.getInstance().SaltarConEnter(e);
            }
        }

        private void txtAltRXoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().SoloNumeros(e);
        }

        private void txtAltRXoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (txtAltRXoi.Text == "0")
                {
                    txtAltRXoi.Text = "0.00";
                }
                FuncionesBasicas.getInstance().SaltarConEnter(e);
            }
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

            txtDiagnosticoOjoDer.Focus();
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

            txtDiagnosticoOjoIz.Focus();
        }

        private void txtEsferaRetinoOD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                bool ok = txtEsferaRetinoOD.Text.Contains("+");
                bool ok2 = txtEsferaRetinoOD.Text.Contains("-");
                if (!ok && !ok2 && txtEsferaRetinoOD.Text != "N")
                {
                    txtEsferaRetinoOD.Text = "+" + txtEsferaRetinoOD.Text;
                }
                FuncionesBasicas.getInstance().SaltarConEnter(e);
            }
        }

        private void txtEsferaRetinoOD_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().ValidaCaracterEsfera(e);
        }

        private void txtCilindroRetinoOD_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().ValidaCaracter(e);
            if (txtEsferaRetinoOD.Text == "N")
            {
                FuncionesBasicas.getInstance().ValidaN(e);
            }
        }

        private void txtEjeRetinoOD_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().SoloNumeros(e);
        }

        private void txtAvlRetinoOD_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().ValidaSlach(e);
        }

        private void txtEsperaRetinoOI_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().ValidaCaracterEsfera(e);
        }

        private void txtCilindroRetinoOI_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().ValidaCaracterEsfera(e);
        }

        private void txtEjeRetinoOI_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().ValidaCaracterEsfera(e);
        }

        private void txtAvlRetinoOI_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().ValidaCaracterEsfera(e);
        }

        private void txtCilindroRetinoOD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                bool ok = txtCilindroRetinoOD.Text.Contains("+");
                bool ok2 = txtCilindroRetinoOD.Text.Contains("-");
                if (!ok && !ok2)
                {
                    txtCilindroRetinoOD.Text = "+" + txtCilindroRetinoOD.Text;
                }
                if (txtEsferaRetinoOD.Text == "N")
                {
                    txtCilindroRetinoOD.Text = txtCilindroRetinoOD.Text.Replace('+', '-');
                    txtEsferaRetinoOD.Text = txtCilindroRetinoOD.Text.Replace('-', '+');
                }
                FuncionesBasicas.getInstance().SaltarConEnter(e);

            }
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
        }

        public void LimpiarCampos()
        {
            FuncionesBasicas.getInstance().BorrarCampos(p_Atencion);
            //p_PacienteDatos.Visible = false;
            p_Atencion.Enabled = false;
            btnBusca.Visible = true;
            btnGuardar.Visible = false;
            btnCancelar.Visible = false;
            //cmbTipoLente.Text = "";
            g_DatosPaciente.Visible = false;
            btnCertificado.Visible = false;
            btnGeneral.Enabled = false;
            btnOrdenLejana.Enabled = false;
            btnOrdenCercana.Visible = false;
            btnLentesBlandos.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validacion())
            {
                ATENCION objAtencion = new ATENCION();
                RETINOSCOPIA_DILATADA objRetiniscopia = new RETINOSCOPIA_DILATADA();

                LENTES_CONTACTO objLentes = new LENTES_CONTACTO();
                RX_FINAL objRx = new RX_FINAL();
                RX_EN_USO objRxUso = new RX_EN_USO();
                OFTALMOLOGIA objOftalmica = null;
                List<RETINOSCOPIA_DILATADA> listaRetinoscopia = new List<RETINOSCOPIA_DILATADA>();
                List<LENTES_CONTACTO> listaLentes = new List<LENTES_CONTACTO>();
                List<RX_FINAL> listaRx = new List<RX_FINAL>();
                LENTE_DEFINITIVO objLenteDef = new LENTE_DEFINITIVO();
                ADAPTACION_LENTES objAdaptacion = new ADAPTACION_LENTES();
                LENTE_PRUEBA objLentePrueba = new LENTE_PRUEBA();


                objAtencion.ID_PACIENTE = Convert.ToInt64(lblHc.Text);
                objAtencion.Tipo_Consulta = "NORMAL";
                objAtencion.Fecha_Creacion = DateTime.Now;
                objAtencion.Tipo_Seguro = lblTipo.Text;
                objAtencion.Observaciones = txtObservaciones.Text;
                objAtencion.DiagnosticoOD = txtDiagnosticoOjoDer.Text;
                objAtencion.DiagnosticoOI = txtDiagnosticoOjoIz.Text;
                objAtencion.Recomendaciones = txtRecomendaciones.Text;
                objAtencion.CUENTADIVIDIA = "NO";
                Password frm = new Password();
                frm.ShowDialog();
                if (frm.idUsuario == 0)
                {
                    return;
                }
                objAtencion.Usuario = frm.idUsuario;
                objAtencion.OPTOMETRA = txtMedico.Text;
                objAtencion.Mpc = txtMpc.Text;

                objRetiniscopia.Esfera = txtEsferaRetinoOD.Text;
                objRetiniscopia.Cilindro = txtCilindroRetinoOD.Text;
                objRetiniscopia.Eje = txtEjeRetinoOD.Text;
                objRetiniscopia.Avl = txtAvlRetinoOD.Text;
                objRetiniscopia.OJO = "D";
                listaRetinoscopia.Add(objRetiniscopia);
                objRetiniscopia = new RETINOSCOPIA_DILATADA();

                objRetiniscopia.Esfera = txtEsperaRetinoOI.Text;
                objRetiniscopia.Cilindro = txtCilindroRetinoOI.Text;
                objRetiniscopia.Eje = txtEjeRetinoOI.Text;
                objRetiniscopia.Avl = txtAvlRetinoOI.Text;
                objRetiniscopia.OJO = "I";
                listaRetinoscopia.Add(objRetiniscopia);

                objLentes.Esfera = txtEsferaLenteOD.Text;
                objLentes.Cilindro = txtCilindroLenteOD.Text;
                objLentes.Eje = txtEjeLenteOD.Text;
                objLentes.Tipo = txtTipoOD.Text;
                objLentes.OJO = "D";
                listaLentes.Add(objLentes);
                objLentes = new LENTES_CONTACTO();

                objLentes.Esfera = txtEsferaLenteOI.Text;
                objLentes.Cilindro = txtCilindroLenteOI.Text;
                objLentes.Eje = txtEjeLenteOI.Text;
                objLentes.Tipo = txtTipoOI.Text;
                objLentes.OJO = "I";
                listaLentes.Add(objLentes);

                objRx.Esfera = txtEsferaRXod.Text;
                objRx.Cilindro = txtCilindroRXod.Text;
                objRx.Eje = txtEjeRXod.Text;
                objRx.A_D_D = txtAddRXod.Text;
                objRx.AVSC = txtAvscRXod.Text;
                objRx.AVL = txtAvlRXod.Text;
                objRx.AVC = txtAvcRXod.Text;
                objRx.ALT = txtAltRXod.Text;
                objRx.DNP_DP = txtDnpRXod.Text;
                objRx.AVCC = txtAvcccRxod.Text;
                objRx.OJO = "D";
                listaRx.Add(objRx);
                objRx = new RX_FINAL();


                objRx.Esfera = txtEsferaRXoi.Text;
                objRx.Cilindro = txtCilindroRXoi.Text;
                objRx.Eje = txtEjeRXoi.Text;
                objRx.A_D_D = txtAddRXoi.Text;
                objRx.AVSC = txtAvscRXoi.Text;
                objRx.AVL = txtAvlRXoi.Text;
                objRx.AVC = txtAvcRXoi.Text;
                objRx.ALT = txtAltRXoi.Text;
                objRx.DNP_DP = txtDnpRXoi.Text;
                objRx.AVCC = txtAvcccRxoi.Text;
                objRx.OJO = "I";
                listaRx.Add(objRx);
                if (MessageBox.Show("Desea Guardar y facturar?", "OPT3000", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    objAtencion.FACTURAR = true;
                }
                else
                {
                    objAtencion.FACTURAR = false;
                }
                if (NegGuarda.getInstance().GuardaAtencion(objAtencion, listaRetinoscopia, listaLentes, listaRx, objOftalmica, objAdaptacion, objLentePrueba, objLenteDef))
                {
                    MessageBox.Show("Atención Guardada con exito :)", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGuardar.Visible = false;
                    btnGeneral.Enabled = true;
                    btnOrdenCercana.Enabled = true;
                    btnLentesBlandos.Enabled = true;
                    btnOrdenLejana.Enabled = true;
                    btnCertificado.Visible = true;
                    p_Atencion.Enabled = false;
                    reimprimirOrden1 = Convert.ToInt64(lblAtencion.Text);
                }
                else
                {
                    MessageBox.Show("Algo salio mal!!!,\r\n Revise la información a guardar :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Debe ingresar los datos solicitados. :{", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void AgregarError(Control control)
        {
            error.SetError(control, "Campo Requerido");
        }
        private void AgregarError(Control control, string texto)
        {
            error.SetError(control, texto);
        }

        public bool Validacion()
        {
            error.Clear();
            bool valido = true;
            if (txtMedico.Text == string.Empty)
            {
                AgregarError(txtMedico, "Este campor es requerido");
                valido = false;
            }
            if (txtMpc.Text == string.Empty)
            {
                AgregarError(txtMpc, "Este campor es requerido");
                valido = false;
            }
            //if (lblTipo.Text == string.Empty)
            //{
            //    AgregarError(lblTipo, "Este campor es requerido");
            //    valido = false;
            //}
            //if (txtObservaciones.Text == string.Empty)
            //{
            //    AgregarError(txtObservaciones, "Este campor es requerido");
            //    valido = false;
            //}
            if (txtDiagnosticoOjoDer.Text == string.Empty)
            {
                AgregarError(txtDiagnosticoOjoDer, "Este campor es requerido");
                valido = false;
            }
            if (txtDiagnosticoOjoIz.Text == string.Empty)
            {
                AgregarError(txtDiagnosticoOjoIz, "Este campor es requerido");
                valido = false;
            }
            //if (txtEsferaRetinoOD.Text == string.Empty)
            //{
            //    AgregarError(txtEsferaRetinoOD, "Este campor es requerido");
            //    valido = false;
            //}
            //if (txtCilindroRetinoOD.Text == string.Empty)
            //{
            //    AgregarError(txtCilindroRetinoOD, "Este campor es requerido");
            //    valido = false;
            //}
            //if (txtEjeRetinoOD.Text == string.Empty)
            //{
            //    AgregarError(txtEjeRetinoOD, "Este campor es requerido");
            //    valido = false;
            //}
            //if (txtAvlRetinoOD.Text == string.Empty)
            //{
            //    AgregarError(txtAvlRetinoOD, "Este campor es requerido");
            //    valido = false;
            //}
            //if (txtEsperaRetinoOI.Text == string.Empty)
            //{
            //    AgregarError(txtEsperaRetinoOI, "Este campor es requerido");
            //    valido = false;
            //}
            //if (txtCilindroRetinoOI.Text == string.Empty)
            //{
            //    AgregarError(txtCilindroRetinoOI, "Este campor es requerido");
            //    valido = false;
            //}
            //if (txtEjeRetinoOI.Text == string.Empty)
            //{
            //    AgregarError(txtEjeRetinoOI, "Este campor es requerido");
            //    valido = false;
            //}
            //if (txtAvlRetinoOI.Text == string.Empty)
            //{
            //    AgregarError(txtAvlRetinoOI, "Este campor es requerido");
            //    valido = false;
            //}
            //if (txtEsferaLenteOD.Text == string.Empty)
            //{
            //    AgregarError(txtEsferaLenteOD, "Este campor es requerido");
            //    valido = false;
            //}
            //if (txtCilindroLenteOD.Text == string.Empty)
            //{
            //    AgregarError(txtCilindroLenteOD, "Este campor es requerido");
            //    valido = false;
            //}
            //if (txtCilindroLenteOD.Text == string.Empty)
            //{
            //    AgregarError(txtCilindroLenteOD, "Este campor es requerido");
            //    valido = false;
            //}
            //if (txtEsferaLenteOI.Text == string.Empty)
            //{
            //    AgregarError(txtEsferaLenteOI, "Este campor es requerido");
            //    valido = false;
            //}
            //if (txtCilindroLenteOI.Text == string.Empty)
            //{
            //    AgregarError(txtCilindroLenteOI, "Este campor es requerido");
            //    valido = false;
            //}
            //if (txtCilindroLenteOI.Text == string.Empty)
            //{
            //    AgregarError(txtCilindroLenteOI, "Este campor es requerido");
            //    valido = false;
            //}
            //if (txtEsferaRXod.Text == string.Empty)
            //{
            //    AgregarError(txtEsferaRXod, "Este campor es requerido");
            //    valido = false;
            //}
            //if (txtCilindroRXod.Text == string.Empty)
            //{
            //    AgregarError(txtCilindroRXod, "Este campor es requerido");
            //    valido = false;
            //}
            //if (txtEjeRXod.Text == string.Empty)
            //{
            //    AgregarError(txtEjeRXod, "Este campor es requerido");
            //    valido = false;
            //}
            //if (txtAddRXod.Text == string.Empty)
            //{
            //    AgregarError(txtAddRXod, "Este campor es requerido");
            //    valido = false;
            //}
            //else
            //{
            //    if (txtAddRXod.Text == "")
            //    {
            //        if (txtAltRXod.Text == string.Empty)
            //        {
            //            AgregarError(txtAltRXod, "El valor debe ser mayor a 0");
            //            valido = false;
            //        }
            //    }
            //}
            //if (txtAvlRXod.Text == string.Empty)
            //{
            //    AgregarError(txtAvlRXod, "Este campor es requerido");
            //    valido = false;
            //}
            //if (txtAvcRXod.Text == string.Empty)
            //{
            //    AgregarError(txtAvcRXod, "Este campor es requerido");
            //    valido = false;
            //}
            //if (txtAltRXod.Text == string.Empty)
            //{
            //    AgregarError(txtAltRXod, "Este campor es requerido");
            //    valido = false;
            //}
            //if (txtDnpRXod.Text == string.Empty)
            //{
            //    AgregarError(txtDnpRXod, "Este campor es requerido");
            //    valido = false;
            //}
            //if (txtEsferaRXoi.Text == string.Empty)
            //{
            //    AgregarError(txtEsferaRXoi, "Este campor es requerido");
            //    valido = false;
            //}
            //if (txtCilindroRXoi.Text == string.Empty)
            //{
            //    AgregarError(txtCilindroRXoi, "Este campor es requerido");
            //    valido = false;
            //}
            //if (txtEjeRXoi.Text == string.Empty)
            //{
            //    AgregarError(txtEjeRXoi, "Este campor es requerido");
            //    valido = false;
            //}
            //if (txtAddRXoi.Text == string.Empty)
            //{
            //    AgregarError(txtAddRXoi, "Este campor es requerido");
            //    valido = false;
            //}
            //else
            //{
            //    if (txtAddRXoi.Text == "")
            //    {
            //        if (txtAltRXoi.Text == string.Empty)
            //        {
            //            AgregarError(txtAltRXoi, "El valor debe ser mayor a 0");
            //            valido = false;
            //        }
            //    }
            //}
            //if (txtAvlRXoi.Text == string.Empty)
            //{
            //    AgregarError(txtAvlRXoi, "Este campor es requerido");
            //    valido = false;
            //}
            //if (txtAvcRXoi.Text == string.Empty)
            //{
            //    AgregarError(txtAvcRXoi, "Este campor es requerido");
            //    valido = false;
            //}
            //if (txtAltRXoi.Text == string.Empty)
            //{
            //    AgregarError(txtAltRXoi, "Este campor es requerido");
            //    valido = false;
            //}
            //if (txtDnpRXoi.Text == string.Empty)
            //{
            //    AgregarError(txtDnpRXoi, "Este campor es requerido");
            //    valido = false;
            //}

            return valido;
        }

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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FuncionesBasicas.getInstance().BorrarCampos(p_Atencion);
            txtMedico.Text = "";
            RX_EN_USO();
            txtRecomendaciones.Text = "USO PERMANENTE. \r\nLUBRICACIÓN OCULAR.\r\nCONTROL EN UN AÑO.";
            p_Atencion.Enabled = true;
            btnBusca.Visible = false;
            btnCertificado.Visible = false;
            btnGuardar.Visible = true;
            btnCancelar.Visible = true;
            Int64 maximo = NegConsultas.getInstance().MaxAtencion() + 1;
            lblAtencion.Text = maximo.ToString();
            btnNuevo.Visible = false;

            btnGeneral.Enabled = false;
            btnOrdenCercana.Enabled = false;
            btnLentesBlandos.Enabled = false;
            btnOrdenLejana.Enabled = false;
            calculador = false;
            btnCertificado.Visible = false;
        }

        private void btnCargaDoc_Click(object sender, EventArgs e)
        {
            MoverArchivo frmMover = new MoverArchivo(Convert.ToInt64(lblHc.Text));
            frmMover.ShowDialog();
        }

        private void btnVerDoc_Click(object sender, EventArgs e)
        {
            string path = @"E:\PruebasGuardado\HC-" + lblHc.Text;
            if (Directory.Exists(path))
                System.Diagnostics.Process.Start(path);
            else
                System.Windows.Forms.MessageBox.Show("Paciente aun no tiene MicroFile", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMedico_Click(object sender, EventArgs e)
        {
            Medicos frm = new Medicos();
            frm.ShowDialog();
            if (frm._medico != "")
            {
                txtMedico.Text = "";
                txtMedico.Text = frm._medico;
                txtMedico.ReadOnly = true;
            }
            else
            {
                txtMedico.Text = "";
                txtMedico.ReadOnly = false;
            }
        }

        private void btnBorraOD_Click(object sender, EventArgs e)
        {
            txtEsferaVCod.Text = "";
            txtEsferaRXod.Text = "";
            txtCilindroVCod.Text = "";
            txtCilindroRXod.Text = "";
            txtEjeVCod.Text = "";
            txtEjeRXod.Text = "";
        }

        private void btnBorraOI_Click(object sender, EventArgs e)
        {
            txtEsferaVCoi.Text = "";
            txtEsferaRXoi.Text = "";
            txtCilindroVCoi.Text = "";
            txtCilindroRXoi.Text = "";
            txtEjeVCoi.Text = "";
            txtEjeRXoi.Text = "";
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
                    txtAvcscVCod.Text = "";
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
                txtAvcscVCoi.Text = "";
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

            btnCieDer.Focus();
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

        private void btnGeneral_Click(object sender, EventArgs e)
        {

            Orden1 orden = new Orden1();
            orden = NegConsultas.getInstance().RecuperaOrden2(Convert.ToInt64(lblAtencion.Text));
            Int64 reimprimirOrden1 = Convert.ToInt64(lblAtencion.Text);
            if (orden != null) 
            {
                reimprimirOrden1 = (long)orden.ID_ORDEN1;
                mensaje = true;
            }
            else
                mensaje = false;
            if (txtEsferaRXod.Text == "")
            {
                MessageBox.Show("No se puede imprimir orden de trabajo Progresivo o Bifocal ya que no tiene datos en RxFinal :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtAddRXod.Text == "")
            {
                MessageBox.Show("No se puede imprimir orden de trabajo Progresivo o Bifocal ya que no tiene datos en ADD :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Orden_Normal frm = new Orden_Normal(reimprimirOrden1, lblIdentificacion.Text, mensaje, lblAtencion.Text);
            frm.ShowDialog();
        }

        private void btnOrdenCercana_Click(object sender, EventArgs e)
        {
            ORDEN_LEJANA orden = new ORDEN_LEJANA();
            orden = NegConsultas.getInstance().RecuperaOrdenLejana2(Convert.ToInt64(lblAtencion.Text));
            Int64 reimprimirOrden2 = Convert.ToInt64(lblAtencion.Text);
            if (orden != null)
            {
                reimprimirOrden2 = orden.ID_ORDEN3;
                mensaje = true;
            }
            else
                mensaje = false;
            if (txtEsferaRXod.Text == "")
            {
                MessageBox.Show("No se puede imprimir orden de trabajo Visión Lejana ya que no tiene datos en RxFinal :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OrdenVisionLejana frm = new OrdenVisionLejana(reimprimirOrden2, lblIdentificacion.Text, mensaje, lblAtencion.Text);
            frm.ShowDialog();
        }

        private void btnOrdenLejana_Click(object sender, EventArgs e)
        {
            ORDEN_VISION_CERCA orden = new ORDEN_VISION_CERCA();
            orden = NegConsultas.getInstance().RecuperaOrdenVC2(Convert.ToInt64(lblAtencion.Text));
            Int64 reimprimirOrden2 = Convert.ToInt64(lblAtencion.Text);
            if (orden != null)
            {
                reimprimirOrden2 = orden.ID_ORDEN2;
                mensaje = true;
            }
            else
                mensaje = false;
            if (txtEsferaVCod.Text == "")
            {
                MessageBox.Show("No se puede imprimir orden de trabajo Visión Cercana ya que no tiene datos en Visión Cercana :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OrdenVisionCerca frm = new OrdenVisionCerca(reimprimirOrden2, lblIdentificacion.Text, mensaje, lblAtencion.Text);
            frm.ShowDialog();
            
        }

        private void btnLentesBlandos_Click(object sender, EventArgs e)
        {

            ORDEN_LENTESBLANDOS orden = new ORDEN_LENTESBLANDOS();
            orden = NegConsultas.getInstance().RecuperaOrdenLentesBlandos2(Convert.ToInt64(lblAtencion.Text));
            Int64 reimprimirOrden2 = Convert.ToInt64(lblAtencion.Text);
            if (orden != null)
            {
                reimprimirOrden2 = orden.ID_ORDEN4;
                mensaje = true;
            }
            else
                mensaje = false;
            if (txtEsferaLenteOD.Text == "")
            {
                MessageBox.Show("No se puede imprimir orden de trabajo Lentes de Contacto Blandos ya que no tiene datos en Lentes Blandos :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OrdenLentesBlandos frm = new OrdenLentesBlandos(reimprimirOrden2, lblIdentificacion.Text, mensaje, lblAtencion.Text);
            frm.ShowDialog();
        }

        private void chbRetinoscopia_CheckedChanged(object sender, EventArgs e)
        {
            if (chbRetinoscopia.Checked)
            {
                txtEsferaRetinoOD.Enabled = false;

                txtCilindroRetinoOD.Enabled = false;

                txtEjeRetinoOD.Enabled = false;

                txtAvlRetinoOD.Enabled = false;

                txtEsperaRetinoOI.Enabled = false;

                txtCilindroRetinoOI.Enabled = false;

                txtEjeRetinoOI.Enabled = false;

                txtAvlRetinoOI.Enabled = false;

            }
            else
            {

                txtEsferaRetinoOD.Enabled = true;
                txtEsferaRetinoOD.Text = "";
                txtCilindroRetinoOD.Enabled = true;
                txtCilindroRetinoOD.Text = "";
                txtEjeRetinoOD.Enabled = true;
                txtEjeRetinoOD.Text = "";
                txtAvlRetinoOD.Enabled = true;
                txtAvlRetinoOD.Text = "";
                txtEsperaRetinoOI.Enabled = true;
                txtEsperaRetinoOI.Text = "";
                txtCilindroRetinoOI.Enabled = true;
                txtCilindroRetinoOI.Text = "";
                txtEjeRetinoOI.Enabled = true;
                txtEjeRetinoOI.Text = "";
                txtAvlRetinoOI.Enabled = true;
                txtAvlRetinoOI.Text = "";

            }
        }

        private void chbLentes_CheckedChanged(object sender, EventArgs e)
        {
            if (chbLentes.Checked)
            {
                txtEsferaLenteOD.Enabled = false;
                txtEsferaLenteOD.Text = " ";
                txtCilindroLenteOD.Enabled = false;
                txtCilindroLenteOD.Text = " ";
                txtEjeLenteOD.Enabled = false;
                txtEjeLenteOD.Text = " ";
                txtTipoOD.Enabled = false;
                txtTipoOD.Text = " ";
                txtEsferaLenteOI.Enabled = false;
                txtEsferaLenteOI.Text = " ";
                txtCilindroLenteOI.Enabled = false;
                txtCilindroLenteOI.Text = " ";
                txtEjeLenteOI.Enabled = false;
                txtEjeLenteOI.Text = " ";
                txtTipoOI.Enabled = false;
                txtTipoOI.Text = " ";
            }
            else
            {
                txtEsferaLenteOD.Enabled = true;
                txtEsferaLenteOD.Text = "";
                txtCilindroLenteOD.Enabled = true;
                txtCilindroLenteOD.Text = "";
                txtEjeLenteOD.Enabled = true;
                txtEjeLenteOD.Text = "";
                txtTipoOD.Enabled = true;
                txtTipoOD.Text = " ";
                txtEsferaLenteOI.Enabled = true;
                txtEsferaLenteOI.Text = "";
                txtCilindroLenteOI.Enabled = true;
                txtCilindroLenteOI.Text = "";
                txtEjeLenteOI.Enabled = true;
                txtEjeLenteOI.Text = "";
                txtTipoOI.Enabled = true;
                txtTipoOI.Text = "";
            }
        }

        private void chbRxFinal_CheckedChanged(object sender, EventArgs e)
        {
            if (chbRxFinal.Checked)
            {
                txtEsferaRXod.Enabled = false;
                txtEsferaRXod.Text = " ";
                txtCilindroRXod.Enabled = false;
                txtCilindroRXod.Text = " ";
                txtEjeRXod.Enabled = false;
                txtEjeRXod.Text = " ";
                txtAddRXod.Enabled = false;
                txtAddRXod.Text = " ";
                txtAvlRXod.Enabled = false;
                txtAvlRXod.Text = " ";
                txtAvcRXod.Enabled = false;
                txtAvcRXod.Text = " ";
                txtAltRXod.Enabled = false;
                txtAltRXod.Text = " ";
                txtDnpRXod.Enabled = false;
                txtDnpRXod.Text = " ";

                txtEsferaRXoi.Enabled = false;
                txtEsferaRXoi.Text = " ";
                txtCilindroRXoi.Enabled = false;
                txtCilindroRXoi.Text = " ";
                txtEjeRXoi.Enabled = false;
                txtEjeRXoi.Text = " ";
                txtAddRXoi.Enabled = false;
                txtAddRXoi.Text = " ";
                txtAvlRXoi.Enabled = false;
                txtAvlRXoi.Text = " ";
                txtAvcRXoi.Enabled = false;
                txtAvcRXoi.Text = " ";
                txtAltRXoi.Enabled = false;
                txtAltRXoi.Text = " ";
                txtDnpRXoi.Enabled = false;
                txtDnpRXoi.Text = " ";
                btnCalculadora.Enabled = false;

                txtEsferaVCod.Enabled = false;
                txtEsferaVCod.Text = " ";
                txtCilindroVCod.Enabled = false;
                txtCilindroVCod.Text = " ";
                txtEjeVCod.Enabled = false;
                txtEjeVCod.Text = " ";
                txtDnpVCod.Enabled = false;
                txtDnpVCod.Text = " ";
                txtAvcVCod.Enabled = false;
                txtAvcVCod.Text = " ";

                txtEsferaVCoi.Enabled = false;
                txtEsferaVCoi.Text = " ";
                txtCilindroVCoi.Enabled = false;
                txtCilindroVCoi.Text = " ";
                txtEjeVCoi.Enabled = false;
                txtEjeVCoi.Text = " ";
                txtDnpVCoi.Enabled = false;
                txtDnpVCoi.Text = " ";
                txtAvcVCoi.Enabled = false;
                txtAvcVCoi.Text = " ";
            }
            else
            {
                txtEsferaRXod.Enabled = true;
                txtEsferaRXod.Text = "";
                txtCilindroRXod.Enabled = true;
                txtCilindroRXod.Text = "";
                txtEjeRXod.Enabled = true;
                txtEjeRXod.Text = "";
                txtAddRXod.Enabled = true;
                txtAddRXod.Text = "";
                txtAvlRXod.Enabled = true;
                txtAvlRXod.Text = "";
                txtAvcRXod.Enabled = true;
                txtAvcRXod.Text = "";
                txtAltRXod.Enabled = true;
                txtAltRXod.Text = "";
                txtDnpRXod.Enabled = true;
                txtDnpRXod.Text = "";

                txtEsferaRXoi.Enabled = true;
                txtEsferaRXoi.Text = "";
                txtCilindroRXoi.Enabled = true;
                txtCilindroRXoi.Text = "";
                txtEjeRXoi.Enabled = true;
                txtEjeRXoi.Text = "";
                txtAddRXoi.Enabled = true;
                txtAddRXoi.Text = "";
                txtAvlRXoi.Enabled = true;
                txtAvlRXoi.Text = "";
                txtAvcRXoi.Enabled = true;
                txtAvcRXoi.Text = "";
                txtAltRXoi.Enabled = true;
                txtAltRXoi.Text = "";
                txtDnpRXoi.Enabled = true;
                txtDnpRXoi.Text = "";

                txtEsferaVCod.Enabled = true;
                txtEsferaVCod.Text = "";
                txtCilindroVCod.Enabled = true;
                txtCilindroVCod.Text = "";
                txtEjeVCod.Enabled = true;
                txtEjeVCod.Text = "";
                txtDnpVCod.Enabled = true;
                txtDnpVCod.Text = "";
                txtAvcVCod.Enabled = true;
                txtAvcVCod.Text = "";

                txtEsferaVCoi.Enabled = true;
                txtEsferaVCoi.Text = "";
                txtCilindroVCoi.Enabled = true;
                txtCilindroVCoi.Text = "";
                txtEjeVCoi.Enabled = true;
                txtEjeVCoi.Text = "";
                txtDnpVCoi.Enabled = true;
                txtDnpVCoi.Text = "";
                txtAvcVCoi.Enabled = true;
                txtAvcVCoi.Text = "";

                btnCalculadora.Enabled = true;
            }
        }

        private void chbUso_CheckedChanged(object sender, EventArgs e)
        {
            if (chbUso.Checked)
            {
                txtEsferaRXusoOD.Enabled = false;
                txtEsferaRXusoOD.Text = " ";
                txtCilindroRXusoOD.Enabled = false;
                txtCilindroRXusoOD.Text = " ";
                txtEjeRXusoOD.Enabled = false;
                txtEjeRXusoOD.Text = " ";
                txtAVLRXusoOD.Enabled = false;
                txtAVLRXusoOD.Text = " ";
                txtAVCRXusoOD.Enabled = false;
                txtAVCRXusoOD.Text = " ";

                txtEsferaRXusoOI.Enabled = false;
                txtEsferaRXusoOI.Text = " ";
                txtCilindroRXusoOI.Enabled = false;
                txtCilindroRXusoOI.Text = " ";
                txtEjeRXusoOI.Enabled = false;
                txtEjeRXusoOI.Text = " ";
                txtAVLRXusoOI.Enabled = false;
                txtAVLRXusoOI.Text = " ";
                txtAVCRXusoOI.Enabled = false;
                txtAVCRXusoOI.Text = " ";
            }
            else
            {
                txtEsferaRXusoOD.Enabled = true;
                txtEsferaRXusoOD.Text = "";
                txtCilindroRXusoOD.Enabled = true;
                txtCilindroRXusoOD.Text = "";
                txtEjeRXusoOD.Enabled = true;
                txtEjeRXusoOD.Text = "";
                txtAVLRXusoOD.Enabled = true;
                txtAVLRXusoOD.Text = "";
                txtAVCRXusoOD.Enabled = true;
                txtAVCRXusoOD.Text = "";

                txtEsferaRXusoOI.Enabled = true;
                txtEsferaRXusoOI.Text = "";
                txtCilindroRXusoOI.Enabled = true;
                txtCilindroRXusoOI.Text = "";
                txtEjeRXusoOI.Enabled = true;
                txtEjeRXusoOI.Text = "";
                txtAVLRXusoOI.Enabled = true;
                txtAVLRXusoOI.Text = "";
                txtAVCRXusoOI.Enabled = true;
                txtAVCRXusoOI.Text = "";
            }
        }

        private void txtEsferaRXusoOD_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtCilindroRXusoOD_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtEjeRXusoOD_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtEsferaRXusoOI_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtCilindroRXusoOI_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtEjeRXusoOI_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnCertificado_Click(object sender, EventArgs e)
        {
            Entidades.Certificado cer = new Entidades.Certificado();
            cer.paciente = lblNombrePaciente.Text;
            cer.edad = lblEdad.Text;
            cer.ODLejosEsfera = txtEsferaRXod.Text;
            cer.OILejosesfera = txtEsferaRXoi.Text;
            cer.ODLejosCilindro = txtCilindroRXod.Text;
            cer.OILejosCilindro = txtCilindroRXoi.Text;
            cer.ODLejosEje = txtEjeRXod.Text;
            cer.OILejosEje = txtEjeRXoi.Text;
            cer.ODLecturaEsfera = txtEsferaVCod.Text;
            cer.OILecturaEsfera = txtEsferaVCoi.Text;
            cer.ODLecturaCilindro = txtCilindroVCod.Text;
            cer.OILecturaCilindro = txtCilindroVCoi.Text;
            cer.Cie10OD = txtDiagnosticoOjoDer.Text;
            cer.Cie10OI = txtDiagnosticoOjoIz.Text;
            cer.ODavlsc = txtAvscRXod.Text;
            cer.OIavlsc = txtAvscRXoi.Text;
            cer.ODavlcc = txtAvlRXod.Text;
            cer.OIavlcc = txtAvlRXoi.Text;
            cer.ODavcsc = txtAvcccRxod.Text;
            cer.OIavcsc = txtAvcccRxoi.Text;
            cer.ODavccc = txtAvcRXod.Text;
            cer.OIavccc = txtAvcRXoi.Text;
            cer.ODAddEsfera = txtAddRXod.Text;
            cer.OIAddEsfera = txtAddRXoi.Text;
            CertificadoMedico frmCert = new CertificadoMedico(txtRecomendaciones.Text);
            frmCert.ShowDialog();
            if (frmCert.oftal.Trim() == "" || frmCert.vision.Trim() == "" || frmCert.recom.Trim() == "")
                return;
            cer.oftalmica = frmCert.oftal;
            cer.Recomendaciones = frmCert.recom;
            cer.visionColor = frmCert.vision;
            Utilitarios.Reportes.Reporteador frm = new Utilitarios.Reportes.Reporteador(null, "Certificado", cer);
            frm.Show();
        }

        private void txtAvcccRxod_Leave(object sender, EventArgs e)
        {
            if (txtAvcccRxod.Text != "" && txtAddRXod.Text != "")
            {
                txtAvcscVCod.Text = txtAvcccRxod.Text;
            }
        }

        private void txtAvcccRxoi_Leave(object sender, EventArgs e)
        {
            if (txtAvcccRxoi.Text != "" && txtAddRXod.Text != "")
            {
                txtAvcscVCoi.Text = txtAvcccRxoi.Text;
            }
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

        private void btnAbiriAtenciones_Click(object sender, EventArgs e)
        {
            frmOrdenesTrab frm = new frmOrdenesTrab(lblIdentificacion.Text);
            frm.Show();

        }

        private void txtMpc_Leave(object sender, EventArgs e)
        {
            btnMedico.Focus();
        }

        private void txtDiagnosticoOjoDer_Leave(object sender, EventArgs e)
        {
        }
    }
}

