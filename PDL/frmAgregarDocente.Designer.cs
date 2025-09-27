
namespace CONASIS.PDL
{
    partial class frmCalendarioEsc
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
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblDocente = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lbldiasfestivos = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Gestion = new System.Windows.Forms.TabPage();
            this.Fases = new System.Windows.Forms.TabPage();
            this.Trimestres = new System.Windows.Forms.TabPage();
            this.Actividades = new System.Windows.Forms.TabPage();
            this.Fechas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiasFestivos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelContenido.SuspendLayout();
            this.panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContenido
            // 
            this.panelContenido.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelContenido.Controls.Add(this.tabControl1);
            this.panelContenido.Controls.Add(this.dataGridView1);
            this.panelContenido.Controls.Add(this.lbldiasfestivos);
            this.panelContenido.Controls.Add(this.lblFecha);
            this.panelContenido.Controls.Add(this.monthCalendar1);
            this.panelContenido.Controls.Add(this.panelBotones);
            this.panelContenido.Controls.Add(this.lblDocente);
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(0, 0);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(897, 529);
            this.panelContenido.TabIndex = 0;
            // 
            // panelBotones
            // 
            this.panelBotones.BackColor = System.Drawing.Color.MediumAquamarine;
            this.panelBotones.Controls.Add(this.btnCancelar);
            this.panelBotones.Controls.Add(this.btnAceptar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelBotones.Location = new System.Drawing.Point(799, 0);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(98, 529);
            this.panelBotones.TabIndex = 158;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnCancelar.Location = new System.Drawing.Point(0, 39);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(98, 39);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnAceptar.Location = new System.Drawing.Point(0, 0);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(98, 39);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // lblDocente
            // 
            this.lblDocente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDocente.AutoSize = true;
            this.lblDocente.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocente.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblDocente.Location = new System.Drawing.Point(292, 24);
            this.lblDocente.Name = "lblDocente";
            this.lblDocente.Size = new System.Drawing.Size(194, 23);
            this.lblDocente.TabIndex = 155;
            this.lblDocente.Text = "Calendario Escolar";
            this.lblDocente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(4, 1);
            this.monthCalendar1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthCalendar1.Location = new System.Drawing.Point(9, 92);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.ShowToday = false;
            this.monthCalendar1.TabIndex = 159;
            this.monthCalendar1.TrailingForeColor = System.Drawing.Color.PeachPuff;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFecha.Location = new System.Drawing.Point(27, 75);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(54, 18);
            this.lblFecha.TabIndex = 285;
            this.lblFecha.Text = "Fecha";
            // 
            // lbldiasfestivos
            // 
            this.lbldiasfestivos.AutoSize = true;
            this.lbldiasfestivos.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldiasfestivos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbldiasfestivos.Location = new System.Drawing.Point(27, 257);
            this.lbldiasfestivos.Name = "lbldiasfestivos";
            this.lbldiasfestivos.Size = new System.Drawing.Size(158, 18);
            this.lbldiasfestivos.TabIndex = 286;
            this.lbldiasfestivos.Text = "Feriados Nacionales";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fechas,
            this.DiasFestivos});
            this.dataGridView1.Location = new System.Drawing.Point(30, 295);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(288, 213);
            this.dataGridView1.TabIndex = 287;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Gestion);
            this.tabControl1.Controls.Add(this.Fases);
            this.tabControl1.Controls.Add(this.Trimestres);
            this.tabControl1.Controls.Add(this.Actividades);
            this.tabControl1.Location = new System.Drawing.Point(338, 257);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(437, 251);
            this.tabControl1.TabIndex = 288;
            // 
            // Gestion
            // 
            this.Gestion.Location = new System.Drawing.Point(4, 22);
            this.Gestion.Name = "Gestion";
            this.Gestion.Padding = new System.Windows.Forms.Padding(3);
            this.Gestion.Size = new System.Drawing.Size(429, 225);
            this.Gestion.TabIndex = 0;
            this.Gestion.Text = "Gestion";
            this.Gestion.UseVisualStyleBackColor = true;
            // 
            // Fases
            // 
            this.Fases.Location = new System.Drawing.Point(4, 22);
            this.Fases.Name = "Fases";
            this.Fases.Padding = new System.Windows.Forms.Padding(3);
            this.Fases.Size = new System.Drawing.Size(429, 225);
            this.Fases.TabIndex = 1;
            this.Fases.Text = "Fases";
            this.Fases.UseVisualStyleBackColor = true;
            // 
            // Trimestres
            // 
            this.Trimestres.Location = new System.Drawing.Point(4, 22);
            this.Trimestres.Name = "Trimestres";
            this.Trimestres.Size = new System.Drawing.Size(429, 225);
            this.Trimestres.TabIndex = 2;
            this.Trimestres.Text = "Trimestres";
            this.Trimestres.UseVisualStyleBackColor = true;
            // 
            // Actividades
            // 
            this.Actividades.Location = new System.Drawing.Point(4, 22);
            this.Actividades.Name = "Actividades";
            this.Actividades.Size = new System.Drawing.Size(429, 225);
            this.Actividades.TabIndex = 3;
            this.Actividades.Text = "Actividades";
            this.Actividades.UseVisualStyleBackColor = true;
            // 
            // Fechas
            // 
            this.Fechas.HeaderText = "Fechas";
            this.Fechas.Name = "Fechas";
            // 
            // DiasFestivos
            // 
            this.DiasFestivos.HeaderText = "Dias Festivos";
            this.DiasFestivos.Name = "DiasFestivos";
            // 
            // frmCalendarioEsc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(897, 529);
            this.Controls.Add(this.panelContenido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCalendarioEsc";
            this.Text = "FrmCalendarioEsc";
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Label lblDocente;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbldiasfestivos;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Gestion;
        private System.Windows.Forms.TabPage Fases;
        private System.Windows.Forms.TabPage Trimestres;
        private System.Windows.Forms.TabPage Actividades;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fechas;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiasFestivos;
    }
}