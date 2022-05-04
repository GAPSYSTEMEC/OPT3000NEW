using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opt3000.BaseDatos;
using Opt3000.Negocio;
using Opt3000.Entidades;

namespace Opt3000.Vista.Utilitarios
{
    public partial class RevisionEstadoOrdenes : Form
    {
        #region Variables

        DataTable pacientes = new DataTable();

        #endregion
        private DevExpress.XtraBars.Navigation.TileNavPane tileNavPane1;
        private DevExpress.XtraBars.Navigation.NavButton nbtActualizar;
        private DevExpress.XtraBars.Navigation.NavButton nbtExportar;
        private DevExpress.XtraBars.Navigation.NavButton nbtSalir;
        private CheckBox chkGenerado;
        private CheckBox chkEnviado;
        private CheckBox chkRecibido;
        private CheckBox chkEntregado;
        private DataGridView dgv_Detalle1;
        private Label label2;
        private TextBox txtcodigo;
        private TextBox textBox1;
        private Label label1;
        Orden1 orden;
        public RevisionEstadoOrdenes()
        {
            InitializeComponent();
            CargaOrdenes();
        }
        public void CargaOrdenes()
        {
            pacientes.Columns.Add("Paciente");
            pacientes.Columns.Add("Atencion");
            pacientes.Columns.Add("Orden");
            pacientes.Columns.Add("FechaPedido");
            pacientes.Columns.Add("FechaEntrega");
            pacientes.Columns.Add("Usuario");
            pacientes.Columns.Add("Generado");
            pacientes.Columns.Add("Enviado");
            pacientes.Columns.Add("Recibido");
            pacientes.Columns.Add("Entregado");

            List<OrdenPendiente> orden = new List<OrdenPendiente>();
            orden = NegConsultas.getInstance().CargaOrdenNormal();
            dgv_Detalle1.DataSource = pacientes;
            dgv_Detalle1.DataSource = orden;
            dgv_Detalle1.Columns["Paciente"].Width = 300;
            dgv_Detalle1.Columns["Atencion"].Width = 50;
            dgv_Detalle1.Columns["Orden"].Width = 50;
            dgv_Detalle1.Columns["FechaPedido"].Width = 100;
            dgv_Detalle1.Columns["FechaEntrega"].Width = 100;
            dgv_Detalle1.Columns["Usuario"].Width = 200;
            dgv_Detalle1.Columns["Generado"].Width = 50;
            dgv_Detalle1.Columns["Enviado"].Width = 50;
            dgv_Detalle1.Columns["Recibido"].Width = 50;
            dgv_Detalle1.Columns["Entregado"].Width = 50;
        }

        private void InitializeComponent()
        {
            this.dgv_Detalle1 = new System.Windows.Forms.DataGridView();
            this.tileNavPane1 = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.nbtActualizar = new DevExpress.XtraBars.Navigation.NavButton();
            this.nbtExportar = new DevExpress.XtraBars.Navigation.NavButton();
            this.nbtSalir = new DevExpress.XtraBars.Navigation.NavButton();
            this.chkGenerado = new System.Windows.Forms.CheckBox();
            this.chkEnviado = new System.Windows.Forms.CheckBox();
            this.chkRecibido = new System.Windows.Forms.CheckBox();
            this.chkEntregado = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Detalle1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileNavPane1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Detalle1
            // 
            this.dgv_Detalle1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Detalle1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Detalle1.Location = new System.Drawing.Point(0, 76);
            this.dgv_Detalle1.Name = "dgv_Detalle1";
            this.dgv_Detalle1.Size = new System.Drawing.Size(1054, 290);
            this.dgv_Detalle1.TabIndex = 0;
            this.dgv_Detalle1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Detalle1_CellEndEdit);
            this.dgv_Detalle1.DoubleClick += new System.EventHandler(this.dgv_Detalle1_DoubleClick);
            // 
            // tileNavPane1
            // 
            this.tileNavPane1.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.tileNavPane1.Appearance.BackColor2 = System.Drawing.Color.Silver;
            this.tileNavPane1.Appearance.Options.UseBackColor = true;
            this.tileNavPane1.Buttons.Add(this.nbtActualizar);
            this.tileNavPane1.Buttons.Add(this.nbtExportar);
            this.tileNavPane1.Buttons.Add(this.nbtSalir);
            // 
            // tileNavCategory1
            // 
            this.tileNavPane1.DefaultCategory.Name = "tileNavCategory1";
            // 
            // 
            // 
            this.tileNavPane1.DefaultCategory.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileNavPane1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tileNavPane1.Location = new System.Drawing.Point(0, 0);
            this.tileNavPane1.Name = "tileNavPane1";
            this.tileNavPane1.Size = new System.Drawing.Size(1054, 76);
            this.tileNavPane1.TabIndex = 76;
            this.tileNavPane1.Text = "tileNavPane1";
            // 
            // nbtActualizar
            // 
            this.nbtActualizar.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.nbtActualizar.Caption = "Guardar";
            this.nbtActualizar.Name = "nbtActualizar";
            this.nbtActualizar.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.nbtActualizar_ElementClick);
            // 
            // nbtExportar
            // 
            this.nbtExportar.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.nbtExportar.Caption = "Exportar";
            this.nbtExportar.Name = "nbtExportar";
            this.nbtExportar.Visible = false;
            // 
            // nbtSalir
            // 
            this.nbtSalir.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.nbtSalir.Caption = "Salir";
            this.nbtSalir.Name = "nbtSalir";
            this.nbtSalir.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.nbtSalir_ElementClick);
            // 
            // chkGenerado
            // 
            this.chkGenerado.AutoSize = true;
            this.chkGenerado.Location = new System.Drawing.Point(167, 12);
            this.chkGenerado.Name = "chkGenerado";
            this.chkGenerado.Size = new System.Drawing.Size(73, 17);
            this.chkGenerado.TabIndex = 77;
            this.chkGenerado.Text = "Generado";
            this.chkGenerado.UseVisualStyleBackColor = true;
            // 
            // chkEnviado
            // 
            this.chkEnviado.AutoSize = true;
            this.chkEnviado.Location = new System.Drawing.Point(289, 12);
            this.chkEnviado.Name = "chkEnviado";
            this.chkEnviado.Size = new System.Drawing.Size(65, 17);
            this.chkEnviado.TabIndex = 78;
            this.chkEnviado.Text = "Enviado";
            this.chkEnviado.UseVisualStyleBackColor = true;
            // 
            // chkRecibido
            // 
            this.chkRecibido.AutoSize = true;
            this.chkRecibido.Location = new System.Drawing.Point(403, 12);
            this.chkRecibido.Name = "chkRecibido";
            this.chkRecibido.Size = new System.Drawing.Size(68, 17);
            this.chkRecibido.TabIndex = 79;
            this.chkRecibido.Text = "Recibido";
            this.chkRecibido.UseVisualStyleBackColor = true;
            // 
            // chkEntregado
            // 
            this.chkEntregado.AutoSize = true;
            this.chkEntregado.Location = new System.Drawing.Point(518, 12);
            this.chkEntregado.Name = "chkEntregado";
            this.chkEntregado.Size = new System.Drawing.Size(75, 17);
            this.chkEntregado.TabIndex = 80;
            this.chkEntregado.Text = "Entregado";
            this.chkEntregado.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(14, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 82;
            this.label2.Text = "Código:";
            // 
            // txtcodigo
            // 
            this.txtcodigo.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtcodigo.Location = new System.Drawing.Point(63, 12);
            this.txtcodigo.MaxLength = 30;
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.ReadOnly = true;
            this.txtcodigo.Size = new System.Drawing.Size(61, 20);
            this.txtcodigo.TabIndex = 81;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(167, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(201, 20);
            this.textBox1.TabIndex = 83;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(14, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 84;
            this.label1.Text = "Buscar Paciente:";
            // 
            // RevisionEstadoOrdenes
            // 
            this.ClientSize = new System.Drawing.Size(1054, 366);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtcodigo);
            this.Controls.Add(this.chkEntregado);
            this.Controls.Add(this.chkRecibido);
            this.Controls.Add(this.chkEnviado);
            this.Controls.Add(this.chkGenerado);
            this.Controls.Add(this.dgv_Detalle1);
            this.Controls.Add(this.tileNavPane1);
            this.Name = "RevisionEstadoOrdenes";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Detalle1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileNavPane1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void dgv_Detalle1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void nbtActualizar_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            try
            {
                NegConsultas.actualizaOrdenes(chkGenerado.Checked,chkEnviado.Checked,chkRecibido.Checked,chkEntregado.Checked,Convert.ToUInt16(txtcodigo.Text));
                MessageBox.Show("Datos Almacenados Correctamente.", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                CargaOrdenes();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void nbtSalir_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            this.Close();
        }

        private void dgv_Detalle1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                chkGenerado.Checked = Convert.ToBoolean(this.dgv_Detalle1.SelectedRows[0].Cells[0].Value);
                chkEnviado.Checked = Convert.ToBoolean(this.dgv_Detalle1.SelectedRows[0].Cells[1].Value);
                chkRecibido.Checked = Convert.ToBoolean(this.dgv_Detalle1.SelectedRows[0].Cells[2].Value);
                chkEntregado.Checked = Convert.ToBoolean(this.dgv_Detalle1.SelectedRows[0].Cells[3].Value);
                txtcodigo.Text = Convert.ToString(this.dgv_Detalle1.SelectedRows[0].Cells[4].Value);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string parametro = "";
            parametro = "Paciente";
            var filtro = parametro + " like '%" + textBox1.Text + "%'";
            pacientes.DefaultView.RowFilter = filtro;
        }
        public void Limpiar()
        {
            chkGenerado.Checked = false;
            chkEntregado.Checked = false;
            chkEnviado.Checked = false;
            chkRecibido.Checked = false;
            txtcodigo.Text = "";
        }
    }
}
