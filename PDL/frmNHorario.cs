using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CONASIS.DAL;
using CONASIS.BDL;


namespace CONASIS.PDL
{
    public partial class frmNHorario : Form
    {
        private int? idAdministrativoSeleccionado = null;
        private int? idDocenteSeleccionado = null;
        private BDL_Docente bdlDocente = new BDL_Docente();
        public frmNHorario()
        {
            InitializeComponent();
        }

        private void frmNHorario_Load(object sender, EventArgs e)
        {

        }
        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string nombre = txtNombre.Text.Trim();

                // 🔹 Administrativo
                BDL_Administrativo bdlAdm = new BDL_Administrativo();
                var dtAdm = bdlAdm.BuscarPorNombre(nombre);

                if (dtAdm.Rows.Count > 0)
                {
                    idAdministrativoSeleccionado = Convert.ToInt32(dtAdm.Rows[0]["idadm"]);
                    pbCheck.Image = Properties.Resources.check;
                    tabFijo.Enabled = true;
                    tabHorario.Enabled = false;
                    return;
                }

                // 🔹 Docente
                BDL_Docente bdlDocente = new BDL_Docente();
                var lista = bdlDocente.BuscarPorNombre(nombre);

                if (lista.Count > 0)
                {
                    idDocenteSeleccionado = lista[0].IdDocente;
                    pbCheck.Image = Properties.Resources.check;
                    tabHorario.Enabled = true;
                    tabFijo.Enabled = false;
                    return;
                }

                MessageBox.Show("No se encontró ningún plantel con ese nombre.");
            }
        }


    }
}
