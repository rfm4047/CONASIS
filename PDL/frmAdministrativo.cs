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
    public partial class frmAdministrativo : Form
    {
        private readonly BDL_Administrativo bdl;

        public frmAdministrativo()
        {
            InitializeComponent();
            bdl = new BDL_Administrativo();
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

                //  Si es frmNAdministrativo, enganchar el evento
                if (formulario is frmNAdministrativo frmNuevoAdministrativo)
                {
                    frmNuevoAdministrativo.AdministrativoAgregado += (s, args) =>
                    {
                        // Refresca la grilla
                        dgvAdm.DataSource = bdl.ListarAdministrativoConPlantel();
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
            if (formulario is frmNAdministrativo frmNuevoAdministrativo)
            {
                frmNuevoAdministrativo.AdministrativoAgregado += (s, args) =>
                {
                    dgvAdm.DataSource = bdl.ListarAdministrativoConPlantel();
                };
            }

            formulario.Show();
            formulario.BringToFront();
        }
       

        private void frmAdministrativo_Load(object sender, EventArgs e)
        {
            dgvAdm.RowPostPaint += dgvAdm_RowPostPaint;

            dgvAdm.DataSource = bdl.ListarAdministrativoConPlantel();
            // Ajusta automáticamente el ancho de cada columna al contenido
            dgvAdm.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            // CENTRAR ENCABEZADOS DE LA TABLA
            dgvAdm.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (dgvAdm.Columns.Contains("idadm"))
                dgvAdm.Columns["idadm"].Visible = false;

            // Configuración de columnas 
            if (dgvAdm.Columns.Contains("cplant"))
                dgvAdm.Columns["cplant"].HeaderText = "Código Plantel";
            if (dgvAdm.Columns.Contains("nomplantel"))
                dgvAdm.Columns["nomplantel"].HeaderText = "Nombre";
            if (dgvAdm.Columns.Contains("applantel"))
                dgvAdm.Columns["applantel"].HeaderText = "Apellido Paterno";
            if (dgvAdm.Columns.Contains("amplantel"))
                dgvAdm.Columns["amplantel"].HeaderText = "Apellido Materno";
            if (dgvAdm.Columns.Contains("itemplantel"))
                dgvAdm.Columns["itemplantel"].HeaderText = "Item";
            if (dgvAdm.Columns.Contains("rdaplantel"))
                dgvAdm.Columns["rdaplantel"].HeaderText = "RDA";
            if (dgvAdm.Columns.Contains("cargoadm"))
                dgvAdm.Columns["cargoadm"].HeaderText = "Cargo";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirFormularioNieto<frmNAdministrativo>();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
           
        }
        private void dgvAdm_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (dgvAdm.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un administrativo para editar.");
                return;
            }
           
            // Asumiendo que en el DataGridView tienes una columna idadministrativo
            int idAdministrativo = Convert.ToInt32(dgvAdm.CurrentRow.Cells["idadm"].Value);
            var frm = new frmNAdministrativo(idAdministrativo);

            frm.AdministrativoAgregado += (s, args) =>
            {
                dgvAdm.DataSource = bdl.ListarAdministrativoConPlantel(); // refrescar la grilla
            };
            AbrirFormularioNieto(frm);
        }
    }
}
