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
using System.Data.SqlClient;
using CONASIS.DAL;


namespace CONASIS.PDL
{

    public partial class frmNInstitucion : Form
    {
        Institucion inst = new Institucion();
        Conexion cnx = new Conexion();
        public frmNInstitucion()
        {
            InitializeComponent();
            CargarInst();
        }
        public void CargarInst()
        {

            cnx.AbrirConexion();
            SqlCommand Comando = new SqlCommand("[CargarInstitucion]", cnx.ObtenerConexion());
            Comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader reg = Comando.ExecuteReader();
            if (reg.Read())
            {

                txtNombre2.Text = reg["nominst"].ToString();
                txtDepartamento2.Text = reg["dptoinst"].ToString();
                txtNivel2.Text = reg["nivelinst"].ToString();
                txtTurno2.Text = reg["turnoinst"].ToString();
                txtNroServicio2.Text = reg["nservicioinst"].ToString();
                txtNroPrograma2.Text = reg["nprogramainst"].ToString();
                txtNroSIE2.Text = reg["nsieinst"].ToString();
                txtMejoramiento2.Text = reg["mejorarinst"].ToString();
                txtDireccion2.Text = reg["direccioninst"].ToString();
                txtNucleoEscolar2.Text = reg["nucleoescinst"].ToString();
                txtSubdistrito2.Text = reg["subdistinst"].ToString();
                txtUnidadVecinal2.Text = reg["uvinst"].ToString();
                txtManzana2.Text = reg["mzinst"].ToString();
                txtDistritoEd2.Text = reg["distedinst"].ToString();
                txtDistritoMunicipal2.Text = reg["distmuninst"].ToString();
                txtTelfInstitucion2.Text = reg["telfuniedinst"].ToString();
                txtTelfDirectora2.Text = reg["telfdirectorainst"].ToString();

            }

            cnx.CerrarConexion();
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
                // formulario.FormClosed += new FormClosedEventHandler(FormClosed);
            }
            else
            {
                formulario.BringToFront();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Institucion objInst = new Institucion();

            bool modificado = objInst.ModificarInstitucion(
                txtNombre2.Text,
                txtDepartamento2.Text,
                txtNivel2.Text,
                txtTurno2.Text,
                txtNroServicio2.Text,
                txtNroPrograma2.Text,
                txtNroSIE2.Text,
                txtMejoramiento2.Text,
                txtDireccion2.Text,
                txtNucleoEscolar2.Text,
                txtSubdistrito2.Text,
                txtUnidadVecinal2.Text,
                txtManzana2.Text,
                txtDistritoEd2.Text,
                txtDistritoMunicipal2.Text,
                txtTelfInstitucion2.Text,
                txtTelfDirectora2.Text,
                1 // codinst: si siempre es 1 porque solo hay una institución registrada, o lo que corresponda
            );

            if (modificado)
            {
                MessageBox.Show("Institución modificada exitosamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // opcional: cerrar el formulario de edición
            }
            else
            {
                MessageBox.Show("Error al modificar la institución", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
