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
    public partial class ACCESSORIES : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='F:\C# FINAL ASSIGNMENT (GROUP 06)\DATABASE (Accounts).mdf';Integrated Security=True;Connect Timeout=30");

        public ACCESSORIES()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void PicExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void BtnAccessories_Click(object sender, EventArgs e)
        {
            ACCESSORIES a = new ACCESSORIES();
            a.Show();
            this.Hide();
        }

        private void Bbutton1_Click(object sender, EventArgs e)
        {
            SignIn si = new SignIn();
            si.Show();
            this.Hide();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            SignIn si = new SignIn();
            si.Show();
            this.Hide();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            MainPic.Show();
            MOBILES.Hide();
            LAPTOPS.Hide();
            NormalPanel.Show();
            MainPicLaptops.Hide();
            MainPicMobiles.Hide();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Mobiles")
            {
                MOBILES.Show();
                LAPTOPS.Hide();
                MainPic.Hide();
                NormalPanel.Hide();
                MainPicLaptops.Hide();
                MainPicMobiles.Show();
            }
            else if (comboBox1.SelectedItem.ToString() == "Laptops")
            {
                LAPTOPS.Show();
                MOBILES.Hide();
                MainPic.Hide();
                NormalPanel.Hide();
                MainPicMobiles.Hide();
                MainPicLaptops.Show();
            }
            else
            {
                MOBILES.Hide();
                LAPTOPS.Hide();
                MainPic.Show();
                MainPicMobiles.Hide();
                MainPicLaptops.Hide();
            }
        }

        private void HeadPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void HeadPanel_MouseEnter(object sender, EventArgs e)
        {
            Heading.ForeColor = Color.DeepSkyBlue;
        }

        private void HeadPanel_MouseMove(object sender, MouseEventArgs e)
        {
            Heading.ForeColor = Color.DeepSkyBlue;
        }

        private void HeadPanel_MouseLeave(object sender, EventArgs e)
        {
            Heading.ForeColor = Color.LightCoral;
        }

        private void MOBILES_Enter(object sender, EventArgs e)
        {

        }

        private void Heading_MouseLeave(object sender, EventArgs e)
        {
            Heading.ForeColor = Color.LightCoral;
        }

        private void Heading_MouseMove(object sender, MouseEventArgs e)
        {
            Heading.ForeColor = Color.DeepSkyBlue;
        }

        private void Heading_MouseEnter(object sender, EventArgs e)
        {
            Heading.ForeColor = Color.DeepSkyBlue;
        }

        private void HeadPanel_MouHeadPanel_MouseDownseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnAddToCart6_Click(object sender, EventArgs e)
        { 
            string query = "Insert into Items Values ( '" + lblID6.Text + "' , '" + C01.Text + "' , '" + "Display-15.60 inch, Processor-Core i7, Hard Disk-1TB, Ram-16GB, OS-Windows 10 Home, Graphics-Nvidia GeForce GTX 1050" + "', '" + C01Price.Text + "' , '" + C1Qty.SelectedItem + "' ,'" + C01Price.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Items successfully added to your cart!", "CONGRATULATIONS!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void BtnAddToCart2_Click(object sender, EventArgs e)
        {
            string query = "Insert into Items Values ( '" + lblID2.Text + "' , '" + M02.Text + "' , '" + "Display-6.5 inch, Apple A12 Bionic, 4GB Ram, Battery-3174mAh, Front Camera- 7MP, Rear camera-12MP, Storage-64GB" + "', '" + M02Price.Text + "' , '" + M2Qty.SelectedItem + "' , '" + M02Price.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Items successfully added to your cart!", "CONGRATULATIONS!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void BtnAddToCart3_Click(object sender, EventArgs e)
        {
            string query = "Insert into Items Values ( '" + lblID3.Text + "' , '" + M03.Text + "' , '" + "Display-6.5 inch, Apple A13 Bionic, 4GB Ram, Battery-3969mAh, Front Camera- 12MP, Rear camera-12MP, Storage-64GB" + "', '" + M03Price.Text + "' , '" + M3Qty.SelectedItem + "' , '" + M03Price.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Items successfully added to your cart!", "CONGRATULATIONS!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void BtnAddToCart4_Click(object sender, EventArgs e)
        {
            string query = "Insert into Items Values ( '" + lblID4.Text + "' , '" + M04.Text + "' , '" + "Display-6.1 inch, Kirin 970, 6/8GB Ram, Battery-4000mAh, Front Camera- 24MP, Rear camera-40MP, Storage-64/128/256GB" + "', '" + M04Price.Text + "' , '" + M4Qty.SelectedItem + "' , '" + M04Price.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Items successfully added to your cart!", "CONGRATULATIONS!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void BtnAddToCart5_Click(object sender, EventArgs e)
        {
            string query = "Insert into Items Values ( '" + lblID5.Text + "' , '" + M05.Text + "' , '" + "Display-6.4inch, Exynos 9820, 8/12GB Ram, Battery-4100mAh, Front Camera- 10MP, Rear camera-12MP, Storage-64/128/256GB" + "', '" + M05Price.Text + "' , '" + M5Qty.SelectedItem + "' , '" + M05Price.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Items successfully added to your cart!", "CONGRATULATIONS!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error detected :" + ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void BtnAddToCart7_Click(object sender, EventArgs e)
        {
            string query = "Insert into Items Values ( '" + lblID7.Text + "' , '" + C02.Text + "' , '" + "Display-13.30 inch, Processor-Core i7, Hard Disk-No, SSD-360GB, Ram-8GB, OS-Windows 10 Home, Graphics-Intel Integrated UHD Graphics 620" + "', '" + C02Price.Text + "' , '" + C2Qty.SelectedItem + "' , '" + C02Price.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Items successfully added to your cart!", "CONGRATULATIONS!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void BtnAddToCart8_Click(object sender, EventArgs e)
        {
            string query = "Insert into Items Values ( '" + lblID8.Text + "' , '" + C03.Text + "' , '" + "Display-16 inch, Processor-Core i9, Storage-512 GB SSD, Ram-16GB, OS-Windows 10 Home, Graphics-Nvidia GeForce GTX 1660 Ti" + "', '" + C03Price.Text + "' , '" + C3Qty.SelectedItem + "' , '" + C03Price.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Items successfully added to your cart!", "CONGRATULATIONS!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void BtnAddToCart9_Click(object sender, EventArgs e)
        {
            string query = "Insert into Items Values ( '" + lblID9.Text + "' , '" + C04.Text + "' , '" + "Display-15.6 inch, Processor-Core i7, Storage-iTB HDD, Ram-8GB, OS-Windows 10 Home, Graphics-Nvidia VGA" + "', '" + C04Price.Text + "' , '" + C4Qty.SelectedItem + "' , '" + C04Price.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Items successfully added to your cart!", "CONGRATULATIONS!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void BtnAddToCart10_Click(object sender, EventArgs e)
        {
            string query = "Insert into Items Values ( '" + lblID10.Text + "' , '" + C05.Text + "' , '" + "Display-15.6 inch, Processor-Core i5, Storage-iTB HDD, Ram-8GB, OS-Windows 10 Home, Graphics-MX130 DDR5" + "', '" + C05Price.Text + "' , '" + C5Qty.SelectedItem + "' , '" + C05Price.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Items successfully added to your cart!", "CONGRATULATIONS!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void Button1_Click(object sender, EventArgs e)
        {
            SignIn si = new SignIn();
            si.Show();
            this.Hide();
        }

        private void btnAddToCart1_Click(object sender, EventArgs e)
        {
            string query = "Insert into Items Values ( '" + lblID1.Text + "' , '" + M01.Text + "' , '" + "Display-6.90-inch (1440x3200), Processor-Samsung Exynos 990, Front Camera-40MP, Rear Camera-108MP + 48MP + 12MP + Depth, RAM-12GB, Storage-128GB, Battery Capacity-5000mAh, OS-Android 10" + "', '" + M01Price.Text + "' , '" + M1Qty.SelectedItem + "' , '" + M01Price.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Items successfully added to your cart!", "CONGRATULATIONS!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void MOBILES_Enter_1(object sender, EventArgs e)
        {

        }

        private void HeadPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblID1_Click(object sender, EventArgs e)
        {

        }

        private void lblID2_Click(object sender, EventArgs e)
        {

        }

        private void lblID3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
