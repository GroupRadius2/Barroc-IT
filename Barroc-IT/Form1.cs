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
    public partial class Form1 : Form
    {
        public string psS = "sales123";
        private string psF = "";
        public string psD = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database.GetInstance().CloseConnection();
            Database.GetInstance().OpenConnection();

            switch(comboBox1.Text)
            {
                case "Finance":
                    if (textBox2.Text == psF)
                    {
                        FormFinance finance = new FormFinance();
                        finance.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid login credentials");
                    }
                    break;
                case "Development":
                    if (textBox2.Text == psD)
                    {
                        Development d = new Development();
                        d.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid login credentials");
                    }
                    break;
                case "Sales":
                    if (textBox2.Text == psS)
                    {
                        Sales_dash SD = new Sales_dash();
                        SD.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid login credentials");
                    }
                    break;
                default:
                    MessageBox.Show("Invalid login credentials");
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Text = comboBox1.GetItemText(comboBox1.Items[0]);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                switch (comboBox1.Text)
                {
                    case "Finance":
                        if (textBox2.Text == psF)
                        {
                            MainForm mf = new MainForm();
                            mf.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Invalid login credentials");
                        }
                        break;
                    case "Development":
                        if (textBox2.Text == psD)
                        {
                            Development d = new Development();
                            d.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid login credentials");
                        }
                        break;
                    case "Sales":
                        if (textBox2.Text == psS)
                        {
                            Sales_dash SD = new Sales_dash();
                            SD.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid login credentials");
                        }
                        break;
                    default:
                        MessageBox.Show("Invalid login credentials");
                        break;
                }
            }
        }
    }   
}
