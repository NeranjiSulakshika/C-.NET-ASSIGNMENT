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

namespace Buysmart_Online_Shopping_Store
{
    public partial class CART1 : Form
    {
        public CART1()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void Logo2_Click(object sender, EventArgs e)
        {
            Logged_HomeScreen lh = new Logged_HomeScreen();
            lh.Show();
            this.Hide();
        }

        private void btnAccessories_Click(object sender, EventArgs e)
        {
            Logged_AccessoriesPage la = new Logged_AccessoriesPage();
            la.Show();
            this.Hide();
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

        private void dataGridCart_MouseEnter(object sender, EventArgs e)
        {
            Heading.ForeColor = Color.DeepSkyBlue;
        }

        private void dataGridCart_MouseLeave(object sender, EventArgs e)
        {
            Heading.ForeColor = Color.LightCoral;
        }

        private void dataGridCart_MouseMove(object sender, MouseEventArgs e)
        {
            Heading.ForeColor = Color.DeepSkyBlue;
        }

        private void HeadPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='F:\C# FINAL ASSIGNMENT (GROUP 06)\DATABASE (Accounts).mdf';Integrated Security=True;Connect Timeout=30");

            String update = "UPDATE Items SET Quantity = '" + CbQty.SelectedItem + "' WHERE Item_No = '" + TxtItemNo1.Text + "' ";
            SqlCommand cmd = new SqlCommand(update, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Quantity Updated successfully!", "CONGRATULATIONS!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CART c = new CART();
                c.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error detected :" + ex, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='F:\C# FINAL ASSIGNMENT (GROUP 06)\DATABASE (Accounts).mdf';Integrated Security=True;Connect Timeout=30");

            String delete = "DELETE from Items WHERE Item_No = '" + TxtItemNo2.Text + "' ";
            SqlCommand cmd = new SqlCommand(delete, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Deleted successfully!", "CONGRATULATIONS!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CART c = new CART();
                c.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error detected :" + ex, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void CART1_Load(object sender, EventArgs e)
        {
            string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='F:\C# FINAL ASSIGNMENT (GROUP 06)\DATABASE (Accounts).mdf';Integrated Security=True;Connect Timeout=30";

            string query = "SELECT * FROM Items";

            SqlDataAdapter da = new SqlDataAdapter(query, conString);

            DataSet ds = new DataSet();

            da.Fill(ds, "Items");
            dataGridCart.DataSource = ds.Tables["Items"];
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
            picMaximize.Visible = false;
            picNormal.Visible = true;
        }

        private void picNormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            picNormal.Visible = false;
            picMaximize.Visible = true;
        }

        private void BtnUpdate_MouseEnter(object sender, EventArgs e)
        {
            BtnUpdate.BackColor = Color.Silver;
            BtnUpdate.ForeColor = Color.Black;
        }

        private void BtnUpdate_MouseLeave(object sender, EventArgs e)
        {
            BtnUpdate.BackColor = Color.Black;
            BtnUpdate.ForeColor = Color.White;
        }

        private void BtnUpdate_MouseMove(object sender, MouseEventArgs e)
        {
            BtnUpdate.BackColor = Color.Silver;
            BtnUpdate.ForeColor = Color.Black;
        }

        private void BtnDelete_MouseEnter(object sender, EventArgs e)
        {
            BtnDelete.BackColor = Color.Silver;
            BtnDelete.ForeColor = Color.Black;
        }

        private void BtnDelete_MouseLeave(object sender, EventArgs e)
        {
            BtnDelete.BackColor = Color.Black;
            BtnDelete.ForeColor = Color.White;
        }

        private void BtnDelete_MouseMove(object sender, MouseEventArgs e)
        {
            BtnDelete.BackColor = Color.Silver;
            BtnDelete.ForeColor = Color.Black;
        }

        private void btnBuyNow_MouseEnter(object sender, EventArgs e)
        {
            btnBuyNow.ForeColor = Color.Red;
        }

        private void btnBuyNow_MouseLeave(object sender, EventArgs e)
        {
            btnBuyNow.ForeColor = Color.White;
        }

        private void btnBuyNow_MouseMove(object sender, MouseEventArgs e)
        {
            btnBuyNow.ForeColor = Color.Red;
        }

        private void SignOut_Click(object sender, EventArgs e)
        {
            HOME hm = new HOME();
            hm.Show();
            this.Hide();
        }

        private void btnBuyNow_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='F:\C# FINAL ASSIGNMENT (GROUP 06)\DATABASE (Accounts).mdf';Integrated Security=True;Connect Timeout=30");

            String delete = "DELETE FROM Items";
            SqlCommand cmd = new SqlCommand(delete, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your order is successfull!", "CONGRATULATIONS!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logged_HomeScreen lh = new Logged_HomeScreen();
                lh.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error detected :" + ex, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
