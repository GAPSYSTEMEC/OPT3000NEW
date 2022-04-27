namespace Opt3000.Vista.Utilitarios
{
    partial class Cie10
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
            this.g_Cie10 = new System.Windows.Forms.DataGridView();
            this.txtBuscador = new System.Windows.Forms.TextBox();
            this.r_Descripcion = new System.Windows.Forms.RadioButton();
            this.r_Codigo = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.g_Cie10)).BeginInit();
            this.SuspendLayout();
            // 
            // g_Cie10
            // 
            this.g_Cie10.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_Cie10.Location = new System.Drawing.Point(12, 81);
            this.g_Cie10.Name = "g_Cie10";
            this.g_Cie10.Size = new System.Drawing.Size(427, 233);
            this.g_Cie10.TabIndex = 0;
            this.g_Cie10.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.g_Cie10_CellClick);
            this.g_Cie10.KeyDown += new System.Windows.Forms.KeyEventHandler(this.g_Cie10_KeyDown);
            // 
            // txtBuscador
            // 
            this.txtBuscador.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBuscador.BackColor = System.Drawing.SystemColors.Menu;
            this.txtBuscador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscador.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscador.Location = new System.Drawing.Point(12, 12);
            this.txtBuscador.MaxLength = 5;
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Size = new System.Drawing.Size(427, 24);
            this.txtBuscador.TabIndex = 33;
            this.txtBuscador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBuscador.TextChanged += new System.EventHandler(this.txtEsferaVCod_TextChanged);
            this.txtBuscador.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscador_KeyDown);
            // 
            // r_Descripcion
            // 
            this.r_Descripcion.AutoSize = true;
            this.r_Descripcion.Location = new System.Drawing.Point(120, 42);
            this.r_Descripcion.Name = "r_Descripcion";
            this.r_Descripcion.Size = new System.Drawing.Size(81, 17);
            this.r_Descripcion.TabIndex = 34;
            this.r_Descripcion.Text = "Descripción";
            this.r_Descripcion.UseVisualStyleBackColor = true;
            this.r_Descripcion.CheckedChanged += new System.EventHandler(this.r_Descripcion_CheckedChanged);
            // 
            // r_Codigo
            // 
            this.r_Codigo.AutoSize = true;
            this.r_Codigo.Checked = true;
            this.r_Codigo.Location = new System.Drawing.Point(232, 42);
            this.r_Codigo.Name = "r_Codigo";
            this.r_Codigo.Size = new System.Drawing.Size(58, 17);
            this.r_Codigo.TabIndex = 35;
            this.r_Codigo.TabStop = true;
            this.r_Codigo.Text = "Código";
            this.r_Codigo.UseVisualStyleBackColor = true;
            this.r_Codigo.CheckedChanged += new System.EventHandler(this.r_Codigo_CheckedChanged);
            // 
            // Cie10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 326);
            this.ControlBox = false;
            this.Controls.Add(this.r_Codigo);
            this.Controls.Add(this.r_Descripcion);
            this.Controls.Add(this.txtBuscador);
            this.Controls.Add(this.g_Cie10);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Cie10";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cie10";
            this.Load += new System.EventHandler(this.Cie10_Load);
            ((System.ComponentModel.ISupportInitialize)(this.g_Cie10)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView g_Cie10;
        private System.Windows.Forms.TextBox txtBuscador;
        private System.Windows.Forms.RadioButton r_Descripcion;
        private System.Windows.Forms.RadioButton r_Codigo;
    }
}