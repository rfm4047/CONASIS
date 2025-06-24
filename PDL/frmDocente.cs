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
        DateTimePicker dt = new DateTimePicker();

        public frmDocente()
        {
            InitializeComponent();

            // Suscribirse al evento que se lanza cuando el DataGridView termina de enlazar datos
            dgvDocente.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgvDocente_DataBindingComplete);
        }

        private void dgvDocente_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            AccionesTabla();
        }


        private void AbrirFormularioNieto<MiForm>() where MiForm : Form, new()
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
                //formulario.FormClosed += new FormClosedEventHandler(FormClosed);
            }
            else
                formulario.BringToFront();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirFormularioNieto<frmNDocente>();
        }

        public void mostrarDocente()
        {
            BDL_Docente doc = new BDL_Docente();
            dgvDocente.DataSource = doc.mostrarDocente(); 

        }

        public void AccionesTabla()
        {
            // Mostrar el número de fila
            dgvDocente.RowHeadersVisible = true;
            
            dgvDocente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Ocultar ID interno (si existe)
            if (dgvDocente.Columns.Contains("iddocente"))
                dgvDocente.Columns["iddocente"].Visible = false;

            // Cambiar encabezados para que se vea más claro al usuario
            if (dgvDocente.Columns.Contains("nomplantel"))
                dgvDocente.Columns["nomplantel"].HeaderText = "Nombre";
                dgvDocente.Columns["nomplantel"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (dgvDocente.Columns.Contains("applantel"))
                dgvDocente.Columns["applantel"].HeaderText = "Apellido Paterno";

            if (dgvDocente.Columns.Contains("amplantel"))
                dgvDocente.Columns["amplantel"].HeaderText = "Apellido Materno";

            if (dgvDocente.Columns.Contains("itemplantel"))
                dgvDocente.Columns["itemplantel"].HeaderText = "Item";

            if (dgvDocente.Columns.Contains("rdaplantel"))
                dgvDocente.Columns["rdaplantel"].HeaderText = "RDA";

            if (dgvDocente.Columns.Contains("cargahorariadocente"))
                dgvDocente.Columns["cargahorariadocente"].HeaderText = "Carga Horaria";

            if (dgvDocente.Columns.Contains("horaplanilla"))
                dgvDocente.Columns["horaplanilla"].HeaderText = "Hora Planilla";

            // Limpiar selección
            dgvDocente.ClearSelection();
        }

        private void frmDocente_Load(object sender, EventArgs e)
        {
            mostrarDocente();
            dgvDocente.Refresh();
         //   AccionesTabla();
        }



        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDocente.SelectedRows.Count > 0)
            {
                int iddocente = Convert.ToInt32(dgvDocente.CurrentRow.Cells["iddocente"].Value);

                BDL_Docente doc = new BDL_Docente();
                DataTable dtDocente = doc.obtenerDocenteCompleto(iddocente);

                if (dtDocente.Rows.Count > 0)
                {
                    DataRow row = dtDocente.Rows[0];

                    frmNDocente frm = new frmNDocente();
                    frm.Editar = true;

                    // Asignar datos a controles
                    frm.IdPDoc = row["iddocente"].ToString();
                    frm.txtNombre.Text = row["nomplantel"].ToString();
                    frm.txtApPaterno.Text = row["applantel"].ToString();
                    frm.txtMaterno.Text = row["amplantel"].ToString();
                    frm.cbxGenero.Text = row["generoplantel"].ToString();
                    frm.txtCarnet.Text = row["ciplantel"].ToString();
                    frm.cbxExtension.Text = row["extplantel"].ToString();
                    frm.txtTelefono.Text = row["telfplantel"].ToString();
                    frm.dtpFechaNac.Value = Convert.ToDateTime(row["fechanacplantel"]);
                    frm.txtDireccion.Text = row["direccionplantel"].ToString();
                    frm.txtEspecialidad.Text = row["especialidadplantel"].ToString();
                    frm.txtItem.Text = row["itemplantel"].ToString();
                    frm.txtRda.Text = row["rdaplantel"].ToString();
                    frm.txtCargaHoraria.Text = row["cargahorariadocente"].ToString();
                    frm.txtHrPlanilla.Text = row["horaplanilla"].ToString();

                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No se pudo obtener los datos del docente.");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila.");
            }

        }



        private void dt_TextChanged(Object sender, EventArgs e)
            {
       
            dgvDocente.CurrentCell.Value = dt.Text.ToString();

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
