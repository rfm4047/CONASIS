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
                         .Where(r => r.Field<string>("nom_tipodia") != "Hábil")
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

                    // Si es consecutivo y con mismo motivo, se agrupa
                    if (fecha == fin.AddDays(1) && motivoActual == motivo)
                    {
                        fin = fecha;
                    }
                    else
                    {
                        // Agregar rango cerrado
                        dtMostrar.Rows.Add(contador++, inicio.ToString("dd/MM/yyyy"), fin.ToString("dd/MM/yyyy"), motivo);

                        // Reiniciar el rango
                        inicio = fecha;
                        fin = fecha;
                        motivo = motivoActual;
                    }
                }

                // Agregar el último rango
                dtMostrar.Rows.Add(contador++, inicio.ToString("dd/MM/yyyy"), fin.ToString("dd/MM/yyyy"), motivo);

                dgvtipodia.DataSource = dtMostrar;
            }
            else
            {
                dgvtipodia.DataSource = null;
            }

            // Ajustes visuales
            dgvtipodia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvtipodia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvtipodia.ReadOnly = true;
        }


        private void frmNCalendario_Load(object sender, EventArgs e)
        {
            BDL_Gestion bdlGestion = new BDL_Gestion();
           // codGestionActual = bdlGestion.ObtenerUltimaGestion();
            DataTable dt = bdlGestion.Mostrar();

            if (dt.Rows.Count > 0)
            {
                codGestionActual = Convert.ToInt32(dt.Rows[0]["cod_gestion"]);
                string nombreGestion = dt.Rows[0]["nom_gestion"].ToString();
                DateTime fechaini = Convert.ToDateTime(dt.Rows[0]["fechaini_gestion"]);
                DateTime fechafin = Convert.ToDateTime(dt.Rows[0]["fechafin_gestion"]);

                txtCodGestion.Text = codGestionActual.ToString();
                txtGestion.Text = nombreGestion;
                dtGestionInicio.Value = fechaini;
                dtGestionFin.Value = fechafin;

                txtGestion.ReadOnly = true;
                dtGestionInicio.Enabled = false;
                dtGestionFin.Enabled = false;


                CargarFeriados(); // refresca el grid al abrir
                CargarPeriodos();
                CargarActividades();
            }

        }

        private void btnTipoDia_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = Calendario.SelectionStart;
            DateTime fechaFin = Calendario.SelectionEnd;

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

        private void btnPeriodos_Click(object sender, EventArgs e)
        {
            int gestion = codGestionActual;
            using (frmPeriodos frm = new frmPeriodos(gestion))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarPeriodos();
                }
            }
        }
        private void CargarPeriodos()
        {
            BDL_Periodo bdlPeriodo = new BDL_Periodo();
            var dt = bdlPeriodo.Mostrar(codGestionActual);
            dgvPeriodos.DataSource = dt;
            
            // Ocultar columnas que no quieres mostrar
            dgvPeriodos.Columns["cod_periodo"].Visible = false;
            dgvPeriodos.Columns["cod_gestion"].Visible = false;

            // Cambiar los encabezados de las columnas
            dgvPeriodos.Columns["tipo"].HeaderText = "Tipo de Periodo";
            dgvPeriodos.Columns["nombre"].HeaderText = "Nombre del Periodo";
            dgvPeriodos.Columns["fechaini"].HeaderText = "Fecha Inicio";
            dgvPeriodos.Columns["fechafin"].HeaderText = "Fecha Fin";
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

        private void btnActividades_Click(object sender, EventArgs e)
        {
            int gestion = codGestionActual;
            using (frmActividades frm = new frmActividades(gestion))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarPeriodos();
                }
            }
        }
        private void CargarActividades()
        {
            BDL_Actividad bdl = new BDL_Actividad();
            dgvActividades.DataSource = bdl.Mostrar();
            dgvActividades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Cambiar nombres de cabeceras
            if (dgvActividades.Columns["cod_actividad"] != null)
                dgvActividades.Columns["cod_actividad"].HeaderText = "Código";

            if (dgvActividades.Columns["nombre"] != null)
                dgvActividades.Columns["nombre"].HeaderText = "Nombre Actividad";

            if (dgvActividades.Columns["fechaini"] != null)
                dgvActividades.Columns["fechaini"].HeaderText = "Fecha de Inicio";

            if (dgvActividades.Columns["fechafin"] != null)
                dgvActividades.Columns["fechafin"].HeaderText = "Fecha de Fin";

            dgvActividades.Columns["cod_gestion"].Visible = false;
            dgvActividades.Columns["nom_gestion"].Visible = false;
            dgvActividades.Columns["fechaini_gestion"].Visible = false;
            dgvActividades.Columns["fechafin_gestion"].Visible = false;

        }
    }
}
