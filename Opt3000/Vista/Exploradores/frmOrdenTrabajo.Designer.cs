
namespace Opt3000.Vista.Exploradores
{
    partial class frmOrdenTrabajo
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
            this.tileNavPane1 = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.nbtActualizar = new DevExpress.XtraBars.Navigation.NavButton();
            this.nbtExportar = new DevExpress.XtraBars.Navigation.NavButton();
            this.nbtSalir = new DevExpress.XtraBars.Navigation.NavButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dtpHasta = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDesde = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tileNavPane1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDesde.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.tileNavPane1.Size = new System.Drawing.Size(800, 52);
            this.tileNavPane1.TabIndex = 3;
            this.tileNavPane1.Text = "tileNavPane1";
            // 
            // nbtActualizar
            // 
            this.nbtActualizar.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.nbtActualizar.Caption = "Actualizar";
            this.nbtActualizar.Name = "nbtActualizar";
            this.nbtActualizar.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.nbtActualizar_ElementClick);
            // 
            // nbtExportar
            // 
            this.nbtExportar.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.nbtExportar.Caption = "Exportar";
            this.nbtExportar.Name = "nbtExportar";
            this.nbtExportar.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.nbtExportar_ElementClick);
            // 
            // nbtSalir
            // 
            this.nbtSalir.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.nbtSalir.Caption = "Salir";
            this.nbtSalir.Name = "nbtSalir";
            this.nbtSalir.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.nbtSalir_ElementClick);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 52);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(800, 350);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 30;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // dtpHasta
            // 
            this.dtpHasta.EditValue = null;
            this.dtpHasta.Location = new System.Drawing.Point(287, 14);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpHasta.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.ClassicNew;
            this.dtpHasta.Properties.MaxValue = new System.DateTime(2199, 12, 31, 23, 59, 0, 0);
            this.dtpHasta.Properties.MinValue = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpHasta.Properties.NullDate = new System.DateTime(2199, 12, 31, 10, 27, 14, 0);
            this.dtpHasta.Properties.NullDateCalendarValue = new System.DateTime(2199, 12, 31, 0, 0, 0, 0);
            this.dtpHasta.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.dtpHasta.Size = new System.Drawing.Size(112, 20);
            this.dtpHasta.TabIndex = 61;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(244, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 60;
            this.label2.Text = "hasta";
            // 
            // dtpDesde
            // 
            this.dtpDesde.EditValue = null;
            this.dtpDesde.Location = new System.Drawing.Point(115, 12);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDesde.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.ClassicNew;
            this.dtpDesde.Properties.MaxValue = new System.DateTime(2199, 12, 31, 23, 59, 0, 0);
            this.dtpDesde.Properties.MinValue = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpDesde.Properties.NullDate = new System.DateTime(2021, 1, 6, 10, 25, 59, 323);
            this.dtpDesde.Properties.NullDateCalendarValue = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpDesde.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.dtpDesde.Size = new System.Drawing.Size(112, 20);
            this.dtpDesde.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(25, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 58;
            this.label1.Text = "Fecha:  desde";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 402);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 48);
            this.panel1.TabIndex = 72;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Thistle;
            this.panel3.Location = new System.Drawing.Point(249, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(48, 41);
            this.panel3.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.NavajoWhite;
            this.panel2.Location = new System.Drawing.Point(52, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(48, 41);
            this.panel2.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(303, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "OJO IZQUIERDO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(121, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "OJO DERECHO";
            // 
            // frmOrdenTrabajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.tileNavPane1);
            this.Controls.Add(this.panel1);
            this.Name = "frmOrdenTrabajo";
            this.Text = "frmOrdenTrabajo";
            ((System.ComponentModel.ISupportInitialize)(this.tileNavPane1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDesde.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Navigation.TileNavPane tileNavPane1;
        private DevExpress.XtraBars.Navigation.NavButton nbtActualizar;
        private DevExpress.XtraBars.Navigation.NavButton nbtExportar;
        private DevExpress.XtraBars.Navigation.NavButton nbtSalir;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.DateEdit dtpHasta;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DateEdit dtpDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}