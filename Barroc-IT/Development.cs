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
    public partial class Development : Form
    {

        public Development()
        {
            InitializeComponent();
        }

        private void Development_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Tabcontrol1.SelectedTab = tabPage1;
            label1.ForeColor = Color.Red;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Tabcontrol1.SelectedTab = tabPage2;
            label1.ForeColor = Color.Black;
            label4.ForeColor = Color.Red;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Tabcontrol1.SelectedTab = tabPage3;
            label1.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Red;
            label6.ForeColor = Color.Black;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Tabcontrol1.SelectedTab = tabPage4;
            label1.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Red;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

    }
}
