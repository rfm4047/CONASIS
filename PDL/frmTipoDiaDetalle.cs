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

    public partial class frmTipoDiaDetalle : Form
    {
        private int cod_gestion;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private bool modoEdicion = false;
        private int idTipoDiaSeleccionado = 0;


      
        public frmTipoDiaDetalle(DateTime fechaInicio, DateTime fechaFin, int cod_gestion)
        {
            InitializeComponent();
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.cod_gestion = cod_gestion;
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        // 🔹 Load del formulario
        private void frmTipoDiaDetalle_Load_1(object sender, EventArgs e)
        {
            dtTipodiaFechaInicio.Value = fechaInicio;
            dtTipodiaFechaFin.Value = fechaFin;
            CargarComboTipoDia();
            CargarFeriados();
            LimpiarCampos();
          
        }


        // 🔹 Botón Aceptar → agregar o modificar
        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (cbxtipodia.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un tipo de día.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime fi = dtTipodiaFechaInicio.Value.Date;
                DateTime ff = dtTipodiaFechaFin.Value.Date;

                if (ff < fi)
                {
                    MessageBox.Show("La fecha fin no puede ser menor a la fecha inicio.");
                    return;
                }

                string motivo = txtMotivo.Text.Trim();
                int codCatTipo = Convert.ToInt32(cbxtipodia.SelectedValue);

                BDL_TipoDia bdlTipo = new BDL_TipoDia();
                int nuevoID = 0;

                if (!modoEdicion)
                {
                    // ➕ AGREGAR nuevo tipo de día
                    nuevoID = bdlTipo.Agregar(cod_gestion, codCatTipo, motivo, fi, ff);
                    MessageBox.Show($"Tipo de día agregado (ID: {nuevoID}).");
                }
                else
                {
                    // ✏️ MODIFICAR existente
                    bdlTipo.Modificar(idTipoDiaSeleccionado, cod_gestion, codCatTipo, motivo, fi, ff);
                    MessageBox.Show("Registro actualizado correctamente.");
                    modoEdicion = false;
                }

                // 🔹 Ahora insertar en Calendario_Escolar todas las fechas del rango
                BDL_CalendarioEscolar bdlCal = new BDL_CalendarioEscolar();

                for (DateTime d = fi; d <= ff; d = d.AddDays(1))
                {
                    bdlCal.Agregar(d, codCatTipo, motivo, cod_gestion);
                }

                MessageBox.Show("Fechas registradas en el calendario escolar.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

              
                CargarFeriados();
                LimpiarCampos();
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

        // 🔹 Botón Editar → cargar datos
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvTipoDia.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro para editar.");
                return;
            }

            idTipoDiaSeleccionado = Convert.ToInt32(dgvTipoDia.CurrentRow.Cells["cod_tipodia"].Value);
            dtTipodiaFechaInicio.Value = Convert.ToDateTime(dgvTipoDia.CurrentRow.Cells["fecha_inicio"].Value);
            dtTipodiaFechaFin.Value = Convert.ToDateTime(dgvTipoDia.CurrentRow.Cells["fecha_fin"].Value);
            cbxtipodia.Text = dgvTipoDia.CurrentRow.Cells["nom_cattipo"].Value.ToString();
            txtMotivo.Text = dgvTipoDia.CurrentRow.Cells["descripcion"].Value.ToString();
            modoEdicion = true;
        }
    

        // 🔹 Botón Eliminar
        
        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dgvTipoDia.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro para eliminar.");
                return;
            }

            int cod = Convert.ToInt32(dgvTipoDia.CurrentRow.Cells["cod_tipodia"].Value);
            string tipo = dgvTipoDia.CurrentRow.Cells["nom_cattipo"].Value.ToString();

            if (MessageBox.Show($"¿Eliminar el registro de tipo '{tipo}'?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                BDL_TipoDia bdl = new BDL_TipoDia();
                bdl.Eliminar(cod);
                MessageBox.Show("Registro eliminado correctamente.");
                CargarFeriados();
            }
        }
        private void CargarComboTipoDia()
        {
            try
            {
                BDL_CatTipoDia bdl = new BDL_CatTipoDia();
                DataTable dt = bdl.Mostrar();

                cbxtipodia.DataSource = dt;
                cbxtipodia.DisplayMember = "nom_cattipo";   
                cbxtipodia.ValueMember = "cod_cattipo";
                cbxtipodia.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tipos de día: " + ex.Message);
            }
        }
        private void CargarFeriados()
        {
            try
            {
                BDL_TipoDia bdl = new BDL_TipoDia();
                DataTable dt = bdl.Mostrar(cod_gestion);

                dgvTipoDia.DataSource = dt;
                dgvTipoDia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTipoDia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvTipoDia.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar feriados: " + ex.Message);
            }
        }
        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtMotivo.Clear();
            cbxtipodia.SelectedIndex = -1;
            dtTipodiaFechaInicio.Value = DateTime.Today;
            dtTipodiaFechaFin.Value = DateTime.Today;
            modoEdicion = false;
            idTipoDiaSeleccionado = 0;
        }
        private void CargarTiposDia()
        {
            try
            {
                BDL_CatTipoDia obj = new BDL_CatTipoDia();
                DataTable dt = obj.Mostrar();  // Debe retornar los registros activos de Cat_TipoDia

                cbxtipodia.DataSource = dt;
                cbxtipodia.DisplayMember = "nombre";      // Texto que se muestra
                cbxtipodia.ValueMember = "cod_cattipo";   // Valor asociado
                cbxtipodia.SelectedIndex = -1;            // Ningún seleccionado al inicio
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tipos de día: " + ex.Message);
            }
        }
        

    }
}
