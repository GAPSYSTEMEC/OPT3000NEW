
namespace Opt3000.Vista.Utilitarios
{
    partial class OrdenLentesBlandos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdenLentesBlandos));
            this.p_superior = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new System.Windows.Forms.PictureBox();
            this.btnBusca = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.dt_FechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.dt_FechaPedido = new System.Windows.Forms.DateTimePicker();
            this.txtNombrePaciente = new System.Windows.Forms.TextBox();
            this.txtLaboratorio = new System.Windows.Forms.TextBox();
            this.lblNumeroOrden = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.txtEjeLenteOI = new System.Windows.Forms.TextBox();
            this.txtCilindroLenteOI = new System.Windows.Forms.TextBox();
            this.txtEsferaLenteOI = new System.Windows.Forms.TextBox();
            this.txtEjeLenteOD = new System.Windows.Forms.TextBox();
            this.txtCilindroLenteOD = new System.Windows.Forms.TextBox();
            this.txtEsferaLenteOD = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtTipoOD = new System.Windows.Forms.TextBox();
            this.txtTipoOI = new System.Windows.Forms.TextBox();
            this.btnInventario = new System.Windows.Forms.Button();
            this.p_superior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBusca)).BeginInit();
            this.SuspendLayout();
            // 
            // p_superior
            // 
            this.p_superior.BackColor = System.Drawing.Color.WhiteSmoke;
            this.p_superior.Controls.Add(this.btnCancelar);
            this.p_superior.Controls.Add(this.btnGuardar);
            this.p_superior.Controls.Add(this.btnBusca);
            this.p_superior.Controls.Add(this.btnSalir);
            this.p_superior.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_superior.Location = new System.Drawing.Point(0, 0);
            this.p_superior.Name = "p_superior";
            this.p_superior.Size = new System.Drawing.Size(461, 50);
            this.p_superior.TabIndex = 261;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(84, 0);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(42, 50);
            this.btnCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Visible = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(42, 0);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(42, 50);
            this.btnGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.TabStop = false;
            this.btnGuardar.Visible = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnBusca
            // 
            this.btnBusca.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBusca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBusca.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBusca.Image = ((System.Drawing.Image)(resources.GetObject("btnBusca.Image")));
            this.btnBusca.Location = new System.Drawing.Point(0, 0);
            this.btnBusca.Name = "btnBusca";
            this.btnBusca.Size = new System.Drawing.Size(42, 50);
            this.btnBusca.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnBusca.TabIndex = 10;
            this.btnBusca.TabStop = false;
            this.btnBusca.Click += new System.EventHandler(this.btnBusca_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(244)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(425, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(24, 24);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(244)))));
            this.label23.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.Menu;
            this.label23.Location = new System.Drawing.Point(59, 238);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(393, 21);
            this.label23.TabIndex = 424;
            this.label23.Text = "MEDIDAS";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dt_FechaEntrega
            // 
            this.dt_FechaEntrega.Location = new System.Drawing.Point(84, 179);
            this.dt_FechaEntrega.Name = "dt_FechaEntrega";
            this.dt_FechaEntrega.Size = new System.Drawing.Size(274, 20);
            this.dt_FechaEntrega.TabIndex = 412;
            // 
            // dt_FechaPedido
            // 
            this.dt_FechaPedido.Enabled = false;
            this.dt_FechaPedido.Location = new System.Drawing.Point(84, 153);
            this.dt_FechaPedido.Name = "dt_FechaPedido";
            this.dt_FechaPedido.Size = new System.Drawing.Size(274, 20);
            this.dt_FechaPedido.TabIndex = 411;
            // 
            // txtNombrePaciente
            // 
            this.txtNombrePaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombrePaciente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombrePaciente.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombrePaciente.Location = new System.Drawing.Point(85, 123);
            this.txtNombrePaciente.MaxLength = 5;
            this.txtNombrePaciente.Name = "txtNombrePaciente";
            this.txtNombrePaciente.ReadOnly = true;
            this.txtNombrePaciente.Size = new System.Drawing.Size(274, 24);
            this.txtNombrePaciente.TabIndex = 410;
            this.txtNombrePaciente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLaboratorio
            // 
            this.txtLaboratorio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLaboratorio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLaboratorio.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLaboratorio.Location = new System.Drawing.Point(85, 95);
            this.txtLaboratorio.MaxLength = 5;
            this.txtLaboratorio.Name = "txtLaboratorio";
            this.txtLaboratorio.Size = new System.Drawing.Size(274, 24);
            this.txtLaboratorio.TabIndex = 409;
            this.txtLaboratorio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNumeroOrden
            // 
            this.lblNumeroOrden.AutoSize = true;
            this.lblNumeroOrden.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroOrden.ForeColor = System.Drawing.Color.Red;
            this.lblNumeroOrden.Location = new System.Drawing.Point(367, 95);
            this.lblNumeroOrden.Name = "lblNumeroOrden";
            this.lblNumeroOrden.Size = new System.Drawing.Size(32, 23);
            this.lblNumeroOrden.TabIndex = 408;
            this.lblNumeroOrden.Text = "N°";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 184);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 13);
            this.label16.TabIndex = 407;
            this.label16.Text = "Entrega:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(18, 155);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 13);
            this.label17.TabIndex = 406;
            this.label17.Text = "Fecha:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(19, 126);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(42, 13);
            this.label18.TabIndex = 405;
            this.label18.Text = "Cliente:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(19, 98);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(60, 13);
            this.label26.TabIndex = 404;
            this.label26.Text = "Laboratorio";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(244)))));
            this.label14.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.Menu;
            this.label14.Location = new System.Drawing.Point(13, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(439, 21);
            this.label14.TabIndex = 403;
            this.label14.Text = "ORDEN DE TRABAJO";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtObservacion
            // 
            this.txtObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservacion.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacion.Location = new System.Drawing.Point(110, 414);
            this.txtObservacion.MaxLength = 5000;
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(335, 42);
            this.txtObservacion.TabIndex = 401;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 419);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 13);
            this.label13.TabIndex = 402;
            this.label13.Text = "Observaciones:";
            // 
            // txtFiltro
            // 
            this.txtFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFiltro.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.Location = new System.Drawing.Point(110, 384);
            this.txtFiltro.MaxLength = 5000;
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(335, 24);
            this.txtFiltro.TabIndex = 397;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 389);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 398;
            this.label9.Text = "Color:";
            // 
            // txtMaterial
            // 
            this.txtMaterial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaterial.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterial.Location = new System.Drawing.Point(110, 353);
            this.txtMaterial.MaxLength = 5000;
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(335, 24);
            this.txtMaterial.TabIndex = 395;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 358);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 396;
            this.label8.Text = "Material:";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(244)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Menu;
            this.label6.Location = new System.Drawing.Point(9, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(442, 21);
            this.label6.TabIndex = 392;
            this.label6.Text = "LENTES DE CONTACTO BLANDOS";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label49
            // 
            this.label49.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(244)))));
            this.label49.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.ForeColor = System.Drawing.SystemColors.Menu;
            this.label49.Location = new System.Drawing.Point(89, 314);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(39, 21);
            this.label49.TabIndex = 437;
            this.label49.Text = "O.I.";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label50
            // 
            this.label50.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(244)))));
            this.label50.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.SystemColors.Menu;
            this.label50.Location = new System.Drawing.Point(89, 287);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(39, 21);
            this.label50.TabIndex = 436;
            this.label50.Text = "O.D.";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtEjeLenteOI
            // 
            this.txtEjeLenteOI.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEjeLenteOI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEjeLenteOI.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEjeLenteOI.Location = new System.Drawing.Point(266, 311);
            this.txtEjeLenteOI.MaxLength = 5;
            this.txtEjeLenteOI.Name = "txtEjeLenteOI";
            this.txtEjeLenteOI.Size = new System.Drawing.Size(62, 24);
            this.txtEjeLenteOI.TabIndex = 430;
            this.txtEjeLenteOI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCilindroLenteOI
            // 
            this.txtCilindroLenteOI.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCilindroLenteOI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCilindroLenteOI.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCilindroLenteOI.Location = new System.Drawing.Point(200, 311);
            this.txtCilindroLenteOI.MaxLength = 5;
            this.txtCilindroLenteOI.Name = "txtCilindroLenteOI";
            this.txtCilindroLenteOI.Size = new System.Drawing.Size(62, 24);
            this.txtCilindroLenteOI.TabIndex = 429;
            this.txtCilindroLenteOI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEsferaLenteOI
            // 
            this.txtEsferaLenteOI.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEsferaLenteOI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEsferaLenteOI.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEsferaLenteOI.Location = new System.Drawing.Point(134, 311);
            this.txtEsferaLenteOI.MaxLength = 5;
            this.txtEsferaLenteOI.Name = "txtEsferaLenteOI";
            this.txtEsferaLenteOI.Size = new System.Drawing.Size(62, 24);
            this.txtEsferaLenteOI.TabIndex = 428;
            this.txtEsferaLenteOI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEjeLenteOD
            // 
            this.txtEjeLenteOD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEjeLenteOD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEjeLenteOD.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEjeLenteOD.Location = new System.Drawing.Point(266, 285);
            this.txtEjeLenteOD.MaxLength = 5;
            this.txtEjeLenteOD.Name = "txtEjeLenteOD";
            this.txtEjeLenteOD.Size = new System.Drawing.Size(62, 24);
            this.txtEjeLenteOD.TabIndex = 427;
            this.txtEjeLenteOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCilindroLenteOD
            // 
            this.txtCilindroLenteOD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCilindroLenteOD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCilindroLenteOD.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCilindroLenteOD.Location = new System.Drawing.Point(200, 285);
            this.txtCilindroLenteOD.MaxLength = 5;
            this.txtCilindroLenteOD.Name = "txtCilindroLenteOD";
            this.txtCilindroLenteOD.Size = new System.Drawing.Size(62, 24);
            this.txtCilindroLenteOD.TabIndex = 426;
            this.txtCilindroLenteOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEsferaLenteOD
            // 
            this.txtEsferaLenteOD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEsferaLenteOD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEsferaLenteOD.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEsferaLenteOD.Location = new System.Drawing.Point(134, 285);
            this.txtEsferaLenteOD.MaxLength = 5;
            this.txtEsferaLenteOD.Name = "txtEsferaLenteOD";
            this.txtEsferaLenteOD.Size = new System.Drawing.Size(62, 24);
            this.txtEsferaLenteOD.TabIndex = 425;
            this.txtEsferaLenteOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(351, 269);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 435;
            this.label11.Text = "Tipo";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(287, 269);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(26, 13);
            this.label15.TabIndex = 434;
            this.label15.Text = "EJE";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(203, 269);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 433;
            this.label12.Text = "CILINDRO";
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(142, 269);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(49, 13);
            this.label19.TabIndex = 432;
            this.label19.Text = "ESFERA";
            // 
            // txtTipoOD
            // 
            this.txtTipoOD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTipoOD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipoOD.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoOD.Location = new System.Drawing.Point(334, 285);
            this.txtTipoOD.MaxLength = 5;
            this.txtTipoOD.Name = "txtTipoOD";
            this.txtTipoOD.Size = new System.Drawing.Size(62, 24);
            this.txtTipoOD.TabIndex = 438;
            this.txtTipoOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTipoOI
            // 
            this.txtTipoOI.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTipoOI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipoOI.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoOI.Location = new System.Drawing.Point(334, 311);
            this.txtTipoOI.MaxLength = 5;
            this.txtTipoOI.Name = "txtTipoOI";
            this.txtTipoOI.Size = new System.Drawing.Size(62, 24);
            this.txtTipoOI.TabIndex = 439;
            this.txtTipoOI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnInventario
            // 
            this.btnInventario.Location = new System.Drawing.Point(73, 353);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(32, 23);
            this.btnInventario.TabIndex = 440;
            this.btnInventario.Text = "F1";
            this.btnInventario.UseVisualStyleBackColor = true;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // OrdenLentesBlandos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(461, 567);
            this.Controls.Add(this.btnInventario);
            this.Controls.Add(this.txtTipoOI);
            this.Controls.Add(this.txtTipoOD);
            this.Controls.Add(this.label49);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.txtEjeLenteOI);
            this.Controls.Add(this.txtCilindroLenteOI);
            this.Controls.Add(this.txtEsferaLenteOI);
            this.Controls.Add(this.txtEjeLenteOD);
            this.Controls.Add(this.txtCilindroLenteOD);
            this.Controls.Add(this.txtEsferaLenteOD);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.dt_FechaEntrega);
            this.Controls.Add(this.dt_FechaPedido);
            this.Controls.Add(this.txtNombrePaciente);
            this.Controls.Add(this.txtLaboratorio);
            this.Controls.Add(this.lblNumeroOrden);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtMaterial);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.p_superior);
            this.Location = new System.Drawing.Point(677, 101);
            this.Name = "OrdenLentesBlandos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "OrdenLentesBlandos";
            this.p_superior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBusca)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel p_superior;
        private System.Windows.Forms.PictureBox btnCancelar;
        private System.Windows.Forms.PictureBox btnGuardar;
        private System.Windows.Forms.PictureBox btnBusca;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DateTimePicker dt_FechaEntrega;
        private System.Windows.Forms.DateTimePicker dt_FechaPedido;
        private System.Windows.Forms.TextBox txtNombrePaciente;
        private System.Windows.Forms.TextBox txtLaboratorio;
        private System.Windows.Forms.Label lblNumeroOrden;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.TextBox txtEjeLenteOI;
        private System.Windows.Forms.TextBox txtCilindroLenteOI;
        private System.Windows.Forms.TextBox txtEsferaLenteOI;
        private System.Windows.Forms.TextBox txtEjeLenteOD;
        private System.Windows.Forms.TextBox txtCilindroLenteOD;
        private System.Windows.Forms.TextBox txtEsferaLenteOD;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtTipoOD;
        private System.Windows.Forms.TextBox txtTipoOI;
        private System.Windows.Forms.Button btnInventario;
    }
}