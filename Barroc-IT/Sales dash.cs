using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barroc_IT
{
    public partial class Sales_dash : Form
    {
        public Sales_dash()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageNewCustomer MNC = new MessageNewCustomer();
            MNC.Show();        
        }

        private void label1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            Sales_dash SD = new Sales_dash();
            SD.Close();
            login.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageNewProject MNP = new MessageNewProject();
            MNP.Show();        
        }

        private void label7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage6;
        }
    }
}
