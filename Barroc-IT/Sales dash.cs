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
        private selectedIndexCustomer;
        public Sales_dash()
        {
            selectedIndexCustomer = 1;
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

            MessageNewCustomer MNC = new MessageNewCustomer(this);
            MNC.Show();
            MNC.lblAddress1.Text = textBoxAddress1.Text;
            MNC.lblAddress2.Text = textBoxAddress2.Text;
            MNC.lblTelephone1.Text = textBoxTelephone1.Text;
            MNC.lblTelephone2.Text = textBoxTelephone2.Text;
            MNC.lblEmail.Text = textBoxEmail.Text;
            MNC.lblCompanyName.Text = textBoxCompanyName.Text;
            MNC.lblZipcode1.Text = textBoxZipcode1.Text;
            MNC.lblZipcode2.Text = textBoxZipcode2.Text;
            MNC.lblResidence1.Text = textBoxResidence1.Text;
            MNC.lblResidence2.Text = textBoxResidence2.Text;
            MNC.lblContactperson.Text = textBoxContactPerson.Text;
            MNC.lblFaxnumber.Text = textBoxFaxnumber.Text;
            MNC.lblHousenumber.Text = textBoxHousenumber.Text;
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
            Database.GetInstance().QueryInDatagridView("SELECT * FROM tbl_companies;", dataGridView3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin login = new FormLogin();
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

        private void Sales_dash_Load(object sender, EventArgs e)
        {
           Database.GetInstance().QueryInDatagridView("SELECT * FROM tbl_companies;", dataGridView3);
           Database.GetInstance().QueryInDatagridView("SELECT * FROM tbl_appiontments", dataGridView1);
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView3.SelectedRows)
            {
                if (row.Selected)
                {
                    if (row.Cells[0].Value.ToString() != null)
                    {
                        if (int.TryParse(row.Cells[0].Value.ToString(), out selectedIndexCustomer))
                        {
                            textBoxChangeCustomerId.Text = row.Cells[1].Value.ToString();
                            textBoxChangeInvoiceDescription.Text = row.Cells[2].Value.ToString();
                            textBoxChangeInvoicePrice.Text = row.Cells[3].Value.ToString();

                            tabControlFinance.SelectTab(tabPageChangeInvoice);
                        }
                    }
                }   
            }
        }
        }
    }
