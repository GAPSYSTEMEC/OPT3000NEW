
namespace Opt3000.Vista.Utilitarios
{
    partial class Anticipo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Anticipo));
            this.dgv_Anticipos = new System.Windows.Forms.DataGridView();
            this.bntImprime = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.txtFormaPago = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiferido = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAutorizacion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.error = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Anticipos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bntImprime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Anticipos
            // 
            this.dgv_Anticipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Anticipos.Location = new System.Drawing.Point(12, 59);
            this.dgv_Anticipos.Name = "dgv_Anticipos";
            this.dgv_Anticipos.Size = new System.Drawing.Size(234, 151);
            this.dgv_Anticipos.TabIndex = 1;
            // 
            // bntImprime
            // 
            this.bntImprime.Image = ((System.Drawing.Image)(resources.GetObject("bntImprime.Image")));
            this.bntImprime.Location = new System.Drawing.Point(0, 0);
            this.bntImprime.Name = "bntImprime";
            this.bntImprime.Size = new System.Drawing.Size(49, 50);
            this.bntImprime.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.bntImprime.TabIndex = 2;
            this.bntImprime.TabStop = false;
            this.toolTipController1.SetTitle(this.bntImprime, "IMPRIMIR");
            this.toolTipController1.SetToolTip(this.bntImprime, "Del anticipo seleccionado se genera un recibo");
            this.bntImprime.Click += new System.EventHandler(this.bntImprime_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(55, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(49, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.toolTipController1.SetTitle(this.pictureBox2, "ASIGANACION ANTICIPO");
            this.toolTipController1.SetToolTip(this.pictureBox2, "El anticipo seleccionado puede ser ingresado a otro paciente para que este utilic" +
        "e el mismo en su cuenta");
            // 
            // txtFormaPago
            // 
            this.txtFormaPago.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFormaPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFormaPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFormaPago.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFormaPago.Location = new System.Drawing.Point(145, 275);
            this.txtFormaPago.MaxLength = 0;
            this.txtFormaPago.Name = "txtFormaPago";
            this.txtFormaPago.ReadOnly = true;
            this.txtFormaPago.Size = new System.Drawing.Size(101, 24);
            this.txtFormaPago.TabIndex = 28;
            this.toolTipController1.SetTitle(this.txtFormaPago, "FORMA DE PAGO");
            this.toolTipController1.SetToolTip(this.txtFormaPago, "Preciona F1 para obtener las ayudas");
            this.txtFormaPago.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFormaPago_KeyDown);
            this.txtFormaPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFormaPago_KeyPress);
            this.txtFormaPago.Leave += new System.EventHandler(this.txtFormaPago_Leave);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNuevo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(244)))));
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.Black;
            this.btnNuevo.Location = new System.Drawing.Point(32, 222);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(197, 44);
            this.btnNuevo.TabIndex = 15;
            this.btnNuevo.Text = "ABONO";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 21);
            this.label3.TabIndex = 27;
            this.label3.Text = "FORMA DE PAGO:";
            // 
            // txtDiferido
            // 
            this.txtDiferido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDiferido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiferido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDiferido.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiferido.Location = new System.Drawing.Point(145, 305);
            this.txtDiferido.MaxLength = 0;
            this.txtDiferido.Name = "txtDiferido";
            this.txtDiferido.ReadOnly = true;
            this.txtDiferido.Size = new System.Drawing.Size(101, 24);
            this.txtDiferido.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 21);
            this.label1.TabIndex = 29;
            this.label1.Text = "TIEMPO DIFERIDO:";
            // 
            // txtLote
            // 
            this.txtLote.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLote.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLote.Location = new System.Drawing.Point(145, 335);
            this.txtLote.MaxLength = 0;
            this.txtLote.Name = "txtLote";
            this.txtLote.ReadOnly = true;
            this.txtLote.Size = new System.Drawing.Size(101, 24);
            this.txtLote.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 336);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 21);
            this.label2.TabIndex = 31;
            this.label2.Text = "LOTE:";
            // 
            // txtAutorizacion
            // 
            this.txtAutorizacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAutorizacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAutorizacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAutorizacion.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAutorizacion.Location = new System.Drawing.Point(145, 365);
            this.txtAutorizacion.MaxLength = 0;
            this.txtAutorizacion.Name = "txtAutorizacion";
            this.txtAutorizacion.ReadOnly = true;
            this.txtAutorizacion.Size = new System.Drawing.Size(101, 24);
            this.txtAutorizacion.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 366);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 21);
            this.label4.TabIndex = 33;
            this.label4.Text = "AUTORIZACIÓN:";
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(145, 395);
            this.txtTotal.MaxLength = 0;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(101, 24);
            this.txtTotal.TabIndex = 36;
            this.txtTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTotal_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 396);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 21);
            this.label5.TabIndex = 35;
            this.label5.Text = "TOTAL PAGO:";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(244)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(32, 428);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 44);
            this.button1.TabIndex = 37;
            this.button1.Text = "GUARDA ANTICIPO";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // error
            // 
            this.error.ContainerControl = this;
            // 
            // Anticipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 476);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAutorizacion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLote);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDiferido);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFormaPago);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.bntImprime);
            this.Controls.Add(this.dgv_Anticipos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Anticipo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anticipo";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Anticipos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bntImprime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Anticipos;
        private System.Windows.Forms.PictureBox bntImprime;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.TextBox txtFormaPago;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiferido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAutorizacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider error;
    }
}