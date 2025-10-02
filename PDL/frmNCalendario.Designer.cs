
namespace CONASIS.PDL
{
    partial class frmNCalendario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.tabControlCalendario = new System.Windows.Forms.TabControl();
            this.Gestion = new System.Windows.Forms.TabPage();
            this.btnSiguiente1 = new System.Windows.Forms.Button();
            this.dtGestionFin = new System.Windows.Forms.DateTimePicker();
            this.btnGenerarCalendario = new System.Windows.Forms.Button();
            this.lblFechaFinG = new System.Windows.Forms.Label();
            this.lblFechaInicioG = new System.Windows.Forms.Label();
            this.dtGestionInicio = new System.Windows.Forms.DateTimePicker();
            this.txtGestion = new System.Windows.Forms.TextBox();
            this.txtCodGestion = new System.Windows.Forms.TextBox();
            this.lblCodGestion = new System.Windows.Forms.Label();
            this.lblGestion = new System.Windows.Forms.Label();
            this.Feriados_Vacaciones = new System.Windows.Forms.TabPage();
            this.btnTipoDia = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnsiguiente2 = new System.Windows.Forms.Button();
            this.lbldiasfestivos = new System.Windows.Forms.Label();
            this.dgvtipodia = new System.Windows.Forms.DataGridView();
            this.Trimestres = new System.Windows.Forms.TabPage();
            this.btnPeriodos = new System.Windows.Forms.Button();
            this.lblPeriodos = new System.Windows.Forms.Label();
            this.btnAnterior2 = new System.Windows.Forms.Button();
            this.dgvPeriodos = new System.Windows.Forms.DataGridView();
            this.btnSiguiente3 = new System.Windows.Forms.Button();
            this.Actividades = new System.Windows.Forms.TabPage();
            this.btnActividades = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvActividades = new System.Windows.Forms.DataGridView();
            this.btnCancelarAct = new System.Windows.Forms.Button();
            this.Calendario = new System.Windows.Forms.MonthCalendar();
            this.lblDocente = new System.Windows.Forms.Label();
            this.panelContenido.SuspendLayout();
            this.tabControlCalendario.SuspendLayout();
            this.Gestion.SuspendLayout();
            this.Feriados_Vacaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtipodia)).BeginInit();
            this.Trimestres.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodos)).BeginInit();
            this.Actividades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActividades)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContenido
            // 
            this.panelContenido.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelContenido.Controls.Add(this.tabControlCalendario);
            this.panelContenido.Controls.Add(this.Calendario);
            this.panelContenido.Controls.Add(this.lblDocente);
            this.panelContenido.Location = new System.Drawing.Point(1, 0);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(801, 511);
            this.panelContenido.TabIndex = 0;
            // 
            // tabControlCalendario
            // 
            this.tabControlCalendario.Controls.Add(this.Gestion);
            this.tabControlCalendario.Controls.Add(this.Feriados_Vacaciones);
            this.tabControlCalendario.Controls.Add(this.Trimestres);
            this.tabControlCalendario.Controls.Add(this.Actividades);
            this.tabControlCalendario.Location = new System.Drawing.Point(24, 75);
            this.tabControlCalendario.Name = "tabControlCalendario";
            this.tabControlCalendario.SelectedIndex = 0;
            this.tabControlCalendario.Size = new System.Drawing.Size(751, 258);
            this.tabControlCalendario.TabIndex = 302;
            // 
            // Gestion
            // 
            this.Gestion.Controls.Add(this.btnSiguiente1);
            this.Gestion.Controls.Add(this.dtGestionFin);
            this.Gestion.Controls.Add(this.btnGenerarCalendario);
            this.Gestion.Controls.Add(this.lblFechaFinG);
            this.Gestion.Controls.Add(this.lblFechaInicioG);
            this.Gestion.Controls.Add(this.dtGestionInicio);
            this.Gestion.Controls.Add(this.txtGestion);
            this.Gestion.Controls.Add(this.txtCodGestion);
            this.Gestion.Controls.Add(this.lblCodGestion);
            this.Gestion.Controls.Add(this.lblGestion);
            this.Gestion.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gestion.Location = new System.Drawing.Point(4, 22);
            this.Gestion.Name = "Gestion";
            this.Gestion.Padding = new System.Windows.Forms.Padding(3);
            this.Gestion.Size = new System.Drawing.Size(743, 232);
            this.Gestion.TabIndex = 0;
            this.Gestion.Text = "Gestion";
            this.Gestion.UseVisualStyleBackColor = true;
            // 
            // btnSiguiente1
            // 
            this.btnSiguiente1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiguiente1.Location = new System.Drawing.Point(625, 186);
            this.btnSiguiente1.Name = "btnSiguiente1";
            this.btnSiguiente1.Size = new System.Drawing.Size(84, 28);
            this.btnSiguiente1.TabIndex = 292;
            this.btnSiguiente1.Text = "Siguiente";
            this.btnSiguiente1.UseVisualStyleBackColor = true;
            this.btnSiguiente1.Click += new System.EventHandler(this.btnSiguiente1_Click);
            // 
            // dtGestionFin
            // 
            this.dtGestionFin.Location = new System.Drawing.Point(412, 90);
            this.dtGestionFin.Name = "dtGestionFin";
            this.dtGestionFin.Size = new System.Drawing.Size(157, 21);
            this.dtGestionFin.TabIndex = 15;
            // 
            // btnGenerarCalendario
            // 
            this.btnGenerarCalendario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarCalendario.Location = new System.Drawing.Point(408, 186);
            this.btnGenerarCalendario.Name = "btnGenerarCalendario";
            this.btnGenerarCalendario.Size = new System.Drawing.Size(161, 28);
            this.btnGenerarCalendario.TabIndex = 291;
            this.btnGenerarCalendario.Text = "Generar Calendario";
            this.btnGenerarCalendario.UseVisualStyleBackColor = true;
            this.btnGenerarCalendario.Click += new System.EventHandler(this.btnGenerarCalendario_Click_1);
            // 
            // lblFechaFinG
            // 
            this.lblFechaFinG.AutoSize = true;
            this.lblFechaFinG.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFinG.Location = new System.Drawing.Point(311, 93);
            this.lblFechaFinG.Name = "lblFechaFinG";
            this.lblFechaFinG.Size = new System.Drawing.Size(68, 17);
            this.lblFechaFinG.TabIndex = 14;
            this.lblFechaFinG.Text = "Fecha Fin";
            // 
            // lblFechaInicioG
            // 
            this.lblFechaInicioG.AutoSize = true;
            this.lblFechaInicioG.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicioG.Location = new System.Drawing.Point(16, 89);
            this.lblFechaInicioG.Name = "lblFechaInicioG";
            this.lblFechaInicioG.Size = new System.Drawing.Size(85, 17);
            this.lblFechaInicioG.TabIndex = 13;
            this.lblFechaInicioG.Text = "Fecha Inicio";
            // 
            // dtGestionInicio
            // 
            this.dtGestionInicio.Location = new System.Drawing.Point(129, 90);
            this.dtGestionInicio.Name = "dtGestionInicio";
            this.dtGestionInicio.Size = new System.Drawing.Size(157, 21);
            this.dtGestionInicio.TabIndex = 12;
            // 
            // txtGestion
            // 
            this.txtGestion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGestion.Location = new System.Drawing.Point(129, 51);
            this.txtGestion.Name = "txtGestion";
            this.txtGestion.Size = new System.Drawing.Size(93, 21);
            this.txtGestion.TabIndex = 3;
            // 
            // txtCodGestion
            // 
            this.txtCodGestion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodGestion.Enabled = false;
            this.txtCodGestion.Location = new System.Drawing.Point(128, 19);
            this.txtCodGestion.Name = "txtCodGestion";
            this.txtCodGestion.Size = new System.Drawing.Size(93, 21);
            this.txtCodGestion.TabIndex = 2;
            // 
            // lblCodGestion
            // 
            this.lblCodGestion.AutoSize = true;
            this.lblCodGestion.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodGestion.Location = new System.Drawing.Point(15, 21);
            this.lblCodGestion.Name = "lblCodGestion";
            this.lblCodGestion.Size = new System.Drawing.Size(58, 17);
            this.lblCodGestion.TabIndex = 1;
            this.lblCodGestion.Text = "Código";
            // 
            // lblGestion
            // 
            this.lblGestion.AutoSize = true;
            this.lblGestion.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGestion.Location = new System.Drawing.Point(16, 54);
            this.lblGestion.Name = "lblGestion";
            this.lblGestion.Size = new System.Drawing.Size(57, 17);
            this.lblGestion.TabIndex = 0;
            this.lblGestion.Text = "Gestión";
            // 
            // Feriados_Vacaciones
            // 
            this.Feriados_Vacaciones.Controls.Add(this.btnTipoDia);
            this.Feriados_Vacaciones.Controls.Add(this.btnAnterior);
            this.Feriados_Vacaciones.Controls.Add(this.btnsiguiente2);
            this.Feriados_Vacaciones.Controls.Add(this.lbldiasfestivos);
            this.Feriados_Vacaciones.Controls.Add(this.dgvtipodia);
            this.Feriados_Vacaciones.Location = new System.Drawing.Point(4, 22);
            this.Feriados_Vacaciones.Name = "Feriados_Vacaciones";
            this.Feriados_Vacaciones.Padding = new System.Windows.Forms.Padding(3);
            this.Feriados_Vacaciones.Size = new System.Drawing.Size(743, 232);
            this.Feriados_Vacaciones.TabIndex = 4;
            this.Feriados_Vacaciones.Text = "Feriados /Vacaciones";
            this.Feriados_Vacaciones.UseVisualStyleBackColor = true;
            // 
            // btnTipoDia
            // 
            this.btnTipoDia.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTipoDia.Location = new System.Drawing.Point(23, 189);
            this.btnTipoDia.Name = "btnTipoDia";
            this.btnTipoDia.Size = new System.Drawing.Size(84, 28);
            this.btnTipoDia.TabIndex = 299;
            this.btnTipoDia.Text = "Tipo Día";
            this.btnTipoDia.UseVisualStyleBackColor = true;
            this.btnTipoDia.Click += new System.EventHandler(this.btnTipoDia_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnterior.Location = new System.Drawing.Point(497, 189);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(84, 28);
            this.btnAnterior.TabIndex = 298;
            this.btnAnterior.Text = "Anterior";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnsiguiente2
            // 
            this.btnsiguiente2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsiguiente2.Location = new System.Drawing.Point(620, 189);
            this.btnsiguiente2.Name = "btnsiguiente2";
            this.btnsiguiente2.Size = new System.Drawing.Size(84, 28);
            this.btnsiguiente2.TabIndex = 297;
            this.btnsiguiente2.Text = "Siguiente";
            this.btnsiguiente2.UseVisualStyleBackColor = true;
            this.btnsiguiente2.Click += new System.EventHandler(this.btnsiguiente2_Click);
            // 
            // lbldiasfestivos
            // 
            this.lbldiasfestivos.AutoSize = true;
            this.lbldiasfestivos.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldiasfestivos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbldiasfestivos.Location = new System.Drawing.Point(20, 20);
            this.lbldiasfestivos.Name = "lbldiasfestivos";
            this.lbldiasfestivos.Size = new System.Drawing.Size(175, 18);
            this.lbldiasfestivos.TabIndex = 295;
            this.lbldiasfestivos.Text = "Feriados / Vacaciones";
            // 
            // dgvtipodia
            // 
            this.dgvtipodia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvtipodia.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dgvtipodia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvtipodia.Location = new System.Drawing.Point(23, 57);
            this.dgvtipodia.Name = "dgvtipodia";
            this.dgvtipodia.Size = new System.Drawing.Size(681, 112);
            this.dgvtipodia.TabIndex = 296;
            this.dgvtipodia.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvtipodia_CellContentClick);
            // 
            // Trimestres
            // 
            this.Trimestres.Controls.Add(this.btnPeriodos);
            this.Trimestres.Controls.Add(this.lblPeriodos);
            this.Trimestres.Controls.Add(this.btnAnterior2);
            this.Trimestres.Controls.Add(this.dgvPeriodos);
            this.Trimestres.Controls.Add(this.btnSiguiente3);
            this.Trimestres.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Trimestres.Location = new System.Drawing.Point(4, 22);
            this.Trimestres.Name = "Trimestres";
            this.Trimestres.Size = new System.Drawing.Size(743, 232);
            this.Trimestres.TabIndex = 2;
            this.Trimestres.Text = "Periodos";
            this.Trimestres.UseVisualStyleBackColor = true;
            // 
            // btnPeriodos
            // 
            this.btnPeriodos.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPeriodos.Location = new System.Drawing.Point(30, 189);
            this.btnPeriodos.Name = "btnPeriodos";
            this.btnPeriodos.Size = new System.Drawing.Size(84, 28);
            this.btnPeriodos.TabIndex = 301;
            this.btnPeriodos.Text = "Periodos";
            this.btnPeriodos.UseVisualStyleBackColor = true;
            this.btnPeriodos.Click += new System.EventHandler(this.btnPeriodos_Click);
            // 
            // lblPeriodos
            // 
            this.lblPeriodos.AutoSize = true;
            this.lblPeriodos.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPeriodos.Location = new System.Drawing.Point(27, 18);
            this.lblPeriodos.Name = "lblPeriodos";
            this.lblPeriodos.Size = new System.Drawing.Size(71, 18);
            this.lblPeriodos.TabIndex = 300;
            this.lblPeriodos.Text = "Periodos";
            // 
            // btnAnterior2
            // 
            this.btnAnterior2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnterior2.Location = new System.Drawing.Point(480, 188);
            this.btnAnterior2.Name = "btnAnterior2";
            this.btnAnterior2.Size = new System.Drawing.Size(84, 28);
            this.btnAnterior2.TabIndex = 299;
            this.btnAnterior2.Text = "Anterior";
            this.btnAnterior2.UseVisualStyleBackColor = true;
            this.btnAnterior2.Click += new System.EventHandler(this.btnAnterior2_Click);
            // 
            // dgvPeriodos
            // 
            this.dgvPeriodos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPeriodos.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dgvPeriodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeriodos.Location = new System.Drawing.Point(30, 53);
            this.dgvPeriodos.Name = "dgvPeriodos";
            this.dgvPeriodos.Size = new System.Drawing.Size(672, 110);
            this.dgvPeriodos.TabIndex = 295;
            this.dgvPeriodos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPeriodos_CellContentClick);
            // 
            // btnSiguiente3
            // 
            this.btnSiguiente3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiguiente3.Location = new System.Drawing.Point(613, 188);
            this.btnSiguiente3.Name = "btnSiguiente3";
            this.btnSiguiente3.Size = new System.Drawing.Size(89, 28);
            this.btnSiguiente3.TabIndex = 294;
            this.btnSiguiente3.Text = "Siguiente";
            this.btnSiguiente3.UseVisualStyleBackColor = true;
            this.btnSiguiente3.Click += new System.EventHandler(this.btnSiguiente3_Click);
            // 
            // Actividades
            // 
            this.Actividades.Controls.Add(this.btnActividades);
            this.Actividades.Controls.Add(this.label1);
            this.Actividades.Controls.Add(this.dgvActividades);
            this.Actividades.Controls.Add(this.btnCancelarAct);
            this.Actividades.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Actividades.Location = new System.Drawing.Point(4, 22);
            this.Actividades.Name = "Actividades";
            this.Actividades.Size = new System.Drawing.Size(743, 232);
            this.Actividades.TabIndex = 3;
            this.Actividades.Text = "Actividades";
            this.Actividades.UseVisualStyleBackColor = true;
            // 
            // btnActividades
            // 
            this.btnActividades.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActividades.Location = new System.Drawing.Point(32, 184);
            this.btnActividades.Name = "btnActividades";
            this.btnActividades.Size = new System.Drawing.Size(108, 28);
            this.btnActividades.TabIndex = 299;
            this.btnActividades.Text = "Actividades";
            this.btnActividades.UseVisualStyleBackColor = true;
            this.btnActividades.Click += new System.EventHandler(this.btnActividades_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 298;
            this.label1.Text = "Actividades";
            // 
            // dgvActividades
            // 
            this.dgvActividades.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvActividades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvActividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvActividades.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvActividades.Location = new System.Drawing.Point(29, 51);
            this.dgvActividades.Name = "dgvActividades";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvActividades.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvActividades.Size = new System.Drawing.Size(637, 116);
            this.dgvActividades.TabIndex = 297;
            // 
            // btnCancelarAct
            // 
            this.btnCancelarAct.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarAct.Location = new System.Drawing.Point(621, 184);
            this.btnCancelarAct.Name = "btnCancelarAct";
            this.btnCancelarAct.Size = new System.Drawing.Size(89, 28);
            this.btnCancelarAct.TabIndex = 296;
            this.btnCancelarAct.Text = "Guardar";
            this.btnCancelarAct.UseVisualStyleBackColor = true;
            // 
            // Calendario
            // 
            this.Calendario.CalendarDimensions = new System.Drawing.Size(4, 1);
            this.Calendario.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Calendario.Location = new System.Drawing.Point(12, 345);
            this.Calendario.MaxSelectionCount = 30;
            this.Calendario.Name = "Calendario";
            this.Calendario.ShowToday = false;
            this.Calendario.TabIndex = 302;
            this.Calendario.TrailingForeColor = System.Drawing.Color.PeachPuff;
            // 
            // lblDocente
            // 
            this.lblDocente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDocente.AutoSize = true;
            this.lblDocente.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocente.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblDocente.Location = new System.Drawing.Point(314, 19);
            this.lblDocente.Name = "lblDocente";
            this.lblDocente.Size = new System.Drawing.Size(194, 23);
            this.lblDocente.TabIndex = 299;
            this.lblDocente.Text = "Calendario Escolar";
            this.lblDocente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmNCalendario
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(803, 510);
            this.Controls.Add(this.panelContenido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNCalendario";
            this.Text = "frmNCalendario";
            this.Load += new System.EventHandler(this.frmNCalendario_Load);
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            this.tabControlCalendario.ResumeLayout(false);
            this.Gestion.ResumeLayout(false);
            this.Gestion.PerformLayout();
            this.Feriados_Vacaciones.ResumeLayout(false);
            this.Feriados_Vacaciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtipodia)).EndInit();
            this.Trimestres.ResumeLayout(false);
            this.Trimestres.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodos)).EndInit();
            this.Actividades.ResumeLayout(false);
            this.Actividades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActividades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.TabControl tabControlCalendario;
        private System.Windows.Forms.TabPage Gestion;
        private System.Windows.Forms.Button btnSiguiente1;
        private System.Windows.Forms.DateTimePicker dtGestionFin;
        private System.Windows.Forms.Button btnGenerarCalendario;
        private System.Windows.Forms.Label lblFechaFinG;
        private System.Windows.Forms.Label lblFechaInicioG;
        private System.Windows.Forms.DateTimePicker dtGestionInicio;
        private System.Windows.Forms.TextBox txtGestion;
        private System.Windows.Forms.TextBox txtCodGestion;
        private System.Windows.Forms.Label lblCodGestion;
        private System.Windows.Forms.Label lblGestion;
        private System.Windows.Forms.TabPage Feriados_Vacaciones;
        private System.Windows.Forms.Button btnsiguiente2;
        private System.Windows.Forms.Label lbldiasfestivos;
        private System.Windows.Forms.DataGridView dgvtipodia;
        private System.Windows.Forms.TabPage Trimestres;
        private System.Windows.Forms.DataGridView dgvPeriodos;
        private System.Windows.Forms.Button btnSiguiente3;
        private System.Windows.Forms.TabPage Actividades;
        private System.Windows.Forms.DataGridView dgvActividades;
        private System.Windows.Forms.Button btnCancelarAct;
        private System.Windows.Forms.Label lblDocente;
        private System.Windows.Forms.MonthCalendar Calendario;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnTipoDia;
        private System.Windows.Forms.Button btnAnterior2;
        private System.Windows.Forms.Label lblPeriodos;
        private System.Windows.Forms.Button btnPeriodos;
        private System.Windows.Forms.Button btnActividades;
        private System.Windows.Forms.Label label1;
    }
}