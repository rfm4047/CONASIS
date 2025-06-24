using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using CONASIS.PDL;

namespace CONASIS.SEGURIDAD 
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
            [DllImport("user32.DLL", EntryPoint= "SendMessage")]
            private extern static void SendMessage(System.IntPtr hwnd, int wmsg,
                int wparam, int lparam);

        private void btnacceder_Click(object sender, EventArgs e)
        {
            if (txtuser.Text != "USUARIO")
            {
                if (txtpswd.Text != "CONTRASEÑA")
                {
                    UserBussines user = new UserBussines();
                    var validLogin = user.LoginUser(txtuser.Text, txtpswd.Text);
                if (validLogin ==true)
                    {
                        frmPrincipal mainmenu = new frmPrincipal();
                        mainmenu.Show();
                        mainmenu.FormClosed += Logout;
                        this.Hide();
                    }
                else
                    {
                        msgError("Nombre de usuario o contraseña incorrecta.\n Por favor intenta de nuevo");
                        txtpswd.Text = "CONTRASEÑA";
                        txtuser.Focus();
                    }
                }
                else
                    msgError("Por favor ingrese su contraseña");
            }
            else
                msgError("Por favor ingrese su usuario");
        }
        private void msgError(string msg)
        {
            lblMessageError.Text = msg;
            lblMessageError.Visible = true;
        }
        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtpswd.Text= "CONTRASEÑA";
            txtpswd.UseSystemPasswordChar = false;
            txtuser.Clear();
            lblMessageError.Visible = false;
            this.Show();
           // txtuser.Focus();
        }
        private void txtuser_Enter(object sender, EventArgs e)
        {
            if(txtuser.Text=="USUARIO")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.LightGray;    
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if(txtuser.Text=="")
            {
                txtuser.Text = "USUARIO";
                txtuser.ForeColor = Color.Gainsboro;
            }
        }

        private void txtpswd_Enter(object sender, EventArgs e)
        {
            if(txtpswd.Text=="CONTRASEÑA")
            { 
            txtpswd.Text = "";
            txtpswd.ForeColor = Color.LightGray;
                txtpswd.UseSystemPasswordChar = true;
            }
        }

        private void txtpswd_Leave(object sender, EventArgs e)
        {
            if( txtpswd.Text=="")
            {
                txtpswd.Text = "CONTRASEÑA";
                txtpswd.ForeColor = Color.Gainsboro;
                txtpswd.UseSystemPasswordChar = false;
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnacceder_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        
    }
}
