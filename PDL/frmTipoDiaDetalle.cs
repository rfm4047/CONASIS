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
        private int codGestion;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        public frmTipoDiaDetalle()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }   

        public frmTipoDiaDetalle(DateTime fechaInicio, DateTime fechaFin, int codGestion)
        {
            InitializeComponent();
            this.codGestion = codGestion;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;

        }

        private void frmTipoDiaDetalle_Load_1(object sender, EventArgs e)
        {
            txtFechaInicio.Text = fechaInicio.ToString("dd/MM/yyyy");
            txtFechaFin.Text = fechaFin.ToString("dd/MM/yyyy");

            txtFechaInicio.ReadOnly = true;
            txtFechaFin.ReadOnly = true;

            // 🔹 Cargar combo con los tipos de día desde la BD
            BDL_TipoDia bdl = new BDL_TipoDia();
            cbxtipodia.DataSource = bdl.Mostrar();
            cbxtipodia.DisplayMember = "nom_tipodia";
            cbxtipodia.ValueMember = "idtipodia";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (cbxtipodia.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un tipo de día.");
                return;
            }

            int idTipoDia = Convert.ToInt32(cbxtipodia.SelectedValue);
            string motivo = txtMotivo.Text.Trim();

            try
            {
                BDL_CalendarioEscolar bdlCal = new BDL_CalendarioEscolar();

                for (DateTime d = fechaInicio; d <= fechaFin; d = d.AddDays(1))
                {
                    bdlCal.Agregar(d, idTipoDia, motivo, codGestion);
                }

                MessageBox.Show("Tipo de día registrado correctamente.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void txtFecha_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
