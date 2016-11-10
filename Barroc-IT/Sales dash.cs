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
        private int selectedIndexCustomer;
        private int selectedIndexAppointments;
        public Sales_dash()
        {
            selectedIndexCustomer = 1;
            selectedIndexAppointments = 1;
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            tabControlSales.SelectedTab = tabNewCustomer;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            tabControlSales.SelectedTab = TabDashboard;
        }

        private void customerSave_Click(object sender, EventArgs e)
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
            tabControlSales.SelectedTab = TabDashboard;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            tabControlSales.SelectedTab = tabCustomerFinance;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            tabControlSales.SelectedTab = tabCustomers;
            Database.GetInstance().QueryInDatagridView("SELECT * FROM tbl_companies;", dataGridCustomers);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin login = new FormLogin();
            login.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControlSales.SelectedTab = TabDashboard;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageNewProject MNP = new MessageNewProject(this);
            MNP.Show();
            MNP.lblCompanyName.Text = textBoxC_Name.Text;
            MNP.lblCustomerName.Text = textBoxCustomerName.Text;
            MNP.lblProjectName.Text = textBoxP_Name.Text;
            MNP.lblStartDate.Text = textBoxBeginDate.Text;
            MNP.lblEndDate.Text = textBoxEndDate.Text;
            MNP.lblCost.Text = textBoxCost.Text;
            MNP.lblTerms.Text = textBoxTerms.Text;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            tabControlSales.SelectedTab = tabNewProject;
            Database.GetInstance().QueryInDatagridView("SELECT * FROM tbl_projects;", datagridProjects);
        }

        private void Sales_dash_Load(object sender, EventArgs e)
        {
            this.dataGridAppointments.DefaultCellStyle.Font = new Font("Tahoma", 16);
            this.dataGridAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Database.GetInstance().QueryInDatagridView("SELECT * FROM tbl_companies;", dataGridCustomers);
            Database.GetInstance().QueryInDatagridView("SELECT a_date AS Date, a_time_of AS Time, project_id AS Projects FROM tbl_appointments", dataGridAppointments);
            Database.GetInstance().QueryInDatagridView("SELECT * FROM tbl_projects", datagridProjects);
            Database.GetInstance().QueryInDatagridView("SELECT * FROM tbl_appointments", dataGridAppointments);
            UpdateInfo();

        }

        private void label8_Click(object sender, EventArgs e)
        {
            tabControlSales.SelectedTab = tabTemplateProjects;
            UpdateInfo();
        }

        private void dataGridCustomers_SelectionChanged_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridCustomers.Rows)
            {
                if (row.Selected)
                {
                    tabControlSales.SelectedTab = tabChangeCustomer;

                    txtbChAdress.Text = row.Cells["c_address"].Value.ToString();
                    txtbChAdress2.Text = row.Cells["c_address2"].Value.ToString();
                    txtbChCompanyName.Text = row.Cells["c_name"].Value.ToString();
                    txtbChHousenumber.Text = row.Cells["c_housenumber"].Value.ToString();
                    txtbChCity.Text = row.Cells["c_city"].Value.ToString();
                    txtbChContactperson.Text = row.Cells["c_contactperson_first_name"].Value.ToString();
                    txtbChTelephone.Text = row.Cells["c_contactperson_telephone_number"].Value.ToString();
                    txtbChTelephone2.Text = row.Cells["c_contactperson_telephone_number2"].Value.ToString();
                    txtbChFaxnumber.Text = row.Cells["c_contactperson_faxnumber"].Value.ToString();
                    txtbChEmail.Text = row.Cells["c_contactperson_email"].Value.ToString();
                    txtbChZipcode.Text = row.Cells["c_zipcode"].Value.ToString();
                    txtbChZipcode2.Text = row.Cells["c_zipcode2"].Value.ToString();
                    txtbChCity2.Text = row.Cells["c_city2"].Value.ToString();
                }
            }
        }

        private void buttonBackChangeCustomers_Click(object sender, EventArgs e)
        {
            tabControlSales.SelectedTab = tabCustomers;
        }

        private void btnChSave_Click(object sender, EventArgs e)
        {
            Database.GetInstance().Query("UPDATE tbl_companies SET c_name = @c_name, c_address = @c_address, c_housenumber = @c_housenumber, c_city = @c_city, c_contactperson_first_name = @c_contactperson_first_name, " +
                "c_contactperson_telephone_number = @c_contactperson_telephone_number, @c_contactperson_faxnumber = @c_contactperson_faxnumber, c_contactperson_email = @c_contactperson_email, c_contactperson_telephone_number2 = @c_contactperson_telephone_number2, c_city2 = @c_city2, c_zipcode = @c_zipcode, c_zipcode2 = @c_zipcode2, c_address2 = @c_address2");
            Database.GetInstance().AddParameter("@c_name", txtbChCompanyName.Text);
            Database.GetInstance().AddParameter("@c_address", txtbChAdress.Text);
            Database.GetInstance().AddParameter("@c_housenumber", txtbChHousenumber.Text);
            Database.GetInstance().AddParameter("@c_city", txtbChCity.Text);
            Database.GetInstance().AddParameter("@c_contactperson_first_name", txtbChContactperson.Text);
            Database.GetInstance().AddParameter("@c_contactperson_telephone_number", txtbChTelephone.Text);
            Database.GetInstance().AddParameter("@c_contactperson_faxnumber", txtbChFaxnumber.Text);
            Database.GetInstance().AddParameter("@c_contactperson_telephone_number2", txtbChTelephone2.Text);
            Database.GetInstance().AddParameter("@c_contactperson_email", txtbChEmail.Text);
            Database.GetInstance().AddParameter("@c_zipcode", txtbChZipcode.Text);
            Database.GetInstance().AddParameter("@c_zipcode2", txtbChZipcode2.Text);
            Database.GetInstance().AddParameter("@c_address2", txtbChAdress2.Text);
            Database.GetInstance().AddParameter("@c_city2", txtbChCity2.Text);

            Database.GetInstance().ExecuteQuery();
            UpdateInfo();
        }
        public void UpdateInfo()
        {
            Database.GetInstance().QueryInDatagridView("SELECT * FROM tbl_companies WHERE c_creditworthy = 0", dataGridNegativeB);
            Database.GetInstance().QueryInDatagridView("SELECT * FROM tbl_companies WHERE c_creditworthy = 1", dataGridPositiveB);
            Database.GetInstance().QueryInDatagridView("SELECT * FROM tbl_companies", dataGridCustomers);
            Database.GetInstance().QueryInDatagridView("SELECT * FROM tbl_projects", datagridProjects);
            Database.GetInstance().QueryInDatagridView("SELECT * FROM tbl_appointments", dataGridAppointments);

            Database.GetInstance().Query("SELECT COUNT(*) FROM tbl_companies WHERE c_creditworthy = 0");
            lblNegBalance.Text = Database.GetInstance().ExecuteQuery().ToString();
            Database.GetInstance().Query("SELECT COUNT(*) FROM tbl_companies WHERE c_creditworthy = 1");
            lblPosBalance.Text = Database.GetInstance().ExecuteQuery().ToString();
        }

        private void btnNewApp_Click(object sender, EventArgs e)
        {
            tabControlSales.SelectedTab = tabNewAppointment;
        }

        private void lblNotification_Click(object sender, EventArgs e)
        {
            FormNotifications salesNotification = new FormNotifications(Department.Sales);
            salesNotification.ReceiveMessages();
            salesNotification.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime dt;
            DateTime.TryParse(textBoxA_time.Text, out dt);

            int countOfAppointments = (int)Database.GetInstance().ExecuteQuery();
            Database.GetInstance().Query("INSERT INTO tbl_appointments(appointment_id, project_id, a_date, a_time_of)" +
                "VALUES(@appointment_id, @project_id, @a_date, @a_time_of)");
            Database.GetInstance().AddParameter("@appointment_id", ++countOfAppointments);
            Database.GetInstance().AddParameter("@project_id", textBoxA_Project.Text);
            Database.GetInstance().AddParameter("@a_date", textBoxA_Date.Text);
            Database.GetInstance().AddParameter("@a_time_of", dt);

            Database.GetInstance().ExecuteQuery();
            tabControlSales.SelectedTab = TabDashboard;
            UpdateInfo();
        }

        private void buttonDeleteCustomer_Click(object sender, EventArgs e)
        {
            Database.GetInstance().Query("DELETE FROM tbl_companies WHERE c_id = @c_id");
            Database.GetInstance().AddParameter("@c_id", selectedIndexCustomer);

            Database.GetInstance().ExecuteQuery();
            tabControlSales.SelectedTab = tabCustomers;
        }

        private void btnA_Back_Click(object sender, EventArgs e)
        {
            tabControlSales.SelectedTab = TabDashboard;
        }

        private void btnDelete_ChA_Click(object sender, EventArgs e)
        {
            Database.GetInstance().Query("DELETE FROM tbl_appointments WHERE appointment_id = @appointment_id");
            Database.GetInstance().AddParameter("@appointments_id", selectedIndexAppointments);

            Database.GetInstance().ExecuteQuery();
            tabControlSales.SelectedTab = TabDashboard;
        }

        private void btnBack_ChA_Click(object sender, EventArgs e)
        {
            tabControlSales.SelectedTab = TabDashboard;
        }

        private void dataGridAppointments_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridAppointments.Rows)
            {
                if (row.Selected)
                {
                    if (row != null)
                    {
                        tabControlSales.SelectedTab = tabChange_A;

                        textBoxA_Project.Text = row.Cells["project_id"].Value.ToString();
                        textBoxA_Date.Text = row.Cells["a_date"].Value.ToString();
                        textBoxA_time.Text = row.Cells["a_time_of"].Value.ToString();
                    }
                    MessageBox.Show("Wrong Selection");
                }
            }
        }

        private void btnCh_Save_Click(object sender, EventArgs e)
        {
            tabControlSales.SelectedTab = TabDashboard;
            Database.GetInstance().Query("UPDATE tbl_appointments SET project_id = @project_id, a_date = @a_date, a_time_off = @a_time_off");
            Database.GetInstance().AddParameter("@project_id", textBChA_projects.Text);
            Database.GetInstance().AddParameter("@a_date", textBChA_Date.Text);
            Database.GetInstance().AddParameter("@a_time_of", textBChA_time.Text);
            Database.GetInstance().ExecuteQuery();
            Database.GetInstance().QueryInDatagridView("SELECT * FROM tbl_appointments", dataGridAppointments);

            UpdateInfo();
        }
        }
    }
