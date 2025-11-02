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
    public partial class frmNCalendario : Form
    {
        int codGestionActual = 0;
        public frmNCalendario()
        {
            InitializeComponent();
        }
                     

        private void btnGenerarCalendario_Click_1(object sender, EventArgs e)
        {
            try
            {
                // 1. Insertar gestión
                BDL_Gestion bdlGestion = new BDL_Gestion();
                codGestionActual = bdlGestion.Agregar(txtGestion.Text, dtGestionInicio.Value, dtGestionFin.Value);

                txtCodGestion.Text = codGestionActual.ToString();

                // 2. Insertar calendario escolar (todos los días hábiles)
                BDL_CalendarioEscolar bdlCal = new BDL_CalendarioEscolar();
                for (DateTime d = dtGestionInicio.Value; d <= dtGestionFin.Value; d = d.AddDays(1))
                {
                    bdlCal.Agregar(d, 1, "Hábil", codGestionActual); // 1 = Tipo Día Hábil
                }

                MessageBox.Show("Calendario generado para gestión " + txtGestion.Text);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error en generación: " + ex.Message);
            }
        }

        private void btnSiguiente1_Click(object sender, EventArgs e)
        {
            if (tabControlCalendario.SelectedIndex < tabControlCalendario.TabCount - 1)
            {
                tabControlCalendario.SelectedIndex++;
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (tabControlCalendario.SelectedIndex > 0)
            {
                tabControlCalendario.SelectedIndex--;
            }
        }
        private void CargarFeriados()
        {
            BDL_CalendarioEscolar bdl = new BDL_CalendarioEscolar();
            DataTable dt = bdl.MostrarPorGestion(codGestionActual);

            var rows = dt.AsEnumerable()
                         .Where(r => r.Field<string>("tipo_dia") != "HÁBIL")  // 👈 CAMBIO AQUÍ
                         .OrderBy(r => r.Field<DateTime>("fecha"));

            if (rows.Any())
            {
                DataTable dtMostrar = new DataTable();
                dtMostrar.Columns.Add("Nro", typeof(int));
                dtMostrar.Columns.Add("Fecha Inicio", typeof(string));
                dtMostrar.Columns.Add("Fecha Fin", typeof(string));
                dtMostrar.Columns.Add("Motivo", typeof(string));

                int contador = 1;
                DateTime inicio = rows.First().Field<DateTime>("fecha");
                DateTime fin = inicio;
                string motivo = rows.First().Field<string>("motivo");

                foreach (var row in rows.Skip(1))
                {
                    DateTime fecha = row.Field<DateTime>("fecha");
                    string motivoActual = row.Field<string>("motivo");

                    if (fecha == fin.AddDays(1) && motivoActual == motivo)
                    {
                        fin = fecha;
                    }
                    else
                    {
                        dtMostrar.Rows.Add(contador++, inicio.ToString("dd/MM/yyyy"), fin.ToString("dd/MM/yyyy"), motivo);
                        inicio = fecha;
                        fin = fecha;
                        motivo = motivoActual;
                    }
                }

                dtMostrar.Rows.Add(contador++, inicio.ToString("dd/MM/yyyy"), fin.ToString("dd/MM/yyyy"), motivo);

                dgvtipodia.DataSource = dtMostrar;
            }
            else
            {
                dgvtipodia.DataSource = null;
            }

            dgvtipodia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvtipodia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvtipodia.ReadOnly = true;
        }

        private void btnTipoDia_Click(object sender, EventArgs e)
        {
            BDL_Gestion bdlGestion = new BDL_Gestion();
            DateTime fechaInicio = Calendario.SelectionStart;
            DateTime fechaFin = Calendario.SelectionEnd;
            codGestionActual = bdlGestion.ObtenerGestionActiva();// 1;//COLOCAR CODIGO DEL COMBO DONDE SE EXTRAE EL cod_gestion

            // ✅ Pasamos la gestión actual creada
            using (frmTipoDiaDetalle frm = new frmTipoDiaDetalle(fechaInicio, fechaFin, codGestionActual)) 
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarFeriados();
                }
            }
        }

        private void btnsiguiente2_Click(object sender, EventArgs e)
        {
            if (tabControlCalendario.SelectedIndex < tabControlCalendario.TabCount - 1)
            {
                tabControlCalendario.SelectedIndex++;
            }
        }

        private void btnAnterior2_Click(object sender, EventArgs e)
        {
            if (tabControlCalendario.SelectedIndex > 0)
            {
                tabControlCalendario.SelectedIndex--;
            }
        }   

        private void dgvtipodia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPeriodos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnSiguiente3_Click(object sender, EventArgs e)
        {
            if (tabControlCalendario.SelectedIndex < tabControlCalendario.TabCount - 1)
            {
                tabControlCalendario.SelectedIndex++;
            }
        }
       
        private void RefrescarCalendario()
        {
            Calendario.RemoveAllBoldedDates();
            toolTip1.RemoveAll();

            BDL_CalendarioEscolar bdl = new BDL_CalendarioEscolar();
            DataTable dias = bdl.MostrarPorGestion(codGestionActual);

            foreach (DataRow row in dias.Rows)
            {
                DateTime fecha = Convert.ToDateTime(row["fecha"]);
                string tipo = row["tipo_dia"].ToString();
                string motivo = row["motivo"].ToString();

                // 🔹 Marcar en negrita
                Calendario.AddBoldedDate(fecha);

                // 🔹 Tooltip dinámico (usa MouseMove)
                toolTip1.SetToolTip(Calendario, $"{fecha:dd/MM/yyyy}: {tipo} - {motivo}");
            }

            Calendario.UpdateBoldedDates();
        }

        private void txtGestion_TextChanged(object sender, EventArgs e)
        {

        }
        private void Calendario_DateSelected(object sender, DateRangeEventArgs e)
        {
            try
            {
                // Obtener la fecha seleccionada
                DateTime fechaInicio = e.Start;
                DateTime fechaFin = e.End;

                // Obtener la gestión activa
                BDL_Gestion bdlGestion = new BDL_Gestion();
                codGestionActual = bdlGestion.ObtenerGestionActiva();

                if (codGestionActual == 0)
                {
                    MessageBox.Show("No hay gestión activa. Genere o seleccione una primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Abrir el formulario Tipo Día con las fechas seleccionadas
                using (frmTipoDiaDetalle frm = new frmTipoDiaDetalle(fechaInicio, fechaFin, codGestionActual))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        // Refrescar datos y calendario
                        CargarFeriados();
                        RefrescarCalendario();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de Tipo Día: " + ex.Message);
            }
        }

        private void frmNCalendario_Load(object sender, EventArgs e)
        {

            codGestionActual = new BDL_Gestion().ObtenerGestionActiva();
            if (codGestionActual > 0)
                RefrescarCalendario();
        }
    }
}
