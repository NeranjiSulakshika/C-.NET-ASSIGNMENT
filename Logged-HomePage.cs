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

namespace Buysmart_Online_Shopping_Store
{
    public partial class Logged_HomeScreen : Form
    {
        public Logged_HomeScreen()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void Logged_HomeScreen_Load(object sender, EventArgs e)
        {

        }

        private void SideButton_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 243)
            {
                MenuVertical.Width = 63;
                Logo2.Visible = false;
                Logo1.Visible = true;
                btnAccessories.Visible = false;
            }
            else
            {
                MenuVertical.Width = 243;
                Logo2.Visible = true;
                Logo1.Visible = false;
                btnAccessories.Visible = true;
            }
        }

        private void Logo2_Click(object sender, EventArgs e)
        {
            Logged_HomeScreen lh = new Logged_HomeScreen();
            lh.Show();
            this.Hide();
        }

        private void picMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picNormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            picNormal.Visible = false;
            picMaximize.Visible = true;
        }

        private void picMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            picMaximize.Visible = false;
            picNormal.Visible = true;
        }

        private void HeadPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private int imagenumber = 1;

        private void LoadNextImage()
        {
            if (imagenumber == 28)
            {
                imagenumber = 1;
            }
            SlidePic.ImageLocation = string.Format(@"Slideshow\{0}.jpg", imagenumber);
            imagenumber++;
        }

        private void Timer1_Tick_1(object sender, EventArgs e)
        {
            LoadNextImage();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            HOME hm = new HOME();
            hm.Show();
            this.Hide();
        }

        private void Label1_MouseMove(object sender, MouseEventArgs e)
        {
            Heading.ForeColor = Color.DeepSkyBlue;
        }

        private void Label1_MouseLeave(object sender, EventArgs e)
        {
            Heading.ForeColor = Color.LightCoral;
        }

        private void BtnAccessories_Click(object sender, EventArgs e)
        {
            Logged_AccessoriesPage la = new Logged_AccessoriesPage();
            la.Show();
            this.Hide();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            CART c = new CART();
            c.Show();
            this.Hide();
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            Logged_AccessoriesPage la = new Logged_AccessoriesPage();
            la.Show();
            this.Hide();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            Logged_AccessoriesPage la = new Logged_AccessoriesPage();
            la.Show();
            this.Hide();
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            Logged_AccessoriesPage la = new Logged_AccessoriesPage();
            la.Show();
            this.Hide();
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            Logged_AccessoriesPage la = new Logged_AccessoriesPage();
            la.Show();
            this.Hide();
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            Logged_AccessoriesPage la = new Logged_AccessoriesPage();
            la.Show();
            this.Hide();
        }

        private void HeadPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
