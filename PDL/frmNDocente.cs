using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CONASIS.DAL;
using CONASIS.BDL;

namespace CONASIS.PDL
{
    public partial class frmNDocente : Form
    {
        // Evento que notifica cuando se agregó o editó un docente
        public event EventHandler DocenteAgregado;

        private int? _idDocenteEditar = null;      // id del docente (si es edición)
        private int? _currentCodPlantel = null;    // id del Plantel al que pertenece
        private readonly BDL_Docente bdl = new BDL_Docente();
        private int idDocente;

        public frmNDocente()
        {
            InitializeComponent();
        }

        public frmNDocente(int idDocente) : this()
        {
            _idDocenteEditar = idDocente;
            this.idDocente = idDocente;
            CargarDatos();
        }

        private DocenteFull _docenteActual;

        private void CargarDatos()
        {
            var docente = bdl.ObtenerPorId(idDocente); // Debes implementar en BDL si aún no lo tienes

            if (docente == null)
                return;

            // Guardar id del Plantel para actualizar después
            _currentCodPlantel = docente.CodPlantel;

            txtCodigo.Text = docente.CPlant;
            txtNombre.Text = docente.NomPlantel;
            txtApPaterno.Text = docente.ApPlantel?.Trim() ?? string.Empty;
            txtMaterno.Text = docente.AmPlantel?.Trim() ?? string.Empty;
            cbxGenero.Text = docente.GeneroPlantel;
            txtCarnet.Text = docente.CIPlantel;
            cbxExtension.Text = docente.ExtPlantel;
            txtTelefono.Text = docente.TelfPlantel?.Trim();
            dtpFechaNac.Value = docente.FechaNacPlantel ?? DateTime.Today;
            cbxEstado.Text = docente.EstadoPlantel;
            txtDireccion.Text = docente.DireccionPlantel?.Trim() ?? string.Empty;
            txtEspecialidad.Text = docente.EspecialidadPlantel?.Trim() ?? string.Empty;
            txtItem.Text = docente.ItemPlantel;
            txtRda.Text = docente.RdaPlantel;

            // Datos propios de Docente
            txtCargaHoraria.Text = docente.CargaHorariaDocente;
            txtHrPlanilla.Text = docente.HoraPlanilla;
        }

        private void frmNDocente_Load(object sender, EventArgs e)
        {
            try
            {
                if (_idDocenteEditar.HasValue)   // Modo edición
                {
                    CargarDatos();
                }
                else // Modo nuevo
                {
                    DocenteDAL docenteDAL = new DocenteDAL();
                    int siguienteCodigo = docenteDAL.ObtenerSiguienteCodigo() + 1;
                    txtCodigo.Text = "DOC" + siguienteCodigo.ToString("D3");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el formulario: " + ex.Message);
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApPaterno.Clear();
            txtMaterno.Clear();
            txtCarnet.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEspecialidad.Clear();
            txtItem.Clear();
            txtRda.Clear();
            txtHrPlanilla.Clear();
            txtCargaHoraria.Clear();
            txtCodigo.Clear();

            cbxExtension.SelectedIndex = -1;
            cbxGenero.SelectedIndex = -1;
            cbxEstado.SelectedIndex = -1;

            dtpFechaNac.Value = DateTime.Now;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                // 🔎 VALIDACIONES
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre del docente.");
                    txtNombre.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtApPaterno.Text) &&
                    string.IsNullOrWhiteSpace(txtMaterno.Text))
                {
                    MessageBox.Show("Debe ingresar al menos un apellido.");
                    txtApPaterno.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCarnet.Text) || !txtCarnet.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Debe ingresar un carnet válido (solo números).");
                    txtCarnet.Focus();
                    return;
                }

                if (dtpFechaNac.Value.Date > DateTime.Today)
                {
                    MessageBox.Show("La fecha de nacimiento no puede ser futura.");
                    return;
                }

                int edad = DateTime.Today.Year - dtpFechaNac.Value.Year;
                if (dtpFechaNac.Value.Date > DateTime.Today.AddYears(-edad)) edad--;
                if (edad < 18)
                {
                    MessageBox.Show("El docente debe ser mayor de 18 años.");
                    return;
                }

                if (cbxGenero.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar el género.");
                    return;
                }

                if (cbxExtension.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar una extensión.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTelefono.Text) || !txtTelefono.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Debe ingresar un teléfono válido.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDireccion.Text))
                {
                    MessageBox.Show("Debe ingresar la dirección.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEspecialidad.Text))
                {
                    MessageBox.Show("Debe ingresar la especialidad.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtItem.Text))
                {
                    MessageBox.Show("Debe ingresar el Item.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtRda.Text))
                {
                    MessageBox.Show("Debe ingresar el RDA.");
                    return;
                }

                if (!int.TryParse(txtHrPlanilla.Text, out _))
                {
                    MessageBox.Show("Hora planilla debe ser numérica.");
                    return;
                }

                if (!int.TryParse(txtCargaHoraria.Text, out _))
                {
                    MessageBox.Show("Carga horaria debe ser numérica.");
                    return;
                }

                // 🔎 SI LLEGA AQUÍ, PASÓ VALIDACIONES

                string cnx = System.Configuration.ConfigurationManager.ConnectionStrings["cnxAsistencia"].ConnectionString;
                DAL_Plantel plantelDAL = new DAL_Plantel(cnx);
                DocenteDAL docenteDAL = new DocenteDAL();

                if (_idDocenteEditar.HasValue) // 🔄 MODO EDICIÓN
                {
                    if (!_currentCodPlantel.HasValue)
                    {
                        MessageBox.Show("No se pudo obtener el código del Plantel para actualizar.");
                        return;
                    }

                    // Actualizar Plantel
                    var plantelEdit = new Plantel
                    {
                        CodPlantel = _currentCodPlantel.Value,
                        NomPlantel = txtNombre.Text.Trim(),
                        ApPlantel = txtApPaterno.Text.Trim(),
                        AmPlantel = txtMaterno.Text.Trim(),
                        CIPlantel = txtCarnet.Text.Trim(),
                        ExtPlantel = cbxExtension.Text,
                        FechaNacPlantel = dtpFechaNac.Value,
                        GeneroPlantel = cbxGenero.Text,
                        DireccionPlantel = txtDireccion.Text.Trim(),
                        TelfPlantel = txtTelefono.Text.Trim(),
                        EspecialidadPlantel = txtEspecialidad.Text.Trim(),
                        ItemPlantel = txtItem.Text.Trim(),
                        RdaPlantel = txtRda.Text.Trim(),
                        EstadoPlantel = cbxEstado.Text
                    };
                    plantelDAL.MODIFICAR(plantelEdit);

                    // Actualizar Docente
                    Docente docenteEdit = new Docente
                    {
                        IdDocente = _idDocenteEditar.Value,
                        IdPlantelF = plantelEdit.CodPlantel,
                        HoraPlanilla = txtHrPlanilla.Text.Trim(),
                        CargaHorariaDocente = txtCargaHoraria.Text.Trim()
                    };
                    docenteDAL.MODIFICAR(docenteEdit);

                    MessageBox.Show("Docente actualizado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DocenteAgregado?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
                else // ➕ NUEVO DOCENTE
                {
                    // Insertar Plantel
                    Plantel nuevoPlantel = new Plantel
                    {
                        NomPlantel = txtNombre.Text.Trim(),
                        ApPlantel = txtApPaterno.Text.Trim(),
                        AmPlantel = txtMaterno.Text.Trim(),
                        CIPlantel = txtCarnet.Text.Trim(),
                        ExtPlantel = cbxExtension.Text,
                        FechaNacPlantel = dtpFechaNac.Value,
                        GeneroPlantel = cbxGenero.Text,
                        EstadoPlantel = "ACTIVO",
                        DireccionPlantel = txtDireccion.Text.Trim(),
                        TelfPlantel = txtTelefono.Text.Trim(),
                        EspecialidadPlantel = txtEspecialidad.Text.Trim(),
                        ItemPlantel = txtItem.Text.Trim(),
                        RdaPlantel = txtRda.Text.Trim()
                    };
                    int idPlantelGenerado = plantelDAL.AGREGAR(nuevoPlantel);

                    // Insertar Docente
                    Docente nuevoDocente = new Docente
                    {
                        IdPlantelF = idPlantelGenerado,
                        HoraPlanilla = txtHrPlanilla.Text.Trim(),
                        CargaHorariaDocente = txtCargaHoraria.Text.Trim()
                    };
                    var resultado = docenteDAL.AGREGAR(nuevoDocente);

                    txtCodigo.Text = resultado.CPlant;

                    MessageBox.Show($"Docente registrado con código {resultado.CPlant}.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DocenteAgregado?.Invoke(this, EventArgs.Empty);
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void panelContenido_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
