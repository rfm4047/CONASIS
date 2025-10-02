
namespace CONASIS.PDL
{
    partial class frmPeriodos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtPeriodo_FechaFin = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dtPeriodo_FechaInicio = new System.Windows.Forms.DateTimePicker();
            this.txtNombrePeriodo = new System.Windows.Forms.TextBox();
            this.txttipoperiodo = new System.Windows.Forms.TextBox();
            this.txtcodperiodo = new System.Windows.Forms.TextBox();
            this.lblNombrePeriodo = new System.Windows.Forms.Label();
            this.lbtipoperiodo = new System.Windows.Forms.Label();
            this.lblCodigoPeriodo = new System.Windows.Forms.Label();
            this.lblPeriodos = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.dgvPeriodos = new System.Windows.Forms.DataGridView();
            this.panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtPeriodo_FechaFin
            // 
            this.dtPeriodo_FechaFin.Location = new System.Drawing.Point(373, 133);
            this.dtPeriodo_FechaFin.Name = "dtPeriodo_FechaFin";
            this.dtPeriodo_FechaFin.Size = new System.Drawing.Size(156, 20);
            this.dtPeriodo_FechaFin.TabIndex = 21;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFin.Location = new System.Drawing.Point(290, 137);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(68, 17);
            this.lblFechaFin.TabIndex = 20;
            this.lblFechaFin.Text = "Fecha Fin";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicio.Location = new System.Drawing.Point(22, 137);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(85, 17);
            this.lblFechaInicio.TabIndex = 19;
            this.lblFechaInicio.Text = "Fecha Inicio";
            // 
            // dtPeriodo_FechaInicio
            // 
            this.dtPeriodo_FechaInicio.Location = new System.Drawing.Point(113, 133);
            this.dtPeriodo_FechaInicio.Name = "dtPeriodo_FechaInicio";
            this.dtPeriodo_FechaInicio.Size = new System.Drawing.Size(155, 20);
            this.dtPeriodo_FechaInicio.TabIndex = 18;
            // 
            // txtNombrePeriodo
            // 
            this.txtNombrePeriodo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombrePeriodo.Location = new System.Drawing.Point(373, 96);
            this.txtNombrePeriodo.Name = "txtNombrePeriodo";
            this.txtNombrePeriodo.Size = new System.Drawing.Size(156, 20);
            this.txtNombrePeriodo.TabIndex = 17;
            // 
            // txttipoperiodo
            // 
            this.txttipoperiodo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txttipoperiodo.Location = new System.Drawing.Point(113, 96);
            this.txttipoperiodo.Name = "txttipoperiodo";
            this.txttipoperiodo.Size = new System.Drawing.Size(155, 20);
            this.txttipoperiodo.TabIndex = 15;
            // 
            // txtcodperiodo
            // 
            this.txtcodperiodo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcodperiodo.Enabled = false;
            this.txtcodperiodo.Location = new System.Drawing.Point(113, 60);
            this.txtcodperiodo.Name = "txtcodperiodo";
            this.txtcodperiodo.Size = new System.Drawing.Size(93, 20);
            this.txtcodperiodo.TabIndex = 13;
            // 
            // lblNombrePeriodo
            // 
            this.lblNombrePeriodo.AutoSize = true;
            this.lblNombrePeriodo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombrePeriodo.Location = new System.Drawing.Point(290, 97);
            this.lblNombrePeriodo.Name = "lblNombrePeriodo";
            this.lblNombrePeriodo.Size = new System.Drawing.Size(61, 17);
            this.lblNombrePeriodo.TabIndex = 16;
            this.lblNombrePeriodo.Text = "Nombre";
            // 
            // lbtipoperiodo
            // 
            this.lbtipoperiodo.AutoSize = true;
            this.lbtipoperiodo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtipoperiodo.Location = new System.Drawing.Point(22, 96);
            this.lbtipoperiodo.Name = "lbtipoperiodo";
            this.lbtipoperiodo.Size = new System.Drawing.Size(34, 17);
            this.lbtipoperiodo.TabIndex = 14;
            this.lbtipoperiodo.Text = "Tipo";
            // 
            // lblCodigoPeriodo
            // 
            this.lblCodigoPeriodo.AutoSize = true;
            this.lblCodigoPeriodo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoPeriodo.Location = new System.Drawing.Point(22, 60);
            this.lblCodigoPeriodo.Name = "lblCodigoPeriodo";
            this.lblCodigoPeriodo.Size = new System.Drawing.Size(58, 17);
            this.lblCodigoPeriodo.TabIndex = 12;
            this.lblCodigoPeriodo.Text = "Código";
            // 
            // lblPeriodos
            // 
            this.lblPeriodos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPeriodos.AutoSize = true;
            this.lblPeriodos.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodos.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblPeriodos.Location = new System.Drawing.Point(255, 22);
            this.lblPeriodos.Name = "lblPeriodos";
            this.lblPeriodos.Size = new System.Drawing.Size(93, 23);
            this.lblPeriodos.TabIndex = 301;
            this.lblPeriodos.Text = "Periodos";
            this.lblPeriodos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(341, 324);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 29);
            this.btnCancelar.TabIndex = 312;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(131, 324);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(107, 29);
            this.btnAceptar.TabIndex = 311;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
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
            this.btnEliminar.Size = new System.Drawing.Size(98, 39);
            this.btnEliminar.TabIndex = 4;
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
            this.btnEditar.Size = new System.Drawing.Size(98, 39);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // panelBotones
            // 
            this.panelBotones.BackColor = System.Drawing.Color.MediumAquamarine;
            this.panelBotones.Controls.Add(this.btnEliminar);
            this.panelBotones.Controls.Add(this.btnEditar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelBotones.Location = new System.Drawing.Point(592, 0);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(98, 387);
            this.panelBotones.TabIndex = 313;
            // 
            // dgvPeriodos
            // 
            this.dgvPeriodos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPeriodos.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPeriodos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPeriodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeriodos.Location = new System.Drawing.Point(52, 182);
            this.dgvPeriodos.Name = "dgvPeriodos";
            this.dgvPeriodos.Size = new System.Drawing.Size(477, 116);
            this.dgvPeriodos.TabIndex = 314;
            // 
            // frmPeriodos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(690, 387);
            this.Controls.Add(this.dgvPeriodos);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblPeriodos);
            this.Controls.Add(this.dtPeriodo_FechaFin);
            this.Controls.Add(this.lblFechaFin);
            this.Controls.Add(this.lblFechaInicio);
            this.Controls.Add(this.dtPeriodo_FechaInicio);
            this.Controls.Add(this.txtNombrePeriodo);
            this.Controls.Add(this.txttipoperiodo);
            this.Controls.Add(this.txtcodperiodo);
            this.Controls.Add(this.lblNombrePeriodo);
            this.Controls.Add(this.lbtipoperiodo);
            this.Controls.Add(this.lblCodigoPeriodo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmPeriodos";
            this.ShowInTaskbar = false;
            this.Text = "frmPeriodos";
            this.Load += new System.EventHandler(this.frmPeriodos_Load);
            this.panelBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtPeriodo_FechaFin;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker dtPeriodo_FechaInicio;
        private System.Windows.Forms.TextBox txtNombrePeriodo;
        private System.Windows.Forms.TextBox txttipoperiodo;
        private System.Windows.Forms.TextBox txtcodperiodo;
        private System.Windows.Forms.Label lblNombrePeriodo;
        private System.Windows.Forms.Label lbtipoperiodo;
        private System.Windows.Forms.Label lblCodigoPeriodo;
        private System.Windows.Forms.Label lblPeriodos;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.DataGridView dgvPeriodos;
    }
}