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
    public partial class frmAdministrativo : Form
    {
        public frmAdministrativo()
        {
            InitializeComponent();
        }

        private void AbrirFormularioNieto<MiForm>() where MiForm : Form, new()
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
                //formulario.FormClosed += new FormClosedEventHandler(FormClosed);
            }
            else
                formulario.BringToFront();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirFormularioNieto<frmNAdministrativo>();
        }
        
        public void mostrarAdmin()
        {
            BDL_Administrativo adm = new BDL_Administrativo();
            dvgAdm.DataSource = adm.mostrarAdministrativo();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmNAdministrativo frm = new frmNAdministrativo();

            if(dvgAdm.SelectedRows.Count >0)
            {
                frm.Editar = true;
                frm.IdPAdm = dvgAdm.CurrentRow.Cells[0].Value.ToString();
                frm.txtNombre.Text = dvgAdm.CurrentRow.Cells[1].Value.ToString();
                frm.txtApPaterno.Text = dvgAdm.CurrentRow.Cells[2].Value.ToString();
                frm.txtMaterno.Text = dvgAdm.CurrentRow.Cells[3].Value.ToString();
                frm.cbxGenero.Text = dvgAdm.CurrentRow.Cells[4].Value.ToString();
                frm.txtCarnet.Text = dvgAdm.CurrentRow.Cells[5].Value.ToString();
                frm.cbxExtension.Text = dvgAdm.CurrentRow.Cells[6].Value.ToString();
                frm.txtTelefono.Text = dvgAdm.CurrentRow.Cells[7].Value.ToString();
                frm.dtpFechaNac.Text = dvgAdm.CurrentRow.Cells[8].Value.ToString();
                frm.txtDierccion.Text = dvgAdm.CurrentRow.Cells[9].Value.ToString();
                frm.txtEspecialidad.Text = dvgAdm.CurrentRow.Cells[10].Value.ToString();
                frm.txtItem.Text = dvgAdm.CurrentRow.Cells[11].Value.ToString();
                frm.txtRda.Text = dvgAdm.CurrentRow.Cells[12].Value.ToString();
                frm.txtCargo.Text = dvgAdm.CurrentRow.Cells[13].Value.ToString();

            }
        }

        
        public void AccionesTabla()
        {
            dvgAdm.Columns[0].Width = 100;
            dvgAdm.Columns[1].Width = 100;
            dvgAdm.Columns[2].Width = 100;
            dvgAdm.Columns[3].Width = 100;
            dvgAdm.Columns[4].Width = 0;
            dvgAdm.Columns[5].Width = 0;
            dvgAdm.Columns[6].Width = 0;
            dvgAdm.Columns[7].Width = 0;
            dvgAdm.Columns[8].Width = 0;
            dvgAdm.Columns[9].Width = 0;
            dvgAdm.Columns[10].Width = 0;
            dvgAdm.Columns[11].Width = 100;
            dvgAdm.Columns[12].Width = 100;

            dvgAdm.ClearSelection();

        }

        private void frmAdministrativo_Load(object sender, EventArgs e)
        {
            mostrarAdmin(); 
            AccionesTabla();
        }

    }
}
