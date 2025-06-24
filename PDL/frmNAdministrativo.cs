using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CONASIS.BDL;
namespace CONASIS.PDL
{
    public partial class frmNAdministrativo : Form
    {
        BDL_Administrativo admin = new BDL_Administrativo();
        BDL_Plantel pla = new BDL_Plantel();
        public bool Editar = false;
        public string IdPAdm;
        string IdPlant = null;
        public frmNAdministrativo()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(Editar ==false)
            {
                try { 
                    pla.agregarplantel(txtNombre.Text, txtApPaterno.Text, txtMaterno.Text, cbxGenero.Text, txtCarnet.Text, cbxExtension.Text, txtTelefono.Text,
                    dtpFechaNac.Text, txtDierccion.Text, txtEspecialidad.Text, txtItem.Text, txtRda.Text);
                    IdPlant = admin.ultimocodigoplantel();
                    admin.agregarAdministrativo(Convert.ToInt32(IdPlant), txtCargo.Text);
                    MessageBox.Show("Se agregaron los datos correctamente" + IdPlant);
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
                    cbxExtension.Text, txtTelefono.Text, dtpFechaNac.Text, txtDierccion.Text,
                    txtEspecialidad.Text, txtItem.Text, txtRda.Text, IdPAdm);

                    admin.editarAdministrativo(txtCargo.Text, Convert.ToInt32(IdPAdm));
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

        
    }
}
