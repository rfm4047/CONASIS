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
    public partial class frmNDocente : Form
    {
        BDL_Docente doc = new BDL_Docente();
        BDL_Plantel pla = new BDL_Plantel();
        public bool Editar = false;
        string IdPlant=null;
        public string IdPDoc;
        public frmNDocente()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Editar==false)
            {
                try {           
                               pla.agregarplantel(txtNombre.Text, txtApPaterno.Text, txtMaterno.Text, cbxGenero.Text, txtCarnet.Text, 
                               cbxExtension.Text, txtTelefono.Text, dtpFechaNac.Text, txtDireccion.Text, 
                               txtEspecialidad.Text, txtItem.Text, txtRda.Text);
                               IdPlant = doc.ultimocodigoplantel();
                               doc.agregarDocente(Convert.ToInt32(IdPlant), txtCargaHoraria.Text, txtHrPlanilla.Text);
                               MessageBox.Show ("Se agregaron los datos correctamente" + IdPlant);
                               this.Close();
                    }
                    catch (Exception ex)
                    {
                    MessageBox.Show("No se pudo insertar los datos por:" + ex);
                    }
            }
            if (Editar == true)
            {
                try
                {
                               pla.editarplantel(txtNombre.Text, txtApPaterno.Text, txtMaterno.Text, cbxGenero.Text, txtCarnet.Text,
                               cbxExtension.Text, txtTelefono.Text, dtpFechaNac.Text, txtDireccion.Text,
                               txtEspecialidad.Text, txtItem.Text, txtRda.Text, IdPDoc);
                              
                               doc.editarDocente(txtCargaHoraria.Text, txtHrPlanilla.Text, Convert.ToInt32(IdPDoc));
                               MessageBox.Show("Se editaron los datos correctamente");
                               Editar = false;
                    }
                    catch (Exception ex)
                    {
                    MessageBox.Show("No se pudo insertar los datos por:" + ex);
                }
            }
            this.Close();
            
        }

        private void panelContenido_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
