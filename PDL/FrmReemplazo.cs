using CONASIS.BDL;
using CONASIS.DAL;
using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;


namespace CONASIS.PDL
{
    public partial class FrmReemplazo : Form
    {
        private readonly DAL_Motivo dalMotivo = new DAL_Motivo();
        private int idSeleccionado = 0; // 0 => nuevo, >0 => editar
        public FrmReemplazo()
        {
            InitializeComponent();
            dgvReemplazos.SelectionChanged += dgvReemplazos_SelectionChanged;
        }
        private void FrmReemplazo_Load(object sender, EventArgs e)
        {
            CargarMotivos();
            CargarReemplazantes();
            CargarPlanteles();
            CargarDatos();
            LimpiarFormulario();
        }
        private void CargarMotivos()
        {
            DataTable dt = dalMotivo.Listar();
            cbxMotivo.DataSource = dt;
            cbxMotivo.DisplayMember = "motivo";
            cbxMotivo.ValueMember = "codmotivo";
            cbxMotivo.SelectedIndex = -1;
        }

        private void btnReemplazante_Click(object sender, EventArgs e)
        {
            frmReemplazante formReemplazante = new frmReemplazante();
            formReemplazante.StartPosition = FormStartPosition.CenterParent; // Centro respecto a FrmReemplazo
            formReemplazante.ShowDialog(this); // "this" es FrmReemplazo
        }



        private void btnmotivo_Click(object sender, EventArgs e)
        {
            frmMotivo formMotivo = new frmMotivo();
            formMotivo.StartPosition = FormStartPosition.CenterParent;
            formMotivo.ShowDialog(this);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxSolicita.SelectedValue == null || cbxReemplazante.SelectedValue == null || cbxMotivo.SelectedValue == null)
                {
                    MessageBox.Show("Complete los campos obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idPlantelSolicita = Convert.ToInt32(cbxSolicita.SelectedValue);

                // obtenemos fila seleccionada del combo reemplazante (DataRowView)
                DataRowView drv = cbxReemplazante.SelectedItem as DataRowView;
                int? idReemplazante = null;
                int? idPlantelReemplazante = null;
                if (drv != null)
                {
                    string tipo = drv["Tipo"].ToString();
                    int codigo = Convert.ToInt32(drv["Codigo"]);
                    if (tipo == "EXTERNO")
                        idReemplazante = codigo;
                    else
                        idPlantelReemplazante = codigo;
                }

                DateTime fechaSolicitud = datetimeSol.Value.Date;
                DateTime fechaInicio = datetimeini.Value.Date;
                DateTime fechaFin = datetimefin.Value.Date;
                int idMotivo = Convert.ToInt32(cbxMotivo.SelectedValue);

                BDL_Reemplazo bdl = new BDL_Reemplazo();

                if (idSeleccionado == 0)
                {
                    bdl.Agregar(idPlantelSolicita, idReemplazante, idPlantelReemplazante,
                    fechaSolicitud, fechaInicio, fechaFin, idMotivo);

                    MessageBox.Show("Reemplazo agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    bdl.Modificar(idSeleccionado, idPlantelSolicita, idReemplazante, idPlantelReemplazante,
                                  fechaSolicitud, fechaInicio, fechaFin, idMotivo);
                    MessageBox.Show("Reemplazo modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CargarDatos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el reemplazo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarReemplazos()
        {
            DAL_Reemplazo dal = new DAL_Reemplazo();
            dgvReemplazos.DataSource = dal.Listar();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void dgvReemplazos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReemplazos.CurrentRow == null) return;

            DataGridViewRow row = dgvReemplazos.CurrentRow;
            idSeleccionado = Convert.ToInt32(row.Cells["IdReemplazo"].Value);

            // Plantel que solicita (usa el ValueMember "Codigo" del dt de planteles)
            if (row.Cells["IdPlantelSolicita"].Value != DBNull.Value)
                cbxSolicita.SelectedValue = Convert.ToInt32(row.Cells["IdPlantelSolicita"].Value);
            else
                cbxSolicita.SelectedIndex = -1;

            // Motivo
            if (row.Cells["IdMotivo"].Value != DBNull.Value)
                cbxMotivo.SelectedValue = Convert.ToInt32(row.Cells["IdMotivo"].Value);
            else
                cbxMotivo.SelectedIndex = -1;

            // Fechas
            if (row.Cells["FechaSolicitud"].Value != DBNull.Value) datetimeSol.Value = Convert.ToDateTime(row.Cells["FechaSolicitud"].Value);
            if (row.Cells["FechaInicio"].Value != DBNull.Value) datetimeini.Value = Convert.ToDateTime(row.Cells["FechaInicio"].Value);
            if (row.Cells["FechaFin"].Value != DBNull.Value) datetimefin.Value = Convert.ToDateTime(row.Cells["FechaFin"].Value);

            // Reemplazante: puede estar en IdReemplazante (externo) o en IdPlantelReemplazante (interno)
            if (row.Cells["IdReemplazante"].Value != DBNull.Value)
            {
                int idReemp = Convert.ToInt32(row.Cells["IdReemplazante"].Value);
                cbxReemplazante.SelectedValue = idReemp;
            }
            else if (row.Cells["IdPlantelReemplazante"].Value != DBNull.Value)
            {
                int idPlantelReemp = Convert.ToInt32(row.Cells["IdPlantelReemplazante"].Value);
                cbxReemplazante.SelectedValue = idPlantelReemp;
            }
            else
            {
                cbxReemplazante.SelectedIndex = -1;
            }
        }

        private void CargarReemplazantes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Codigo", typeof(int));
            dt.Columns.Add("NombreCompleto", typeof(string));
            dt.Columns.Add("Tipo", typeof(string));      // "PLANTEL" o "EXTERNO"
            dt.Columns.Add("IdPlantel", typeof(int));    // para plantel -> id, para externo -> DBNull

            // Internos: Plantel
            DAL_Plantel dalPlantel = new DAL_Plantel();
            DataTable dtPlantel = dalPlantel.ListarPlanteles(); // devuelve Codigo, NombreCompleto
            foreach (DataRow r in dtPlantel.Rows)
            {
                int codigo = Convert.ToInt32(r["codplantel"]);
                dt.Rows.Add(codigo, r["NombreCompleto"].ToString().Trim(), "PLANTEL", codigo);
            }

            // Externos: Reemplazantes
            DAL_Reemplazante dalReemp = new DAL_Reemplazante();
            DataTable dtReemp = dalReemp.Listar(); // debe devolver codreemplazante, nomreemp, appaterno, apmaterno
            foreach (DataRow r in dtReemp.Rows)
            {
                int codigo = Convert.ToInt32(r["codreemplazante"]);
                string nombre = $"{r["appaternoreemp"].ToString().Trim()} {r["apmaternoreemp"].ToString().Trim()} {r["nomreemp"].ToString().Trim()}";
                dt.Rows.Add(codigo, nombre.Trim(), "EXTERNO", DBNull.Value);
            }

            cbxReemplazante.DataSource = dt;
            cbxReemplazante.DisplayMember = "NombreCompleto";
            cbxReemplazante.ValueMember = "Codigo";
            cbxReemplazante.SelectedIndex = -1;

            cbxReemplazante.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbxReemplazante.AutoCompleteSource = AutoCompleteSource.ListItems;
        }


        private void CargarPlanteles()
        {
            DAL_Plantel dal = new DAL_Plantel();
            DataTable dt = dal.ListarPlanteles();

            cbxSolicita.DataSource = dt;          // tabla que viene de SQL
            cbxSolicita.DisplayMember = "NombreCompleto"; // lo que ve el usuario
            cbxSolicita.ValueMember = "codplantel";       // lo que se guarda en SelectedValue

            cbxSolicita.SelectedIndex = -1;              // para que salga vacío

          
            cbxSolicita.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbxSolicita.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void CargarDatos()
        {
            DAL_Reemplazo dal = new DAL_Reemplazo();
            DataTable dt = dal.Listar();
            dgvReemplazos.DataSource = dt;

          
            // ocultar columnas id si quieres:
            if (dgvReemplazos.Columns.Contains("IdPlantelSolicita")) dgvReemplazos.Columns["IdPlantelSolicita"].Visible = false;
            if (dgvReemplazos.Columns.Contains("IdReemplazante")) dgvReemplazos.Columns["IdReemplazante"].Visible = false;
            if (dgvReemplazos.Columns.Contains("IdPlantelReemplazante")) dgvReemplazos.Columns["IdPlantelReemplazante"].Visible = false;
            if (dgvReemplazos.Columns.Contains("IdMotivo")) dgvReemplazos.Columns["IdMotivo"].Visible = false;

            if (dgvReemplazos.Columns.Contains("IdReemplazo"))
                dgvReemplazos.Columns["IdReemplazo"].HeaderText = "Código";

            if (dgvReemplazos.Columns.Contains("PlantelSolicitaNo"))
                dgvReemplazos.Columns["PlantelSolicitaNo"].HeaderText = "Solicita";

            if (dgvReemplazos.Columns.Contains("ReemplazanteNombre"))
                dgvReemplazos.Columns["ReemplazanteNombre"].HeaderText = "Reemplazante";

            if (dgvReemplazos.Columns.Contains("FechaSolicitud"))
                dgvReemplazos.Columns["FechaSolicitud"].HeaderText = "Solicitud";

            if (dgvReemplazos.Columns.Contains("FechaInicio"))
                dgvReemplazos.Columns["FechaInicio"].HeaderText = "Inicio";

            if (dgvReemplazos.Columns.Contains("FechaFin"))
                dgvReemplazos.Columns["FechaFin"].HeaderText = "Fin";

            if (dgvReemplazos.Columns.Contains("MotivoNombre"))
                dgvReemplazos.Columns["MotivoNombre"].HeaderText = "Motivo";

            dgvReemplazos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReemplazos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }
        private void LimpiarFormulario()
        {
            idSeleccionado = 0;
            cbxSolicita.SelectedIndex = -1;
            cbxReemplazante.SelectedIndex = -1;
            cbxMotivo.SelectedIndex = -1;
            datetimeSol.Value = DateTime.Today;
            datetimeini.Value = DateTime.Today;
            datetimefin.Value = DateTime.Today;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvReemplazos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // dgvReemplazos_SelectionChanged ya llenó los controles y puso idSeleccionado
            MessageBox.Show("Datos cargados en el formulario. Modifique los campos y presione Aceptar para guardar.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvReemplazos.CurrentRow != null)
            {
                int idReemplazo = Convert.ToInt32(dgvReemplazos.CurrentRow.Cells["IdReemplazo"].Value);

                var confirm = MessageBox.Show("¿Está seguro de eliminar este reemplazo?",
                                              "Confirmar eliminación",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    BDL_Reemplazo bdl = new BDL_Reemplazo();
                    bdl.Eliminar(idReemplazo);

                    MessageBox.Show("Reemplazo eliminado correctamente.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarDatos(); // refresca la grilla
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un reemplazo de la lista.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
