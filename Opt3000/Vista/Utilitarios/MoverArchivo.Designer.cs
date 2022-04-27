namespace Opt3000.Vista.Utilitarios
{
    partial class MoverArchivo
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtSeleccionar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVerDoc = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtSeleccionar
            // 
            this.txtSeleccionar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSeleccionar.BackColor = System.Drawing.SystemColors.Menu;
            this.txtSeleccionar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSeleccionar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSeleccionar.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeleccionar.Location = new System.Drawing.Point(21, 28);
            this.txtSeleccionar.MaxLength = 5;
            this.txtSeleccionar.Name = "txtSeleccionar";
            this.txtSeleccionar.Size = new System.Drawing.Size(312, 24);
            this.txtSeleccionar.TabIndex = 35;
            this.txtSeleccionar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "SELECCIONE EL ARCHIVO";
            // 
            // btnVerDoc
            // 
            this.btnVerDoc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVerDoc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnVerDoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerDoc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(244)))));
            this.btnVerDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerDoc.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerDoc.ForeColor = System.Drawing.Color.Black;
            this.btnVerDoc.Location = new System.Drawing.Point(339, 28);
            this.btnVerDoc.Name = "btnVerDoc";
            this.btnVerDoc.Size = new System.Drawing.Size(133, 24);
            this.btnVerDoc.TabIndex = 240;
            this.btnVerDoc.Text = "DOCUMENTO";
            this.btnVerDoc.UseVisualStyleBackColor = false;
            this.btnVerDoc.Click += new System.EventHandler(this.btnVerDoc_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGuardar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(244)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(171, 62);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(133, 24);
            this.btnGuardar.TabIndex = 241;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // MoverArchivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 98);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnVerDoc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSeleccionar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MoverArchivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mover Archivo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtSeleccionar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVerDoc;
        private System.Windows.Forms.Button btnGuardar;
    }
}