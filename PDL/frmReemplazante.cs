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
    public partial class frmReemplazante : Form
    {
        private DAL_Reemplazante dalReemplazante = new DAL_Reemplazante();
        private int codReemplazanteSeleccionado = 0;
        public frmReemplazante()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            codReemplazanteSeleccionado = 0;
            txtCodigo.Clear();
            txtNombre.Clear();
            txtApPaterno.Clear();
            txtApMaterno.Clear();
        }
        private void ConfigurarGrid()
        {
            if (dgvReemplazante.Columns.Count > 0)
            {
                dgvReemplazante.Columns["codreemplazante"].Visible = false; // ocultar ID
                dgvReemplazante.Columns["creemp"].HeaderText = "Código";
                dgvReemplazante.Columns["nomreemp"].HeaderText = "Nombre";
                dgvReemplazante.Columns["appaternoreemp"].HeaderText = "Apellido Paterno";
                dgvReemplazante.Columns["apmaternoreemp"].HeaderText = "Apelido Materno";

                dgvReemplazante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvReemplazante.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
               string.IsNullOrWhiteSpace(txtApPaterno.Text) ||
               string.IsNullOrWhiteSpace(txtApMaterno.Text))
            {
                MessageBox.Show("Complete todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (codReemplazanteSeleccionado == 0) // AGREGAR
            {
                dalReemplazante.Agregar(txtNombre.Text.Trim(), txtApPaterno.Text.Trim(), txtApMaterno.Text.Trim());
                MessageBox.Show("Reemplazante agregado correctamente.");
            }
            else // MODIFICAR
            {
                dalReemplazante.Modificar(codReemplazanteSeleccionado, txtNombre.Text.Trim(), txtApPaterno.Text.Trim(), txtApMaterno.Text.Trim());
                MessageBox.Show("Reemplazante actualizado correctamente.");
            }

            Limpiar();
            CargarReemplazantes();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvReemplazante.CurrentRow != null)
            {
                codReemplazanteSeleccionado = Convert.ToInt32(dgvReemplazante.CurrentRow.Cells["codreemplazante"].Value);
                txtCodigo.Text = codReemplazanteSeleccionado.ToString();
                txtNombre.Text = dgvReemplazante.CurrentRow.Cells["nomreemp"].Value.ToString();
                txtApPaterno.Text = dgvReemplazante.CurrentRow.Cells["appaternoreemp"].Value.ToString();
                txtApMaterno.Text = dgvReemplazante.CurrentRow.Cells["apmaternoreemp"].Value.ToString();
            }
        }

        private void frmReemplazante_Load(object sender, EventArgs e)
        {
            CargarReemplazantes();
            ConfigurarGrid();
        }
        private void CargarReemplazantes()
        {
            DataTable dt = dalReemplazante.Listar();
            dgvReemplazante.DataSource = dt;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvReemplazante.CurrentRow != null)
            {
                int cod = Convert.ToInt32(dgvReemplazante.CurrentRow.Cells["codreemplazante"].Value);
                dalReemplazante.Eliminar(cod);
                MessageBox.Show("Reemplazante eliminado correctamente.");

                CargarReemplazantes();
            }
        }
    }
}
