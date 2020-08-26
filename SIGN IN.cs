using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Buysmart_Online_Shopping_Store
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }       

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        string Email, Password;        

        private void Button1_Click(object sender, EventArgs e)
        {            
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
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
            HOME h = new HOME();
            h.Show();
            this.Hide();
        }

        private void PicMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PicMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            PicMaximize.Visible = false;
            PicNormal.Visible = true;
        }

        private void PicNormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            PicNormal.Visible = false;
            PicMaximize.Visible = true;
        }

        private void PicExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SignInPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void MenuVertical_Paint(object sender, PaintEventArgs e)
        {
        }

        private void HeadPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void LinkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUP SU = new SignUP();
            SU.Show();
            this.Hide();
        }

        private void ChShow_CheckedChanged(object sender, EventArgs e)
        {
            if (chShow.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please fill the all fields!", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='F:\C# FINAL ASSIGNMENT (GROUP 06)\DATABASE (Accounts).mdf';Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SignUp WHERE Email = '" + txtEmail.Text + "' AND Password = '" + txtPassword.Text + "' ", con);

                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                int count = 0;

                while (dr.Read())
                {
                    count += 1;
                }

                if (count == 1)
                {
                    MessageBox.Show("Hello " + txtEmail.Text + ", Welcome back to our online shopping store!", "WELCOME!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logged_HomeScreen lg = new Logged_HomeScreen();
                    lg.Show();
                    this.Hide();
                }
                else if (count > 0)
                {
                    MessageBox.Show("Duplicate email & password.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Clear();
                    txtPassword.Clear();
                }
                else
                {
                    MessageBox.Show("Email or password is not correct.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Clear();
                    txtPassword.Clear();
                }
            }          
        }

        private void Heading_MouseEnter(object sender, EventArgs e)
        {
            Heading.ForeColor = Color.DeepSkyBlue;
        }

        private void Heading_MouseHover(object sender, EventArgs e)
        {
        }

        private void Heading_MouseMove(object sender, MouseEventArgs e)
        {
            Heading.ForeColor = Color.DeepSkyBlue;
        }

        private void Heading_MouseLeave(object sender, EventArgs e)
        {
            Heading.ForeColor = Color.LightCoral;
        }

        private void TxtEmail_Enter(object sender, EventArgs e)
        {
        }

        private void TxtPassword_Enter(object sender, EventArgs e)
        {
        }

        private void TxtEmail_Leave(object sender, EventArgs e)
        {
            EmailValidation();

            Email = txtEmail.Text;

            if (Email == (""))
            {
                txtEmail.Text = "Email";
                txtEmail.ForeColor = Color.Gray;
            }
        }

        void EmailValidation()
        {
            if (txtEmail.Text.Length > 0)
            {
                Regex RegxEmail = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
                if (!RegxEmail.IsMatch(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Invalid email. Please provide valid email.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return;
                }
            }
        }

        private void TxtPassword_Leave(object sender, EventArgs e)
        {
        }

        private void TxtEmail_TextChanged(object sender, EventArgs e)
        {
        }

        private void BtnAccessories_Click(object sender, EventArgs e)
        {
            ACCESSORIES a = new ACCESSORIES();
            a.Show();
            this.Hide();
        }

        private void BtnSignIn_MouseEnter(object sender, EventArgs e)
        {
            btnSignIn.BackColor = Color.LightCoral;
            btnSignIn.ForeColor = Color.DeepSkyBlue;
        }

        private void Button1_MouseMove(object sender, MouseEventArgs e)
        {
            btnSignIn.BackColor = Color.LightCoral;
            btnSignIn.ForeColor = Color.DeepSkyBlue;
        }

        private void Bbutton1_MouseLeave(object sender, EventArgs e)
        {
            btnSignIn.BackColor = Color.DeepSkyBlue;
            btnSignIn.ForeColor = Color.LightCoral;
        }

        private void btnSignIn_MouseLeave(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {            
        }
    }
}
