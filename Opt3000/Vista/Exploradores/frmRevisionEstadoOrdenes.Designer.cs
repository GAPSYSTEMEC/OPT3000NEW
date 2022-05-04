
namespace Opt3000.Vista.Exploradores
{
    partial class frmRevisionEstadoOrdenes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tileNavPane1 = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.nbtActualizar = new DevExpress.XtraBars.Navigation.NavButton();
            this.nbtExportar = new DevExpress.XtraBars.Navigation.NavButton();
            this.nbtSalir = new DevExpress.XtraBars.Navigation.NavButton();
            this.chkGenerado = new System.Windows.Forms.CheckBox();
            this.chkEnviado = new System.Windows.Forms.CheckBox();
            this.chkRecibido = new System.Windows.Forms.CheckBox();
            this.chkEntregado = new System.Windows.Forms.CheckBox();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileNavPane1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 52);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(800, 398);
            this.gridControl1.TabIndex = 82;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // tileNavPane1
            // 
            this.tileNavPane1.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.tileNavPane1.Appearance.BackColor2 = System.Drawing.Color.Gainsboro;
            this.tileNavPane1.Appearance.Options.UseBackColor = true;
            this.tileNavPane1.BackColor = System.Drawing.Color.LightGray;
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
            this.tileNavPane1.Size = new System.Drawing.Size(800, 52);
            this.tileNavPane1.TabIndex = 81;
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
            this.chkGenerado.BackColor = System.Drawing.Color.Gainsboro;
            this.chkGenerado.Location = new System.Drawing.Point(154, 12);
            this.chkGenerado.Name = "chkGenerado";
            this.chkGenerado.Size = new System.Drawing.Size(73, 17);
            this.chkGenerado.TabIndex = 83;
            this.chkGenerado.Text = "Generado";
            this.chkGenerado.UseVisualStyleBackColor = false;
            // 
            // chkEnviado
            // 
            this.chkEnviado.AutoSize = true;
            this.chkEnviado.BackColor = System.Drawing.Color.Gainsboro;
            this.chkEnviado.Location = new System.Drawing.Point(240, 12);
            this.chkEnviado.Name = "chkEnviado";
            this.chkEnviado.Size = new System.Drawing.Size(65, 17);
            this.chkEnviado.TabIndex = 84;
            this.chkEnviado.Text = "Enviado";
            this.chkEnviado.UseVisualStyleBackColor = false;
            // 
            // chkRecibido
            // 
            this.chkRecibido.AutoSize = true;
            this.chkRecibido.BackColor = System.Drawing.Color.Gainsboro;
            this.chkRecibido.Location = new System.Drawing.Point(326, 12);
            this.chkRecibido.Name = "chkRecibido";
            this.chkRecibido.Size = new System.Drawing.Size(68, 17);
            this.chkRecibido.TabIndex = 85;
            this.chkRecibido.Text = "Recibido";
            this.chkRecibido.UseVisualStyleBackColor = false;
            // 
            // chkEntregado
            // 
            this.chkEntregado.AutoSize = true;
            this.chkEntregado.BackColor = System.Drawing.Color.Gainsboro;
            this.chkEntregado.Location = new System.Drawing.Point(412, 12);
            this.chkEntregado.Name = "chkEntregado";
            this.chkEntregado.Size = new System.Drawing.Size(75, 17);
            this.chkEntregado.TabIndex = 86;
            this.chkEntregado.Text = "Entregado";
            this.chkEntregado.UseVisualStyleBackColor = false;
            // 
            // txtcodigo
            // 
            this.txtcodigo.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtcodigo.Location = new System.Drawing.Point(72, 12);
            this.txtcodigo.MaxLength = 30;
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.ReadOnly = true;
            this.txtcodigo.Size = new System.Drawing.Size(61, 20);
            this.txtcodigo.TabIndex = 87;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(24, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 88;
            this.label1.Text = "Orden:";
            // 
            // frmRevisionEstadoOrdenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtcodigo);
            this.Controls.Add(this.chkEntregado);
            this.Controls.Add(this.chkRecibido);
            this.Controls.Add(this.chkEnviado);
            this.Controls.Add(this.chkGenerado);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.tileNavPane1);
            this.Name = "frmRevisionEstadoOrdenes";
            this.Text = "frmRevisionEstadoOrdenes";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileNavPane1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.Navigation.TileNavPane tileNavPane1;
        private DevExpress.XtraBars.Navigation.NavButton nbtActualizar;
        private DevExpress.XtraBars.Navigation.NavButton nbtExportar;
        private DevExpress.XtraBars.Navigation.NavButton nbtSalir;
        private System.Windows.Forms.CheckBox chkGenerado;
        private System.Windows.Forms.CheckBox chkEnviado;
        private System.Windows.Forms.CheckBox chkRecibido;
        private System.Windows.Forms.CheckBox chkEntregado;
        private System.Windows.Forms.TextBox txtcodigo;
        private System.Windows.Forms.Label label1;
    }
}