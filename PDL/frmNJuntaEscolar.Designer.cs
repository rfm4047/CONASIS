namespace CONASIS.PDL
{
    partial class frmNJuntaEscolar
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
            this.panelBasico = new System.Windows.Forms.Panel();
            this.txtcodrepje = new System.Windows.Forms.TextBox();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dvgJuntaEscolar = new System.Windows.Forms.DataGridView();
            this.cbxCargo = new System.Windows.Forms.ComboBox();
            this.lblCargo = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.cbxExtension = new System.Windows.Forms.ComboBox();
            this.txtCarnet = new System.Windows.Forms.TextBox();
            this.txtApMaterno = new System.Windows.Forms.TextBox();
            this.txtApPaterno = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblCarnet = new System.Windows.Forms.Label();
            this.lblMaterno = new System.Windows.Forms.Label();
            this.lblApPaterno = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblJuntaEscolar = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.panelBasico.SuspendLayout();
            this.panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgJuntaEscolar)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBasico
            // 
            this.panelBasico.Controls.Add(this.txtcodrepje);
            this.panelBasico.Controls.Add(this.panelBotones);
            this.panelBasico.Controls.Add(this.dvgJuntaEscolar);
            this.panelBasico.Controls.Add(this.cbxCargo);
            this.panelBasico.Controls.Add(this.lblCargo);
            this.panelBasico.Controls.Add(this.txtTelefono);
            this.panelBasico.Controls.Add(this.lblTelefono);
            this.panelBasico.Controls.Add(this.cbxExtension);
            this.panelBasico.Controls.Add(this.txtCarnet);
            this.panelBasico.Controls.Add(this.txtApMaterno);
            this.panelBasico.Controls.Add(this.txtApPaterno);
            this.panelBasico.Controls.Add(this.txtNombre);
            this.panelBasico.Controls.Add(this.lblCarnet);
            this.panelBasico.Controls.Add(this.lblMaterno);
            this.panelBasico.Controls.Add(this.lblApPaterno);
            this.panelBasico.Controls.Add(this.lblNombre);
            this.panelBasico.Controls.Add(this.lblJuntaEscolar);
            this.panelBasico.Controls.Add(this.btnCancelar);
            this.panelBasico.Controls.Add(this.btnAceptar);
            this.panelBasico.Location = new System.Drawing.Point(1, 0);
            this.panelBasico.Name = "panelBasico";
            this.panelBasico.Size = new System.Drawing.Size(894, 563);
            this.panelBasico.TabIndex = 0;
            this.panelBasico.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBasico_Paint);
            // 
            // txtcodrepje
            // 
            this.txtcodrepje.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcodrepje.Location = new System.Drawing.Point(193, 29);
            this.txtcodrepje.Name = "txtcodrepje";
            this.txtcodrepje.Size = new System.Drawing.Size(100, 23);
            this.txtcodrepje.TabIndex = 275;
            this.txtcodrepje.Visible = false;
            // 
            // panelBotones
            // 
            this.panelBotones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(199)))), ((int)(((byte)(193)))));
            this.panelBotones.Controls.Add(this.btnEliminar);
            this.panelBotones.Controls.Add(this.btnEditar);
            this.panelBotones.Controls.Add(this.btnAgregar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelBotones.Location = new System.Drawing.Point(796, 0);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(98, 563);
            this.panelBotones.TabIndex = 274;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnEliminar.Location = new System.Drawing.Point(0, 78);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(98, 39);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnEditar.Location = new System.Drawing.Point(0, 39);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(98, 39);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnAgregar.Location = new System.Drawing.Point(0, 0);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(98, 39);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dvgJuntaEscolar
            // 
            this.dvgJuntaEscolar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgJuntaEscolar.Location = new System.Drawing.Point(29, 260);
            this.dvgJuntaEscolar.Name = "dvgJuntaEscolar";
            this.dvgJuntaEscolar.Size = new System.Drawing.Size(743, 225);
            this.dvgJuntaEscolar.TabIndex = 273;
            // 
            // cbxCargo
            // 
            this.cbxCargo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCargo.FormattingEnabled = true;
            this.cbxCargo.Items.AddRange(new object[] {
            "Presidente",
            "Vicepresidente",
            "Tesorero(a)"});
            this.cbxCargo.Location = new System.Drawing.Point(609, 181);
            this.cbxCargo.Name = "cbxCargo";
            this.cbxCargo.Size = new System.Drawing.Size(163, 25);
            this.cbxCargo.TabIndex = 272;
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblCargo.Location = new System.Drawing.Point(460, 186);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(55, 18);
            this.lblCargo.TabIndex = 271;
            this.lblCargo.Text = "Cargo";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(193, 181);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(163, 23);
            this.txtTelefono.TabIndex = 268;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblTelefono.Location = new System.Drawing.Point(26, 186);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(71, 18);
            this.lblTelefono.TabIndex = 267;
            this.lblTelefono.Text = "Telefono";
            // 
            // cbxExtension
            // 
            this.cbxExtension.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.cbxExtension.Location = new System.Drawing.Point(715, 119);
            this.cbxExtension.Name = "cbxExtension";
            this.cbxExtension.Size = new System.Drawing.Size(57, 24);
            this.cbxExtension.TabIndex = 266;
            // 
            // txtCarnet
            // 
            this.txtCarnet.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCarnet.Location = new System.Drawing.Point(609, 119);
            this.txtCarnet.Name = "txtCarnet";
            this.txtCarnet.Size = new System.Drawing.Size(100, 23);
            this.txtCarnet.TabIndex = 265;
            // 
            // txtApMaterno
            // 
            this.txtApMaterno.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApMaterno.Location = new System.Drawing.Point(193, 126);
            this.txtApMaterno.Name = "txtApMaterno";
            this.txtApMaterno.Size = new System.Drawing.Size(163, 23);
            this.txtApMaterno.TabIndex = 264;
            // 
            // txtApPaterno
            // 
            this.txtApPaterno.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApPaterno.Location = new System.Drawing.Point(609, 69);
            this.txtApPaterno.Name = "txtApPaterno";
            this.txtApPaterno.Size = new System.Drawing.Size(163, 23);
            this.txtApPaterno.TabIndex = 263;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(193, 75);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(236, 23);
            this.txtNombre.TabIndex = 262;
            // 
            // lblCarnet
            // 
            this.lblCarnet.AutoSize = true;
            this.lblCarnet.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarnet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblCarnet.Location = new System.Drawing.Point(461, 124);
            this.lblCarnet.Name = "lblCarnet";
            this.lblCarnet.Size = new System.Drawing.Size(58, 18);
            this.lblCarnet.TabIndex = 261;
            this.lblCarnet.Text = "Carnet";
            // 
            // lblMaterno
            // 
            this.lblMaterno.AutoSize = true;
            this.lblMaterno.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblMaterno.Location = new System.Drawing.Point(26, 131);
            this.lblMaterno.Name = "lblMaterno";
            this.lblMaterno.Size = new System.Drawing.Size(137, 18);
            this.lblMaterno.TabIndex = 260;
            this.lblMaterno.Text = "Apellido Materno";
            // 
            // lblApPaterno
            // 
            this.lblApPaterno.AutoSize = true;
            this.lblApPaterno.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApPaterno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblApPaterno.Location = new System.Drawing.Point(461, 73);
            this.lblApPaterno.Name = "lblApPaterno";
            this.lblApPaterno.Size = new System.Drawing.Size(131, 18);
            this.lblApPaterno.TabIndex = 259;
            this.lblApPaterno.Text = "Apellido Paterno";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblNombre.Location = new System.Drawing.Point(26, 76);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(86, 18);
            this.lblNombre.TabIndex = 258;
            this.lblNombre.Text = "Nombre(s)";
            // 
            // lblJuntaEscolar
            // 
            this.lblJuntaEscolar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblJuntaEscolar.AutoSize = true;
            this.lblJuntaEscolar.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJuntaEscolar.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblJuntaEscolar.Location = new System.Drawing.Point(377, 26);
            this.lblJuntaEscolar.Name = "lblJuntaEscolar";
            this.lblJuntaEscolar.Size = new System.Drawing.Size(138, 23);
            this.lblJuntaEscolar.TabIndex = 257;
            this.lblJuntaEscolar.Text = "Junta Escolar";
            this.lblJuntaEscolar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(476, 504);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(127, 31);
            this.btnCancelar.TabIndex = 256;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(244, 504);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(127, 31);
            this.btnAceptar.TabIndex = 255;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmNJuntaEscolar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(894, 563);
            this.Controls.Add(this.panelBasico);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNJuntaEscolar";
            this.Text = "frmNJuntaEscolar";
            this.Load += new System.EventHandler(this.frmNJuntaEscolar_Load);
            this.panelBasico.ResumeLayout(false);
            this.panelBasico.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgJuntaEscolar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBasico;
        private System.Windows.Forms.ComboBox cbxCargo;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.ComboBox cbxExtension;
        private System.Windows.Forms.TextBox txtCarnet;
        private System.Windows.Forms.TextBox txtApMaterno;
        private System.Windows.Forms.TextBox txtApPaterno;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblCarnet;
        private System.Windows.Forms.Label lblMaterno;
        private System.Windows.Forms.Label lblApPaterno;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblJuntaEscolar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridView dvgJuntaEscolar;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox txtcodrepje;
    }
}