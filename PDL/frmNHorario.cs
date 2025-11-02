using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CONASIS.DAL;
using CONASIS.BDL;


namespace CONASIS.PDL
{
    public partial class frmNHorario : Form
    {
        private int? idAdministrativoSeleccionado = null;
        private int? idDocenteSeleccionado = null;
        private BDL_Docente bdlDocente = new BDL_Docente();
        public frmNHorario()
        {
            InitializeComponent();
        }

        private void frmNHorario_Load(object sender, EventArgs e)
        {
            comboNombre.PreviewKeyDown += comboNombre_PreviewKeyDown;
            pbCheck.Image = null;
            pbCheck.Visible = false;
        }

        private void LimpiarFormulario()
        {
            // Quitar selección de administrativo/docente
            comboNombre.DataSource = null;
            comboNombre.Text = "";
            idAdministrativoSeleccionado = null;
            idDocenteSeleccionado = null;

            pbCheck.Image = null;
            pbCheck.Visible = false;

            // Desactivar pestañas
            tabFijo.Enabled = false;
            tabVariable.Enabled = false;

            // Resetear días de la semana
            foreach (var chk in new[] { chbxLunes, chbxMartes, chbxMiercoles, chbxJueves, chbxViernes, chbxSabado, chbxDomingo })
            {
                chk.Checked = false;
            }

                    // Resetear horas
                    foreach (var dtp in new[] {
                dateTimeELunes, dateTimeSLunes, dateTimeILunes, dateTimeFLunes,
                dateTimeEMartes, dateTimeSMartes, dateTimeIMartes, dateTimeFMartes,
                dateTimeEMiercoles, dateTimeSMiercoles, dateTimeIMiercoles, dateTimeFMiercoles,
                dateTimeEJueves, dateTimeSJueves, dateTimeIJueves, dateTimeFJueves,
                dateTimeEViernes, dateTimeSViernes, dateTimeIViernes, dateTimeFViernes,
                dateTimeESabado, dateTimeSSabado, dateTimeISabado, dateTimeFSabado,
                dateTimeEDomingo, dateTimeSDomingo, dateTimeIDomingo, dateTimeFDomingo
            })
                    {
                        dtp.Value = DateTime.Today.AddHours(8); // por defecto 08:00
                    }

                    // Resetear tolerancias
                    foreach (var num in new[] {
                numLunesTolerancia, numMartesTolerancia, numMiercolesTolerancia,
                numJuevesTolerancia, numViernesTolerancia, numSabadoTolerancia, numDomingoTolerancia
            })
                    {
                        num.Value = 0;
                    }
        }



        private void comboNombre_KeyUp(object sender, KeyEventArgs e)
        {
            if (comboNombre.Text.Length >= 2 && e.KeyCode != Keys.Enter)
            {
                BDL_Administrativo bdl = new BDL_Administrativo();
                DataTable dt = bdl.BuscarPorNombre(comboNombre.Text);

                if (dt.Rows.Count > 0)
                {
                    if (!dt.Columns.Contains("NombreCompleto"))
                    {
                        dt.Columns.Add("NombreCompleto", typeof(string));
                    }

                    foreach (DataRow row in dt.Rows)
                    {
                        string ap = row["ApPlantel"].ToString().Trim();
                        string am = row["AmPlantel"].ToString().Trim();
                        string nom = row["NomPlantel"].ToString().Trim();
                        row["NombreCompleto"] = $"{ap} {am} {nom}".Trim();
                    }

                    comboNombre.DataSource = null;
                    comboNombre.DisplayMember = "NombreCompleto";
                    comboNombre.ValueMember = "IdAdm";
                    comboNombre.DataSource = dt;

                    comboNombre.DroppedDown = true;
                }
            }
        }


        private void comboNombre_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboNombre.SelectedIndex != -1)
                {
                    idAdministrativoSeleccionado = Convert.ToInt32(comboNombre.SelectedValue);

                    pbCheck.Image = Properties.Resources.check;
                    pbCheck.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbCheck.Visible = true; // 🔹 recién aquí se muestra

                    tabFijo.Enabled = true;
                    tabVariable.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Seleccione un nombre válido de la lista.");
                    pbCheck.Image = null;
                    pbCheck.Visible = false;
                }

                e.IsInputKey = true; // asegura que Enter se procese
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (idAdministrativoSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un administrativo antes de guardar.");
                return;
            }

            int idAdm = idAdministrativoSeleccionado.Value;
            BDL_HorarioAdministrativo bdl = new BDL_HorarioAdministrativo();

            // 🔹 Antes de insertar, eliminamos todos los horarios previos de ese administrativo
            bdl.EliminarTodos(idAdm);

            // 🔹 Lista de días y sus controles
            var dias = new[]
            {
        new {Chk = chbxLunes, Dia = "Lunes",
             Entrada = dateTimeELunes, Salida = dateTimeSLunes,
             RecesoIni = dateTimeILunes, RecesoFin = dateTimeFLunes,
             Tolerancia = numLunesTolerancia},

        new {Chk = chbxMartes, Dia = "Martes",
             Entrada = dateTimeEMartes, Salida = dateTimeSMartes,
             RecesoIni = dateTimeIMartes, RecesoFin = dateTimeFMartes,
             Tolerancia = numMartesTolerancia},

        new {Chk = chbxMiercoles, Dia = "Miercoles",
             Entrada = dateTimeEMiercoles, Salida = dateTimeSMiercoles,
             RecesoIni = dateTimeIMiercoles, RecesoFin = dateTimeFMiercoles,
             Tolerancia = numMiercolesTolerancia},

        new {Chk = chbxJueves, Dia = "Jueves",
             Entrada = dateTimeEJueves, Salida = dateTimeSJueves,
             RecesoIni = dateTimeIJueves, RecesoFin = dateTimeFJueves,
             Tolerancia = numJuevesTolerancia},

        new {Chk = chbxViernes, Dia = "Viernes",
             Entrada = dateTimeEViernes, Salida = dateTimeSViernes,
             RecesoIni = dateTimeIViernes, RecesoFin = dateTimeFViernes,
             Tolerancia = numViernesTolerancia},

        new {Chk = chbxSabado, Dia = "Sabado",
             Entrada = dateTimeESabado, Salida = dateTimeSSabado,
             RecesoIni = dateTimeISabado, RecesoFin = dateTimeFSabado,
             Tolerancia = numSabadoTolerancia},

        new {Chk = chbxDomingo, Dia = "Domingo",
             Entrada = dateTimeEDomingo, Salida = dateTimeSDomingo,
             RecesoIni = dateTimeIDomingo, RecesoFin = dateTimeFDomingo,
             Tolerancia = numDomingoTolerancia},
    };

            // 🔹 Recorremos cada día y guardamos solo los seleccionados
            foreach (var d in dias)
            {
                if (d.Chk.Checked)
                {
                    TimeSpan entrada = d.Entrada.Value.TimeOfDay;
                    TimeSpan salida = d.Salida.Value.TimeOfDay;
                    TimeSpan? recIni = d.RecesoIni.Checked ? d.RecesoIni.Value.TimeOfDay : (TimeSpan?)null;
                    TimeSpan? recFin = d.RecesoFin.Checked ? d.RecesoFin.Value.TimeOfDay : (TimeSpan?)null;

                    int toleranciaMinutos = (int)d.Tolerancia.Value;

                    // Guardar en la base de datos
                    bdl.Agregar(idAdm, d.Dia, entrada, salida, recIni, recFin, toleranciaMinutos);

                    // Cálculo de horas trabajadas (solo informativo)
                    double totalHoras = (salida - entrada).TotalHours;
                    Console.WriteLine($"[{d.Dia}] Total horas = {totalHoras:F2}");
                }
            }

            MessageBox.Show("Horario guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 🔹 Refrescar el DataGridView del formulario padre
            _padre?.CargarHorarios();

            // 🔹 Limpiar los controles del formulario (opcional)
            LimpiarFormulario();

            // 🔹 Cerrar el formulario hijo (al cerrar se removerá del panel en frmHorario)
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

            // Si hay referencia al padre, traer foco.
            if (_padre != null)
            {
                _padre.BringToFront();
                _padre.Focus();
            }
        }
        public void CargarHorarioExistente(int id, string cplant)
        {
            // Detectar tipo de personal
            bool esDocente = cplant.StartsWith("DOC");
            bool esAdministrativo = cplant.StartsWith("ADM");

            if (!esDocente && !esAdministrativo)
                throw new Exception("Código de personal inválido.");

            DataTable dt;
            if (esDocente)
            {
                BDL_HorarioDocente bdlDoc = new BDL_HorarioDocente();
                dt = bdlDoc.Mostrar(); // Retorna todos los horarios de docentes
            }
            else
            {
                BDL_HorarioAdministrativo bdlAdm = new BDL_HorarioAdministrativo();
                dt = bdlAdm.Mostrar(); // Retorna todos los horarios de administrativos
            }

            var horarios = dt.AsEnumerable()
                             .Where(r => Convert.ToInt32(esDocente ? r["iddocente"] : r["idadm"]) == id);

            foreach (var row in horarios)
            {
                string dia = row["diaSemana"].ToString();
                TimeSpan entrada = (TimeSpan)row[esDocente ? "horaInicio" : "horaEntrada"];
                TimeSpan salida = (TimeSpan)row[esDocente ? "horaFin" : "horaSalida"];
                TimeSpan? recIni = row[esDocente ? "horaRecesoInicio" : "horaRecesoInicio"] != DBNull.Value
                                    ? (TimeSpan)row[esDocente ? "horaRecesoInicio" : "horaRecesoInicio"] : (TimeSpan?)null;
                TimeSpan? recFin = row[esDocente ? "horaRecesoFin" : "horaRecesoFin"] != DBNull.Value
                                    ? (TimeSpan)row[esDocente ? "horaRecesoFin" : "horaRecesoFin"] : (TimeSpan?)null;
                int tolerancia = Convert.ToInt32(row["toleranciaMinutos"]);

                // Mapear días a controles
                switch (dia.ToLower())
                {
                    case "lunes":
                        chbxLunes.Checked = true;
                        dateTimeELunes.Value = DateTime.Today.Add(entrada);
                        dateTimeSLunes.Value = DateTime.Today.Add(salida);
                        if (recIni.HasValue) dateTimeILunes.Value = DateTime.Today.Add(recIni.Value);
                        if (recFin.HasValue) dateTimeFLunes.Value = DateTime.Today.Add(recFin.Value);
                        numLunesTolerancia.Value = tolerancia;
                        break;

                    case "martes":
                        chbxMartes.Checked = true;
                        dateTimeEMartes.Value = DateTime.Today.Add(entrada);
                        dateTimeSMartes.Value = DateTime.Today.Add(salida);
                        if (recIni.HasValue) dateTimeIMartes.Value = DateTime.Today.Add(recIni.Value);
                        if (recFin.HasValue) dateTimeFMartes.Value = DateTime.Today.Add(recFin.Value);
                        numMartesTolerancia.Value = tolerancia;
                        break;

                    case "miercoles":
                        chbxMiercoles.Checked = true;
                        dateTimeEMiercoles.Value = DateTime.Today.Add(entrada);
                        dateTimeSMiercoles.Value = DateTime.Today.Add(salida);
                        if (recIni.HasValue) dateTimeIMiercoles.Value = DateTime.Today.Add(recIni.Value);
                        if (recFin.HasValue) dateTimeFMiercoles.Value = DateTime.Today.Add(recFin.Value);
                        numMiercolesTolerancia.Value = tolerancia;
                        break;

                    case "jueves":
                        chbxJueves.Checked = true;
                        dateTimeEJueves.Value = DateTime.Today.Add(entrada);
                        dateTimeSJueves.Value = DateTime.Today.Add(salida);
                        if (recIni.HasValue) dateTimeIJueves.Value = DateTime.Today.Add(recIni.Value);
                        if (recFin.HasValue) dateTimeFJueves.Value = DateTime.Today.Add(recFin.Value);
                        numJuevesTolerancia.Value = tolerancia;
                        break;

                    case "viernes":
                        chbxViernes.Checked = true;
                        dateTimeEViernes.Value = DateTime.Today.Add(entrada);
                        dateTimeSViernes.Value = DateTime.Today.Add(salida);
                        if (recIni.HasValue) dateTimeIViernes.Value = DateTime.Today.Add(recIni.Value);
                        if (recFin.HasValue) dateTimeFViernes.Value = DateTime.Today.Add(recFin.Value);
                        numViernesTolerancia.Value = tolerancia;
                        break;

                    case "sabado":
                        chbxSabado.Checked = true;
                        dateTimeESabado.Value = DateTime.Today.Add(entrada);
                        dateTimeSSabado.Value = DateTime.Today.Add(salida);
                        if (recIni.HasValue) dateTimeISabado.Value = DateTime.Today.Add(recIni.Value);
                        if (recFin.HasValue) dateTimeFSabado.Value = DateTime.Today.Add(recFin.Value);
                        numSabadoTolerancia.Value = tolerancia;
                        break;

                    case "domingo":
                        chbxDomingo.Checked = true;
                        dateTimeEDomingo.Value = DateTime.Today.Add(entrada);
                        dateTimeSDomingo.Value = DateTime.Today.Add(salida);
                        if (recIni.HasValue) dateTimeIDomingo.Value = DateTime.Today.Add(recIni.Value);
                        if (recFin.HasValue) dateTimeFDomingo.Value = DateTime.Today.Add(recFin.Value);
                        numDomingoTolerancia.Value = tolerancia;
                        break;
                }
            }

            // Mostrar check verde
            pbCheck.Image = Properties.Resources.check;
            pbCheck.Visible = true;
            tabFijo.Enabled = true;
            tabVariable.Enabled = false;
        }


        private void chbxSabado_CheckedChanged(object sender, EventArgs e)
        {

        }
        private frmHorario _padre;

        public frmNHorario(frmHorario padre) : this() // llama al constructor por defecto para InitializeComponent
        {
            _padre = padre;
        }

    }
}


