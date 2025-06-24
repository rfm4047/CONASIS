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
using CONASIS.DAL;
using System.Data.SqlClient;


namespace CONASIS.PDL
{
    public partial class frmInstitucion : Form
    {
        Conexion cnx = new Conexion();
        public frmInstitucion()
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

                txtNombre.Text = reg["nominst"].ToString();
                txtDepartamento.Text = reg["dptoinst"].ToString();
                txtNivel.Text = reg["nivelinst"].ToString();
                txtTurno.Text = reg["turnoinst"].ToString();
                txtNroServicio.Text = reg["nservicioinst"].ToString();
                txtNroPrograma.Text = reg["nprogramainst"].ToString();
                txtNroSIE.Text = reg["nsieinst"].ToString();
                txtMejoramiento.Text = reg["mejorarinst"].ToString();
                txtDireccion.Text = reg["direccioninst"].ToString();
                txtNucleoEscolar.Text = reg["nucleoescinst"].ToString();
                txtSubdistrito.Text = reg["subdistinst"].ToString();
                txtUnidadVecinal.Text = reg["uvinst"].ToString();
                txtManzana.Text = reg["mzinst"].ToString();
                txtDistritoEd.Text = reg["distedinst"].ToString();
                txtDistritoMunicipal.Text = reg["distmuninst"].ToString();
                txtTelfInstitucion.Text = reg["telfuniedinst"].ToString();
                txtTelfDirectora.Text = reg["telfdirectorainst"].ToString();

            }

            cnx.CerrarConexion();

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
        private void MostrarInstitucion()
        {
           
            Institucion objInst = new Institucion();

        }

        private void frmInstitucion_Load(object sender, EventArgs e)
        {
            MostrarInstitucion();
            
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {

            var frm = AbrirFormularioNieto<frmNInstitucion>();
            frm.FormClosed += (s, args) => { CargarInst(); };  // <-- Al cerrar, recarga los datos
        }

        private void panelContenido_Paint(object sender, PaintEventArgs e)
        {
            MostrarInstitucion();
        }
    }
}
