namespace CONASIS.PDL
{
    partial class frmDocente
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
            this.dgvDocente = new System.Windows.Forms.DataGridView();
            this.lblDocente = new System.Windows.Forms.Label();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btneliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocente)).BeginInit();
            this.panelBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContenido
            // 
            this.panelContenido.Controls.Add(this.dgvDocente);
            this.panelContenido.Controls.Add(this.lblDocente);
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(0, 0);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(897, 529);
            this.panelContenido.TabIndex = 0;
            // 
            // dgvDocente
            // 
            this.dgvDocente.AllowUserToAddRows = false;
            this.dgvDocente.AllowUserToDeleteRows = false;
            this.dgvDocente.AllowUserToOrderColumns = true;
            this.dgvDocente.AllowUserToResizeColumns = false;
            this.dgvDocente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDocente.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDocente.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dgvDocente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDocente.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDocente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocente.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvDocente.Location = new System.Drawing.Point(28, 136);
            this.dgvDocente.Name = "dgvDocente";
            this.dgvDocente.ReadOnly = true;
            this.dgvDocente.Size = new System.Drawing.Size(745, 345);
            this.dgvDocente.TabIndex = 38;
            this.dgvDocente.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDocente_RowPostPaint);
            // 
            // lblDocente
            // 
            this.lblDocente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDocente.AutoSize = true;
            this.lblDocente.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocente.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblDocente.Location = new System.Drawing.Point(323, 32);
            this.lblDocente.Name = "lblDocente";
            this.lblDocente.Size = new System.Drawing.Size(182, 23);
            this.lblDocente.TabIndex = 155;
            this.lblDocente.Text = "Personal Docente";
            this.lblDocente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelBotones
            // 
            this.panelBotones.BackColor = System.Drawing.Color.MediumAquamarine;
            this.panelBotones.Controls.Add(this.btneliminar);
            this.panelBotones.Controls.Add(this.btnEditar);
            this.panelBotones.Controls.Add(this.btnAgregar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelBotones.Location = new System.Drawing.Point(799, 0);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(98, 529);
            this.panelBotones.TabIndex = 155;
            // 
            // btneliminar
            // 
            this.btneliminar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btneliminar.FlatAppearance.BorderSize = 0;
            this.btneliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btneliminar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btneliminar.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btneliminar.Location = new System.Drawing.Point(0, 78);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(98, 39);
            this.btneliminar.TabIndex = 3;
            this.btneliminar.Text = "Eliminar";
            this.btneliminar.UseVisualStyleBackColor = true;
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
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
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
            // frmDocente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(897, 529);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelContenido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDocente";
            this.Text = "frmDocente";
            this.Load += new System.EventHandler(this.frmDocente_Load);
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocente)).EndInit();
            this.panelBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Label lblDocente;
        private System.Windows.Forms.DataGridView dgvDocente;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btneliminar;
    }
}