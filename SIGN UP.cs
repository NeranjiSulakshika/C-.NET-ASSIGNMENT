using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Buysmart_Online_Shopping_Store
{
    public partial class SignUP : Form
    {
        public object RegularExpression { get; private set; }

        public SignUP()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void ChShow_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void TtEmail_Validating(object sender, CancelEventArgs e)
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

        private void picMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            PicMaximize.Visible = false;
            PicNormal.Visible = true;
        }

        private void picNormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            PicNormal.Visible = false;
            PicMaximize.Visible = true;
        }

        private void HeadPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void TxtFname_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void Button1_Click_1(object sender, EventArgs e)
        {
            string FirstName = txtFname.Text;
            string LastName = txtLname.Text;
            string Email = txtEmail.Text;
            string Password = txtPassword.Text;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='E:\ASSIGNMENT C#\DATABASE (Accounts).mdf';Integrated Security=True;Connect Timeout=30");
            String query = "Insert into SignUp Values ('" + FirstName + "' , '" + LastName + "' , '" + Email + "' , '" + Password + "')";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Welcome!");

                Logged_HomeScreen lh = new Logged_HomeScreen();
                lh.Show();
                this.Hide();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("" + sqlEx);
            }           

        }

        private void ChShow_CheckedChanged_1(object sender, EventArgs e)
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

        private void TxtFname_Enter(object sender, EventArgs e)
        {
            string FirstName = txtFname.Text;

            if (FirstName == "First Name")
            {
                txtFname.Text = "";
                txtFname.ForeColor = Color.Black;
            }
        }

        private void TxtFname_Leave(object sender, EventArgs e)
        {
            string FirstName = txtFname.Text;

            if (FirstName == (""))
            {
                txtFname.Text = "First Name";
                txtFname.ForeColor = Color.Gray;
            }
        }

        private void TxtLname_Enter(object sender, EventArgs e)
        {
            string LastName = txtLname.Text;

            if (LastName == "Last name")
            {
                txtLname.Text = "";
                txtLname.ForeColor = Color.Black;
            }
        }

        private void TxtLname_Leave(object sender, EventArgs e)
        {
            string LastName = txtLname.Text;

            if (LastName == (""))
            {
                txtLname.Text = "Last name";
                txtLname.ForeColor = Color.Gray;
            }
        }

        private void TxtEmail_Enter(object sender, EventArgs e)
        {
            string Email = txtEmail.Text;

            if (Email == "Email")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void TxtEmail_Leave(object sender, EventArgs e)
        {
            EmailValidation();

            string Email = txtEmail.Text;

            if (Email == (""))
            {
                txtEmail.Text = "Email";
                txtEmail.ForeColor = Color.Gray;
            }
        }

        void EmailValidation()
        {
            if(txtEmail.Text.Length > 0)
            {
                Regex RegxEmail = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
                if(!RegxEmail.IsMatch(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Invalid email. Please provide valid email.");
                    txtEmail.Focus();
                    return;
                }
            }
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TxtPassword_Enter(object sender, EventArgs e)
        {
            string Password = txtPassword.Text;

            if (Password == "Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
            }
        }

        private void TtxtPassword_Leave(object sender, EventArgs e)
        {
            string Password = txtPassword.Text;

            if (Password == (""))
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Gray;
            }
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

        private void Bbutton1_MouseEnter(object sender, EventArgs e)
        {
            btnSignUp.BackColor = Color.LightCoral;
            btnSignUp.ForeColor = Color.DeepSkyBlue;
        }

        private void BtnSignUp_MouseMove(object sender, MouseEventArgs e)
        {
            btnSignUp.BackColor = Color.LightCoral;
            btnSignUp.ForeColor = Color.DeepSkyBlue;
        }

        private void Bbutton1_MouseLeave(object sender, EventArgs e)
        {
            btnSignUp.ForeColor = Color.LightCoral;
            btnSignUp.BackColor = Color.DeepSkyBlue;
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignIn si = new SignIn();
            si.Show();
            this.Hide();
        }
    }
}
