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

namespace CONASIS.PDL
{
    public partial class frmCargoJuntaEscolar : Form
    {
        private readonly BDL_Cargo bdlCargo = new BDL_Cargo();

        // Evento que avisa cuando se actualizan datos
        public event Action DatosActualizados;

        public frmCargoJuntaEscolar()
        {
            InitializeComponent();
        }

        private void frmCargoJuntaEscolar_Load(object sender, EventArgs e)
        {
            dgvCargo.DataSource = bdlCargo.ObtenerCargos();
            ConfigurarGrid();

            txtCodigo.ReadOnly = true; // El código no se puede modificar manualmente
        }

        private void ConfigurarGrid()
        {
            if (dgvCargo.Columns.Count > 0)
            {
                dgvCargo.Columns["codcargo"].Visible = false; // ocultar ID
                dgvCargo.Columns["ccar"].HeaderText = "Código";
                dgvCargo.Columns["nomcargo"].HeaderText = "Cargo";

                dgvCargo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvCargo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtNombre.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Validación: campo vacío
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese un nombre de cargo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validación: nombre repetido
            foreach (DataGridViewRow row in dgvCargo.Rows)
            {
                if (row.Cells["nomcargo"].Value != null &&
                    row.Cells["nomcargo"].Value.ToString().Equals(txtNombre.Text, StringComparison.OrdinalIgnoreCase) &&
                    row.Cells["codcargo"].Value.ToString() != txtCodigo.Text) // evitar conflicto al editar
                {
                    MessageBox.Show("Ya existe un cargo con ese nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                // Crear
                bdlCargo.CrearCargo(txtNombre.Text);
                MessageBox.Show("Cargo agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Editar
                int id = int.Parse(txtCodigo.Text);
                bdlCargo.ModificarCargo(id, txtNombre.Text);
                MessageBox.Show("Cargo modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Refrescar grilla
            dgvCargo.DataSource = bdlCargo.ObtenerCargos();
            ConfigurarGrid();

            // Limpiar campos
            LimpiarCampos();

            // Avisar al padre que hubo cambios
            DatosActualizados?.Invoke();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCargo.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvCargo.CurrentRow.Cells["codcargo"].Value);

                var confirm = MessageBox.Show("¿Está seguro que desea eliminar este cargo?",
                    "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    bdlCargo.BorrarCargo(id);
                    dgvCargo.DataSource = bdlCargo.ObtenerCargos();
                    ConfigurarGrid();

                    MessageBox.Show("Cargo eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarCampos();
                    DatosActualizados?.Invoke();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cargo para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCargo.CurrentRow != null)
            {
                txtCodigo.Text = dgvCargo.CurrentRow.Cells["codcargo"].Value.ToString();
                txtNombre.Text = dgvCargo.CurrentRow.Cells["nomcargo"].Value.ToString().Trim(); 
            }
            else
            {
                MessageBox.Show("Seleccione un cargo para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvCargo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCodigo.Text = dgvCargo.Rows[e.RowIndex].Cells["codcargo"].Value.ToString();
                txtNombre.Text = dgvCargo.Rows[e.RowIndex].Cells["nomcargo"].Value.ToString().Trim();
            }
        }
    }
}
