
namespace Opt3000.Vista.Utilitarios
{
    partial class BuscaUsuarios
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.r_Cedula = new System.Windows.Forms.RadioButton();
            this.r_Nombre = new System.Windows.Forms.RadioButton();
            this.txtBuscador = new System.Windows.Forms.TextBox();
            this.g_Pacientes = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_Pacientes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.r_Cedula);
            this.groupBox1.Controls.Add(this.r_Nombre);
            this.groupBox1.Location = new System.Drawing.Point(148, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 51);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CRITERIO DE BUSQUEDA";
            // 
            // r_Cedula
            // 
            this.r_Cedula.AutoSize = true;
            this.r_Cedula.Location = new System.Drawing.Point(177, 26);
            this.r_Cedula.Name = "r_Cedula";
            this.r_Cedula.Size = new System.Drawing.Size(74, 17);
            this.r_Cedula.TabIndex = 38;
            this.r_Cedula.Text = "USUARIO";
            this.r_Cedula.UseVisualStyleBackColor = true;
            // 
            // r_Nombre
            // 
            this.r_Nombre.AutoSize = true;
            this.r_Nombre.Checked = true;
            this.r_Nombre.Location = new System.Drawing.Point(6, 26);
            this.r_Nombre.Name = "r_Nombre";
            this.r_Nombre.Size = new System.Drawing.Size(137, 17);
            this.r_Nombre.TabIndex = 36;
            this.r_Nombre.TabStop = true;
            this.r_Nombre.Text = "NOMBRE Y APELLIDO";
            this.r_Nombre.UseVisualStyleBackColor = true;
            // 
            // txtBuscador
            // 
            this.txtBuscador.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBuscador.BackColor = System.Drawing.SystemColors.Menu;
            this.txtBuscador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscador.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscador.Location = new System.Drawing.Point(78, 69);
            this.txtBuscador.MaxLength = 5;
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Size = new System.Drawing.Size(427, 24);
            this.txtBuscador.TabIndex = 40;
            this.txtBuscador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBuscador.TextChanged += new System.EventHandler(this.txtBuscador_TextChanged);
            // 
            // g_Pacientes
            // 
            this.g_Pacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_Pacientes.Location = new System.Drawing.Point(14, 99);
            this.g_Pacientes.Name = "g_Pacientes";
            this.g_Pacientes.Size = new System.Drawing.Size(561, 194);
            this.g_Pacientes.TabIndex = 39;
            this.g_Pacientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.g_Pacientes_CellClick);
            // 
            // BuscaUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 311);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtBuscador);
            this.Controls.Add(this.g_Pacientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BuscaUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_Pacientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton r_Cedula;
        private System.Windows.Forms.RadioButton r_Nombre;
        private System.Windows.Forms.TextBox txtBuscador;
        private System.Windows.Forms.DataGridView g_Pacientes;
    }
}