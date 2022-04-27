
namespace Opt3000.Vista.Utilitarios
{
    partial class FormasPago
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
            this.dgv_FormasPago = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FormasPago)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_FormasPago
            // 
            this.dgv_FormasPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_FormasPago.Location = new System.Drawing.Point(12, 12);
            this.dgv_FormasPago.Name = "dgv_FormasPago";
            this.dgv_FormasPago.Size = new System.Drawing.Size(270, 248);
            this.dgv_FormasPago.TabIndex = 0;
            this.dgv_FormasPago.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_FormasPago_CellClick);
            this.dgv_FormasPago.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_FormasPago_KeyDown);
            // 
            // FormasPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 272);
            this.Controls.Add(this.dgv_FormasPago);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormasPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formas Pago";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FormasPago)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_FormasPago;
    }
}