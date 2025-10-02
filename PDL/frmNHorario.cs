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

            // Lista de días y sus controles (puedes ampliarlo hasta domingo)
            var dias = new[]
                    {
                new {Chk = chbxLunes, Dia = "Lunes",
                     Entrada = dateTimeELunes, Salida = dateTimeSLunes,
                     RecesoIni = dateTimeILunes, RecesoFin = dateTimeFLunes,
                     Tolerancia =numLunesTolerancia},

                new {Chk =chbxMartes, Dia = "Martes",
                     Entrada = dateTimeEMartes, Salida =dateTimeSMartes,
                     RecesoIni = dateTimeIMartes, RecesoFin = dateTimeFMartes,
                     Tolerancia = numMartesTolerancia},

                new {Chk =chbxMiercoles, Dia = "Miercoles",
                     Entrada = dateTimeEMiercoles, Salida =dateTimeSMiercoles,
                     RecesoIni = dateTimeIMiercoles, RecesoFin = dateTimeFMiercoles,
                     Tolerancia = numMiercolesTolerancia},

                new {Chk =chbxJueves, Dia = "Jueves",
                     Entrada = dateTimeEJueves, Salida =dateTimeSJueves,
                     RecesoIni = dateTimeIJueves, RecesoFin = dateTimeFJueves,
                     Tolerancia = numJuevesTolerancia},

                new {Chk =chbxViernes, Dia = "Viernes",
                     Entrada = dateTimeEViernes, Salida =dateTimeSViernes,
                     RecesoIni = dateTimeIViernes, RecesoFin = dateTimeFViernes,
                     Tolerancia = numViernesTolerancia},

                new {Chk =chbxSabado, Dia = "Sabado",
                     Entrada = dateTimeESabado, Salida =dateTimeSSabado,
                     RecesoIni = dateTimeISabado, RecesoFin = dateTimeFSabado,
                     Tolerancia = numSabadoTolerancia},

                new {Chk =chbxDomingo, Dia = "Domingo",
                     Entrada = dateTimeEDomingo, Salida =dateTimeSDomingo,
                     RecesoIni = dateTimeIDomingo, RecesoFin = dateTimeFDomingo,
                     Tolerancia = numDomingoTolerancia},

            };

            foreach (var d in dias)
            {
                if (d.Chk.Checked)
                {
                    TimeSpan entrada = d.Entrada.Value.TimeOfDay;
                    TimeSpan salida = d.Salida.Value.TimeOfDay;
                    TimeSpan? recIni = d.RecesoIni.Checked ? d.RecesoIni.Value.TimeOfDay : (TimeSpan?)null;
                    TimeSpan? recFin = d.RecesoFin.Checked ? d.RecesoFin.Value.TimeOfDay : (TimeSpan?)null;

                    // tolerancia: usamos solo los minutos del control
                    int toleranciaMinutos = (int)d.Tolerancia.Value;


                    // Guardamos en la BD
                    bdl.Agregar(idAdm, d.Dia, entrada, salida, recIni, recFin, toleranciaMinutos);

                    // Calcular horas trabajadas (sin restar receso/tolerancia)
                    double totalHoras = (salida - entrada).TotalHours;
                    Console.WriteLine($"[{d.Dia}] Total horas = {totalHoras:F2}");
                }
            }

            MessageBox.Show("Horario guardado correctamente.");

            // 🔹 Refrescar DataGridView del formulario padre (frmHorario)
            if (this.Owner is frmHorario parent)
            {
                parent.CargarHorarios();
            }
            LimpiarFormulario();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void CargarHorarioExistente(int idAdm)
        {
            idAdministrativoSeleccionado = idAdm;

            BDL_HorarioAdministrativo bdl = new BDL_HorarioAdministrativo();
            DataTable dt = bdl.Mostrar(); // muestra todos los horarios

            var horarios = dt.AsEnumerable()
                             .Where(r => Convert.ToInt32(r["idadm"]) == idAdm);

            foreach (var row in horarios)
            {
                string dia = row["diaSemana"].ToString();
                TimeSpan entrada = (TimeSpan)row["horaEntrada"];
                TimeSpan salida = (TimeSpan)row["horaSalida"];
                TimeSpan? recIni = row["horaRecesoInicio"] != DBNull.Value ? (TimeSpan)row["horaRecesoInicio"] : (TimeSpan?)null;
                TimeSpan? recFin = row["horaRecesoFin"] != DBNull.Value ? (TimeSpan)row["horaRecesoFin"] : (TimeSpan?)null;
                int tolerancia = Convert.ToInt32(row["toleranciaMinutos"]);

                // 🔹 según el día, llenamos los controles
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

                        // 🔹 repetir para Miércoles → Domingo
                }
            }

            // Mostrar check verde porque ya está cargado
            pbCheck.Image = Properties.Resources.check;
            pbCheck.Visible = true;
            tabFijo.Enabled = true;
            tabVariable.Enabled = false;
        }

    }
}


