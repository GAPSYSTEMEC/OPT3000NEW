
namespace Opt3000.Vista.Utilitarios
{
    partial class Anticipos
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
            this.dgv_Anticipos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Anticipos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Anticipos
            // 
            this.dgv_Anticipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Anticipos.Location = new System.Drawing.Point(12, 12);
            this.dgv_Anticipos.Name = "dgv_Anticipos";
            this.dgv_Anticipos.Size = new System.Drawing.Size(234, 151);
            this.dgv_Anticipos.TabIndex = 0;
            this.dgv_Anticipos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Anticipos_CellClick);
            this.dgv_Anticipos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_Anticipos_KeyDown);
            // 
            // Anticipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 174);
            this.Controls.Add(this.dgv_Anticipos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Anticipos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anticipos";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Anticipos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Anticipos;
    }
}