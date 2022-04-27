
namespace Opt3000.Vista.Utilitarios
{
    partial class Calculadora
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtEsfera = new System.Windows.Forms.TextBox();
            this.txtCilindro = new System.Windows.Forms.TextBox();
            this.txtEje = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEjeR = new System.Windows.Forms.TextBox();
            this.txtCilindroR = new System.Windows.Forms.TextBox();
            this.txtEsferaR = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "TRASPOSICIÓN CYL -";
            // 
            // txtEsfera
            // 
            this.txtEsfera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEsfera.Location = new System.Drawing.Point(118, 55);
            this.txtEsfera.Name = "txtEsfera";
            this.txtEsfera.Size = new System.Drawing.Size(77, 26);
            this.txtEsfera.TabIndex = 1;
            this.txtEsfera.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEsfera_KeyDown);
            this.txtEsfera.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEsfera_KeyPress);
            this.txtEsfera.Leave += new System.EventHandler(this.txtEsfera_Leave);
            // 
            // txtCilindro
            // 
            this.txtCilindro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCilindro.Location = new System.Drawing.Point(118, 109);
            this.txtCilindro.Name = "txtCilindro";
            this.txtCilindro.Size = new System.Drawing.Size(77, 26);
            this.txtCilindro.TabIndex = 2;
            this.txtCilindro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCilindro_KeyDown);
            this.txtCilindro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCilindro_KeyPress);
            this.txtCilindro.Leave += new System.EventHandler(this.txtCilindro_Leave);
            // 
            // txtEje
            // 
            this.txtEje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEje.Location = new System.Drawing.Point(118, 165);
            this.txtEje.Name = "txtEje";
            this.txtEje.Size = new System.Drawing.Size(77, 26);
            this.txtEje.TabIndex = 3;
            this.txtEje.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEje_KeyDown);
            this.txtEje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEje_KeyPress);
            this.txtEje.Leave += new System.EventHandler(this.txtEje_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "CILINDRO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "ESFERA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "EJE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(207, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "=";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(206, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "=";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(206, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 25);
            this.label7.TabIndex = 9;
            this.label7.Text = "=";
            // 
            // txtEjeR
            // 
            this.txtEjeR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEjeR.Location = new System.Drawing.Point(238, 165);
            this.txtEjeR.Name = "txtEjeR";
            this.txtEjeR.ReadOnly = true;
            this.txtEjeR.Size = new System.Drawing.Size(77, 26);
            this.txtEjeR.TabIndex = 12;
            // 
            // txtCilindroR
            // 
            this.txtCilindroR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCilindroR.Location = new System.Drawing.Point(238, 109);
            this.txtCilindroR.Name = "txtCilindroR";
            this.txtCilindroR.ReadOnly = true;
            this.txtCilindroR.Size = new System.Drawing.Size(77, 26);
            this.txtCilindroR.TabIndex = 11;
            // 
            // txtEsferaR
            // 
            this.txtEsferaR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEsferaR.Location = new System.Drawing.Point(238, 55);
            this.txtEsferaR.Name = "txtEsferaR";
            this.txtEsferaR.ReadOnly = true;
            this.txtEsferaR.Size = new System.Drawing.Size(77, 26);
            this.txtEsferaR.TabIndex = 10;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGuardar.BackColor = System.Drawing.Color.White;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(244)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(71, 211);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(197, 44);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // Calculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 267);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtEjeR);
            this.Controls.Add(this.txtCilindroR);
            this.Controls.Add(this.txtEsferaR);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEje);
            this.Controls.Add(this.txtCilindro);
            this.Controls.Add(this.txtEsfera);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Calculadora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEsfera;
        private System.Windows.Forms.TextBox txtCilindro;
        private System.Windows.Forms.TextBox txtEje;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEjeR;
        private System.Windows.Forms.TextBox txtCilindroR;
        private System.Windows.Forms.TextBox txtEsferaR;
        private System.Windows.Forms.Button btnGuardar;
    }
}