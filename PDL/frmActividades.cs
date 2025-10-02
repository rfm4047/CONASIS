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
    public partial class frmActividades : Form
    {
        private readonly BDL_Actividad bdl = new BDL_Actividad();
        private int codGestionActual;
        public frmActividades(int gestion)
        {

            InitializeComponent();
            CargarActividades();
            codGestionActual = gestion;
        }
        private void CargarActividades()
        {
            dgvActividades.DataSource = bdl.Mostrar();
            dgvActividades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Cambiar nombres de cabeceras
            if (dgvActividades.Columns["cod_actividad"] != null)
                dgvActividades.Columns["cod_actividad"].HeaderText = "Código";

            if (dgvActividades.Columns["nombre"] != null)
                dgvActividades.Columns["nombre"].HeaderText = "Nombre Actividad";

            if (dgvActividades.Columns["fechaini"] != null)
                dgvActividades.Columns["fechaini"].HeaderText = "Fecha de Inicio";

            if (dgvActividades.Columns["fechafin"] != null)
                dgvActividades.Columns["fechafin"].HeaderText = "Fecha de Fin";

            dgvActividades.Columns["cod_gestion"].Visible = false;
            dgvActividades.Columns["nom_gestion"].Visible = false;
            dgvActividades.Columns["fechaini_gestion"].Visible = false;
            dgvActividades.Columns["fechafin_gestion"].Visible = false;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombreActividad.Text;
                DateTime fechaini = dtFechaInicioActividad.Value;
                DateTime fechafin = dtFechaFinActividad.Value;
                int codActividad = codGestionActual; // 🔹 reemplaza con el periodo que corresponda

                if (string.IsNullOrEmpty(txtCodActividad.Text))
                {
                    // Nuevo
                    if (bdl.Agregar(nombre, fechaini, fechafin, codActividad))
                        MessageBox.Show("Actividad registrada.");
                }
                else
                {
                    // Modificación
                    int cod = int.Parse(txtCodActividad.Text);
                    if (bdl.Modificar(cod, nombre, fechaini, fechafin, codActividad))
                        MessageBox.Show("Actividad modificada.");
                }

                CargarActividades();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvActividades.CurrentRow != null)
            {
                txtCodActividad.Text = dgvActividades.CurrentRow.Cells["cod_actividad"].Value.ToString();
                txtNombreActividad.Text = dgvActividades.CurrentRow.Cells["nombre"].Value.ToString();
                dtFechaInicioActividad.Value = Convert.ToDateTime(dgvActividades.CurrentRow.Cells["fechaini"].Value);
                dtFechaFinActividad.Value = Convert.ToDateTime(dgvActividades.CurrentRow.Cells["fechafin"].Value);
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvActividades.CurrentRow != null)
            {
                int cod = Convert.ToInt32(dgvActividades.CurrentRow.Cells["cod_actividad"].Value);
                DialogResult r = MessageBox.Show("¿Está seguro de eliminar?",
                                                "Confirmación",
                                                MessageBoxButtons.YesNo); 
                if (r == DialogResult.Yes)
                {
                    BDL_Actividad bdl = new BDL_Actividad();
                    bdl.Eliminar(cod);
                    MessageBox.Show("Actividad eliminado correctamente.");
                    CargarActividades();
                    LimpiarCampos();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.");
            }
        }
        private void LimpiarCampos()
        {
            txtCodActividad.Clear();
            txtNombreActividad.Clear();
            dtFechaInicioActividad.Value = DateTime.Now;
            dtFechaFinActividad.Value = DateTime.Now;
        }

    }
}
