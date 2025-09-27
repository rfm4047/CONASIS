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
    public partial class frmDocente : Form
    {

        private readonly BDL_Docente bdl;
        public frmDocente()
        {
            InitializeComponent();
            bdl = new BDL_Docente();
        }

        private void AbrirFormularioNieto<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelContenido.Controls.OfType<MiForm>().FirstOrDefault();

            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelContenido.Controls.Add(formulario);
                panelContenido.Tag = formulario;

                //  Si es frmNDocente, enganchar el evento
                if (formulario is frmNDocente frmNuevoDocente)
                {
                    frmNuevoDocente.DocenteAgregado += (s, args) =>
                    {
                        // Refrescar la grilla
                        dgvDocente.DataSource = bdl.ListarDocentesConPlantel();
                    };
                }

                formulario.Show();
                formulario.BringToFront();
            }
            else
            {
                formulario.BringToFront();
            }
        }
        private void AbrirFormularioNieto(Form formulario)
        {
            // Si ya hay un form abierto en el panel, opcionalmente lo cierras:
            var abierto = panelContenido.Controls.OfType<Form>().FirstOrDefault();
            if (abierto != null)
            {
                abierto.Close();
                panelContenido.Controls.Remove(abierto);
            }

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(formulario);
            panelContenido.Tag = formulario;

            // Si es frmNDocente engancha el evento como antes
            if (formulario is frmNDocente frmNuevoDocente)
            {
                frmNuevoDocente.DocenteAgregado += (s, args) =>
                {
                    dgvDocente.DataSource = bdl.ListarDocentesConPlantel();
                };
            }

            formulario.Show();
            formulario.BringToFront();
        }

        private void frmDocente_Load(object sender, EventArgs e)
        {
            dgvDocente.DataSource = bdl.ListarDocentesConPlantel();
            // Ajusta automáticamente el ancho de cada columna al contenido
            dgvDocente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            // CENTRAR ENCABEZADOS DE LA TABLA
            dgvDocente.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //  CENTRAR SOLO ESTAS DOS COLUMNAS
            if (dgvDocente.Columns.Contains("iddocente"))
                dgvDocente.Columns["iddocente"].Visible = false;

            if (dgvDocente.Columns.Contains("horaplanilla"))
                dgvDocente.Columns["horaplanilla"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (dgvDocente.Columns.Contains("cargahorariadocente"))
                dgvDocente.Columns["cargahorariadocente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 4️⃣ Configuración de nombres de encabezados si existen
            if (dgvDocente.Columns.Contains("cplant"))
                dgvDocente.Columns["cplant"].HeaderText = "Código Plantel";
            if (dgvDocente.Columns.Contains("nomplantel"))
                dgvDocente.Columns["nomplantel"].HeaderText = "Nombre";
            if (dgvDocente.Columns.Contains("applantel"))
                dgvDocente.Columns["applantel"].HeaderText = "Apellido Paterno";
            if (dgvDocente.Columns.Contains("amplantel"))
                dgvDocente.Columns["amplantel"].HeaderText = "Apellido Materno";
            if (dgvDocente.Columns.Contains("especialidadplantel"))
                dgvDocente.Columns["especialidadplantel"].HeaderText = "Especialidad";
            if (dgvDocente.Columns.Contains("itemplantel"))
                dgvDocente.Columns["itemplantel"].HeaderText = "Item";
            if (dgvDocente.Columns.Contains("rdaplantel"))
                dgvDocente.Columns["rdaplantel"].HeaderText = "RDA";
            if (dgvDocente.Columns.Contains("horaplanilla"))
                dgvDocente.Columns["horaplanilla"].HeaderText = "Hora Planilla";
            if (dgvDocente.Columns.Contains("cargahorariadocente"))
                dgvDocente.Columns["cargahorariadocente"].HeaderText = "Carga Horaria";
        }

        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirFormularioNieto<frmNDocente>();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDocente.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un docente para editar.");
                return;
            }
                               
            int idDocente = Convert.ToInt32(dgvDocente.CurrentRow.Cells["iddocente"].Value);
            var frm = new frmNDocente(idDocente);
        
            frm.DocenteAgregado += (s, args) =>
            {
                dgvDocente.DataSource = bdl.ListarDocentesConPlantel(); // refrescar la grilla
            };
            AbrirFormularioNieto(frm);
        }
        private void dgvDocente_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // Dibujar el número de fila en la cabecera
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);

            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
        
    }
}
