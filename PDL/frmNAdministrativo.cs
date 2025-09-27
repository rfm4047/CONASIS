using System;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using CONASIS.DAL;
using CONASIS.BDL;

namespace CONASIS.PDL
{
    public partial class frmNAdministrativo : Form
    {
        // Evento que notifica cuando se agregó o editó un adm
        public event EventHandler AdministrativoAgregado;

        private int? _idAdministrativoEditar = null;     // id del administrativo(si es edición)
        private int? _currentCodPlantel = null;    // id del Plantel al que pertenece
        private readonly BDL_Administrativo bdl = new BDL_Administrativo();
        private int idAdministrativo;
        public frmNAdministrativo()
        {
            InitializeComponent();
        }
    
        public frmNAdministrativo(int idAdministrativo) : this()  
        {
            _idAdministrativoEditar = idAdministrativo;
            this.idAdministrativo = idAdministrativo;
            CargarDatos();
        }

        private AdministrativoFull _AdministrativoActual;

        private void CargarDatos()
        {
            var administrativo = bdl.ObtenerPorId(idAdministrativo); // Debes implementar en BDL si aún no lo tienes

            if (administrativo == null)
                return;

            // Guardar id del Plantel para actualizar después
            _currentCodPlantel = administrativo.CodPlantel;

            txtCodigo.Text = administrativo.CPlant;
            txtNombre.Text = administrativo.NomPlantel;
            txtApPaterno.Text = administrativo.ApPlantel?.Trim() ?? string.Empty;
            txtMaterno.Text = administrativo.AmPlantel?.Trim() ?? string.Empty;
            cbxGenero.Text = administrativo.GeneroPlantel;
            txtCarnet.Text = administrativo.CIPlantel;
            cbxExtension.Text = administrativo.ExtPlantel;
            txtTelefono.Text = administrativo.TelfPlantel?.Trim();
            dtpFechaNac.Value = administrativo.FechaNacPlantel ?? DateTime.Today;
            cbxEstado.Text = administrativo.EstadoPlantel;
            txtDireccion.Text = administrativo.DireccionPlantel?.Trim() ?? string.Empty;
            txtEspecialidad.Text = administrativo.EspecialidadPlantel?.Trim() ?? string.Empty;
            txtItem.Text = administrativo.ItemPlantel;
            txtRda.Text = administrativo.RdaPlantel;

            // Datos propios de Administrativo
            txtCargo.Text = administrativo.CargoAdm;
        }

        private void frmNAdministrativo_Load(object sender, EventArgs e)
        {
            try
            {
                if (_idAdministrativoEditar.HasValue)   // 🔄 edición
                {
                    CargarDatos();
                }
                else  // ➕ nuevo
                {
                    AdministrativoDAL administrativoDAL = new AdministrativoDAL();
                    int siguienteCodigo = administrativoDAL.ObtenerSiguienteCodigo() + 1;
                    txtCodigo.Text = "ADM" + siguienteCodigo.ToString("D3");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el formulario: " + ex.Message);
            }
        }
        private void LimpiarFormulario()
        {
            // TextBox
            txtNombre.Clear();
            txtApPaterno.Clear();
            txtMaterno.Clear();
            txtCarnet.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEspecialidad.Clear();
            txtItem.Clear();
            txtRda.Clear();
            txtCodigo.Clear();
            txtCargo.Clear();

            // ComboBox
            cbxEstado.SelectedIndex = -1;

            // DateTimePicker
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

                // Validar nombre
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre del administrativo.");
                    txtNombre.Focus();
                    return;
                }

                // Validar que al menos uno de los dos apellidos esté presente
                if (string.IsNullOrWhiteSpace(txtApPaterno.Text) &&
                    string.IsNullOrWhiteSpace(txtMaterno.Text))
                {
                    MessageBox.Show("Debe ingresar al menos un apellido (paterno o materno).");
                    txtApPaterno.Focus();
                    return;
                }

                // Validar Carnet
                if (string.IsNullOrWhiteSpace(txtCarnet.Text) || !txtCarnet.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Debe ingresar un carnet válido (solo números).");
                    txtCarnet.Focus();
                    return;
                }

                // Validar fecha de nacimiento (no futura y mayor de edad)
                if (dtpFechaNac.Value.Date > DateTime.Today)
                {
                    MessageBox.Show("La fecha de nacimiento no puede ser futura.");
                    dtpFechaNac.Focus();
                    return;
                }
                int edad = DateTime.Today.Year - dtpFechaNac.Value.Year;
                if (dtpFechaNac.Value.Date > DateTime.Today.AddYears(-edad)) edad--;
                if (edad < 18)
                {
                    MessageBox.Show("El docente debe ser mayor de 18 años.");
                    dtpFechaNac.Focus();
                    return;
                }

                // Validar género
                if (cbxGenero.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar el género.");
                    cbxGenero.Focus();
                    return;
                }
                // Validar extensión (obligatoria)
                if (cbxExtension.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar una extensión.");
                    cbxExtension.Focus();
                    return;
                }

                // Validar Teléfono obligatorio y numérico
                if (string.IsNullOrWhiteSpace(txtTelefono.Text))
                {
                    MessageBox.Show("Debe ingresar el teléfono.");
                    txtTelefono.Focus();
                    return;
                }
                if (!txtTelefono.Text.All(char.IsDigit))
                {
                    MessageBox.Show("El teléfono debe contener solo números.");
                    txtTelefono.Focus();
                    return;
                }
                // Validar dirección
                if (string.IsNullOrWhiteSpace(txtDireccion.Text))
                {
                    MessageBox.Show("Debe ingresar la dirección.");
                    txtDireccion.Focus();
                    return;
                }
                //
                // Especialidad obligatoria
                if (string.IsNullOrWhiteSpace(txtEspecialidad.Text))
                {
                    MessageBox.Show("Debe ingresar la especialidad.");
                    txtEspecialidad.Focus();
                    return;
                }

                // Validar Item (obligatorio)
                if (string.IsNullOrWhiteSpace(txtItem.Text))
                {
                    MessageBox.Show("Debe ingresar el Item.");
                    txtItem.Focus();
                    return;
                }

                // Validar RDA (obligatorio)
                if (string.IsNullOrWhiteSpace(txtRda.Text))
                {
                    MessageBox.Show("Debe ingresar el RDA.");
                    txtRda.Focus();
                    return;
                }
                // Validar Cargo (obligatorio)
                if (string.IsNullOrWhiteSpace(txtCargo.Text))
                {
                    MessageBox.Show("Debe ingresar el Cargo.");
                    txtCargo.Focus();
                    return;
                }

                string cnx = System.Configuration.ConfigurationManager.ConnectionStrings["cnxAsistencia"].ConnectionString;
                DAL_Plantel plantelDAL = new DAL_Plantel(cnx);
                AdministrativoDAL administrativoDAL = new AdministrativoDAL();

                if (_idAdministrativoEditar.HasValue) // 🔄 MODO EDICIÓN
                {
                    if (!_currentCodPlantel.HasValue)
                    {
                        MessageBox.Show("No se pudo obtener el código del Plantel.");
                        return;
                    }

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

                    Administrativo admEdit = new Administrativo
                    {
                        IdAdm = _idAdministrativoEditar.Value,
                        IdPlantelF = plantelEdit.CodPlantel,
                        CargoAdm = txtCargo.Text.Trim()
                    };
                    administrativoDAL.MODIFICAR(admEdit);

                    MessageBox.Show("Administrativo actualizado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AdministrativoAgregado?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
                else // ➕ NUEVO
                {
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

                    Administrativo nuevoAdministrativo = new Administrativo
                    {
                        IdPlantelF = idPlantelGenerado,
                        CargoAdm = txtCargo.Text.Trim()
                    };
                    var resultado = administrativoDAL.AGREGAR(nuevoAdministrativo);

                    txtCodigo.Text = resultado.CPlant;

                    MessageBox.Show($"Administrativo registrado con código {resultado.CPlant}.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AdministrativoAgregado?.Invoke(this, EventArgs.Empty);
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }
    }
}