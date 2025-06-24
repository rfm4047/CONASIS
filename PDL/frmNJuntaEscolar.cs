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
    public partial class frmNJuntaEscolar : Form
    {
        BDL_JuntaEsc objje = new BDL_JuntaEsc();
        private bool Editar = false;
        string codrepje = null;

        public frmNJuntaEscolar()
        {
            InitializeComponent();
        }

       
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
        }

        private void MostrarJunta()
        {
            BDL_JuntaEsc jesc = new BDL_JuntaEsc();
            dvgJuntaEscolar.DataSource = jesc.mostrarJuntaEscolar();
        }
        public void AccionesTabla()
        {
            dvgJuntaEscolar.Columns[0].Width = 20;
            dvgJuntaEscolar.Columns[1].Width = 70;
            dvgJuntaEscolar.Columns[2].Width = 70;
            dvgJuntaEscolar.Columns[3].Width = 100;
            dvgJuntaEscolar.Columns[4].Visible = false;
            dvgJuntaEscolar.Columns[5].Visible = false;
            dvgJuntaEscolar.Columns[6].Visible = false;
            
            dvgJuntaEscolar.ClearSelection();

        }

         private void panelBasico_Paint(object sender, PaintEventArgs e)
         {
             //MostrarJunta();
         }
        

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    objje.agregarJuntaE(Convert.ToInt32(codrepje), txtNombre.Text, txtApPaterno.Text, txtApMaterno.Text, txtCarnet.Text, cbxExtension.Text, txtTelefono.Text, cbxCargo.Text);
                    MessageBox.Show("Se guardo correctamente");
                    MostrarJunta();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se pudo guardar los datos por: " + ex);
                }
            }
        }

        private void frmNJuntaEscolar_Load(object sender, EventArgs e)
        {
            MostrarJunta();
            AccionesTabla();
        }
    }
}
