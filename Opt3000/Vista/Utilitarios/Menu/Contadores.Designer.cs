
namespace Opt3000.Vista.Utilitarios.Menu
{
    partial class Contadores
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
            this.cmb_TipoProduc = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCodigoActual = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNuevoCodigo = new System.Windows.Forms.TextBox();
            this.btnRecuperar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmb_TipoProduc
            // 
            this.cmb_TipoProduc.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_TipoProduc.FormattingEnabled = true;
            this.cmb_TipoProduc.Location = new System.Drawing.Point(23, 63);
            this.cmb_TipoProduc.Name = "cmb_TipoProduc";
            this.cmb_TipoProduc.Size = new System.Drawing.Size(123, 29);
            this.cmb_TipoProduc.TabIndex = 279;
            this.cmb_TipoProduc.SelectedIndexChanged += new System.EventHandler(this.cmb_TipoProduc_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label15.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.Menu;
            this.label15.Location = new System.Drawing.Point(23, 39);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(123, 21);
            this.label15.TabIndex = 278;
            this.label15.Text = "Tipo Producto";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Menu;
            this.label6.Location = new System.Drawing.Point(205, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 21);
            this.label6.TabIndex = 277;
            this.label6.Text = "Código Actual";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCodigoActual
            // 
            this.txtCodigoActual.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCodigoActual.BackColor = System.Drawing.SystemColors.Menu;
            this.txtCodigoActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoActual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoActual.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoActual.Location = new System.Drawing.Point(205, 63);
            this.txtCodigoActual.MaxLength = 100;
            this.txtCodigoActual.Name = "txtCodigoActual";
            this.txtCodigoActual.ReadOnly = true;
            this.txtCodigoActual.Size = new System.Drawing.Size(100, 28);
            this.txtCodigoActual.TabIndex = 276;
            this.txtCodigoActual.Text = "0";
            this.txtCodigoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Menu;
            this.label1.Location = new System.Drawing.Point(311, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 21);
            this.label1.TabIndex = 281;
            this.label1.Text = "Código Nuevo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNuevoCodigo
            // 
            this.txtNuevoCodigo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNuevoCodigo.BackColor = System.Drawing.SystemColors.Menu;
            this.txtNuevoCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNuevoCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNuevoCodigo.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNuevoCodigo.Location = new System.Drawing.Point(311, 63);
            this.txtNuevoCodigo.MaxLength = 100;
            this.txtNuevoCodigo.Name = "txtNuevoCodigo";
            this.txtNuevoCodigo.Size = new System.Drawing.Size(89, 28);
            this.txtNuevoCodigo.TabIndex = 280;
            this.txtNuevoCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNuevoCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNuevoCodigo_KeyPress);
            // 
            // btnRecuperar
            // 
            this.btnRecuperar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRecuperar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnRecuperar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecuperar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(244)))));
            this.btnRecuperar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecuperar.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecuperar.ForeColor = System.Drawing.Color.Black;
            this.btnRecuperar.Location = new System.Drawing.Point(156, 125);
            this.btnRecuperar.Name = "btnRecuperar";
            this.btnRecuperar.Size = new System.Drawing.Size(150, 32);
            this.btnRecuperar.TabIndex = 282;
            this.btnRecuperar.Text = "ACTUALIZAR";
            this.btnRecuperar.UseVisualStyleBackColor = false;
            this.btnRecuperar.Click += new System.EventHandler(this.btnRecuperar_Click);
            // 
            // Contadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 194);
            this.Controls.Add(this.btnRecuperar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNuevoCodigo);
            this.Controls.Add(this.cmb_TipoProduc);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCodigoActual);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Contadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contadores";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_TipoProduc;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCodigoActual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNuevoCodigo;
        private System.Windows.Forms.Button btnRecuperar;
    }
}