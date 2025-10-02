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
    public partial class frmPeriodos : Form
    {
        private int codGestionActual;
        public frmPeriodos(int gestion)
        {
            InitializeComponent();
            codGestionActual = gestion;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            BDL_Periodo bdl = new BDL_Periodo();

            if (string.IsNullOrEmpty(txtcodperiodo.Text)) // Agregar
            {
                bdl.Agregar(txttipoperiodo.Text, txtNombrePeriodo.Text,
                            dtPeriodo_FechaInicio.Value, dtPeriodo_FechaFin.Value, codGestionActual);
                MessageBox.Show("Periodo agregado correctamente.");
            }
            else // Modificar
            {
                int codPeriodo = Convert.ToInt32(txtcodperiodo.Text);
                bdl.Modificar(codPeriodo, txttipoperiodo.Text, txtNombrePeriodo.Text,
                              dtPeriodo_FechaInicio.Value, dtPeriodo_FechaFin.Value, codGestionActual);
                MessageBox.Show("Periodo modificado correctamente.");
            }

            CargarPeriodos();
            LimpiarCampos();
        }

        private void frmPeriodos_Load(object sender, EventArgs e)
        {
            CargarPeriodos();
        }
        private void LimpiarCampos()
        {
            txtcodperiodo.Clear();
            txttipoperiodo.Clear();
            txtNombrePeriodo.Clear();
            dtPeriodo_FechaInicio.Value = DateTime.Today;
            dtPeriodo_FechaFin.Value = DateTime.Today;
        }

        private void CargarPeriodos()
        {
            BDL_Periodo bdl = new BDL_Periodo();
            dgvPeriodos.DataSource = bdl.Mostrar(codGestionActual);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvPeriodos.CurrentRow != null)
            {
                txtcodperiodo.Text = dgvPeriodos.CurrentRow.Cells["cod_periodo"].Value.ToString();
                txttipoperiodo.Text = dgvPeriodos.CurrentRow.Cells["tipo"].Value.ToString();
                txtNombrePeriodo.Text = dgvPeriodos.CurrentRow.Cells["nombre"].Value.ToString();
                dtPeriodo_FechaInicio.Value = Convert.ToDateTime(dgvPeriodos.CurrentRow.Cells["fechaini"].Value);
                dtPeriodo_FechaFin.Value = Convert.ToDateTime(dgvPeriodos.CurrentRow.Cells["fechafin"].Value);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPeriodos.CurrentRow != null)
            {
                int codPeriodo = Convert.ToInt32(dgvPeriodos.CurrentRow.Cells["cod_periodo"].Value);
                DialogResult r = MessageBox.Show("¿Está seguro de eliminar?",
                                                 "Confirmación",
                                                 MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    BDL_Periodo bdl = new BDL_Periodo();
                    bdl.Eliminar(codPeriodo);
                    MessageBox.Show("Periodo eliminado correctamente.");
                    CargarPeriodos();
                    LimpiarCampos();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
