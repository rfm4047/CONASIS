namespace CONASIS.PDL
{
    partial class FrmReemplazo
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
            this.lblReemplazo = new System.Windows.Forms.Label();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnmotivo = new System.Windows.Forms.Button();
            this.btnReemplazante = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.cbxReemplazante = new System.Windows.Forms.ComboBox();
            this.gbxSolicitud = new System.Windows.Forms.GroupBox();
            this.cbxMotivo = new System.Windows.Forms.ComboBox();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.datetimefin = new System.Windows.Forms.DateTimePicker();
            this.datetimeini = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.lclFechaIni = new System.Windows.Forms.Label();
            this.datetimeSol = new System.Windows.Forms.DateTimePicker();
            this.lblFechaSol = new System.Windows.Forms.Label();
            this.dgvReemplazos = new System.Windows.Forms.DataGridView();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxSolicita = new System.Windows.Forms.ComboBox();
            this.panelBotones.SuspendLayout();
            this.gbxSolicitud.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReemplazos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReemplazo
            // 
            this.lblReemplazo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReemplazo.AutoSize = true;
            this.lblReemplazo.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReemplazo.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblReemplazo.Location = new System.Drawing.Point(375, 16);
            this.lblReemplazo.Name = "lblReemplazo";
            this.lblReemplazo.Size = new System.Drawing.Size(120, 23);
            this.lblReemplazo.TabIndex = 258;
            this.lblReemplazo.Text = "Reemplazo";
            this.lblReemplazo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelBotones
            // 
            this.panelBotones.BackColor = System.Drawing.Color.MediumAquamarine;
            this.panelBotones.Controls.Add(this.btnmotivo);
            this.panelBotones.Controls.Add(this.btnReemplazante);
            this.panelBotones.Controls.Add(this.btnEliminar);
            this.panelBotones.Controls.Add(this.btnEditar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelBotones.Location = new System.Drawing.Point(785, 0);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(112, 544);
            this.panelBotones.TabIndex = 275;
            // 
            // btnmotivo
            // 
            this.btnmotivo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnmotivo.FlatAppearance.BorderSize = 0;
            this.btnmotivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmotivo.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmotivo.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnmotivo.Location = new System.Drawing.Point(0, 117);
            this.btnmotivo.Name = "btnmotivo";
            this.btnmotivo.Size = new System.Drawing.Size(112, 39);
            this.btnmotivo.TabIndex = 5;
            this.btnmotivo.Text = "MOTIVO";
            this.btnmotivo.UseVisualStyleBackColor = true;
            this.btnmotivo.Click += new System.EventHandler(this.btnmotivo_Click);
            // 
            // btnReemplazante
            // 
            this.btnReemplazante.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReemplazante.FlatAppearance.BorderSize = 0;
            this.btnReemplazante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReemplazante.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReemplazante.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnReemplazante.Location = new System.Drawing.Point(0, 78);
            this.btnReemplazante.Name = "btnReemplazante";
            this.btnReemplazante.Size = new System.Drawing.Size(112, 39);
            this.btnReemplazante.TabIndex = 4;
            this.btnReemplazante.Text = "REEMPLAZANTE";
            this.btnReemplazante.UseVisualStyleBackColor = true;
            this.btnReemplazante.Click += new System.EventHandler(this.btnReemplazante_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnEliminar.Location = new System.Drawing.Point(0, 39);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(112, 39);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnEditar.Location = new System.Drawing.Point(0, 0);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(112, 39);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.Black;
            this.lblNombre.Location = new System.Drawing.Point(29, 101);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(115, 18);
            this.lblNombre.TabIndex = 276;
            this.lblNombre.Text = "Reemplazante";
            // 
            // cbxReemplazante
            // 
            this.cbxReemplazante.FormattingEnabled = true;
            this.cbxReemplazante.Location = new System.Drawing.Point(186, 101);
            this.cbxReemplazante.Name = "cbxReemplazante";
            this.cbxReemplazante.Size = new System.Drawing.Size(498, 24);
            this.cbxReemplazante.TabIndex = 277;
            // 
            // gbxSolicitud
            // 
            this.gbxSolicitud.Controls.Add(this.cbxMotivo);
            this.gbxSolicitud.Controls.Add(this.lblMotivo);
            this.gbxSolicitud.Controls.Add(this.datetimefin);
            this.gbxSolicitud.Controls.Add(this.datetimeini);
            this.gbxSolicitud.Controls.Add(this.lblFechaFin);
            this.gbxSolicitud.Controls.Add(this.lclFechaIni);
            this.gbxSolicitud.Controls.Add(this.datetimeSol);
            this.gbxSolicitud.Controls.Add(this.lblFechaSol);
            this.gbxSolicitud.Location = new System.Drawing.Point(29, 139);
            this.gbxSolicitud.Name = "gbxSolicitud";
            this.gbxSolicitud.Size = new System.Drawing.Size(727, 137);
            this.gbxSolicitud.TabIndex = 278;
            this.gbxSolicitud.TabStop = false;
            this.gbxSolicitud.Text = "Solicitud";
            // 
            // cbxMotivo
            // 
            this.cbxMotivo.FormattingEnabled = true;
            this.cbxMotivo.Location = new System.Drawing.Point(157, 95);
            this.cbxMotivo.Name = "cbxMotivo";
            this.cbxMotivo.Size = new System.Drawing.Size(498, 24);
            this.cbxMotivo.TabIndex = 280;
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotivo.ForeColor = System.Drawing.Color.Black;
            this.lblMotivo.Location = new System.Drawing.Point(6, 101);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(58, 18);
            this.lblMotivo.TabIndex = 265;
            this.lblMotivo.Text = "Motivo";
            // 
            // datetimefin
            // 
            this.datetimefin.Location = new System.Drawing.Point(459, 63);
            this.datetimefin.Name = "datetimefin";
            this.datetimefin.Size = new System.Drawing.Size(162, 21);
            this.datetimefin.TabIndex = 264;
            // 
            // datetimeini
            // 
            this.datetimeini.Location = new System.Drawing.Point(157, 63);
            this.datetimeini.Name = "datetimeini";
            this.datetimeini.Size = new System.Drawing.Size(162, 21);
            this.datetimeini.TabIndex = 263;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFin.ForeColor = System.Drawing.Color.Black;
            this.lblFechaFin.Location = new System.Drawing.Point(347, 64);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(92, 18);
            this.lblFechaFin.TabIndex = 262;
            this.lblFechaFin.Text = "Fecha Final";
            // 
            // lclFechaIni
            // 
            this.lclFechaIni.AutoSize = true;
            this.lclFechaIni.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lclFechaIni.ForeColor = System.Drawing.Color.Black;
            this.lclFechaIni.Location = new System.Drawing.Point(6, 64);
            this.lclFechaIni.Name = "lclFechaIni";
            this.lclFechaIni.Size = new System.Drawing.Size(123, 18);
            this.lclFechaIni.TabIndex = 261;
            this.lclFechaIni.Text = "Fecha de Inicio";
            // 
            // datetimeSol
            // 
            this.datetimeSol.Location = new System.Drawing.Point(157, 28);
            this.datetimeSol.Name = "datetimeSol";
            this.datetimeSol.Size = new System.Drawing.Size(162, 21);
            this.datetimeSol.TabIndex = 260;
            // 
            // lblFechaSol
            // 
            this.lblFechaSol.AutoSize = true;
            this.lblFechaSol.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaSol.ForeColor = System.Drawing.Color.Black;
            this.lblFechaSol.Location = new System.Drawing.Point(6, 28);
            this.lblFechaSol.Name = "lblFechaSol";
            this.lblFechaSol.Size = new System.Drawing.Size(145, 18);
            this.lblFechaSol.TabIndex = 259;
            this.lblFechaSol.Text = "Fecha de Solicitud";
            // 
            // dgvReemplazos
            // 
            this.dgvReemplazos.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dgvReemplazos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReemplazos.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvReemplazos.Location = new System.Drawing.Point(29, 282);
            this.dgvReemplazos.Name = "dgvReemplazos";
            this.dgvReemplazos.Size = new System.Drawing.Size(727, 185);
            this.dgvReemplazos.TabIndex = 279;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(164, 490);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(120, 33);
            this.btnAceptar.TabIndex = 280;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(447, 490);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 33);
            this.btnCancelar.TabIndex = 281;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(29, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 282;
            this.label1.Text = "Solicita";
            // 
            // cbxSolicita
            // 
            this.cbxSolicita.FormattingEnabled = true;
            this.cbxSolicita.Location = new System.Drawing.Point(186, 63);
            this.cbxSolicita.Name = "cbxSolicita";
            this.cbxSolicita.Size = new System.Drawing.Size(498, 24);
            this.cbxSolicita.TabIndex = 283;
            // 
            // FrmReemplazo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(897, 544);
            this.Controls.Add(this.cbxSolicita);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dgvReemplazos);
            this.Controls.Add(this.gbxSolicitud);
            this.Controls.Add(this.cbxReemplazante);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.lblReemplazo);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmReemplazo";
            this.Text = "FrmReemplazante";
            this.Load += new System.EventHandler(this.FrmReemplazo_Load);
            this.panelBotones.ResumeLayout(false);
            this.gbxSolicitud.ResumeLayout(false);
            this.gbxSolicitud.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReemplazos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReemplazo;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.ComboBox cbxReemplazante;
        private System.Windows.Forms.GroupBox gbxSolicitud;
        private System.Windows.Forms.DateTimePicker datetimefin;
        private System.Windows.Forms.DateTimePicker datetimeini;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lclFechaIni;
        private System.Windows.Forms.DateTimePicker datetimeSol;
        private System.Windows.Forms.Label lblFechaSol;
        private System.Windows.Forms.ComboBox cbxMotivo;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.DataGridView dgvReemplazos;
        private System.Windows.Forms.Button btnReemplazante;
        private System.Windows.Forms.Button btnmotivo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxSolicita;
    }
}