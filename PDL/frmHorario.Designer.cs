namespace CONASIS.PDL
{
    partial class frmHorario
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
            this.dgvHorario = new System.Windows.Forms.DataGridView();
            this.lblHorario = new System.Windows.Forms.Label();
            this.panelContenido.SuspendLayout();
            this.panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorario)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContenido
            // 
            this.panelContenido.Controls.Add(this.panelBotones);
            this.panelContenido.Controls.Add(this.dgvHorario);
            this.panelContenido.Controls.Add(this.lblHorario);
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(0, 0);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(881, 491);
            this.panelContenido.TabIndex = 0;
            // 
            // panelBotones
            // 
            this.panelBotones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(199)))), ((int)(((byte)(193)))));
            this.panelBotones.Controls.Add(this.btnEditar);
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
            this.btnEditar.Location = new System.Drawing.Point(0, 0);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(98, 39);
            this.btnEditar.TabIndex = 0;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // dgvHorario
            // 
            this.dgvHorario.BackgroundColor = System.Drawing.SystemColors.MenuBar;
            this.dgvHorario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHorario.Location = new System.Drawing.Point(14, 84);
            this.dgvHorario.Name = "dgvHorario";
            this.dgvHorario.Size = new System.Drawing.Size(745, 363);
            this.dgvHorario.TabIndex = 159;
            // 
            // lblHorario
            // 
            this.lblHorario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHorario.AutoSize = true;
            this.lblHorario.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHorario.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblHorario.Location = new System.Drawing.Point(309, 32);
            this.lblHorario.Name = "lblHorario";
            this.lblHorario.Size = new System.Drawing.Size(155, 23);
            this.lblHorario.TabIndex = 158;
            this.lblHorario.Text = "Horario Escolar";
            this.lblHorario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmHorario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(881, 491);
            this.Controls.Add(this.panelContenido);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHorario";
            this.Text = "frmHorario";
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.DataGridView dgvHorario;
        private System.Windows.Forms.Label lblHorario;
    }
}