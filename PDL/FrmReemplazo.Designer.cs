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
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.gbxSolicitud = new System.Windows.Forms.GroupBox();
            this.lblFechaSol = new System.Windows.Forms.Label();
            this.datetimeSol = new System.Windows.Forms.DateTimePicker();
            this.lclFechaIni = new System.Windows.Forms.Label();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.datetimeini = new System.Windows.Forms.DateTimePicker();
            this.datetimefin = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.cbxmotivo = new System.Windows.Forms.ComboBox();
            this.panelBotones.SuspendLayout();
            this.gbxSolicitud.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.lblReemplazo.Location = new System.Drawing.Point(375, 9);
            this.lblReemplazo.Name = "lblReemplazo";
            this.lblReemplazo.Size = new System.Drawing.Size(120, 23);
            this.lblReemplazo.TabIndex = 258;
            this.lblReemplazo.Text = "Reemplazo";
            this.lblReemplazo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelBotones
            // 
            this.panelBotones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(199)))), ((int)(((byte)(193)))));
            this.panelBotones.Controls.Add(this.btnEliminar);
            this.panelBotones.Controls.Add(this.btnEditar);
            this.panelBotones.Controls.Add(this.btnAgregar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelBotones.Location = new System.Drawing.Point(785, 0);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(112, 529);
            this.panelBotones.TabIndex = 275;
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
            this.btnEliminar.Size = new System.Drawing.Size(112, 39);
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
            this.btnEditar.Size = new System.Drawing.Size(112, 39);
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
            this.btnAgregar.Size = new System.Drawing.Size(112, 39);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblNombre.Location = new System.Drawing.Point(29, 56);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(86, 18);
            this.lblNombre.TabIndex = 276;
            this.lblNombre.Text = "Nombre(s)";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(132, 54);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(498, 24);
            this.comboBox1.TabIndex = 277;
            // 
            // gbxSolicitud
            // 
            this.gbxSolicitud.Controls.Add(this.cbxmotivo);
            this.gbxSolicitud.Controls.Add(this.lblMotivo);
            this.gbxSolicitud.Controls.Add(this.datetimefin);
            this.gbxSolicitud.Controls.Add(this.datetimeini);
            this.gbxSolicitud.Controls.Add(this.lblFechaFin);
            this.gbxSolicitud.Controls.Add(this.lclFechaIni);
            this.gbxSolicitud.Controls.Add(this.datetimeSol);
            this.gbxSolicitud.Controls.Add(this.lblFechaSol);
            this.gbxSolicitud.Location = new System.Drawing.Point(29, 97);
            this.gbxSolicitud.Name = "gbxSolicitud";
            this.gbxSolicitud.Size = new System.Drawing.Size(731, 153);
            this.gbxSolicitud.TabIndex = 278;
            this.gbxSolicitud.TabStop = false;
            this.gbxSolicitud.Text = "Solicitud";
            // 
            // lblFechaSol
            // 
            this.lblFechaSol.AutoSize = true;
            this.lblFechaSol.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaSol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblFechaSol.Location = new System.Drawing.Point(6, 28);
            this.lblFechaSol.Name = "lblFechaSol";
            this.lblFechaSol.Size = new System.Drawing.Size(145, 18);
            this.lblFechaSol.TabIndex = 259;
            this.lblFechaSol.Text = "Fecha de Solicitud";
            // 
            // datetimeSol
            // 
            this.datetimeSol.Location = new System.Drawing.Point(157, 28);
            this.datetimeSol.Name = "datetimeSol";
            this.datetimeSol.Size = new System.Drawing.Size(162, 21);
            this.datetimeSol.TabIndex = 260;
            // 
            // lclFechaIni
            // 
            this.lclFechaIni.AutoSize = true;
            this.lclFechaIni.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lclFechaIni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lclFechaIni.Location = new System.Drawing.Point(6, 64);
            this.lclFechaIni.Name = "lclFechaIni";
            this.lclFechaIni.Size = new System.Drawing.Size(123, 18);
            this.lclFechaIni.TabIndex = 261;
            this.lclFechaIni.Text = "Fecha de Inicio";
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblFechaFin.Location = new System.Drawing.Point(347, 64);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(92, 18);
            this.lblFechaFin.TabIndex = 262;
            this.lblFechaFin.Text = "Fecha Final";
            // 
            // datetimeini
            // 
            this.datetimeini.Location = new System.Drawing.Point(157, 63);
            this.datetimeini.Name = "datetimeini";
            this.datetimeini.Size = new System.Drawing.Size(162, 21);
            this.datetimeini.TabIndex = 263;
            // 
            // datetimefin
            // 
            this.datetimefin.Location = new System.Drawing.Point(459, 63);
            this.datetimefin.Name = "datetimefin";
            this.datetimefin.Size = new System.Drawing.Size(162, 21);
            this.datetimefin.TabIndex = 264;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(29, 284);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(731, 193);
            this.dataGridView1.TabIndex = 279;
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblMotivo.Location = new System.Drawing.Point(6, 101);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(58, 18);
            this.lblMotivo.TabIndex = 265;
            this.lblMotivo.Text = "Motivo";
            // 
            // cbxmotivo
            // 
            this.cbxmotivo.FormattingEnabled = true;
            this.cbxmotivo.Location = new System.Drawing.Point(157, 95);
            this.cbxmotivo.Name = "cbxmotivo";
            this.cbxmotivo.Size = new System.Drawing.Size(498, 24);
            this.cbxmotivo.TabIndex = 280;
            // 
            // FrmReemplazante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(897, 529);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.gbxSolicitud);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.lblReemplazo);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmReemplazante";
            this.Text = "FrmReemplazante";
            this.panelBotones.ResumeLayout(false);
            this.gbxSolicitud.ResumeLayout(false);
            this.gbxSolicitud.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReemplazo;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox gbxSolicitud;
        private System.Windows.Forms.DateTimePicker datetimefin;
        private System.Windows.Forms.DateTimePicker datetimeini;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lclFechaIni;
        private System.Windows.Forms.DateTimePicker datetimeSol;
        private System.Windows.Forms.Label lblFechaSol;
        private System.Windows.Forms.ComboBox cbxmotivo;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}