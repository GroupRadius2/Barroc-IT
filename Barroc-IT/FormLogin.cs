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
    public partial class FormLogin : Form
    {
        private string psS = "sales123";
        private string psF = "";
        private string psD = "development123";

        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
                        MainForm mf = new MainForm();
                        mf.Show();
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
                        MainForm mf = new MainForm();
                        mf.Show();
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
                            MainForm mf = new MainForm();
                            mf.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Invalid login credentials");
                        }
                        break;
                    case "Sales":
                        if (textBox2.Text == psS)
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
                    default:
                        MessageBox.Show("Invalid login credentials");
                        break;
                }
            }
        }
    }   
}
