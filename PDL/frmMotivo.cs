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

namespace CONASIS.PDL
{
    public partial class frmMotivo : Form
    {
        private readonly DAL_Motivo dalMotivo = new DAL_Motivo();
        private int idSeleccionado = 0; // 0 = nuevo, >0 = editar

        // 👉 Evento que avisará a Reemplazos que se actualizaron los datos
        public event Action DatosActualizados;

        public frmMotivo()
        {
            InitializeComponent();
        }
        
        private void CargarMotivos()
        {
            try
            {
                DataTable dt = dalMotivo.Listar();
                dgvMotivo.DataSource = dt;

                if (dt != null && dt.Columns.Count > 0)
                {
                    dgvMotivo.Columns["CodMotivo"].Visible = false;
                    dgvMotivo.Columns["CMot"].HeaderText = "Código";
                    dgvMotivo.Columns["Motivo"].HeaderText = "Descripción";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar motivos: " + ex.Message);
            }
        }
        private void ConfigurarGrid()
        {
            if (dgvMotivo.Columns.Count > 0)
            {
                dgvMotivo.Columns["CodMotivo"].Visible = false; // ocultar ID
                dgvMotivo.Columns["CMot"].HeaderText = "Código";
                dgvMotivo.Columns["Motivo"].HeaderText = "Motivo";

                dgvMotivo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvMotivo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }



        private void LimpiarFormulario()
        {
            txtMotivo.Clear();
            idSeleccionado = 0;
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // 🔹 VALIDACIONES ANTES de guardar
            if (string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show("Debe ingresar un motivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // 👈 Detiene aquí, no sigue ejecutando
            }

            try
            {
                if (idSeleccionado == 0)
                {
                    var nuevo = dalMotivo.Agregar(txtMotivo.Text.Trim());
                    MessageBox.Show($"Motivo agregado correctamente: {nuevo.CMot} - {nuevo.Motivo}");
                }
                else
                {
                    var editado = dalMotivo.Modificar(idSeleccionado, txtMotivo.Text.Trim());
                    MessageBox.Show($"Motivo actualizado correctamente: {editado.CMot} - {editado.Motivo}");
                }

                // 🔹 Refresca el grid
                CargarMotivos();
                LimpiarFormulario();
                DatosActualizados?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMotivo.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un motivo para eliminar.");
                return;
            }

            int id = Convert.ToInt32(dgvMotivo.CurrentRow.Cells["CodMotivo"].Value);
            string descripcion = dgvMotivo.CurrentRow.Cells["Motivo"].Value.ToString();

            var confirm = MessageBox.Show(
                $"¿Seguro de eliminar el motivo '{descripcion}'?",
                "Confirmar",
                MessageBoxButtons.YesNo
            );


            if (confirm == DialogResult.Yes)
            {
                try
                {
                    dalMotivo.Eliminar(id);
                    MessageBox.Show("Motivo eliminado correctamente.");
                    CargarMotivos();
                    DatosActualizados?.Invoke();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void frmMotivo_Load(object sender, EventArgs e)
        {
            CargarMotivos();
            ConfigurarGrid();
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (dgvMotivo.CurrentRow != null)
            {
                idSeleccionado = Convert.ToInt32(dgvMotivo.CurrentRow.Cells["CodMotivo"].Value);
                txtMotivo.Text = dgvMotivo.CurrentRow.Cells["Motivo"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un registro para editar.");
            }
        }
    }
}
