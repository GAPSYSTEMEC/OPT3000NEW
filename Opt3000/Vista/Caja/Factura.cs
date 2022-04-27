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
using Opt3000.Vista.Utilitarios;
using Opt3000.BaseDatos;
using System.Xml.Linq;
using Opt3000.Vista.Utilitarios.Menu;

namespace Opt3000.Vista.Caja
{
    public partial class Factura : Form
    {
        PACIENTE objPaciente = new PACIENTE();
        DataTable objDetalle = new DataTable();
        ATENCION objAtencion = new ATENCION();
        FORMA_PAGO objForPag = new FORMA_PAGO();
        DataTable datForamaPago = new DataTable();
        private decimal valorAnticipo = 0;
        bool gridFPago = false;
        public Factura()
        {
            InitializeComponent();

            objDetalle.Columns.Add("ID").ReadOnly = true;
            objDetalle.Columns.Add("DETALLE").ReadOnly = true;
            objDetalle.Columns.Add("CANTIDAD").ReadOnly = true;
            objDetalle.Columns.Add("PRECIO UNITARIO").ReadOnly = true;
            objDetalle.Columns.Add("DESCUENTO").ReadOnly = false;
            objDetalle.Columns.Add("IVA").ReadOnly = false;
            objDetalle.Columns.Add("PRECIO").ReadOnly = false;
            dgv_Detalle.DataSource = objDetalle;
            lblIva.Text = NegConsultas.getInstance().RecuperaParametro("iva");
            string[] iva = lblIva.Text.Split('.');
            lblIva.Text = iva[1] + "%:";

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (FuncionesBasicas.getInstance().CerrarFormulario("LA FACTURA"))
                this.Close();
        }

        public void SumaSaldos()
        {
            decimal total = 0;
            decimal anticipo = 0;
            try
            {
                anticipo = Convert.ToDecimal(txtAnticipos.Text);
                total = Convert.ToDecimal(txtTotal.Text);
            }
            catch
            {
            }
            label8.Visible = true;
            label22.Visible = true;
            label22.Text = (total - anticipo).ToString();
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            BuscadorPacientes frmBuscador = new BuscadorPacientes();
            frmBuscador.ShowDialog();
            if (frmBuscador.cedula != "")
                objPaciente = NegConsultas.getInstance().CargaPaciente(frmBuscador.cedula);
            else
                return;
            if (objPaciente != null)
            {
                lblNombrePaciente.Text = objPaciente.Apellidos + " " + objPaciente.Nombres;
                lblIdentificacion.Text = objPaciente.Identificacion;
                lblOcupacion.Text = objPaciente.Ocupacion;
                lblHc.Text = objPaciente.ID_PACIENTE.ToString();
                lblEdad.Text = FuncionesBasicas.getInstance().CalculaEdad(objPaciente.F_Nacimiento).ToString();
                CONVENIO objConvenio = new CONVENIO();
                objConvenio = NegConsultas.getInstance().ConsultaConvenio(objPaciente.ID_TIPO);
                lblTipo.Text = objConvenio.Detalle;

                List<ATENCION> lista = new List<ATENCION>();
                lista = NegConsultas.getInstance().CargaAtenciones(objPaciente.ID_PACIENTE, "", 1);
                if (lista.Count > 0)
                {
                    BuscadorAtencion frmBuscaAtencion = new BuscadorAtencion(objPaciente.ID_PACIENTE);
                    frmBuscaAtencion.ShowDialog();
                    if (frmBuscaAtencion.ateCodigo != "")
                    {
                        objAtencion = NegConsultas.getInstance().CargaAtencion(Convert.ToInt64(frmBuscaAtencion.ateCodigo));
                        p_PacienteDatos.Visible = true;
                        p_Atencion.Enabled = true;
                        btnBusca.Visible = false;
                        btnFacturar.Visible = true;
                        btnAgrupacion.Visible = true;
                    }
                    else
                        return;

                    if (objAtencion != null)
                    {
                        lblAtencion.Text = objAtencion.ID_ATENCION.ToString();
                        p_Atencion.Enabled = true;
                        btnFacturar.Visible = true;
                        btnAgrupacion.Visible = true;
                        btnNuevo.Visible = false;
                    }
                    txtNombre.Text = objPaciente.Nombres;
                    txtApellido.Text = objPaciente.Apellidos;
                    txtDireccion.Text = objPaciente.Direccion;
                    txtTelefono.Text = objPaciente.Celular;
                    txtIdentificacion.Text = objPaciente.Identificacion;
                    txtEmail.Text = objPaciente.Email;
                    CargaCuentaPaciente();
                    CargaAnticipos();
                    SumaSaldos();
                }
                else
                {
                    LimpiarCampos();
                    MessageBox.Show("Paciente no tiene valores por cobrar :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void CargaCuentaPaciente()
        {
            try
            {
                decimal conIva = 0;
                decimal sinIva = 0;
                decimal iva = 0;
                decimal descuento = 0;
                decimal subTotal = 0;
                decimal total = 0;
                List<CUENTA_PACIENTE> listaCuenta = new List<CUENTA_PACIENTE>();
                listaCuenta = NegConsultas.getInstance().RetornaCuentasAgrupadas(objAtencion.ID_ATENCION);
                foreach (var item1 in listaCuenta)
                {
                    List<DETALLE> lista = new List<DETALLE>();
                    lista = NegConsultas.getInstance().RecuperaCuentaPaciente(item1.ID_CUENTA_PACIENTE);
                    foreach (var item in lista)
                    {
                        PRODUCTO detalle = NegConsultas.getInstance().Producto(item.ID_PRODUCTO);
                        objDetalle.Rows.Add(new object[] { detalle.CodProducto, detalle.Detalle, item.Cantidad, item.Sub_total, item.Descuento, item.Iva, item.Total });
                        subTotal += item.Sub_total;
                        descuento += item.Descuento;
                        if (item.Iva != 0)
                            conIva += item.Total;
                        else
                            sinIva += item.Total;
                        iva += item.Iva;
                        total += item.Total + item.Iva - item.Descuento;
                    }
                }
                dgv_Detalle.DataSource = objDetalle;
                dgv_Detalle.Columns["ID"].Width = 50;
                dgv_Detalle.Columns["DETALLE"].Width = 350;
                dgv_Detalle.Columns["CANTIDAD"].Width = 75;
                dgv_Detalle.Columns["PRECIO UNITARIO"].Width = 90;
                dgv_Detalle.Columns["DESCUENTO"].Width = 90;
                dgv_Detalle.Columns["IVA"].Width = 90;
                dgv_Detalle.Columns["PRECIO"].Width = 90;
                dgv_Detalle.Columns["IVA"].ReadOnly = true;
                dgv_Detalle.Columns["PRECIO"].ReadOnly = true;
                txtSubtotal.Text = Math.Round(subTotal, 2).ToString();
                txtDescuento.Text = Math.Round(descuento, 2).ToString();
                txtSinIva.Text = Math.Round(sinIva, 2).ToString();
                txtConIva.Text = Math.Round(conIva, 2).ToString();
                TxtIva.Text = Math.Round(iva, 2).ToString();
                txtTotal.Text = Math.Round(total, 2).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar la cuenta del paciente", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void CargaAnticipos()
        {
            try
            {
                List<ANTICIPOS> anticipo = new List<ANTICIPOS>();
                decimal ant = 0;
                anticipo = NegConsultas.getInstance().CargaAnticipos(objPaciente.ID_PACIENTE);
                if (anticipo.Count > 0)
                {
                    foreach (var item in anticipo)
                    {
                        ant += item.Saldo;
                    }
                    if (ant > 0)
                    {
                        txtAnticipos.Text = Math.Round(ant, 2).ToString();

                    }
                }

                SumaSaldos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnCambiaFecha_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("La fecha se va MODIFICAR lo cual va afectar a la fecha en el SRI ¿DESEA CONTINUAR? :O", "OTP3000", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                dtp_FechaConsulta.Enabled = true;
        }

        private void dtp_FechaConsulta_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_FechaConsulta.Value > DateTime.Now.Date)
            {
                dtp_FechaConsulta.Value = DateTime.Now.Date;
            }

        }

        public void LimpiarCampos()
        {
            FuncionesBasicas.getInstance().BorrarCampos(p_Atencion);
            p_PacienteDatos.Visible = false;
            p_Atencion.Enabled = false;
            btnBusca.Visible = true;
            btnFacturar.Visible = false;
            btnAgrupacion.Visible = false;
            btnNuevo.Visible = true;
            objDetalle = new DataTable();
            objDetalle.Columns.Add("ID").ReadOnly = true;
            objDetalle.Columns.Add("DETALLE").ReadOnly = true;
            objDetalle.Columns.Add("CANTIDAD").ReadOnly = true;
            objDetalle.Columns.Add("PRECIO UNITARIO").ReadOnly = true;
            objDetalle.Columns.Add("DESCUENTO").ReadOnly = false;
            objDetalle.Columns.Add("IVA").ReadOnly = false;
            objDetalle.Columns.Add("PRECIO").ReadOnly = false;
            dgv_Detalle.DataSource = objDetalle;
        }

        private void btnCargaDoc_Click(object sender, EventArgs e)
        {
            if (ValidaDatosFactura())
            {
                ColorFondo();
                btnCargaDoc.BackColor = Color.CornflowerBlue;
                CLIENTE cli = new CLIENTE();
                Int64 ateCodigo = 0;
                if (p_datosPaciente.Visible == true)
                {
                    ateCodigo = Convert.ToInt64(lblAtencion.Text);
                }
                else
                {
                    ateCodigo = 1;
                }
                cli.Nombre = txtNombre.Text;
                cli.Apellidos = txtApellido.Text;
                cli.Identificacion = txtIdentificacion.Text;
                cli.Direccion = txtDireccion.Text;
                cli.Telefono = txtTelefono.Text;
                cli.Email = txtEmail.Text;
                BuscarInventario buscador = new BuscarInventario(cli, ateCodigo);
                buscador.ShowDialog();
                objDetalle = new DataTable();
                objDetalle.Columns.Add("ID").ReadOnly = true;
                objDetalle.Columns.Add("DETALLE").ReadOnly = true;
                objDetalle.Columns.Add("CANTIDAD").ReadOnly = true;
                objDetalle.Columns.Add("PRECIO UNITARIO").ReadOnly = true;
                objDetalle.Columns.Add("DESCUENTO").ReadOnly = false;
                objDetalle.Columns.Add("IVA").ReadOnly = false;
                objDetalle.Columns.Add("PRECIO").ReadOnly = false;
                dgv_Detalle.DataSource = objDetalle;
                CargaCuentaPaciente();
                SumaSaldos();
            }
        }

        private bool ValidaDatosFactura()
        {
            error.Clear();
            bool valido = true;
            if (txtNombre.Text == "")
            {
                AgregarError(txtNombre, "Falta Nombre de Cliente :(");
                return valido = false;
            }
            if (txtApellido.Text == "")
            {
                AgregarError(txtApellido, "Falta Apellido de Cliente :(");
                return valido = false;
            }
            if (txtIdentificacion.Text == "")
            {
                AgregarError(txtIdentificacion, "Falta Identificación de Cliente :(");
                return valido = false;
            }
            if (txtDireccion.Text == "")
            {
                AgregarError(txtDireccion, "Falta Dirección de Cliente :(");
                return valido = false;
            }
            if (txtTelefono.Text == "")
            {
                AgregarError(txtTelefono, "Falta Teléfono de Cliente :(");
                return valido = false;
            }
            if (txtEmail.Text == "")
            {
                AgregarError(txtEmail, "Falta E-mail de Cliente :(");
                return valido = false;
            }
            return valido;
        }

        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!rb_Pass.Checked)
                FuncionesBasicas.getInstance().SoloNumeros(e);

        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text != "")
                if (!FuncionesBasicas.getInstance().ValidaEmail(txtEmail.Text))
                {
                    MessageBox.Show("E-mail Incorrecto :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmail.Text = "";
                }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().SoloNumeros(e);
        }

        private void txtIdentificacion_Leave(object sender, EventArgs e)
        {
            if (txtIdentificacion.Text != "")
                if (!rb_Pass.Checked)
                    if (!FuncionesBasicas.getInstance().ValidaIdentificacion(txtIdentificacion.Text))
                    {
                        MessageBox.Show("Identificación Incorrecta :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (MessageBox.Show("Si esta seguro que la identificacion es correcta precione aceptar", "OPT3000", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                            txtIdentificacion.Text = "";
                    }
                    else
                    {
                        if (txtIdentificacion.Text.Length != 13 && rb_Ruc.Checked)
                        {
                            txtIdentificacion.Text += "001";
                        }
                        else if (txtIdentificacion.Text.Length != 10)
                        {
                            txtIdentificacion.Text = txtIdentificacion.Text.Substring(0, 10);
                        }
                        CLIENTE cliente = new CLIENTE();
                        cliente = NegConsultas.getInstance().RecuperaCliente(txtIdentificacion.Text);
                        if (cliente != null)
                        {
                            txtNombre.Text = cliente.Nombre;
                            txtApellido.Text = cliente.Apellidos;
                            txtDireccion.Text = cliente.Direccion;
                            txtTelefono.Text = cliente.Telefono;
                            txtEmail.Text = cliente.Email;
                        }
                    }
        }

        private void chk_OtrosDatos_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_OtrosDatos.Checked)
            {
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtDireccion.Text = "";
                txtTelefono.Text = "";
                txtIdentificacion.Text = "";
                txtEmail.Text = "";
                groupBox1.Enabled = true;
            }
            else
            {
                txtNombre.Text = objPaciente.Nombres;
                txtApellido.Text = objPaciente.Apellidos;
                txtDireccion.Text = objPaciente.Direccion;
                txtTelefono.Text = objPaciente.Celular;
                txtIdentificacion.Text = objPaciente.Identificacion;
                txtEmail.Text = objPaciente.Email;
                groupBox1.Enabled = false;
                rb_Cedula.Checked = true;
                rb_Pass.Checked = false;
                rb_Ruc.Checked = false;
            }
        }

        private void txtIdentificacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void txtApellido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                FuncionesBasicas.getInstance().SaltarConEnter(e);
        }

        private void rb_Cedula_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Cedula.Checked && txtIdentificacion.Text.Length != 10 && txtIdentificacion.Text != "")
            {
                txtIdentificacion.Text = txtIdentificacion.Text.Substring(0, 10);
            }
        }

        private void rb_Ruc_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Ruc.Checked && txtIdentificacion.Text.Length != 13 && rb_Ruc.Checked && txtIdentificacion.Text != "")
            {
                txtIdentificacion.Text = txtIdentificacion.Text.Substring(0, 10) + "001";
            }
        }

        private void txtAnticipos_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesBasicas.getInstance().OnlyNumberDecimal(e);
        }

        private void btnFormaPago_Click(object sender, EventArgs e)
        {
            //GRID DE FORMAS DE PAGO ESTA A LA ALTURA DE GRID DETALLE ESTA COMO VISIBLE FALSE 
            ColorFondo();
            btnFormaPago.BackColor = Color.CornflowerBlue;
            if (btnFormaPago.Text == "FORMAS DE PAGO")
            {
                btnFormaPago.Text = "DETALLE DE FACTURA";
                lblDetalle.Text = "FORMAS DE PAGO";
                dgv_Detalle.Visible = false;
                dgv_FormasPago.Visible = true;
                if (!gridFPago)
                {
                    gridFPago = true;

                }
            }
            else
            {
                btnFormaPago.Text = "FORMAS DE PAGO";
                lblDetalle.Text = "DETALLE DE FACTURA";
                dgv_Detalle.Visible = true;
                dgv_FormasPago.Visible = false;
            }
        }

        private void dgv_FormasPago_KeyDown(object sender, KeyEventArgs e)
        {
            TIEMPODIFERIDO tiempo = new TIEMPODIFERIDO();
            tiempo = NegConsultas.getInstance().RecuperaTiempo(1);
            int columna = dgv_FormasPago.SelectedCells[0].ColumnIndex;
            int fila = dgv_FormasPago.CurrentRow.Index;
            if (e.KeyValue == (char)Keys.F1)
            {
                try
                {
                    decimal tt = 0;
                    if (columna == 0)
                    {
                        FormasPago frm = new FormasPago(objPaciente.ID_PACIENTE);
                        frm.ShowDialog();

                        if (frm.codigo != null)
                        {
                            DataGridViewRow dt = new DataGridViewRow();
                            dt.CreateCells(dgv_FormasPago);
                            dt.Cells[0].Value = "";
                            dt.Cells[1].Value = "";
                            dt.Cells[2].Value = "";
                            dt.Cells[3].Value = "";
                            dt.Cells[4].Value = tiempo.Detalle;
                            dt.Cells[5].Value = "";
                            dt.Cells[6].Value = "";
                            dt.Cells[7].Value = txtApellido.Text + " " + txtNombre.Text;
                            dgv_FormasPago.Rows.Add(dt);
                        }
                        else
                            return;
                        dgv_FormasPago.Rows[fila].Cells[columna].Value = frm.codigo;
                        dgv_FormasPago.Rows[fila].Cells[1].Value = frm.detalle;
                        if (frm.codAnti != null)
                        {
                            dgv_FormasPago.Rows[fila].Cells[8].Value += frm.codAnti;
                            valorAnticipo = Convert.ToDecimal(frm.saldo);
                            dgv_FormasPago.Rows[fila].Cells[2].Value = valorAnticipo;
                            return;
                        }
                        else
                        {

                            for (int i = 0; i < dgv_FormasPago.Rows.Count - 1; i++)
                            {
                                if (dgv_FormasPago.Rows[i].Cells[2].Value.ToString() == "")
                                {
                                    dgv_FormasPago.Rows[i].Cells[2].Value = Convert.ToDecimal(txtTotal.Text) - tt;
                                }
                                else
                                    tt += Convert.ToDecimal(dgv_FormasPago.Rows[i].Cells[2].Value.ToString());
                            }
                            return;

                        }
                    }
                    else if (columna == 3)
                    {
                        Bancos frm = new Bancos(true);
                        frm.ShowDialog();
                        dgv_FormasPago.Rows[fila].Cells[3].Value = frm.banc;
                    }
                    else if (columna == 4)
                    {
                    }
                }
                catch (Exception err)
                {

                    throw err;
                }
            }
            else if (e.KeyValue == (char)Keys.Delete)
            {
                dgv_FormasPago.Rows.RemoveAt(fila);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void GuardaFactura()
        {
            CLIENTE cliente = new CLIENTE();
            List<ANTICIPOS> anticipos = new List<ANTICIPOS>();
            List<FACTURA_PAGO> facturaPago = new List<FACTURA_PAGO>();
            List<DETALLE> detalle = new List<DETALLE>();
            FACTURA factura = new FACTURA();
            cliente.Identificacion = txtIdentificacion.Text;
            cliente.Nombre = txtNombre.Text;
            cliente.Apellidos = txtApellido.Text;
            cliente.Direccion = txtDireccion.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.Email = txtEmail.Text;
            NegGuarda.getInstance().GuardaCliente(cliente);
            for (int i = 0; i < dgv_FormasPago.Rows.Count - 1; i++)
            {
                if (dgv_FormasPago.Rows[i].Cells[8].Value != null)
                {
                    ANTICIPOS anti = new ANTICIPOS();
                    anti = NegConsultas.getInstance().RecuperaAnticipo(Convert.ToInt64(dgv_FormasPago.Rows[i].Cells[8].Value.ToString()));
                    anti.Saldo = anti.Valor - Convert.ToDecimal(dgv_FormasPago.Rows[i].Cells[2].Value);
                    anticipos.Add(anti);
                }
                TIEMPODIFERIDO tiempo = new TIEMPODIFERIDO();

                tiempo = NegConsultas.getInstance().RecuperaTiempo(Convert.ToInt16(dgv_FormasPago.Rows[i].Cells[0].Value.ToString()));
                FACTURA_PAGO pago = new FACTURA_PAGO();
                pago.ID_FORMAPAGO = Convert.ToInt16(dgv_FormasPago.Rows[i].Cells[0].Value.ToString());
                if (dgv_FormasPago.Rows[i].Cells[4].Value.ToString() != "CORRIENTE")
                {
                    pago.Tiempo_Diferido = tiempo.ID_TIEMPODIFERIDO;
                    pago.Lote = dgv_FormasPago.Rows[i].Cells[5].Value.ToString();
                    pago.Autorizacion = dgv_FormasPago.Rows[i].Cells[6].Value.ToString();
                    pago.Duenio = dgv_FormasPago.Rows[i].Cells[7].Value.ToString();
                }
                else
                {
                    pago.Tiempo_Diferido = 1;
                    pago.Lote = "";
                    pago.Autorizacion = "";
                    pago.Duenio = "";
                }

                facturaPago.Add(pago);
            }


            CAJA objCaja = new CAJA();
            objCaja = NegConsultas.getInstance().RecuperaCaja(1);
            int completar = objCaja.Secuencial.ToString().Length;
            completar = 9 - completar;
            int n_factura = objCaja.Secuencial.ToString("D").Length + completar;

            factura.ID_ATENCION = Convert.ToInt64(lblAtencion.Text);
            factura.Fecha_Emision = dtp_FechaConsulta.Value;
            factura.Arqueada = false;
            factura.ID_CAJA = 1;
            factura.Numero_Factura = objCaja.Secuencial.ToString("D" + n_factura.ToString());

            if (NegGuarda.getInstance().GuardaFactura(cliente, anticipos, facturaPago, factura, objCaja))
            {
                MessageBox.Show("Factura Guardada con EXITO :)", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (GeneraXML())
                {
                    MessageBox.Show("Factura enviada al SRI :)", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Factura no enviada al SRI :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }

        }

        public bool GeneraXML()
        {
            try
            {
                #region XML FACTURA
                int idSuc = 1;
                EMPRESA empresa = new EMPRESA();
                SUCURSAL sucursal = new SUCURSAL();
                CAJA caja = new CAJA();
                empresa = NegConsultas.getInstance().RecuperaEmpresa();
                sucursal = NegConsultas.getInstance().RecuperaSucursal(idSuc);
                caja = NegConsultas.getInstance().RecuperaCaja(sucursal.ID_SUCURSAL);
                Int64 NumeroFactura = caja.Secuencial;
                int digitos = 9 - Convert.ToString(NumeroFactura + 1).Length;
                string secuencial = (NumeroFactura + 1).ToString();
                for (int i = 1; i <= digitos; i++)
                {
                    secuencial = "0" + secuencial;
                }
                string numfactura = caja.PtoEmision + caja.Caja + secuencial;
                string clave = "01" + empresa.Ruc + empresa.Ambiente + numfactura;
                clave = FuncionesBasicas.getInstance().ClaveAccesoSRI(dtp_FechaConsulta.Value.ToString(), clave, Convert.ToString(empresa.Emision));
                XDocument documento = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"));
                XElement factura = new XElement("factura", new XAttribute("id", "comprobante"), new XAttribute("version", "1.1.0"));
                documento.Add(factura);

                XElement infoTributaria = new XElement("infoTributaria");
                factura.Add(infoTributaria);
                infoTributaria.Add(new XElement("ambiente", empresa.Ambiente));
                infoTributaria.Add(new XElement("tipoEmision", empresa.Emision));
                infoTributaria.Add(new XElement("razonSocial", empresa.Razon_Social));
                infoTributaria.Add(new XElement("nombreComercial", empresa.Nombre_Comercial));
                infoTributaria.Add(new XElement("ruc", empresa.Ruc));
                infoTributaria.Add(new XElement("claveAcceso", clave));
                infoTributaria.Add(new XElement("codDoc", "01"));
                infoTributaria.Add(new XElement("estab", caja.PtoEmision));
                infoTributaria.Add(new XElement("ptoEmi", caja.Caja));
                infoTributaria.Add(new XElement("secuencial", secuencial));
                infoTributaria.Add(new XElement("dirMatriz", empresa.Direccion_Matriz));

                XElement infoFactura = new XElement("infoFactura");
                factura.Add(infoFactura);
                infoFactura.Add(new XElement("fechaEmision", DateTime.Now.Date.ToString("dd-MM-yyyy")));
                infoFactura.Add(new XElement("dirEstablecimiento", sucursal.Direccion));
                infoFactura.Add(new XElement("contribuyenteEspecial", empresa.Contribuyente));
                if (empresa.Lleva_Contabilidad)
                    infoFactura.Add(new XElement("obligadoContabilidad", "SI"));
                else
                    infoFactura.Add(new XElement("obligadoContabilidad", "NO"));
                string tipoIdentificacion;
                if (rb_Cedula.Checked)
                    tipoIdentificacion = "05";
                else if (rb_Ruc.Checked)
                    tipoIdentificacion = "04";
                else if (rb_Pass.Checked)
                    tipoIdentificacion = "06";
                else
                    tipoIdentificacion = "07";
                infoFactura.Add(new XElement("tipoIdentificacionComprador", tipoIdentificacion));
                infoFactura.Add(new XElement("razonSocialComprador", txtNombre.Text + " " + txtApellido.Text));
                infoFactura.Add(new XElement("identificacionComprador", txtIdentificacion.Text));
                infoFactura.Add(new XElement("direccionComprador", txtDireccion.Text));
                infoFactura.Add(new XElement("totalSinImpuestos", Convert.ToDecimal(txtSubtotal.Text) - Convert.ToDecimal(txtDescuento.Text)));
                infoFactura.Add(new XElement("totalDescuento", txtDescuento.Text));
                XElement totalConImpuestos = new XElement("totalConImpuestos");
                infoFactura.Add(totalConImpuestos);
                for (int i = 0; i < 2; i++)
                {
                    int codigo;
                    decimal valores;
                    decimal ivaTotal;
                    if (i == 0)
                    {
                        valores = Convert.ToDecimal(txtConIva.Text);
                        codigo = 2;
                        ivaTotal = Convert.ToDecimal(TxtIva.Text);
                    }
                    else
                    {
                        valores = Convert.ToDecimal(txtSinIva.Text);
                        codigo = 0;
                        ivaTotal = 0;
                    }
                    XElement totalImpuesto = new XElement("totalImpuesto");
                    totalConImpuestos.Add(totalImpuesto);
                    totalImpuesto.Add(new XElement("codigo", 2));
                    totalImpuesto.Add(new XElement("codigoPorcentaje", codigo));
                    totalImpuesto.Add(new XElement("descuentoAdicional", "0.00"));
                    totalImpuesto.Add(new XElement("baseImponible", valores.ToString("N2")));
                    totalImpuesto.Add(new XElement("valor", ivaTotal.ToString("N2")));
                }
                decimal importe = Convert.ToDecimal(txtTotal.Text);
                infoFactura.Add(new XElement("propina", "0.00"));
                infoFactura.Add(new XElement("importeTotal", importe.ToString("N2")));
                infoFactura.Add(new XElement("moneda", "DOLAR"));
                XElement pagos = new XElement("pagos");
                infoFactura.Add(pagos);
                foreach (DataGridViewRow inspector in dgv_FormasPago.Rows)
                {
                    if (inspector.Cells["MONTO"].Value != null)
                    {
                        decimal valor = Convert.ToDecimal(inspector.Cells["MONTO"].Value.ToString());
                        XElement pago = new XElement("pago");
                        pagos.Add(pago);
                        pago.Add(new XElement("formaPago", inspector.Cells["ID"].Value.ToString()));
                        pago.Add(new XElement("total", valor.ToString("N2")));
                        pago.Add(new XElement("plazo", inspector.Cells["DIFERIDO"].Value.ToString()));
                        pago.Add(new XElement("unidadTiempo", "Días"));
                    }
                }
                XElement detalles = new XElement("detalles");
                factura.Add(detalles);
                foreach (DataGridViewRow inspector in dgv_Detalle.Rows)
                {
                    if (inspector.Cells["DESCUENTO"].Value != null)
                    {
                        int codigo = 0;
                        decimal descuento = Convert.ToDecimal(inspector.Cells["DESCUENTO"].Value.ToString()) / Convert.ToDecimal(inspector.Cells["cantidad"].Value.ToString());
                        decimal sinImpuestos = Convert.ToDecimal(inspector.Cells["PRECIO UNITARIO"].Value.ToString()) - descuento;
                        decimal subtotal = Convert.ToDecimal(inspector.Cells["PRECIO UNITARIO"].Value.ToString()) * Convert.ToDecimal(inspector.Cells["CANTIDAD"].Value.ToString());
                        XElement detalle = new XElement("detalle");
                        detalles.Add(detalle);
                        detalle.Add(new XElement("codigoPrincipal", inspector.Cells["ID"].Value.ToString()));
                        detalle.Add(new XElement("codigoAuxiliar", inspector.Cells["ID"].Value.ToString()));
                        detalle.Add(new XElement("descripcion", inspector.Cells["DETALLE"].Value.ToString()));
                        detalle.Add(new XElement("cantidad", inspector.Cells["CANTIDAD"].Value.ToString()));
                        detalle.Add(new XElement("precioUnitario", subtotal.ToString("N2")));
                        detalle.Add(new XElement("descuento", descuento.ToString("N2")));
                        detalle.Add(new XElement("precioTotalSinImpuesto", sinImpuestos.ToString("N2")));
                        XElement impuestos = new XElement("impuestos");
                        detalle.Add(impuestos);
                        XElement impuesto = new XElement("impuesto");
                        impuestos.Add(impuesto);
                        decimal iva = Convert.ToDecimal(inspector.Cells["iva"].Value.ToString());
                        if (iva != 0)
                        {
                            codigo = 2;
                        }
                        impuesto.Add(new XElement("codigo", 2));
                        impuesto.Add(new XElement("codigoPorcentaje", codigo));
                        impuesto.Add(new XElement("tarifa", 0));
                        impuesto.Add(new XElement("baseImponible", sinImpuestos.ToString("N2")));
                        impuesto.Add(new XElement("valor", iva.ToString("N2")));
                    }
                }
                XElement infoAdicional = new XElement("infoAdicional");
                factura.Add(infoAdicional);
                infoAdicional.Add(new XElement("campoAdicional", new XAttribute("nombre", "Email"), txtEmail.Text));
                infoAdicional.Add(new XElement("campoAdicional", new XAttribute("nombre", "Paciente"), lblNombrePaciente.Text));
                infoAdicional.Add(new XElement("campoAdicional", new XAttribute("nombre", "Historia Clinica"), lblHc.Text));
                infoAdicional.Add(new XElement("campoAdicional", new XAttribute("nombre", "Atencion"), lblAtencion.Text));
                infoAdicional.Add(new XElement("campoAdicional", new XAttribute("nombre", "Observaciones"), txtObservaciones.Text));
                infoAdicional.Add(new XElement("campoAdicional", new XAttribute("nombre", "Cajero"), Cesion.usuario));

                //documento.Save(@"E:\FACTURA_ELECTRONICA\" + "factura- prueba" + objFactura.numeroFactura + "-" + empresa.Nombre_Comercial + ".xml");
                documento.Save(@"E:\FACTURA_ELECTRONICA\" + "factura-OPTICA-" + secuencial + " - prueba.xml");
                #endregion

                return true;
            }
            catch
            {

                return false;
            }
        }
        private void AgregarError(Control control, string texto)
        {
            error.SetError(control, texto);
        }

        public bool ValidaFormulario()
        {
            error.Clear();
            bool valido = true;
            if (dgv_Detalle.Rows.Count == 0)
            {
                AgregarError(dgv_Detalle, "No hay valores para facturar");
                return valido = false;
            }
            if (dgv_FormasPago.Rows.Count == 0)
            {
                AgregarError(dgv_Detalle, "No Formas de Pago");
                return valido = false;
            }


            if (txtObservaciones.Text == "")
            {
                if (MessageBox.Show("No ha ingresado una Observación ¿Desea Guardar Asi la Factura? :(", "OPT3000", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    txtObservaciones.Text = "N/A";
                }
                else
                {
                    AgregarError(txtObservaciones, "Ingrese una Observación");
                    return valido = false;
                }
            }
            if (ValidaDatosFactura())
            {
                return valido;
            }
            else
            {
                valido = false;
            }
            return valido;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Pilas vas a facturar sin paciente!!! :o", "OPT3000", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                p_Atencion.Enabled = true;
                chk_OtrosDatos.Checked = true;
                chk_OtrosDatos.Enabled = false;
                btnBusca.Visible = false;
                btnFacturar.Visible = true;
                btnAgrupacion.Visible = true;
                btnNuevo.Visible = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            //LimpiarCampos();
        }

        private void btnAnticipo_Click(object sender, EventArgs e)
        {
            Anticipo frm = new Anticipo(objPaciente.ID_PACIENTE, lblAtencion.Text);
            frm.ShowDialog();
            CargaAnticipos();
            SumaSaldos();
        }

        private void btnAgrupacion_Click(object sender, EventArgs e)
        {
            ColorFondo();
            btnAgrupacion.BackColor = Color.CornflowerBlue;
            AgrupaCuentas frm = new AgrupaCuentas(objAtencion.ID_ATENCION);
            frm.ShowDialog();
            SumaSaldos();
        }

        public void ColorFondo()
        {
            btnAgrupacion.BackColor = Color.WhiteSmoke;
            btnCargaIndividual.BackColor = Color.WhiteSmoke;
            btnCargaDoc.BackColor = Color.WhiteSmoke;
            btnDevolucion.BackColor = Color.WhiteSmoke;
            btnFormaPago.BackColor = Color.WhiteSmoke;
        }

        public void sumaTodo()
        {
            decimal conIva = 0;
            decimal sinIva = 0;
            decimal iva = 0;
            decimal descuento = 0;
            decimal subTotal = 0;
            decimal total = 0;
            for (int i = 0; i < dgv_Detalle.Rows.Count - 1; i++)
            {
                subTotal += Convert.ToDecimal(dgv_Detalle.Rows[i].Cells[3].Value);
                descuento += Convert.ToDecimal(dgv_Detalle.Rows[i].Cells[4].Value);
                if (Convert.ToDecimal(dgv_Detalle.Rows[i].Cells[5].Value) != 0)
                    conIva += Convert.ToDecimal(dgv_Detalle.Rows[i].Cells[3].Value);
                else
                    sinIva += Convert.ToDecimal(dgv_Detalle.Rows[i].Cells[3].Value);
                iva += Convert.ToDecimal(dgv_Detalle.Rows[i].Cells[5].Value);
                total += Convert.ToDecimal(dgv_Detalle.Rows[i].Cells[3].Value) + Convert.ToDecimal(dgv_Detalle.Rows[i].Cells[5].Value) - Convert.ToDecimal(dgv_Detalle.Rows[i].Cells[4].Value);
            }
            txtSubtotal.Text = Math.Round(subTotal, 2).ToString();
            txtDescuento.Text = Math.Round(descuento, 2).ToString();
            txtSinIva.Text = Math.Round(sinIva, 2).ToString();
            txtConIva.Text = Math.Round(conIva, 2).ToString();
            TxtIva.Text = Math.Round(iva, 2).ToString();
            txtTotal.Text = Math.Round(total, 2).ToString();
        }

        private void dgv_Detalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dgv_Detalle.CurrentRow.Index;
            try
            {
                decimal descuento = Convert.ToDecimal(dgv_Detalle.Rows[fila].Cells[4].Value);
                decimal subtotal = Convert.ToDecimal(dgv_Detalle.Rows[fila].Cells[3].Value);
                decimal iva = 0;
                if (descuento <= subtotal)
                {
                    if (dgv_Detalle.Rows[fila].Cells[5].Value.ToString() != "0.0000")
                    {
                        iva = ((subtotal - descuento) * Convert.ToDecimal(lblIva.Text.Substring(0, 2))) / 100;
                        dgv_Detalle.Rows[fila].Cells[5].Value = iva.ToString();
                    }
                    //dgv_Detalle.Rows[fila].Cells[5].ReadOnly = false;
                    dgv_Detalle.Rows[fila].Cells[5].ReadOnly = true;
                    dgv_Detalle.Rows[fila].Cells[6].Value = (subtotal - descuento).ToString("N2");
                    dgv_Detalle.Rows[fila].Cells[4].Value = descuento.ToString("N2");
                }
                else
                {
                    MessageBox.Show("No puedes dar un descuento mayor al subtotal :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgv_Detalle.Rows[fila].Cells[4].Value = "0.0000";
                }
                sumaTodo();
            }
            catch (Exception)
            {
                MessageBox.Show("Esto no parece una cantidad :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dgv_Detalle.Rows[fila].Cells[0].Value.ToString() == "")
                {
                    dgv_Detalle.Rows[fila].Cells[4].Value = "";
                }
                else
                {
                    dgv_Detalle.Rows[fila].Cells[4].Value = "0.0000";
                }

            }
        }

        private void dgv_Detalle_KeyDown(object sender, KeyEventArgs e)
        {
            int fila = dgv_Detalle.CurrentRow.Index;
            if (e.KeyValue == (char)Keys.F1)
            {
                DescuentoFactura frm = new DescuentoFactura(dgv_Detalle.Rows[fila].Cells[3].Value.ToString());
                frm.ShowDialog();
                dgv_Detalle.Rows[fila].Cells[4].Value = frm.total;
                decimal descuento = frm.total;
                decimal subtotal = Convert.ToDecimal(dgv_Detalle.Rows[fila].Cells[3].Value);
                decimal iva = 0;
                if (descuento <= subtotal)
                {
                    if (dgv_Detalle.Rows[fila].Cells[5].Value.ToString() != "0.0000")
                    {
                        iva = ((subtotal - descuento) * Convert.ToDecimal(lblIva.Text.Substring(0, 2))) / 100;
                        dgv_Detalle.Rows[fila].Cells[5].Value = iva.ToString("N2");
                    }
                    //dgv_Detalle.Rows[fila].Cells[5].ReadOnly = false;
                    dgv_Detalle.Rows[fila].Cells[5].ReadOnly = true;
                    dgv_Detalle.Rows[fila].Cells[6].Value = (subtotal - descuento).ToString("N2");
                }
                else
                {
                    MessageBox.Show("No puedes dar un descuento mayor al subtotal :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgv_Detalle.Rows[fila].Cells[4].Value = "0.0000";
                }
                sumaTodo();
            }
            else
            {
                if (e.KeyValue == (char)Keys.Delete)
                {
                    if (MessageBox.Show("Estas seguro de eliminar el Item de la cuenta? :o", "OPT3000", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string codigoProducto = dgv_Detalle.Rows[fila].Cells[0].Value.ToString();

                        dgv_Detalle.Rows.RemoveAt(fila);
                    }
                    sumaTodo();
                }
            }
        }

        private void btnCargaIndividual_Click(object sender, EventArgs e)
        {
            ColorFondo();
            btnCargaIndividual.BackColor = Color.CornflowerBlue;
            Int64 cod = Convert.ToInt64(lblAtencion.Text);
            CLIENTE cli = new CLIENTE();
            Int64 ateCodigo = 0;
            if (p_datosPaciente.Visible == true)
            {
                ateCodigo = Convert.ToInt64(lblAtencion.Text);
            }
            else
            {
                ateCodigo = 1;
            }
            cli.Nombre = txtNombre.Text;
            cli.Apellidos = txtApellido.Text;
            cli.Identificacion = txtIdentificacion.Text;
            cli.Direccion = txtDireccion.Text;
            cli.Telefono = txtTelefono.Text;
            cli.Email = txtEmail.Text;
            CuentaIndividual frm = new CuentaIndividual(cli, cod);
            frm.ShowDialog();
            objDetalle = new DataTable();
            objDetalle.Columns.Add("ID").ReadOnly = true;
            objDetalle.Columns.Add("DETALLE").ReadOnly = true;
            objDetalle.Columns.Add("CANTIDAD").ReadOnly = true;
            objDetalle.Columns.Add("PRECIO UNITARIO").ReadOnly = true;
            objDetalle.Columns.Add("DESCUENTO").ReadOnly = false;
            objDetalle.Columns.Add("IVA").ReadOnly = false;
            objDetalle.Columns.Add("PRECIO").ReadOnly = false;
            dgv_Detalle.DataSource = objDetalle;
            CargaCuentaPaciente();
            SumaSaldos();
        }

        private void btnDevolucion_Click(object sender, EventArgs e)
        {
            ColorFondo();
            btnDevolucion.BackColor = Color.CornflowerBlue;
            Devolucion frm = new Devolucion(Convert.ToInt64(lblAtencion.Text));
            frm.ShowDialog();
            objDetalle = new DataTable();
            objDetalle.Columns.Add("ID").ReadOnly = true;
            objDetalle.Columns.Add("DETALLE").ReadOnly = true;
            objDetalle.Columns.Add("CANTIDAD").ReadOnly = true;
            objDetalle.Columns.Add("PRECIO UNITARIO").ReadOnly = true;
            objDetalle.Columns.Add("DESCUENTO").ReadOnly = false;
            objDetalle.Columns.Add("IVA").ReadOnly = false;
            objDetalle.Columns.Add("PRECIO").ReadOnly = false;
            dgv_Detalle.DataSource = objDetalle;
            CargaCuentaPaciente();
            SumaSaldos();
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (ValidaFormulario())
            {

                decimal suma = 0;
                for (int i = 0; i < dgv_FormasPago.Rows.Count - 1; i++)
                {
                    suma += Convert.ToDecimal(dgv_FormasPago.Rows[i].Cells[2].Value.ToString());
                }
                if (Math.Round(Convert.ToDecimal(txtTotal.Text), 2) == Math.Round(suma, 2))
                {
                    if (MessageBox.Show("Factura por generarse.\r\n ¿Desea Continuar? :)", "OPT3000", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        try
                        {
                            GuardaFactura();
                            LimpiarCampos();
                            this.Close();
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show("Tengo problemas de ingreso de datos por favor revisa y vuelve a intertar facturar te dejo una descripción para GAPSYSTEM: " + err.ToString(), "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("La(s) forma(s) de pago no son iguales :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void rb_Consumidor_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Consumidor.Checked)
            {
                txtIdentificacion.Enabled = false;
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtTelefono.Enabled = false;
                txtDireccion.Enabled = false;
                txtEmail.Enabled = false;

                txtIdentificacion.Text = "999999999";
                txtNombre.Text = "Consumidor";
                txtApellido.Text = "Final";
                txtTelefono.Text = "NA";
                txtDireccion.Text = "NA";
                txtEmail.Text = "opticajimenezec@gmail.com";

            }
            else
            {
                txtIdentificacion.Enabled = true;
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                txtTelefono.Enabled = true;
                txtDireccion.Enabled = true;
                txtEmail.Enabled = true;

                txtIdentificacion.Text = "";
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtTelefono.Text = "";
                txtDireccion.Text = "";
                txtEmail.Text = "";
            }
        }

        private void btn_divideCuenta_Click(object sender, EventArgs e)
        {
            DividirCuenta frm = new DividirCuenta(Convert.ToInt64(lblAtencion.Text), txtSubtotal.Text, lblIva.Text);
            frm.ShowDialog();
            if (frm.dividida)
            {
                this.Close();
            }
        }
    }
}
