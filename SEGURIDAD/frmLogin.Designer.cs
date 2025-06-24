namespace CONASIS.SEGURIDAD
{
    partial class frmLogin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbluser = new System.Windows.Forms.Label();
            this.lblpswd = new System.Windows.Forms.Label();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.txtpswd = new System.Windows.Forms.TextBox();
            this.lbllogin = new System.Windows.Forms.Label();
            this.btnacceder = new System.Windows.Forms.Button();
            this.linkpswd = new System.Windows.Forms.LinkLabel();
            this.btnminimizar = new System.Windows.Forms.PictureBox();
            this.btncerrar = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblMessageError = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnminimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btncerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 330);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // lbluser
            // 
            this.lbluser.AutoSize = true;
            this.lbluser.Enabled = false;
            this.lbluser.ForeColor = System.Drawing.SystemColors.Control;
            this.lbluser.Location = new System.Drawing.Point(343, 96);
            this.lbluser.Name = "lbluser";
            this.lbluser.Size = new System.Drawing.Size(361, 13);
            this.lbluser.TabIndex = 1;
            this.lbluser.Text = "___________________________________________________________";
            // 
            // lblpswd
            // 
            this.lblpswd.AutoSize = true;
            this.lblpswd.Enabled = false;
            this.lblpswd.ForeColor = System.Drawing.SystemColors.Control;
            this.lblpswd.Location = new System.Drawing.Point(343, 173);
            this.lblpswd.Name = "lblpswd";
            this.lblpswd.Size = new System.Drawing.Size(361, 13);
            this.lblpswd.TabIndex = 2;
            this.lblpswd.Text = "___________________________________________________________";
            // 
            // txtuser
            // 
            this.txtuser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtuser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtuser.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuser.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtuser.Location = new System.Drawing.Point(346, 86);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(358, 20);
            this.txtuser.TabIndex = 1;
            this.txtuser.Text = "USUARIO";
            this.txtuser.Enter += new System.EventHandler(this.txtuser_Enter);
            this.txtuser.Leave += new System.EventHandler(this.txtuser_Leave);
            // 
            // txtpswd
            // 
            this.txtpswd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtpswd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtpswd.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpswd.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtpswd.Location = new System.Drawing.Point(346, 163);
            this.txtpswd.Name = "txtpswd";
            this.txtpswd.Size = new System.Drawing.Size(358, 20);
            this.txtpswd.TabIndex = 2;
            this.txtpswd.Text = "CONTRASEÑA";
            this.txtpswd.Enter += new System.EventHandler(this.txtpswd_Enter);
            this.txtpswd.Leave += new System.EventHandler(this.txtpswd_Leave);
            // 
            // lbllogin
            // 
            this.lbllogin.AutoSize = true;
            this.lbllogin.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllogin.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbllogin.Location = new System.Drawing.Point(432, 9);
            this.lbllogin.Name = "lbllogin";
            this.lbllogin.Size = new System.Drawing.Size(185, 24);
            this.lbllogin.TabIndex = 5;
            this.lbllogin.Text = "INICIO DE SESION";
            // 
            // btnacceder
            // 
            this.btnacceder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnacceder.FlatAppearance.BorderSize = 0;
            this.btnacceder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnacceder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnacceder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnacceder.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnacceder.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnacceder.Location = new System.Drawing.Point(346, 239);
            this.btnacceder.Name = "btnacceder";
            this.btnacceder.Size = new System.Drawing.Size(358, 40);
            this.btnacceder.TabIndex = 3;
            this.btnacceder.Text = "ACCEDER";
            this.btnacceder.UseVisualStyleBackColor = false;
            this.btnacceder.Click += new System.EventHandler(this.btnacceder_Click);
            this.btnacceder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnacceder_MouseDown);
            // 
            // linkpswd
            // 
            this.linkpswd.ActiveLinkColor = System.Drawing.Color.MediumAquamarine;
            this.linkpswd.AutoSize = true;
            this.linkpswd.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkpswd.LinkColor = System.Drawing.Color.Gainsboro;
            this.linkpswd.Location = new System.Drawing.Point(409, 291);
            this.linkpswd.Name = "linkpswd";
            this.linkpswd.Size = new System.Drawing.Size(222, 20);
            this.linkpswd.TabIndex = 0;
            this.linkpswd.TabStop = true;
            this.linkpswd.Text = "¿Ha olvidado la contraseña?";
            this.linkpswd.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // btnminimizar
            // 
            this.btnminimizar.Image = global::CONASIS.Properties.Resources.btnminimizar;
            this.btnminimizar.Location = new System.Drawing.Point(753, 0);
            this.btnminimizar.Name = "btnminimizar";
            this.btnminimizar.Size = new System.Drawing.Size(15, 15);
            this.btnminimizar.TabIndex = 9;
            this.btnminimizar.TabStop = false;
            this.btnminimizar.Click += new System.EventHandler(this.btnminimizar_Click);
            // 
            // btncerrar
            // 
            this.btncerrar.Image = global::CONASIS.Properties.Resources.btncerrar;
            this.btncerrar.Location = new System.Drawing.Point(764, 0);
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(15, 15);
            this.btncerrar.TabIndex = 8;
            this.btncerrar.TabStop = false;
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CONASIS.Properties.Resources.SCZ;
            this.pictureBox2.Location = new System.Drawing.Point(-27, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(309, 300);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // lblMessageError
            // 
            this.lblMessageError.AutoSize = true;
            this.lblMessageError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageError.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblMessageError.Location = new System.Drawing.Point(350, 202);
            this.lblMessageError.Name = "lblMessageError";
            this.lblMessageError.Size = new System.Drawing.Size(96, 16);
            this.lblMessageError.TabIndex = 11;
            this.lblMessageError.Text = "Error Message";
            this.lblMessageError.Visible = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(780, 330);
            this.Controls.Add(this.lblMessageError);
            this.Controls.Add(this.btnminimizar);
            this.Controls.Add(this.btncerrar);
            this.Controls.Add(this.linkpswd);
            this.Controls.Add(this.btnacceder);
            this.Controls.Add(this.lbllogin);
            this.Controls.Add(this.txtpswd);
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.lblpswd);
            this.Controls.Add(this.lbluser);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnminimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btncerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbluser;
        private System.Windows.Forms.Label lblpswd;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.TextBox txtpswd;
        private System.Windows.Forms.Label lbllogin;
        private System.Windows.Forms.Button btnacceder;
        private System.Windows.Forms.LinkLabel linkpswd;
        private System.Windows.Forms.PictureBox btncerrar;
        private System.Windows.Forms.PictureBox btnminimizar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblMessageError;
    }
}