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
    public partial class FormFinance : Form
    {
        private Database database;
        private int selectedIndexInvoice;
        private int selectedIndexCustomer;
        private int selectedIndexProject;
        private string queryProjects;

        public FormFinance()
        {
            InitializeComponent();
            selectedIndexInvoice = 0;
            selectedIndexCustomer = 0;
            queryProjects = "SELECT tbl_companies.c_id, c_name, p_active FROM tbl_companies, tbl_projects WHERE p_paid = 0;";
            database = Database.GetInstance();
            try
            {
                database.OpenConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.FormClosing += FormFinance_FormClosing;
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
            this.Close();
        }

        private void FormFinance_FormClosing(object sender, FormClosingEventArgs e)
        {
            database.CloseConnection();
        }

        private void labelCustomers_Click(object sender, EventArgs e)
        {
            UpdateInfo();
            tabControlFinance.SelectTab(tabPageCustomers);
            labelCustomers.ForeColor = Color.Red;
        }

        private void labelProjects_Click(object sender, EventArgs e)
        {
            UpdateInfo();
            tabControlFinance.SelectTab(tabPageProjects);
            labelProjects.ForeColor = Color.Red;
        }

        private void FormFinance_Load(object sender, EventArgs e)
        {
            database.QueryInDatagridView("SELECT tbl_companies.c_id, c_name, SUM(p_cost) AS Earned FROM tbl_companies, tbl_projects" +
                " WHERE p_paid = 'True' AND tbl_projects.c_id = tbl_companies.c_id GROUP BY tbl_companies.c_id, c_name;", dataGridViewEarnedCustomers);
            database.QueryInDatagridView("SELECT tbl_companies.c_id, c_name, p_active FROM tbl_companies, tbl_projects WHERE p_paid = 'False';", dataGridViewCustomersProjectNeedsPay);

            UpdateInfo();
        }

        private void labelInvoices_Click(object sender, EventArgs e)
        {
            UpdateInfo();
            tabControlFinance.SelectTab(tabPageInvoices);
            labelInvoices.ForeColor = Color.Red;
        }

        private void labelDashboard_Click(object sender, EventArgs e)
        {
            UpdateInfo();
            tabControlFinance.SelectTab(tabPageDashboard);
            labelDashboard.ForeColor = Color.Red;
        }

        private void labelAddCustomer_Click(object sender, EventArgs e)
        {
            UpdateInfo();
            tabControlFinance.SelectTab(tabPageAddCustomer);
            //labelAddCustomer.ForeColor = Color.Red;
        }

        private void labelAddInvoice_Click(object sender, EventArgs e)
        {
            UpdateInfo();
            labelAddInvoice.ForeColor = Color.Red;
            tabControlFinance.SelectTab(tabPageAddInvoice);
        }

        private void buttonCompanySave_Click(object sender, EventArgs e)
        {
            UpdateInfo();

            string ledgerZeros = "";
            int counterLedgerZeros = 0;

            while (textBoxLedgerCustomerInfo.Text.Length < 10)
            {
                counterLedgerZeros++;
                ledgerZeros += "0";
            }

            textBoxLedgerCustomerInfo.Text = ledgerZeros + textBoxLedgerCustomerInfo.Text;

            database.Query("SELECT COUNT(*) FROM tbl_companies");
            int countOfCompanyId = (int)database.ExecuteQuery();

            database.Query("INSERT INTO tbl_companies(c_id, c_name, c_address, c_housenumber, c_code, c_city, c_contactperson, c_contactperson_initials, " +
                "c_contactperson_telephonenumber, c_contactperson_faxnumber, c_contactperson_email, c_potential_customer, c_last_contact_date, c_creditworthy, " +
                "c_discount, c_banknumber, c_credit_balance, c_revenue, c_limit, c_ledger, c_btw_code, c_maintenance_contract)" +
                "VALUES(@id, @c_name, @c_address, @c_housenumber, @c_code, @c_city, @c_contactperson, @c_contactperson_initials, @c_contactperson_telephonenumber, " +
                "@c_contactperson_faxnumber, @c_contactperson_email, @c_potential_customer, @c_last_contact_date, @c_creditworthy, @c_discount, @c_banknumber, " +
                "@c_credit_balance, @c_revenue, @c_limit, @c_ledger, @c_btw_code, @c_maintenance_contract);");

            database.AddParameter("@id", ++countOfCompanyId);
            database.AddParameter("@c_name", textBoxAddCustomerCompanyName.Text);
            database.AddParameter("@c_address", textBoxAddCustomerCompanyAddress.Text);
            database.AddParameter("@c_housenumber", textBoxAddCustomerCompanyHouseNumber.Text);
            database.AddParameter("@c_code", textBoxAddCustomerCompanyCode.Text);
            database.AddParameter("@c_city", textBoxAddCustomerCompanyCity.Text);
            database.AddParameter("@c_contactperson", textBoxAddCustomerContactperson.Text);
            database.AddParameter("@c_contactperson_initials", textBoxAddCustomerInitials.Text);
            database.AddParameter("@c_contactperson_telephonenumber", textBoxAddCustomerTelephone.Text);
            database.AddParameter("@c_contactperson_faxnumber", textBoxAddCustomerFaxnumber.Text);
            database.AddParameter("@c_contactperson_email", textBoxAddCustomerEmail.Text);
            database.AddParameter("@c_potential_customer", checkBoxAddCustomerPotentialCustomer.Checked ? 1 : 0);
            database.AddParameter("@c_last_contact_date", textBoxAddCustomerCompanyLastContactDate.Text);
            database.AddParameter("@c_creditworthy", checkBoxAddCustomerCompanyCreditworthy.Checked ? 1 : 0);
            database.AddParameter("@c_discount", textBoxAddCustomerDiscount.Text);
            database.AddParameter("@c_banknumber", textBoxAddCustomerBanknumber.Text);
            database.AddParameter("@c_credit_balance", textBoxAddCustomerCompanyCreditBalance.Text);
            database.AddParameter("@c_revenue", textBoxAddCustomerRevenue.Text);
            database.AddParameter("@c_limit", textBoxAddCustomerLimit.Text);
            database.AddParameter("@c_ledger", textBoxAddCustomerLedger.Text);
            database.AddParameter("@c_btw_code", textBoxAddCustomerVATCode.Text);
            database.AddParameter("@c_maintenance_contract", textBoxAddCustomerMainContract.Text);

            database.ExecuteQuery();
        }

        private void UpdateInfo()
        {
            //labelAddCustomer.ForeColor = Color.Black;
            labelDashboard.ForeColor = Color.Black;
            labelProjects.ForeColor = Color.Black;
            labelCustomers.ForeColor = Color.Black;
            labelAddInvoice.ForeColor = Color.Black;
            labelInvoices.ForeColor = Color.Black;

            database.Query("SELECT COUNT(*) FROM tbl_companies WHERE c_credit_balance >= 0");
            labelPositiveBalances.Text = "Positive balances (" + database.ExecuteQuery() + ")";

            database.Query("SELECT COUNT(*) FROM tbl_companies WHERE c_credit_balance < 0");
            labelNegativeBalances.Text = "Negative balances (" + database.ExecuteQuery() +")";

            database.Query("SELECT COUNT(*) FROM tbl_invoices;");
            labelNumOfInvoices.Text = "Total Invoices (" + database.ExecuteQuery() + ")";

            database.Query("SELECT COUNT(*) FROM tbl_messages;");
            labelNotifications.Text = "Notifications ( " + database.ExecuteQuery() + " )";

            database.QueryInDatagridView("SELECT project_id, p_name, p_active FROM tbl_projects", dataGridViewProjects);
            database.QueryInDatagridView("SELECT * FROM tbl_invoices", dataGridViewInvoices);
            database.QueryInDatagridView("SELECT * FROM tbl_companies WHERE c_credit_balance >= 0", dataGridViewPositiveCompanies);
            database.QueryInDatagridView("SELECT * FROM tbl_companies WHERE c_credit_balance < 0", dataGridViewNegativeCompanies);
        }

        private void buttonSaveInvoice_Click(object sender, EventArgs e)
        {
            UpdateInfo();

            database.Query("SELECT COUNT(*) FROM tbl_invoices");
            int countOfInvoicesId = (int)database.ExecuteQuery();

            database.Query("INSERT INTO tbl_invoices(invoice_id, project_id, i_description, i_price, i_paid) VALUES " +
                "(@id, @project_id, @i_description, @i_price, @i_paid);");

            database.AddParameter("@id", ++countOfInvoicesId);
            database.AddParameter("@project_id", textBoxProjectId.Text);
            database.AddParameter("@i_description", textBoxInvoiceDescription.Text);
            database.AddParameter("@i_price", textBoxInvoicePrice.Text);
            database.AddParameter("@i_paid", checkBoxAddInvoicePaid.Checked ? 1 : 0); 

            ConfirmBoxBuilder builder = new ConfirmBoxBuilder();
            builder.BuildSize(400, 500);
            builder.BuildTop("Are you sure you want to save the following information:");
            builder.BuildCenter("Project id: " + countOfInvoicesId.ToString() + Environment.NewLine +
                "Description: " + textBoxInvoiceDescription.Text + Environment.NewLine +
                "Price: " + textBoxInvoicePrice.Text + Environment.NewLine +
                "Paid: " + checkBoxChangeInvoicePaid.Checked.ToString());
            builder.BuildBottom(tabControlFinance, tabPageInvoices, dataGridViewInvoices, "SELECT * FROM tbl_invoices;");

            builder.GetConfirmBox().Show();
        }

        private void dataGridViewInvoices_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewInvoices.SelectedRows)
            {
                if (row.Selected)
                {
                    if (row.Cells[1].Value != null)
                    {
                        if (int.TryParse(row.Cells["invoice_id"].Value.ToString(), out selectedIndexInvoice))
                        {
                            textBoxChangeInvoiceProjectId.Text = row.Cells["project_id"].Value.ToString();
                            textBoxChangeInvoiceDescription.Text = row.Cells["i_description"].Value.ToString();
                            textBoxChangeInvoicePrice.Text = row.Cells["i_price"].Value.ToString();
                            checkBoxChangeInvoicePaid.Checked = (bool)row.Cells["i_paid"].Value;

                            tabControlFinance.SelectTab(tabPageChangeInvoice);
                        }
                    }
                }   
            }
        }

        private void buttonSaveChangeInvoice_Click(object sender, EventArgs e)
        {
            database.Query("UPDATE tbl_invoices SET project_id = @project_id, i_description = @i_description, i_price = @i_price WHERE invoice_id = @id;");

            database.AddParameter("@project_id", textBoxChangeInvoiceProjectId.Text);
            database.AddParameter("@i_description", textBoxChangeInvoiceDescription.Text);
            database.AddParameter("@i_price", textBoxChangeInvoicePrice.Text);
            database.AddParameter("@id", selectedIndexInvoice);

            ConfirmBoxBuilder builder = new ConfirmBoxBuilder();
            builder.BuildSize(500, 450);
            builder.BuildTop("You are about to save the following data:");
            builder.BuildCenter("Project id: " + textBoxChangeInvoiceProjectId.Text + Environment.NewLine + 
                "Description: " + textBoxChangeInvoiceDescription.Text + Environment.NewLine +
                "Price: " + textBoxChangeInvoicePrice.Text);
            builder.BuildBottom(tabControlFinance, tabPageInvoices, dataGridViewInvoices, "SELECT * FROM tbl_invoices;");
            builder.GetConfirmBox().Show();
        }

        private void buttonChangeCustomer_Click(object sender, EventArgs e)
        {
            database.Query("UPDATE tbl_companies SET c_name = @c_name, c_address = @c_address, " +
                "c_housenumber = @c_housenumber, c_code = @c_code, c_city = @c_city, c_contactperson = @c_contactperson, " +
                "c_contactperson_initials = @c_contactperson_initials, c_contactperson_telephonenumber = @c_contactperson_telephonenumber, " +
                "c_contactperson_faxnumber = @c_contactperson_faxnumber, c_contactperson_email = @c_contactperson_email, " +
                "c_potential_customer = @c_potential_customer, c_last_contactdate = @c_last_contactdate, " +
                "c_creditworthy = @c_creditworthy, c_discount = @c_discount, c_banknumber = @c_banknumber, " +
                "c_credit_balance = @c_credit_balance, c_revenue = @c_revenue, c_limit = @c_limit, " +
                "c_ledger = @c_ledger, c_btw_code = @c_btw_code, c_maintenance_contract = @c_maintenance_contract " +
                "WHERE c_id = @id");

            database.AddParameter("@id", selectedIndexCustomer);
            database.AddParameter("@c_name", textBoxNameCustomerInfo.Text);
            database.AddParameter("@c_address", textBoxAddressCustomerInfo.Text);
            database.AddParameter("@c_housenumber", textBoxHouseNumberCustomerInfo.Text);
            database.AddParameter("@c_code", textBoxCompanyCodeCustomerInfo.Text);
            database.AddParameter("@c_city", textBoxCityChangeCustomerInfo.Text);
            database.AddParameter("@c_contactperson", textBoxContactpersonCustomerInfo.Text);
            database.AddParameter("@c_contactperson_initials", textBoxInitialsCustomerInfo.Text);
            database.AddParameter("@c_contactperson_telephonenumber", textBoxTelephoneCustomerInfo.Text);
            database.AddParameter("@c_contactperson_faxnumber", textBoxFaxnumberCustomerInfo.Text);
            database.AddParameter("@c_contactperson_email", textBoxEmailCustomerInfo.Text);
            database.AddParameter("@c_potential_customer", checkBoxPotentialCustomerInfo.Checked ? 1 : 0);
            database.AddParameter("@c_last_contactdate", textBoxLastContactDateCustomerInfo.Text);
            database.AddParameter("@c_creditworthy", checkBoxCreditworthyCustomerInfo.Checked ? 1 : 0);
            database.AddParameter("@c_discount", textBoxDiscountCustomerInfo.Text);
            database.AddParameter("@c_banknumber", textBoxBanknumberCustomerInfo.Text);
            database.AddParameter("@c_credit_balance", textBoxCreditBalanceCustomerInfo.Text);
            database.AddParameter("@c_revenue", textBoxRevenueCustomerInfo.Text);
            database.AddParameter("@c_limit", textBoxLimitCustomerInfo.Text);
            database.AddParameter("@c_ledger", textBoxLedgerCustomerInfo.Text);
            database.AddParameter("@c_btw_code", textBoxVATCodeCustomerInfo.Text);
            database.AddParameter("@c_maintenance_contract", textBoxMaintenanceContractCustomerInfo.Text);

            database.ExecuteQuery();
        }

        private void SettingDataChangedCompanies(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                if (row.Selected)
                {
                    if (row.Cells[1] != null)
                    {
                        bool potentialCustomer;
                        bool creditWorthyChecked;
                        bool bkr;
                        int indexCustomer;

                        bool.TryParse(row.Cells["c_creditworthy"].Value.ToString(), out creditWorthyChecked);
                        int.TryParse(row.Cells["c_id"].Value.ToString(), out indexCustomer);

                        selectedIndexCustomer = indexCustomer;

                        textBoxNameCustomerInfo.Text = row.Cells["c_name"].Value.ToString();
                        textBoxAddressCustomerInfo.Text = row.Cells["c_address"].Value.ToString();
                        textBoxHouseNumberCustomerInfo.Text = row.Cells["c_housenumber"].Value.ToString();
                        textBoxCompanyCodeCustomerInfo.Text = row.Cells["c_code"].Value.ToString();
                        textBoxCityChangeCustomerInfo.Text = row.Cells["c_city"].Value.ToString();
                        textBoxContactpersonCustomerInfo.Text = row.Cells["c_contactperson_first_name"].Value.ToString() + " " + row.Cells["c_contactperson_last_name"].Value.ToString();
                        textBoxInitialsCustomerInfo.Text = row.Cells["c_contactperson_initials"].Value.ToString();
                        textBoxTelephoneCustomerInfo.Text = row.Cells["c_contactperson_telephone_number"].Value.ToString();
                        textBoxFaxnumberCustomerInfo.Text = row.Cells["c_contactperson_faxnumber"].Value.ToString();
                        textBoxEmailCustomerInfo.Text = row.Cells["c_contactperson_email"].Value.ToString();
                        checkBoxCreditworthyCustomerInfo.Checked = creditWorthyChecked;
                        textBoxDiscountCustomerInfo.Text = row.Cells["c_discount"].Value.ToString();
                        textBoxBanknumberCustomerInfo.Text = row.Cells["c_ledger"].Value.ToString();
                        textBoxCreditBalanceCustomerInfo.Text = row.Cells["c_credit_balance"].Value.ToString();
                        textBoxRevenueCustomerInfo.Text = row.Cells["c_revenue"].Value.ToString();
                        textBoxLimitCustomerInfo.Text = row.Cells["c_limit"].Value.ToString();
                        textBoxLedgerCustomerInfo.Text = row.Cells["c_ledger"].Value.ToString();
                        textBoxVATCodeCustomerInfo.Text = row.Cells["c_btw_code"].Value.ToString();
                        textBoxMaintenanceContractCustomerInfo.Text = row.Cells["c_maintenance_contract"].Value.ToString();
                        bool.TryParse(row.Cells["c_potential_customer"].Value.ToString(), out potentialCustomer);
                        checkBoxPotentialCustomerInfo.Checked = potentialCustomer;

                        bool.TryParse(row.Cells["c_bkr"].Value.ToString(), out bkr);
                        textBoxCustomerInfoBKR.Text = bkr ? "Positive" : "Negative";

                        tabControlFinance.SelectTab(tabPageCustomerInfo);
                    }
                }
            }
        }

        private void dataGridViewPositiveCompanies_SelectionChanged(object sender, EventArgs e)
        {
            SettingDataChangedCompanies(dataGridViewPositiveCompanies);
        }

        private void dataGridViewNegativeCompanies_SelectionChanged(object sender, EventArgs e)
        {
            SettingDataChangedCompanies(dataGridViewNegativeCompanies);
        }

        private void buttonBackChangeCustomers_Click(object sender, EventArgs e)
        {
            tabControlFinance.SelectTab(tabPageCustomers);
        }

        private void buttonDeleteCustomer_Click(object sender, EventArgs e)
        {
            /*database.Query("DELETE * FROM tbl_customers WHERE c_id = @id;");

            database.AddParameter("@id", selectedIndexCustomer);

            ConfirmBoxBuilder builder = new ConfirmBoxBuilder();
            builder.BuildTop("Are you sure you want to delete the following information:");
            builder.BuildCenter("Address: " + textBoxAddressCustomerInfo.Text);
            builder.BuildBottom();
            builder.GetConfirmBox().Show();*/
        }

        private void buttonBackInvoice_Click(object sender, EventArgs e)
        {
            tabControlFinance.SelectTab(tabPageInvoices);
        }

        private void buttonDeleteInvoice_Click(object sender, EventArgs e)
        {
            database.Query("DELETE * FROM tbl_invoices WHERE invoice_id = @id;");

            database.AddParameter("@id", selectedIndexInvoice);

            ConfirmBoxBuilder builder = new ConfirmBoxBuilder();
            builder.BuildTop("Are you sure you want to delete the following information: ");
            builder.BuildCenter("Project id: " + textBoxChangeInvoiceProjectId.Text + Environment.NewLine +
                "Description: " + textBoxChangeInvoiceDescription.Text + Environment.NewLine +
                "Price: " + textBoxChangeInvoicePrice.Text);
            builder.BuildBottom(tabControlFinance, tabPageInvoices, dataGridViewInvoices, "SELECT * FROM tbl_invoices;");

            database.ExecuteQuery();
        }

        private void dataGridViewProjects_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewProjects.Rows)
            {
                if (row.Selected)
                {
                    if (row.Cells[0].Value != null)
                    {
                        bool isActiveProject = false;
                        bool activeProject;

                        if (bool.TryParse(row.Cells["p_active"].Value.ToString(), out activeProject))
                        {
                            isActiveProject = true;
                        }

                        selectedIndexProject = (int)row.Cells["project_id"].Value;

                        textBoxChangeProjectName.Text = row.Cells["p_name"].Value.ToString();
                        checkBoxActiveChangeProject.Checked = isActiveProject;

                        tabControlFinance.SelectTab(tabPageChangeProject);
                    }
                }
            }
        }

        private void buttonBackChangeProject_Click(object sender, EventArgs e)
        {
            tabControlFinance.SelectTab(tabPageProjects);
        }

        private void buttonChangeProject_Click(object sender, EventArgs e)
        {
            database.Query("UPDATE tbl_projects SET p_active = @p_active WHERE project_id = @project_id;");

            database.AddParameter("@project_id", selectedIndexProject);
            database.AddParameter("@p_active", checkBoxActiveChangeProject.Checked ? 1 : 0);

            ConfirmBoxBuilder builder = new ConfirmBoxBuilder();
            builder.BuildTop("You are about to change the following information:");
            builder.BuildCenter("Active: " + checkBoxActiveChangeProject.Checked.ToString());
            builder.BuildBottom(tabControlFinance, tabPageProjects, dataGridViewProjects, queryProjects);
            builder.GetConfirmBox().Show();
        }

        private void textBoxSearchInvoices_TextChanged(object sender, EventArgs e)
        {
            database.QueryInDatagridView("SELECT * FROM tbl_invoices WHERE i_description LIKE '%" + textBoxSearchInvoices.Text + "%';", "@i_description", 
                textBoxSearchInvoices.Text, dataGridViewInvoices);
        }

        private void labelNotifications_Click(object sender, EventArgs e)
        {
            FormNotifications notifications = new FormNotifications(Department.Finance);

            notifications.ReceiveMessages();
            notifications.Show();
        }
    }
}
