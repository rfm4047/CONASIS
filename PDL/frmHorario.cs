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
            AbrirFormularioNieto<frmNHorario>();
        }

        private void frmHorario_Load(object sender, EventArgs e)
        {
            CargarHorarios();
        }
        private void CargarHorarios()
        {
            BDL_HorarioGeneral bll = new BDL_HorarioGeneral();
            dgvHorario.DataSource = bll.Listar();

            dgvHorario.Columns["NombreCompleto"].HeaderText = "Nombre Completo";
            dgvHorario.Columns["TipoHorario"].HeaderText = "Tipo Horario";
            dgvHorario.Columns["TiempoTotalHoras"].HeaderText = "Tiempo Total (hrs)";
        }
    }
}
