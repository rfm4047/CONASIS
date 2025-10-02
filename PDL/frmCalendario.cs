using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CONASIS.PDL
{
    public partial class frmCalendario : Form
    {
        

        public frmCalendario()
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
        
        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            
            var frm = AbrirFormularioNieto<frmNCalendario>();
        }

        private void label2_Click(object sender, EventArgs e)
        {


        }
    }
}

