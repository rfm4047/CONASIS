namespace CONASIS.PDL
{
    partial class frmNDocente
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
            this.panelContenido = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.gbxDatosLaborales = new System.Windows.Forms.GroupBox();
            this.txtHrPlanilla = new System.Windows.Forms.TextBox();
            this.txtCargaHoraria = new System.Windows.Forms.TextBox();
            this.lblCargaHoraria = new System.Windows.Forms.Label();
            this.lblHoraPlanilla = new System.Windows.Forms.Label();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.txtEspecialidad = new System.Windows.Forms.TextBox();
            this.lblRda = new System.Windows.Forms.Label();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.txtRda = new System.Windows.Forms.TextBox();
            this.gbxDatosPersonales = new System.Windows.Forms.GroupBox();
            this.dtpFechaNac = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.cbxGenero = new System.Windows.Forms.ComboBox();
            this.cbxExtension = new System.Windows.Forms.ComboBox();
            this.txtCarnet = new System.Windows.Forms.TextBox();
            this.txtMaterno = new System.Windows.Forms.TextBox();
            this.txtApPaterno = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblGenero = new System.Windows.Forms.Label();
            this.lblCarnet = new System.Windows.Forms.Label();
            this.lblMaterno = new System.Windows.Forms.Label();
            this.lblApPaterno = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDocente = new System.Windows.Forms.Label();
            this.panelContenido.SuspendLayout();
            this.gbxDatosLaborales.SuspendLayout();
            this.gbxDatosPersonales.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContenido
            // 
            this.panelContenido.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelContenido.Controls.Add(this.btnCancelar);
            this.panelContenido.Controls.Add(this.btnAceptar);
            this.panelContenido.Controls.Add(this.gbxDatosLaborales);
            this.panelContenido.Controls.Add(this.gbxDatosPersonales);
            this.panelContenido.Controls.Add(this.lblDocente);
            this.panelContenido.Location = new System.Drawing.Point(0, 0);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(892, 563);
            this.panelContenido.TabIndex = 0;
            this.panelContenido.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContenido_Paint);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(480, 512);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(127, 31);
            this.btnCancelar.TabIndex = 231;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(247, 512);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(127, 31);
            this.btnAceptar.TabIndex = 230;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // gbxDatosLaborales
            // 
            this.gbxDatosLaborales.Controls.Add(this.txtHrPlanilla);
            this.gbxDatosLaborales.Controls.Add(this.txtCargaHoraria);
            this.gbxDatosLaborales.Controls.Add(this.lblCargaHoraria);
            this.gbxDatosLaborales.Controls.Add(this.lblHoraPlanilla);
            this.gbxDatosLaborales.Controls.Add(this.lblEspecialidad);
            this.gbxDatosLaborales.Controls.Add(this.txtEspecialidad);
            this.gbxDatosLaborales.Controls.Add(this.lblRda);
            this.gbxDatosLaborales.Controls.Add(this.txtItem);
            this.gbxDatosLaborales.Controls.Add(this.lblItem);
            this.gbxDatosLaborales.Controls.Add(this.txtRda);
            this.gbxDatosLaborales.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDatosLaborales.Location = new System.Drawing.Point(14, 372);
            this.gbxDatosLaborales.Name = "gbxDatosLaborales";
            this.gbxDatosLaborales.Size = new System.Drawing.Size(771, 122);
            this.gbxDatosLaborales.TabIndex = 229;
            this.gbxDatosLaborales.TabStop = false;
            this.gbxDatosLaborales.Text = "Datos Laborales";
            // 
            // txtHrPlanilla
            // 
            this.txtHrPlanilla.Location = new System.Drawing.Point(516, 78);
            this.txtHrPlanilla.Name = "txtHrPlanilla";
            this.txtHrPlanilla.Size = new System.Drawing.Size(58, 26);
            this.txtHrPlanilla.TabIndex = 229;
            // 
            // txtCargaHoraria
            // 
            this.txtCargaHoraria.Location = new System.Drawing.Point(219, 83);
            this.txtCargaHoraria.Name = "txtCargaHoraria";
            this.txtCargaHoraria.Size = new System.Drawing.Size(58, 26);
            this.txtCargaHoraria.TabIndex = 226;
            // 
            // lblCargaHoraria
            // 
            this.lblCargaHoraria.AutoSize = true;
            this.lblCargaHoraria.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargaHoraria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblCargaHoraria.Location = new System.Drawing.Point(82, 85);
            this.lblCargaHoraria.Name = "lblCargaHoraria";
            this.lblCargaHoraria.Size = new System.Drawing.Size(120, 19);
            this.lblCargaHoraria.TabIndex = 227;
            this.lblCargaHoraria.Text = "Carga Horaria";
            // 
            // lblHoraPlanilla
            // 
            this.lblHoraPlanilla.AutoSize = true;
            this.lblHoraPlanilla.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoraPlanilla.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblHoraPlanilla.Location = new System.Drawing.Point(396, 85);
            this.lblHoraPlanilla.Name = "lblHoraPlanilla";
            this.lblHoraPlanilla.Size = new System.Drawing.Size(107, 19);
            this.lblHoraPlanilla.TabIndex = 228;
            this.lblHoraPlanilla.Text = "Hora Planilla";
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEspecialidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblEspecialidad.Location = new System.Drawing.Point(16, 40);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(110, 19);
            this.lblEspecialidad.TabIndex = 222;
            this.lblEspecialidad.Text = "Especialidad";
            // 
            // txtEspecialidad
            // 
            this.txtEspecialidad.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEspecialidad.Location = new System.Drawing.Point(156, 34);
            this.txtEspecialidad.Name = "txtEspecialidad";
            this.txtEspecialidad.Size = new System.Drawing.Size(113, 26);
            this.txtEspecialidad.TabIndex = 225;
            // 
            // lblRda
            // 
            this.lblRda.AutoSize = true;
            this.lblRda.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblRda.Location = new System.Drawing.Point(522, 37);
            this.lblRda.Name = "lblRda";
            this.lblRda.Size = new System.Drawing.Size(40, 19);
            this.lblRda.TabIndex = 220;
            this.lblRda.Text = "Rda";
            // 
            // txtItem
            // 
            this.txtItem.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItem.Location = new System.Drawing.Point(370, 34);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(107, 26);
            this.txtItem.TabIndex = 224;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblItem.Location = new System.Drawing.Point(317, 40);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(43, 19);
            this.lblItem.TabIndex = 221;
            this.lblItem.Text = "Item";
            // 
            // txtRda
            // 
            this.txtRda.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRda.Location = new System.Drawing.Point(571, 33);
            this.txtRda.Name = "txtRda";
            this.txtRda.Size = new System.Drawing.Size(100, 26);
            this.txtRda.TabIndex = 223;
            // 
            // gbxDatosPersonales
            // 
            this.gbxDatosPersonales.Controls.Add(this.dtpFechaNac);
            this.gbxDatosPersonales.Controls.Add(this.label1);
            this.gbxDatosPersonales.Controls.Add(this.txtTelefono);
            this.gbxDatosPersonales.Controls.Add(this.lblTelefono);
            this.gbxDatosPersonales.Controls.Add(this.txtDireccion);
            this.gbxDatosPersonales.Controls.Add(this.cbxGenero);
            this.gbxDatosPersonales.Controls.Add(this.cbxExtension);
            this.gbxDatosPersonales.Controls.Add(this.txtCarnet);
            this.gbxDatosPersonales.Controls.Add(this.txtMaterno);
            this.gbxDatosPersonales.Controls.Add(this.txtApPaterno);
            this.gbxDatosPersonales.Controls.Add(this.txtNombre);
            this.gbxDatosPersonales.Controls.Add(this.txtCodigo);
            this.gbxDatosPersonales.Controls.Add(this.lblDireccion);
            this.gbxDatosPersonales.Controls.Add(this.lblGenero);
            this.gbxDatosPersonales.Controls.Add(this.lblCarnet);
            this.gbxDatosPersonales.Controls.Add(this.lblMaterno);
            this.gbxDatosPersonales.Controls.Add(this.lblApPaterno);
            this.gbxDatosPersonales.Controls.Add(this.lblCodigo);
            this.gbxDatosPersonales.Controls.Add(this.lblNombre);
            this.gbxDatosPersonales.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDatosPersonales.Location = new System.Drawing.Point(14, 79);
            this.gbxDatosPersonales.Name = "gbxDatosPersonales";
            this.gbxDatosPersonales.Size = new System.Drawing.Size(771, 259);
            this.gbxDatosPersonales.TabIndex = 228;
            this.gbxDatosPersonales.TabStop = false;
            this.gbxDatosPersonales.Text = "Datos Personales";
            // 
            // dtpFechaNac
            // 
            this.dtpFechaNac.Location = new System.Drawing.Point(518, 176);
            this.dtpFechaNac.Name = "dtpFechaNac";
            this.dtpFechaNac.Size = new System.Drawing.Size(200, 26);
            this.dtpFechaNac.TabIndex = 223;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(337, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 19);
            this.label1.TabIndex = 222;
            this.label1.Text = "Fecha de Nacimiento";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(156, 174);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(100, 26);
            this.txtTelefono.TabIndex = 221;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblTelefono.Location = new System.Drawing.Point(6, 181);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(74, 19);
            this.lblTelefono.TabIndex = 220;
            this.lblTelefono.Text = "Telefono";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(156, 216);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(390, 26);
            this.txtDireccion.TabIndex = 213;
            // 
            // cbxGenero
            // 
            this.cbxGenero.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxGenero.FormattingEnabled = true;
            this.cbxGenero.Items.AddRange(new object[] {
            "FEMENINO",
            "MASCULINO"});
            this.cbxGenero.Location = new System.Drawing.Point(156, 130);
            this.cbxGenero.Name = "cbxGenero";
            this.cbxGenero.Size = new System.Drawing.Size(121, 28);
            this.cbxGenero.TabIndex = 212;
            // 
            // cbxExtension
            // 
            this.cbxExtension.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxExtension.FormattingEnabled = true;
            this.cbxExtension.Items.AddRange(new object[] {
            "LP",
            "OR",
            "PT",
            "CBBA",
            "CH",
            "TJ",
            "PN",
            "BN",
            "SCZ"});
            this.cbxExtension.Location = new System.Drawing.Point(624, 136);
            this.cbxExtension.Name = "cbxExtension";
            this.cbxExtension.Size = new System.Drawing.Size(57, 28);
            this.cbxExtension.TabIndex = 211;
            // 
            // txtCarnet
            // 
            this.txtCarnet.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCarnet.Location = new System.Drawing.Point(518, 136);
            this.txtCarnet.Name = "txtCarnet";
            this.txtCarnet.Size = new System.Drawing.Size(100, 26);
            this.txtCarnet.TabIndex = 210;
            // 
            // txtMaterno
            // 
            this.txtMaterno.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterno.Location = new System.Drawing.Point(518, 86);
            this.txtMaterno.Name = "txtMaterno";
            this.txtMaterno.Size = new System.Drawing.Size(163, 26);
            this.txtMaterno.TabIndex = 209;
            // 
            // txtApPaterno
            // 
            this.txtApPaterno.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApPaterno.Location = new System.Drawing.Point(156, 86);
            this.txtApPaterno.Name = "txtApPaterno";
            this.txtApPaterno.Size = new System.Drawing.Size(163, 26);
            this.txtApPaterno.TabIndex = 208;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(518, 45);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(236, 26);
            this.txtNombre.TabIndex = 207;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(156, 45);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 26);
            this.txtCodigo.TabIndex = 206;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblDireccion.Location = new System.Drawing.Point(9, 220);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(83, 19);
            this.lblDireccion.TabIndex = 205;
            this.lblDireccion.Text = "Direccion";
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblGenero.Location = new System.Drawing.Point(6, 139);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(67, 19);
            this.lblGenero.TabIndex = 204;
            this.lblGenero.Text = "Genero";
            // 
            // lblCarnet
            // 
            this.lblCarnet.AutoSize = true;
            this.lblCarnet.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarnet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblCarnet.Location = new System.Drawing.Point(337, 136);
            this.lblCarnet.Name = "lblCarnet";
            this.lblCarnet.Size = new System.Drawing.Size(61, 19);
            this.lblCarnet.TabIndex = 203;
            this.lblCarnet.Text = "Carnet";
            // 
            // lblMaterno
            // 
            this.lblMaterno.AutoSize = true;
            this.lblMaterno.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblMaterno.Location = new System.Drawing.Point(337, 93);
            this.lblMaterno.Name = "lblMaterno";
            this.lblMaterno.Size = new System.Drawing.Size(143, 19);
            this.lblMaterno.TabIndex = 202;
            this.lblMaterno.Text = "Apellido Materno";
            // 
            // lblApPaterno
            // 
            this.lblApPaterno.AutoSize = true;
            this.lblApPaterno.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApPaterno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblApPaterno.Location = new System.Drawing.Point(6, 93);
            this.lblApPaterno.Name = "lblApPaterno";
            this.lblApPaterno.Size = new System.Drawing.Size(138, 19);
            this.lblApPaterno.TabIndex = 201;
            this.lblApPaterno.Text = "Apellido Paterno";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblCodigo.Location = new System.Drawing.Point(6, 48);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(67, 19);
            this.lblCodigo.TabIndex = 200;
            this.lblCodigo.Text = "Codigo";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblNombre.Location = new System.Drawing.Point(337, 52);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(91, 19);
            this.lblNombre.TabIndex = 199;
            this.lblNombre.Text = "Nombre(s)";
            // 
            // lblDocente
            // 
            this.lblDocente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDocente.AutoSize = true;
            this.lblDocente.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocente.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblDocente.Location = new System.Drawing.Point(347, 19);
            this.lblDocente.Name = "lblDocente";
            this.lblDocente.Size = new System.Drawing.Size(182, 23);
            this.lblDocente.TabIndex = 227;
            this.lblDocente.Text = "Personal Docente";
            this.lblDocente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmNDocente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(894, 563);
            this.Controls.Add(this.panelContenido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNDocente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNDocente";
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            this.gbxDatosLaborales.ResumeLayout(false);
            this.gbxDatosLaborales.PerformLayout();
            this.gbxDatosPersonales.ResumeLayout(false);
            this.gbxDatosPersonales.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbxDatosLaborales;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.Label lblRda;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.GroupBox gbxDatosPersonales;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.Label lblCarnet;
        private System.Windows.Forms.Label lblMaterno;
        private System.Windows.Forms.Label lblApPaterno;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDocente;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblCargaHoraria;
        private System.Windows.Forms.Label lblHoraPlanilla;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtEspecialidad;
        public System.Windows.Forms.TextBox txtItem;
        public System.Windows.Forms.TextBox txtRda;
        public System.Windows.Forms.TextBox txtTelefono;
        public System.Windows.Forms.TextBox txtDireccion;
        public System.Windows.Forms.ComboBox cbxGenero;
        public System.Windows.Forms.ComboBox cbxExtension;
        public System.Windows.Forms.TextBox txtCarnet;
        public System.Windows.Forms.TextBox txtMaterno;
        public System.Windows.Forms.TextBox txtApPaterno;
        public System.Windows.Forms.TextBox txtNombre;
        public System.Windows.Forms.TextBox txtHrPlanilla;
        public System.Windows.Forms.TextBox txtCargaHoraria;
        public System.Windows.Forms.DateTimePicker dtpFechaNac;
        public System.Windows.Forms.Panel panelContenido;
    }
}