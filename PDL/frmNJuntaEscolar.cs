using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CONASIS.BDL;
using CONASIS.DAL;

namespace CONASIS.PDL
{

    public partial class frmNJuntaEscolar : Form
    {
        // Evento que avisará al padre que hay cambios
        public event Action DatosActualizados;
        private readonly BDL_Cargo bdlCargo = new BDL_Cargo();
        private readonly DAL_JuntaEsc dalJunta = new DAL_JuntaEsc();
        private readonly DAL_Cargo cargoDAL = new DAL_Cargo();

        private int idSeleccionado = 0; // 0 = nuevo registro, >0 = editar

        public frmNJuntaEscolar()
        {
            InitializeComponent();
        }

        public void CargarCargos()
        {
            cbxCargo.DataSource = bdlCargo.ObtenerCargos();
            cbxCargo.DisplayMember = "nomcargo";   // columna que muestra el nombre
            cbxCargo.ValueMember = "codcargo";     // columna con el ID
            cbxCargo.SelectedIndex = -1;
        }

        private void CargarJuntaEscolar()
        {
            var lista = dalJunta.Listar();
            dvgJuntaEscolar.DataSource = null;   // limpiar antes
            dvgJuntaEscolar.DataSource = lista;

            // Ocultar columnas que no quieres
            dvgJuntaEscolar.Columns["CodCargo"].Visible = false;
            dvgJuntaEscolar.Columns["CodJe"].Visible = false;
            dvgJuntaEscolar.Columns["CiJe"].Visible = false;
            dvgJuntaEscolar.Columns["ExtJe"].Visible = false;
            dvgJuntaEscolar.Columns["TelfJe"].Visible = false;

            // Cambiar encabezados
            dvgJuntaEscolar.Columns["Codigo"].HeaderText = "Código";
            dvgJuntaEscolar.Columns["NomJe"].HeaderText = "Nombre";
            dvgJuntaEscolar.Columns["ApPaternoJe"].HeaderText = "Apellido Paterno";
            dvgJuntaEscolar.Columns["ApMaternoJe"].HeaderText = "Apellido Materno";
            dvgJuntaEscolar.Columns["Estado"].HeaderText = "Estado";
            dvgJuntaEscolar.Columns["FechaCreacion"].HeaderText = "Fecha Creación";
            dvgJuntaEscolar.Columns["NomCargo"].HeaderText = "Cargo";
        }

        private void frmNJuntaEscolar_Load(object sender, EventArgs e)
        {
            CargarCargos();
            CargarJuntaEscolar();
            cbxEstado.Items.Add("ACTIVO");
            cbxEstado.Items.Add("INACTIVO");
            cbxEstado.SelectedIndex = 0;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                // ✅ Validaciones
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Debe ingresar el Nombre.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtApPaterno.Text))
                {
                    MessageBox.Show("Debe ingresar el Apellido Paterno.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtApMaterno.Text))
                {
                    MessageBox.Show("Debe ingresar el Apellido Materno.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtCarnet.Text))
                {
                    MessageBox.Show("Debe ingresar el Carnet.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cbxExtension.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar una Extensión.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cbxCargo.SelectedValue == null || cbxCargo.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar un Cargo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal? telefono = null;
                if (!string.IsNullOrWhiteSpace(txtTelefono.Text))
                {
                    if (!decimal.TryParse(txtTelefono.Text, out decimal tel))
                    {
                        MessageBox.Show("El teléfono debe ser numérico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    telefono = tel;
                }

                // ✅ Crear objeto
                JuntaEscolar junta = new JuntaEscolar
                {
                    CodJe = idSeleccionado, // se usará solo en UPDATE
                    NomJe = txtNombre.Text.Trim(),
                    ApPaternoJe = txtApPaterno.Text.Trim(),
                    ApMaternoJe = txtApMaterno.Text.Trim(),
                    CiJe = txtCarnet.Text.Trim(),
                    ExtJe = cbxExtension.Text,
                    TelfJe = telefono,
                    Estado = cbxEstado.Text,
                    CodCargo = Convert.ToInt32(cbxCargo.SelectedValue) // nunca null porque validamos arriba
                };

                // ✅ Insertar o Actualizar
                if (idSeleccionado == 0)
                {
                    var (codje, codigo) = dalJunta.Agregar(junta);
                    MessageBox.Show($"Registro guardado con éxito. Código: {codigo}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dalJunta.Modificar(junta);
                    MessageBox.Show("Registro actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Avisar al form padre que se actualicen los datos
                DatosActualizados?.Invoke();

                // Refrescar y limpiar
                CargarJuntaEscolar();
                LimpiarFormulario();
                idSeleccionado = 0; // reset
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtcodrepje.Clear();
            txtNombre.Clear();
            txtApPaterno.Clear();
            txtApMaterno.Clear();
            txtCarnet.Clear();
            cbxExtension.SelectedIndex = -1;
            txtTelefono.Clear();
            cbxEstado.SelectedIndex = -1;
            cbxCargo.SelectedIndex = -1;
        }

        private void btnCargo_Click(object sender, EventArgs e)
        {
            frmCargoJuntaEscolar formCargoJuntaEscolar = new frmCargoJuntaEscolar();
            formCargoJuntaEscolar.StartPosition = FormStartPosition.CenterParent;

            // 👉 Suscribir el evento ANTES de mostrar el form
            formCargoJuntaEscolar.DatosActualizados += () => CargarCargos();

            formCargoJuntaEscolar.ShowDialog(this);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dvgJuntaEscolar.CurrentRow != null)
            {
                DataGridViewRow fila = dvgJuntaEscolar.CurrentRow;

                idSeleccionado = Convert.ToInt32(fila.Cells["CodJe"].Value);

                txtcodrepje.Text = fila.Cells["Codigo"].Value.ToString();
                txtNombre.Text = fila.Cells["NomJe"].Value.ToString();
                txtApPaterno.Text = fila.Cells["ApPaternoJe"].Value.ToString();
                txtApMaterno.Text = fila.Cells["ApMaternoJe"].Value.ToString();
                txtCarnet.Text = fila.Cells["CiJe"].Value.ToString();
                cbxExtension.Text = fila.Cells["ExtJe"].Value?.ToString();
                txtTelefono.Text = fila.Cells["TelfJe"].Value?.ToString();
                cbxEstado.Text = fila.Cells["Estado"].Value.ToString();

                // ✅ Validar CodCargo antes de asignar
                if (fila.Cells["CodCargo"].Value != null)
                    cbxCargo.SelectedValue = fila.Cells["CodCargo"].Value;
                else
                    cbxCargo.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Seleccione un registro para editar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dvgJuntaEscolar.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int codJe = Convert.ToInt32(dvgJuntaEscolar.CurrentRow.Cells["CodJe"].Value);
            string nombre = dvgJuntaEscolar.CurrentRow.Cells["NomJe"].Value.ToString();

            var confirm = MessageBox.Show(
                $"¿Está seguro que desea eliminar al miembro '{nombre}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    dalJunta.Eliminar(codJe);

                    MessageBox.Show("Registro eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarJuntaEscolar();
                    DatosActualizados?.Invoke();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

}
