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

namespace CONASIS.PDL
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            CustomizeDesign();
        }
        #region
        //Metodo para redimensionar el form
        private int tolerance = 12;
        private const int WM_MCHITTEST = 132;
        private const int HTBOTTOMRIGTH = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_MCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGTH);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //Dibujar triangulo
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
            region.Exclude(sizeGripRectangle);
            this.panelBasico.Region = region;
            this.Invalidate();
        }
        //Darle color al triangulo
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }
        //Cerrar boton
        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int lx, ly;
        int sw, sh;
        //Minimizar boton
        private void btnMinimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //Maximizar Boton
        private void btnMaximizar_Click_1(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }
        //Restaurar boton
        private void btnRestaurar_Click_1(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
        }
        //Metodo para arrastrar el form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        //Metodo para SubMenu de Personal
        private void CustomizeDesign()
        {
            panelPersonal.Visible = false;

        }
        private void EsconderSubMenu()
        {
            if (panelPersonal.Visible == true)
                panelPersonal.Visible = false;
        }
        private void MostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                EsconderSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

       private void AbrirFormulario <MiForm>() where MiForm: Form, new()
        {
            Form formulario;
            formulario = panelContenido.Controls.OfType<MiForm>().FirstOrDefault();
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

            }
            else
                formulario.BringToFront();

        }

        private void btnInstitucion_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmInstitucion>();
        }

        private void btnPersonal_Click_1(object sender, EventArgs e)
        {
            MostrarSubMenu(panelPersonal);
        }

        private void btnHorario_Click(object sender, EventArgs e)
        {
            EsconderSubMenu();
            AbrirFormulario<frmHorario>();
        }

        private void btnJuntaEsc_Click(object sender, EventArgs e)
        {
            EsconderSubMenu();
            AbrirFormulario<frmNJuntaEscolar>();
            

        }

        private void btncerrarsesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea cerrar sesion?", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();

        }

        private void btnReemplazos_Click(object sender, EventArgs e)
        {
            {
                EsconderSubMenu();
                AbrirFormulario<FrmReemplazo >();
            }
        }

        private void btnReemplazante_Click(object sender, EventArgs e)
        {
            EsconderSubMenu();
            AbrirFormulario<frmCalendario>();
        }

        private void btnRolesUsuarios_Click(object sender, EventArgs e)
        {
            {
                EsconderSubMenu();
                AbrirFormulario<FrmUsuario>();
            }
        }

        private void btnAdministrativo_Click(object sender, EventArgs e)
        {
            {
                EsconderSubMenu();
                AbrirFormulario<frmAdministrativo>();
            }
        }

        private void btnDocente_Click_1(object sender, EventArgs e)
        {
            EsconderSubMenu();
            AbrirFormulario<frmDocente>();
        }
     



    }
}
