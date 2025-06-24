namespace CONASIS.PDL
{
    partial class frmAdministrativo
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
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dvgAdm = new System.Windows.Forms.DataGridView();
            this.lblAdministrativo = new System.Windows.Forms.Label();
            this.panelContenido.SuspendLayout();
            this.panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgAdm)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContenido
            // 
            this.panelContenido.Controls.Add(this.panelBotones);
            this.panelContenido.Controls.Add(this.dvgAdm);
            this.panelContenido.Controls.Add(this.lblAdministrativo);
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(0, 0);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(881, 491);
            this.panelContenido.TabIndex = 0;
            // 
            // panelBotones
            // 
            this.panelBotones.BackColor = System.Drawing.Color.MediumAquamarine;
            this.panelBotones.Controls.Add(this.btnEditar);
            this.panelBotones.Controls.Add(this.btnAgregar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelBotones.Location = new System.Drawing.Point(783, 0);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(98, 491);
            this.panelBotones.TabIndex = 157;
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
            // dvgAdm
            // 
            this.dvgAdm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgAdm.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dvgAdm.BackgroundColor = System.Drawing.SystemColors.MenuBar;
            this.dvgAdm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dvgAdm.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dvgAdm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgAdm.ColumnHeadersVisible = false;
            this.dvgAdm.Location = new System.Drawing.Point(14, 76);
            this.dvgAdm.Name = "dvgAdm";
            this.dvgAdm.ReadOnly = true;
            this.dvgAdm.RowHeadersVisible = false;
            this.dvgAdm.Size = new System.Drawing.Size(745, 387);
            this.dvgAdm.TabIndex = 159;
            //this.dvgAdm.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgAdm_CellContentClick);
            // 
            // lblAdministrativo
            // 
            this.lblAdministrativo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdministrativo.AutoSize = true;
            this.lblAdministrativo.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdministrativo.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblAdministrativo.Location = new System.Drawing.Point(309, 32);
            this.lblAdministrativo.Name = "lblAdministrativo";
            this.lblAdministrativo.Size = new System.Drawing.Size(236, 23);
            this.lblAdministrativo.TabIndex = 158;
            this.lblAdministrativo.Text = "Personal Administrativo";
            this.lblAdministrativo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmAdministrativo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(881, 491);
            this.Controls.Add(this.panelContenido);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAdministrativo";
            this.Text = "frmAdministrativo";
            this.Load += new System.EventHandler(this.frmAdministrativo_Load);
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgAdm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.DataGridView dvgAdm;
        private System.Windows.Forms.Label lblAdministrativo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEditar;
    }
}