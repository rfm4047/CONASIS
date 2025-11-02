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
            // Si ya hay uno dentro, lo quitamos (evita duplicados)
            foreach (Control c in panelContenido.Controls.OfType<Form>().ToList())
            {
                panelContenido.Controls.Remove(c);
                c.Dispose();
            }

            var frm = new frmNHorario(this);    // <-- paso explícito del padre
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            panelContenido.Controls.Add(frm);
            panelContenido.Tag = frm;

            // Cuando se cierre el form hijo: removemos del panel y recargamos
            frm.FormClosed += (s, ev) =>
            {
                if (panelContenido.Controls.Contains(frm)) panelContenido.Controls.Remove(frm);
                // refrescar el DataGridView
                this.CargarHorarios();
                this.Focus();
            };

            frm.Show();
            frm.BringToFront();

        }

        private void frmHorario_Load(object sender, EventArgs e)
        {
            CargarHorarios();
            

        }
        public void CargarHorarios()
        {
            BDL_HorarioDocente bdlDoc = new BDL_HorarioDocente();
            BDL_HorarioAdministrativo bdlAdm = new BDL_HorarioAdministrativo();

            DataTable dtDoc = bdlDoc.MostrarMensual();
            DataTable dtAdm = bdlAdm.MostrarMensual();

            DataTable dtUnido = new DataTable();
            dtUnido.Columns.Add("Categoria", typeof(string));
            dtUnido.Columns.Add("Codigo", typeof(string));
            dtUnido.Columns.Add("NombreCompleto", typeof(string));
            dtUnido.Columns.Add("TotalHoras", typeof(decimal));

            // 🔹 Agregar columnas de Id ocultas
            dtUnido.Columns.Add("IdPersonal", typeof(int));   // para administrativos
            dtUnido.Columns.Add("IdDocente", typeof(int));    // para docentes

            foreach (DataRow r in dtAdm.Rows)
                dtUnido.Rows.Add(
                    "Administrativo",
                    r["Codigo"].ToString(),
                    r["NombreCompleto"].ToString(),
                    r["TotalHoras"] != DBNull.Value ? Convert.ToDecimal(r["TotalHoras"]) : 0,
                    r["IdPersonal"],   // <-- aquí asignamos el Id
                    DBNull.Value       // IdDocente vacío
                );

            foreach (DataRow r in dtDoc.Rows)
                dtUnido.Rows.Add(
                    "Docente",
                    r["cplant"].ToString(),
                    r["NombreCompleto"].ToString(),
                    r["TotalHoras"] != DBNull.Value ? Convert.ToDecimal(r["TotalHoras"]) : 0,
                     DBNull.Value,      // IdPersonal vacío
                     r["IdDocente"]     // <-- Id del docente
                );

            dgvHorario.DataSource = dtUnido;

            dgvHorario.Columns["Categoria"].HeaderText = "Categoría";
            dgvHorario.Columns["Codigo"].HeaderText = "Código";
            dgvHorario.Columns["NombreCompleto"].HeaderText = "Nombre Completo";
            dgvHorario.Columns["TotalHoras"].HeaderText = "Total Horas Mes";

            dgvHorario.Columns["IdPersonal"].Visible = false;
            dgvHorario.Columns["IdDocente"].Visible = false;
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
            if (dgvHorario.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un personal para editar.");
                return;
            }

            string categoria = dgvHorario.CurrentRow.Cells["Categoria"].Value.ToString();
            string codigo = dgvHorario.CurrentRow.Cells["Codigo"].Value.ToString();

            int id = 0;
            try
            {
                if (categoria == "Administrativo")
                {
                    if (dgvHorario.Columns.Contains("IdPersonal"))
                        id = Convert.ToInt32(dgvHorario.CurrentRow.Cells["IdPersonal"].Value);
                    else if (dgvHorario.Columns.Contains("IdAdm"))
                        id = Convert.ToInt32(dgvHorario.CurrentRow.Cells["IdAdm"].Value);
                    else
                    {
                        MessageBox.Show("No se encontró la columna de Id para administrativos.");
                        return;
                    }
                }
                else // Docente
                {
                    if (dgvHorario.Columns.Contains("IdDocente"))
                        id = Convert.ToInt32(dgvHorario.CurrentRow.Cells["IdDocente"].Value);
                    else
                    {
                        MessageBox.Show("No se encontró la columna de Id para docentes.");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el Id: " + ex.Message);
                return;
            }

            // Abrir frmNHorario fijado al formulario padre y cargar los datos
            frmNHorario frm = new frmNHorario(this); // 🔹 pasar el padre
            frm.CargarHorarioExistente(id, codigo);   // 🔹 cargar datos automáticamente
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            // Agregar al panel del padre
            if (!panelContenido.Controls.Contains(frm))
            {
                panelContenido.Controls.Add(frm);
            }
            frm.BringToFront();
            frm.Show();
        }




    }
}
