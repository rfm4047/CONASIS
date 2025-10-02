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
    public partial class frmHorario : Form
    {
        public frmHorario()
        {
            InitializeComponent();
        }
        private MiForm AbrirFormularioNieto<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelContenido.Controls.OfType<MiForm>().FirstOrDefault();// Busca en la coleccion del formulario
            //si el formularion/ instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelContenido.Controls.Add(formulario);
                panelContenido.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                // formulario.FormClosed += new FormClosedEventHandler(FormClosed);
            }
            else
            {
                formulario.BringToFront();
            }
            return (MiForm)formulario;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNHorario frm = new frmNHorario();
            frm.Owner = this;   // ✅ ahora la ventana "hija" conoce a su padre
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(frm);
            panelContenido.Tag = frm;
            frm.Show();
            frm.BringToFront();

        }

        private void frmHorario_Load(object sender, EventArgs e)
        {
            CargarHorarios();
            

        }
        public void CargarHorarios()
        {
            BDL_HorarioAdministrativo bdl = new BDL_HorarioAdministrativo();
            dgvHorario.DataSource = bdl.MostrarResumen();

            if (dgvHorario.Columns.Contains("NombreCompleto"))
                dgvHorario.Columns["NombreCompleto"].HeaderText = "Nombre Completo";

            if (dgvHorario.Columns.Contains("TotalHoras"))
                dgvHorario.Columns["TotalHoras"].HeaderText = "Tiempo Total (hrs)";

            if (dgvHorario.Columns.Contains("idAdm"))
                dgvHorario.Columns["idAdm"].Visible = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvHorario.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un administrativo para eliminar su horario.");
                return;
            }

            string codigo = dgvHorario.CurrentRow.Cells["Codigo"].Value.ToString();
            int idAdm = Convert.ToInt32(dgvHorario.CurrentRow.Cells["IdAdm"].Value);

            if (MessageBox.Show($"¿Está seguro de eliminar todos los horarios del administrativo {codigo}?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                BDL_HorarioAdministrativo bdl = new BDL_HorarioAdministrativo();
                bdl.EliminarTodos(idAdm);  // 🔹 nuevo método que llama a "ELIMINAR_TODOS"
                MessageBox.Show("Horarios eliminados correctamente.");
                CargarHorarios();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvHorario.CurrentRow != null)
            {
                int idAdm = Convert.ToInt32(dgvHorario.CurrentRow.Cells["idAdm"].Value);

                frmNHorario frm = new frmNHorario();
                frm.Owner = this;
                frm.CargarHorarioExistente(idAdm); // 🔹 nuevo método en frmNHorario
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un administrativo para editar.");
            }
        }
    }
}
