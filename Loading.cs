using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buysmart_Online_Shopping_Store
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 3;
            if(panel2.Width >= 1000)
            {
                timer1.Stop();
                HOME h = new HOME();
                h.Show();
                this.Hide();
            }
        }

        private void Loading_Load(object sender, EventArgs e)
        {

        }
    }
}
