namespace Opt3000.Vista.Clientes
{
    partial class Agendamiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Agendamiento));
            this.p_superior = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new System.Windows.Forms.PictureBox();
            this.btnBusca = new System.Windows.Forms.PictureBox();
            this.btnNuevo = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.p_datosPaciente = new System.Windows.Forms.Panel();
            this.p_PacienteDatos = new System.Windows.Forms.Panel();
            this.lblAtencion = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.lblEdad = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblNombrePaciente = new System.Windows.Forms.Label();
            this.lblIdentificacion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblHc = new System.Windows.Forms.Label();
            this.lblOcupacion = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.p_Atencion = new System.Windows.Forms.Panel();
            this.btnNuevoPaciente = new System.Windows.Forms.Button();
            this.btnAgenda = new System.Windows.Forms.Button();
            this.btn_Agenda = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbConsultorio = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbHora = new System.Windows.Forms.ComboBox();
            this.dtp_FechaConsulta = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMedico = new System.Windows.Forms.ComboBox();
            this.btnCie = new System.Windows.Forms.Button();
            this.txtCie10 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCargaDoc = new System.Windows.Forms.Button();
            this.btnVerDoc = new System.Windows.Forms.Button();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.error = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.p_superior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBusca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNuevo)).BeginInit();
            this.p_datosPaciente.SuspendLayout();
            this.p_PacienteDatos.SuspendLayout();
            this.p_Atencion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.SuspendLayout();
            // 
            // p_superior
            // 
            this.p_superior.BackColor = System.Drawing.Color.WhiteSmoke;
            this.p_superior.Controls.Add(this.btnNuevoPaciente);
            this.p_superior.Controls.Add(this.btnCancelar);
            this.p_superior.Controls.Add(this.btnGuardar);
            this.p_superior.Controls.Add(this.btnBusca);
            this.p_superior.Controls.Add(this.btnNuevo);
            this.p_superior.Controls.Add(this.btnSalir);
            this.p_superior.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_superior.Location = new System.Drawing.Point(0, 0);
            this.p_superior.Name = "p_superior";
            this.p_superior.Size = new System.Drawing.Size(1111, 50);
            this.p_superior.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(126, 0);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(42, 50);
            this.btnCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.TabStop = false;
            this.toolTip1.SetToolTip(this.btnCancelar, "Cancelar Atención");
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(84, 0);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(42, 50);
            this.btnGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.TabStop = false;
            this.toolTip1.SetToolTip(this.btnGuardar, "Guardar Atención");
            this.btnGuardar.Visible = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnBusca
            // 
            this.btnBusca.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBusca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBusca.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBusca.Image = ((System.Drawing.Image)(resources.GetObject("btnBusca.Image")));
            this.btnBusca.Location = new System.Drawing.Point(42, 0);
            this.btnBusca.Name = "btnBusca";
            this.btnBusca.Size = new System.Drawing.Size(42, 50);
            this.btnBusca.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnBusca.TabIndex = 10;
            this.btnBusca.TabStop = false;
            this.toolTip1.SetToolTip(this.btnBusca, "Buscar Atenciones");
            this.btnBusca.Click += new System.EventHandler(this.btnBusca_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.Location = new System.Drawing.Point(0, 0);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(42, 50);
            this.btnNuevo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnNuevo.TabIndex = 9;
            this.btnNuevo.TabStop = false;
            this.toolTip1.SetToolTip(this.btnNuevo, "Nueva Atención");
            this.btnNuevo.Visible = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(244)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(1075, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(24, 24);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(435, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "DATOS PACIENTE";
            // 
            // p_datosPaciente
            // 
            this.p_datosPaciente.BackColor = System.Drawing.Color.Gainsboro;
            this.p_datosPaciente.Controls.Add(this.p_PacienteDatos);
            this.p_datosPaciente.Controls.Add(this.label2);
            this.p_datosPaciente.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_datosPaciente.Location = new System.Drawing.Point(0, 50);
            this.p_datosPaciente.Name = "p_datosPaciente";
            this.p_datosPaciente.Size = new System.Drawing.Size(1111, 148);
            this.p_datosPaciente.TabIndex = 12;
            // 
            // p_PacienteDatos
            // 
            this.p_PacienteDatos.Controls.Add(this.lblAtencion);
            this.p_PacienteDatos.Controls.Add(this.label36);
            this.p_PacienteDatos.Controls.Add(this.lblTipo);
            this.p_PacienteDatos.Controls.Add(this.label35);
            this.p_PacienteDatos.Controls.Add(this.lblEdad);
            this.p_PacienteDatos.Controls.Add(this.label1);
            this.p_PacienteDatos.Controls.Add(this.label7);
            this.p_PacienteDatos.Controls.Add(this.lblNombrePaciente);
            this.p_PacienteDatos.Controls.Add(this.lblIdentificacion);
            this.p_PacienteDatos.Controls.Add(this.label4);
            this.p_PacienteDatos.Controls.Add(this.label5);
            this.p_PacienteDatos.Controls.Add(this.lblHc);
            this.p_PacienteDatos.Controls.Add(this.lblOcupacion);
            this.p_PacienteDatos.Controls.Add(this.label6);
            this.p_PacienteDatos.Location = new System.Drawing.Point(0, 45);
            this.p_PacienteDatos.Name = "p_PacienteDatos";
            this.p_PacienteDatos.Size = new System.Drawing.Size(1108, 100);
            this.p_PacienteDatos.TabIndex = 12;
            this.p_PacienteDatos.Visible = false;
            // 
            // lblAtencion
            // 
            this.lblAtencion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAtencion.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAtencion.ForeColor = System.Drawing.Color.Red;
            this.lblAtencion.Location = new System.Drawing.Point(858, 65);
            this.lblAtencion.Name = "lblAtencion";
            this.lblAtencion.Size = new System.Drawing.Size(54, 21);
            this.lblAtencion.TabIndex = 25;
            this.lblAtencion.Text = "tipo";
            this.lblAtencion.Visible = false;
            // 
            // label36
            // 
            this.label36.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.Color.Red;
            this.label36.Location = new System.Drawing.Point(768, 65);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(89, 21);
            this.label36.TabIndex = 24;
            this.label36.Text = "ATENCIÓN:";
            this.label36.Visible = false;
            // 
            // lblTipo
            // 
            this.lblTipo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(439, 65);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(228, 21);
            this.lblTipo.TabIndex = 23;
            this.lblTipo.Text = "tipo";
            this.lblTipo.Visible = false;
            // 
            // label35
            // 
            this.label35.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(390, 65);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(46, 21);
            this.label35.TabIndex = 22;
            this.label35.Text = "TIPO:";
            this.label35.Visible = false;
            // 
            // lblEdad
            // 
            this.lblEdad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEdad.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEdad.Location = new System.Drawing.Point(315, 65);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(69, 21);
            this.lblEdad.TabIndex = 21;
            this.lblEdad.Text = "edad";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 21);
            this.label1.TabIndex = 12;
            this.label1.Text = "NOMBRES:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(265, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 21);
            this.label7.TabIndex = 20;
            this.label7.Text = "EDAD:";
            // 
            // lblNombrePaciente
            // 
            this.lblNombrePaciente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNombrePaciente.AutoSize = true;
            this.lblNombrePaciente.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombrePaciente.Location = new System.Drawing.Point(111, 33);
            this.lblNombrePaciente.Name = "lblNombrePaciente";
            this.lblNombrePaciente.Size = new System.Drawing.Size(73, 21);
            this.lblNombrePaciente.TabIndex = 13;
            this.lblNombrePaciente.Text = "Nombre";
            // 
            // lblIdentificacion
            // 
            this.lblIdentificacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIdentificacion.AutoSize = true;
            this.lblIdentificacion.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdentificacion.Location = new System.Drawing.Point(576, 33);
            this.lblIdentificacion.Name = "lblIdentificacion";
            this.lblIdentificacion.Size = new System.Drawing.Size(102, 21);
            this.lblIdentificacion.TabIndex = 19;
            this.lblIdentificacion.Text = "identificación";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 21);
            this.label4.TabIndex = 14;
            this.label4.Text = "HISTORIA CLINICA:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(450, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 21);
            this.label5.TabIndex = 18;
            this.label5.Text = "IDENTIFICACIÓN:";
            // 
            // lblHc
            // 
            this.lblHc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHc.AutoSize = true;
            this.lblHc.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHc.Location = new System.Drawing.Point(166, 65);
            this.lblHc.Name = "lblHc";
            this.lblHc.Size = new System.Drawing.Size(26, 21);
            this.lblHc.TabIndex = 15;
            this.lblHc.Text = "hc";
            // 
            // lblOcupacion
            // 
            this.lblOcupacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOcupacion.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOcupacion.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblOcupacion.Location = new System.Drawing.Point(868, 27);
            this.lblOcupacion.Name = "lblOcupacion";
            this.lblOcupacion.Size = new System.Drawing.Size(220, 34);
            this.lblOcupacion.TabIndex = 17;
            this.lblOcupacion.Text = "ocupacion";
            this.lblOcupacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(768, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 21);
            this.label6.TabIndex = 16;
            this.label6.Text = "OCUPACIÓN:";
            // 
            // p_Atencion
            // 
            this.p_Atencion.BackColor = System.Drawing.Color.Gainsboro;
            this.p_Atencion.Controls.Add(this.btnAgenda);
            this.p_Atencion.Controls.Add(this.btn_Agenda);
            this.p_Atencion.Controls.Add(this.label13);
            this.p_Atencion.Controls.Add(this.cmbConsultorio);
            this.p_Atencion.Controls.Add(this.label12);
            this.p_Atencion.Controls.Add(this.label11);
            this.p_Atencion.Controls.Add(this.cmbHora);
            this.p_Atencion.Controls.Add(this.dtp_FechaConsulta);
            this.p_Atencion.Controls.Add(this.label10);
            this.p_Atencion.Controls.Add(this.label3);
            this.p_Atencion.Controls.Add(this.cmbMedico);
            this.p_Atencion.Controls.Add(this.btnCie);
            this.p_Atencion.Controls.Add(this.txtCie10);
            this.p_Atencion.Controls.Add(this.label8);
            this.p_Atencion.Controls.Add(this.btnCargaDoc);
            this.p_Atencion.Controls.Add(this.btnVerDoc);
            this.p_Atencion.Controls.Add(this.txtObservaciones);
            this.p_Atencion.Controls.Add(this.label33);
            this.p_Atencion.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_Atencion.Enabled = false;
            this.p_Atencion.Location = new System.Drawing.Point(0, 198);
            this.p_Atencion.Name = "p_Atencion";
            this.p_Atencion.Size = new System.Drawing.Size(1111, 539);
            this.p_Atencion.TabIndex = 13;
            // 
            // btnNuevoPaciente
            // 
            this.btnNuevoPaciente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNuevoPaciente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNuevoPaciente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoPaciente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(244)))));
            this.btnNuevoPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoPaciente.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoPaciente.ForeColor = System.Drawing.Color.Black;
            this.btnNuevoPaciente.Location = new System.Drawing.Point(924, 2);
            this.btnNuevoPaciente.Name = "btnNuevoPaciente";
            this.btnNuevoPaciente.Size = new System.Drawing.Size(133, 42);
            this.btnNuevoPaciente.TabIndex = 268;
            this.btnNuevoPaciente.Text = "NUEVO PACIENTE";
            this.btnNuevoPaciente.UseVisualStyleBackColor = false;
            this.btnNuevoPaciente.Click += new System.EventHandler(this.btnNuevoPaciente_Click_1);
            // 
            // btnAgenda
            // 
            this.btnAgenda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgenda.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAgenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgenda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(244)))));
            this.btnAgenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgenda.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgenda.ForeColor = System.Drawing.Color.Black;
            this.btnAgenda.Location = new System.Drawing.Point(151, 20);
            this.btnAgenda.Name = "btnAgenda";
            this.btnAgenda.Size = new System.Drawing.Size(133, 53);
            this.btnAgenda.TabIndex = 267;
            this.btnAgenda.Text = "AGENDA HORARIOS";
            this.btnAgenda.UseVisualStyleBackColor = false;
            this.btnAgenda.Click += new System.EventHandler(this.btnAgenda_Click);
            // 
            // btn_Agenda
            // 
            this.btn_Agenda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Agenda.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Agenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Agenda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(244)))));
            this.btn_Agenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Agenda.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Agenda.ForeColor = System.Drawing.Color.Black;
            this.btn_Agenda.Location = new System.Drawing.Point(12, 20);
            this.btn_Agenda.Name = "btn_Agenda";
            this.btn_Agenda.Size = new System.Drawing.Size(133, 53);
            this.btn_Agenda.TabIndex = 266;
            this.btn_Agenda.Text = "HISTORIAL AGENDA";
            this.btn_Agenda.UseVisualStyleBackColor = false;
            this.btn_Agenda.Click += new System.EventHandler(this.btn_Agenda_Click);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Gainsboro;
            this.label13.Location = new System.Drawing.Point(353, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(395, 29);
            this.label13.TabIndex = 265;
            this.label13.Text = "AGENDA DE CITAS OFTALMOLÓGICAS";
            // 
            // cmbConsultorio
            // 
            this.cmbConsultorio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbConsultorio.FormattingEnabled = true;
            this.cmbConsultorio.Location = new System.Drawing.Point(772, 124);
            this.cmbConsultorio.Name = "cmbConsultorio";
            this.cmbConsultorio.Size = new System.Drawing.Size(194, 21);
            this.cmbConsultorio.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label12.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Gainsboro;
            this.label12.Location = new System.Drawing.Point(772, 100);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(194, 21);
            this.label12.TabIndex = 262;
            this.label12.Text = "CONSULTORIO";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label11.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Gainsboro;
            this.label11.Location = new System.Drawing.Point(635, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 21);
            this.label11.TabIndex = 260;
            this.label11.Text = "HORA";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbHora
            // 
            this.cmbHora.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbHora.FormattingEnabled = true;
            this.cmbHora.Location = new System.Drawing.Point(635, 124);
            this.cmbHora.Name = "cmbHora";
            this.cmbHora.Size = new System.Drawing.Size(80, 21);
            this.cmbHora.TabIndex = 2;
            // 
            // dtp_FechaConsulta
            // 
            this.dtp_FechaConsulta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtp_FechaConsulta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_FechaConsulta.Location = new System.Drawing.Point(130, 125);
            this.dtp_FechaConsulta.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtp_FechaConsulta.MinDate = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            this.dtp_FechaConsulta.Name = "dtp_FechaConsulta";
            this.dtp_FechaConsulta.Size = new System.Drawing.Size(121, 20);
            this.dtp_FechaConsulta.TabIndex = 0;
            this.dtp_FechaConsulta.ValueChanged += new System.EventHandler(this.dtp_FechaConsulta_ValueChanged);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label10.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Gainsboro;
            this.label10.Location = new System.Drawing.Point(130, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 21);
            this.label10.TabIndex = 257;
            this.label10.Text = "FECHA";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(307, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(282, 21);
            this.label3.TabIndex = 255;
            this.label3.Text = "MÉDICO";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbMedico
            // 
            this.cmbMedico.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbMedico.FormattingEnabled = true;
            this.cmbMedico.Location = new System.Drawing.Point(307, 124);
            this.cmbMedico.Name = "cmbMedico";
            this.cmbMedico.Size = new System.Drawing.Size(282, 21);
            this.cmbMedico.TabIndex = 1;
            this.cmbMedico.SelectionChangeCommitted += new System.EventHandler(this.cmbMedico_SelectionChangeCommitted);
            // 
            // btnCie
            // 
            this.btnCie.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(244)))));
            this.btnCie.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCie.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(244)))));
            this.btnCie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCie.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCie.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCie.Location = new System.Drawing.Point(664, 181);
            this.btnCie.Name = "btnCie";
            this.btnCie.Size = new System.Drawing.Size(133, 44);
            this.btnCie.TabIndex = 6;
            this.btnCie.Text = "CIE-10";
            this.btnCie.UseVisualStyleBackColor = false;
            this.btnCie.Click += new System.EventHandler(this.btnCie_Click);
            // 
            // txtCie10
            // 
            this.txtCie10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCie10.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCie10.Location = new System.Drawing.Point(19, 287);
            this.txtCie10.Multiline = true;
            this.txtCie10.Name = "txtCie10";
            this.txtCie10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCie10.Size = new System.Drawing.Size(1070, 45);
            this.txtCie10.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label8.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gainsboro;
            this.label8.Location = new System.Drawing.Point(19, 253);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(1069, 21);
            this.label8.TabIndex = 244;
            this.label8.Text = "DIAGNOSTICO / CAUSA";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCargaDoc
            // 
            this.btnCargaDoc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCargaDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(244)))));
            this.btnCargaDoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargaDoc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(244)))));
            this.btnCargaDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargaDoc.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargaDoc.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCargaDoc.Location = new System.Drawing.Point(299, 181);
            this.btnCargaDoc.Name = "btnCargaDoc";
            this.btnCargaDoc.Size = new System.Drawing.Size(133, 44);
            this.btnCargaDoc.TabIndex = 4;
            this.btnCargaDoc.Text = "CARGAR DOCUMENTO";
            this.btnCargaDoc.UseVisualStyleBackColor = false;
            this.btnCargaDoc.Click += new System.EventHandler(this.btnCargaDoc_Click);
            // 
            // btnVerDoc
            // 
            this.btnVerDoc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVerDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(244)))));
            this.btnVerDoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerDoc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(244)))));
            this.btnVerDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerDoc.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerDoc.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnVerDoc.Location = new System.Drawing.Point(481, 181);
            this.btnVerDoc.Name = "btnVerDoc";
            this.btnVerDoc.Size = new System.Drawing.Size(133, 44);
            this.btnVerDoc.TabIndex = 5;
            this.btnVerDoc.Text = "VER DOCUMENTOS";
            this.btnVerDoc.UseVisualStyleBackColor = false;
            this.btnVerDoc.Click += new System.EventHandler(this.btnVerDoc_Click);
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservaciones.Location = new System.Drawing.Point(19, 387);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(1072, 64);
            this.txtObservaciones.TabIndex = 8;
            // 
            // label33
            // 
            this.label33.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label33.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label33.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.Gainsboro;
            this.label33.Location = new System.Drawing.Point(19, 348);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(1073, 21);
            this.label33.TabIndex = 107;
            this.label33.Text = "OBSERVACIONES";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // error
            // 
            this.error.ContainerControl = this;
            // 
            // Agendamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 744);
            this.Controls.Add(this.p_Atencion);
            this.Controls.Add(this.p_datosPaciente);
            this.Controls.Add(this.p_superior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Agendamiento";
            this.Load += new System.EventHandler(this.Agendamiento_Load);
            this.p_superior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBusca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNuevo)).EndInit();
            this.p_datosPaciente.ResumeLayout(false);
            this.p_datosPaciente.PerformLayout();
            this.p_PacienteDatos.ResumeLayout(false);
            this.p_PacienteDatos.PerformLayout();
            this.p_Atencion.ResumeLayout(false);
            this.p_Atencion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_superior;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.PictureBox btnCancelar;
        private System.Windows.Forms.PictureBox btnGuardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel p_datosPaciente;
        private System.Windows.Forms.Panel p_Atencion;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Panel p_PacienteDatos;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblNombrePaciente;
        private System.Windows.Forms.Label lblIdentificacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblHc;
        private System.Windows.Forms.Label lblOcupacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCargaDoc;
        private System.Windows.Forms.Button btnVerDoc;
        private System.Windows.Forms.PictureBox btnBusca;
        private System.Windows.Forms.PictureBox btnNuevo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label lblAtencion;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.ErrorProvider error;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtCie10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbHora;
        private System.Windows.Forms.DateTimePicker dtp_FechaConsulta;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMedico;
        private System.Windows.Forms.Button btnCie;
        private System.Windows.Forms.ComboBox cmbConsultorio;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btn_Agenda;
        private System.Windows.Forms.Button btnAgenda;
        private System.Windows.Forms.Button btnNuevoPaciente;
    }
}