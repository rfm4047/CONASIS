
namespace CONASIS.PDL
{
    partial class FrmNUsuarios
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.gbxInfo = new System.Windows.Forms.GroupBox();
            this.gboxPermisos = new System.Windows.Forms.GroupBox();
            this.rbtnEliminar = new System.Windows.Forms.RadioButton();
            this.rbtnModificar = new System.Windows.Forms.RadioButton();
            this.rbtnCrear = new System.Windows.Forms.RadioButton();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblConfirmarC = new System.Windows.Forms.Label();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblAccesos = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnDocente = new System.Windows.Forms.RadioButton();
            this.rbtnAdm = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.rbtnConsultar = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tpageBiometrico = new System.Windows.Forms.TabPage();
            this.pboxhuella = new System.Windows.Forms.PictureBox();
            this.panelContenido.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbxInfo.SuspendLayout();
            this.gboxPermisos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tpageBiometrico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxhuella)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContenido
            // 
            this.panelContenido.Controls.Add(this.tabControl1);
            this.panelContenido.Controls.Add(this.lblUsuario);
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(0, 0);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(892, 563);
            this.panelContenido.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tpageBiometrico);
            this.tabControl1.Location = new System.Drawing.Point(23, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(753, 500);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.checkBox6);
            this.tabPage1.Controls.Add(this.checkBox5);
            this.tabPage1.Controls.Add(this.checkBox4);
            this.tabPage1.Controls.Add(this.checkBox3);
            this.tabPage1.Controls.Add(this.checkBox2);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.lblAccesos);
            this.tabPage1.Controls.Add(this.textBox4);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.treeView1);
            this.tabPage1.Controls.Add(this.gbxInfo);
            this.tabPage1.Controls.Add(this.gboxPermisos);
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.lblConfirmarC);
            this.tabPage1.Controls.Add(this.lblContraseña);
            this.tabPage1.Controls.Add(this.lblNombre);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(745, 467);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Creación de usuario, asignación de roles y configuración de accesos";
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(21, 86);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(220, 26);
            this.textBox4.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Nombre Plantel";
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.treeView1.CheckBoxes = true;
            this.treeView1.FullRowSelect = true;
            this.treeView1.Location = new System.Drawing.Point(455, 58);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(266, 246);
            this.treeView1.TabIndex = 22;
            // 
            // gbxInfo
            // 
            this.gbxInfo.BackColor = System.Drawing.Color.White;
            this.gbxInfo.Controls.Add(this.label2);
            this.gbxInfo.Location = new System.Drawing.Point(455, 312);
            this.gbxInfo.Name = "gbxInfo";
            this.gbxInfo.Size = new System.Drawing.Size(266, 98);
            this.gbxInfo.TabIndex = 21;
            this.gbxInfo.TabStop = false;
            this.gbxInfo.Text = "Información";
            // 
            // gboxPermisos
            // 
            this.gboxPermisos.BackColor = System.Drawing.Color.White;
            this.gboxPermisos.Controls.Add(this.rbtnConsultar);
            this.gboxPermisos.Controls.Add(this.rbtnEliminar);
            this.gboxPermisos.Controls.Add(this.rbtnModificar);
            this.gboxPermisos.Controls.Add(this.rbtnCrear);
            this.gboxPermisos.Location = new System.Drawing.Point(266, 166);
            this.gboxPermisos.Name = "gboxPermisos";
            this.gboxPermisos.Size = new System.Drawing.Size(165, 151);
            this.gboxPermisos.TabIndex = 20;
            this.gboxPermisos.TabStop = false;
            this.gboxPermisos.Text = "Permisos";
            // 
            // rbtnEliminar
            // 
            this.rbtnEliminar.AutoSize = true;
            this.rbtnEliminar.Location = new System.Drawing.Point(19, 84);
            this.rbtnEliminar.Name = "rbtnEliminar";
            this.rbtnEliminar.Size = new System.Drawing.Size(81, 24);
            this.rbtnEliminar.TabIndex = 2;
            this.rbtnEliminar.TabStop = true;
            this.rbtnEliminar.Text = "Eliminar";
            this.rbtnEliminar.UseVisualStyleBackColor = true;
            // 
            // rbtnModificar
            // 
            this.rbtnModificar.AutoSize = true;
            this.rbtnModificar.Location = new System.Drawing.Point(19, 54);
            this.rbtnModificar.Name = "rbtnModificar";
            this.rbtnModificar.Size = new System.Drawing.Size(98, 24);
            this.rbtnModificar.TabIndex = 1;
            this.rbtnModificar.TabStop = true;
            this.rbtnModificar.Text = "Modificar";
            this.rbtnModificar.UseVisualStyleBackColor = true;
            // 
            // rbtnCrear
            // 
            this.rbtnCrear.AutoSize = true;
            this.rbtnCrear.Location = new System.Drawing.Point(19, 26);
            this.rbtnCrear.Name = "rbtnCrear";
            this.rbtnCrear.Size = new System.Drawing.Size(88, 24);
            this.rbtnCrear.TabIndex = 0;
            this.rbtnCrear.TabStop = true;
            this.rbtnCrear.Text = "Agregar";
            this.rbtnCrear.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(21, 278);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(219, 26);
            this.textBox3.TabIndex = 17;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(21, 213);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(219, 26);
            this.textBox2.TabIndex = 16;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(22, 148);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(219, 26);
            this.textBox1.TabIndex = 15;
            // 
            // lblConfirmarC
            // 
            this.lblConfirmarC.AutoSize = true;
            this.lblConfirmarC.Location = new System.Drawing.Point(18, 251);
            this.lblConfirmarC.Name = "lblConfirmarC";
            this.lblConfirmarC.Size = new System.Drawing.Size(171, 20);
            this.lblConfirmarC.TabIndex = 14;
            this.lblConfirmarC.Text = "Confirmar Contraseña";
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Location = new System.Drawing.Point(18, 186);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(95, 20);
            this.lblContraseña.TabIndex = 13;
            this.lblContraseña.Text = "Contraseña";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(17, 120);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(63, 20);
            this.lblNombre.TabIndex = 12;
            this.lblNombre.Text = "Usuario";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(383, 18);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(96, 25);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuarios";
            // 
            // lblAccesos
            // 
            this.lblAccesos.AutoSize = true;
            this.lblAccesos.Location = new System.Drawing.Point(451, 26);
            this.lblAccesos.Name = "lblAccesos";
            this.lblAccesos.Size = new System.Drawing.Size(72, 20);
            this.lblAccesos.TabIndex = 25;
            this.lblAccesos.Text = "Accesos";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.rbtnDocente);
            this.groupBox1.Controls.Add(this.rbtnAdm);
            this.groupBox1.Location = new System.Drawing.Point(266, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 89);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Roles";
            // 
            // rbtnDocente
            // 
            this.rbtnDocente.AutoSize = true;
            this.rbtnDocente.Location = new System.Drawing.Point(22, 56);
            this.rbtnDocente.Name = "rbtnDocente";
            this.rbtnDocente.Size = new System.Drawing.Size(92, 24);
            this.rbtnDocente.TabIndex = 1;
            this.rbtnDocente.TabStop = true;
            this.rbtnDocente.Text = "Docente";
            this.rbtnDocente.UseVisualStyleBackColor = true;
            // 
            // rbtnAdm
            // 
            this.rbtnAdm.AutoSize = true;
            this.rbtnAdm.Location = new System.Drawing.Point(22, 26);
            this.rbtnAdm.Name = "rbtnAdm";
            this.rbtnAdm.Size = new System.Drawing.Size(130, 24);
            this.rbtnAdm.TabIndex = 0;
            this.rbtnAdm.TabStop = true;
            this.rbtnAdm.Text = "Administrativo";
            this.rbtnAdm.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "info de que hace cada modulo";
            // 
            // rbtnConsultar
            // 
            this.rbtnConsultar.AutoSize = true;
            this.rbtnConsultar.Location = new System.Drawing.Point(19, 114);
            this.rbtnConsultar.Name = "rbtnConsultar";
            this.rbtnConsultar.Size = new System.Drawing.Size(96, 24);
            this.rbtnConsultar.TabIndex = 3;
            this.rbtnConsultar.TabStop = true;
            this.rbtnConsultar.Text = "Consultar";
            this.rbtnConsultar.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(474, 71);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(163, 24);
            this.checkBox1.TabIndex = 31;
            this.checkBox1.Text = "Módulo Institución";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.Color.White;
            this.checkBox2.Location = new System.Drawing.Point(474, 110);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(207, 24);
            this.checkBox2.TabIndex = 32;
            this.checkBox2.Text = "Módulo Plantel Docente";
            this.checkBox2.UseVisualStyleBackColor = false;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.BackColor = System.Drawing.Color.White;
            this.checkBox3.Location = new System.Drawing.Point(474, 151);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(176, 24);
            this.checkBox3.TabIndex = 33;
            this.checkBox3.Text = "Módulo Plantel Adm";
            this.checkBox3.UseVisualStyleBackColor = false;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.BackColor = System.Drawing.Color.White;
            this.checkBox4.Location = new System.Drawing.Point(474, 191);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(176, 24);
            this.checkBox4.TabIndex = 34;
            this.checkBox4.Text = "Módulo Plantel Adm";
            this.checkBox4.UseVisualStyleBackColor = false;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.BackColor = System.Drawing.Color.White;
            this.checkBox5.Location = new System.Drawing.Point(474, 229);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(142, 24);
            this.checkBox5.TabIndex = 35;
            this.checkBox5.Text = "Módulo Horario";
            this.checkBox5.UseVisualStyleBackColor = false;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.BackColor = System.Drawing.Color.White;
            this.checkBox6.Location = new System.Drawing.Point(474, 267);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(185, 24);
            this.checkBox6.TabIndex = 36;
            this.checkBox6.Text = "Módulo Junta Escolar";
            this.checkBox6.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(80, 378);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 32);
            this.button1.TabIndex = 37;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(301, 378);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 32);
            this.button2.TabIndex = 38;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tpageBiometrico
            // 
            this.tpageBiometrico.BackColor = System.Drawing.SystemColors.Control;
            this.tpageBiometrico.Controls.Add(this.pboxhuella);
            this.tpageBiometrico.Location = new System.Drawing.Point(4, 29);
            this.tpageBiometrico.Name = "tpageBiometrico";
            this.tpageBiometrico.Size = new System.Drawing.Size(745, 467);
            this.tpageBiometrico.TabIndex = 1;
            this.tpageBiometrico.Text = "Biométrico";
            // 
            // pboxhuella
            // 
            this.pboxhuella.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pboxhuella.Image = global::CONASIS.Properties.Resources.Captura3;
            this.pboxhuella.Location = new System.Drawing.Point(3, 2);
            this.pboxhuella.Name = "pboxhuella";
            this.pboxhuella.Size = new System.Drawing.Size(491, 465);
            this.pboxhuella.TabIndex = 0;
            this.pboxhuella.TabStop = false;
            // 
            // FrmNUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(892, 563);
            this.Controls.Add(this.panelContenido);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmNUsuarios";
            this.Text = "Usuarios";
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.gbxInfo.ResumeLayout(false);
            this.gbxInfo.PerformLayout();
            this.gboxPermisos.ResumeLayout(false);
            this.gboxPermisos.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tpageBiometrico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxhuella)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox gbxInfo;
        private System.Windows.Forms.GroupBox gboxPermisos;
        private System.Windows.Forms.RadioButton rbtnEliminar;
        private System.Windows.Forms.RadioButton rbtnModificar;
        private System.Windows.Forms.RadioButton rbtnCrear;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblConfirmarC;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnDocente;
        private System.Windows.Forms.RadioButton rbtnAdm;
        private System.Windows.Forms.Label lblAccesos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbtnConsultar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.TabPage tpageBiometrico;
        private System.Windows.Forms.PictureBox pboxhuella;
    }
}