namespace CONASIS.PDL
{
    partial class frmNHorario
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
            this.lblHorario = new System.Windows.Forms.Label();
            this.panelBasico.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBasico
            // 
            this.panelBasico.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelBasico.Controls.Add(this.lblHorario);
            this.panelBasico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBasico.Location = new System.Drawing.Point(0, 0);
            this.panelBasico.Name = "panelBasico";
            this.panelBasico.Size = new System.Drawing.Size(894, 563);
            this.panelBasico.TabIndex = 0;
            // 
            // lblHorario
            // 
            this.lblHorario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHorario.AutoSize = true;
            this.lblHorario.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHorario.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblHorario.Location = new System.Drawing.Point(355, 19);
            this.lblHorario.Name = "lblHorario";
            this.lblHorario.Size = new System.Drawing.Size(155, 23);
            this.lblHorario.TabIndex = 159;
            this.lblHorario.Text = "Horario Escolar";
            this.lblHorario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmNHorario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 563);
            this.Controls.Add(this.panelBasico);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNHorario";
            this.Text = "frmNHorario";
            this.panelBasico.ResumeLayout(false);
            this.panelBasico.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBasico;
        private System.Windows.Forms.Label lblHorario;
    }
}