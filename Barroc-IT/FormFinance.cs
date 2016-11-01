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

        public FormFinance()
        {
            InitializeComponent();
            database = Database.GetInstace();
            try
            {
                database.OpenConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Close();
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
            tabControlFinance.SelectTab(tabPageCustomers);
            labelDashboard.ForeColor = Color.Red;
        }

        private void labelAddCustomer_Click(object sender, EventArgs e)
        {
            UpdateInfo();
            tabControlFinance.SelectTab(tabPageAddCustomer);
            labelAddCustomer.ForeColor = Color.Red;
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
            labelAddCustomer.ForeColor = Color.Black;
            labelDashboard.ForeColor = Color.Black;
            labelProjects.ForeColor = Color.Black;
            labelCustomers.ForeColor = Color.Black;
            labelAddInvoice.ForeColor = Color.Black;
            labelInvoices.ForeColor = Color.Black;

            database.Query("SELECT COUNT(*) FROM tbl_companies WHERE c_creditworthy = 1");
            labelPositiveBalances.Text = "Positive balances (" + database.ExecuteQuery() + ")";

            database.Query("SELECT COUNT(*) FROM tbl_companies WHERE c_creditworthy = 0");
            labelNegativeBalances.Text = "Negative balances (" + database.ExecuteQuery() +")";

            database.QueryInDatagridView("SELECT * FROM tbl_projects", dataGridViewProjects);
            database.QueryInDatagridView("SELECT * FROM tbl_invoices", dataGridViewInvoices);
            database.QueryInDatagridView("SELECT * FROM tbl_companies WHERE c_creditworthy = 1", dataGridViewPositiveCompanies);
            database.QueryInDatagridView("SELECT * FROM tbl_companies WHERE c_creditworthy = 0", dataGridViewNegativeCompanies);
        }

        private void buttonSaveInvoice_Click(object sender, EventArgs e)
        {
            UpdateInfo();

            database.Query("SELECT COUNT(*) FROM tbl_invoices");
            int countOfInvoicesId = (int)database.ExecuteQuery();

            database.Query("INSERT INTO tbl_invoices(invoice_id, project_id, i_description, i_price) VALUES " +
                "(@id, @project_id, @i_description, i_price);");

            database.AddParameter("@id", ++countOfInvoicesId);
            database.AddParameter("@project_id", textBoxProjectId.Text);
            database.AddParameter("@i_description", textBoxInvoiceDescription.Text);
            database.AddParameter("@i_price", textBoxInvoicePrice.Text);

            database.ExecuteQuery();
        }

        private void dataGridViewInvoices_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewInvoices.SelectedRows)
            {
                if (row.Selected)
                {
                    selectedIndexInvoice = (int)row.Cells[0].Value;

                    textBoxChangeInvoiceProjectId.Text = row.Cells[1].Value.ToString();
                    textBoxChangeInvoiceDescription.Text = row.Cells[2].Value.ToString();
                    textBoxChangeInvoicePrice.Text = row.Cells[3].Value.ToString();

                    tabControlFinance.SelectTab(tabPageChangeInvoice);
                }   
            }
        }

        private void buttonSaveChangeInvoice_Click(object sender, EventArgs e)
        {
            database.Query("UPDATE tbl_invoices SET project_id = @project_id, i_description = @description, i_price = @price WHERE invoice_id = @id;");

            database.AddParameter("@project_id", textBoxChangeInvoiceProjectId.Text);
            database.AddParameter("@description", textBoxChangeInvoiceDescription.Text);
            database.AddParameter("@price", textBoxChangeInvoicePrice.Text);
            database.AddParameter("@id", selectedIndexInvoice);

            ConfirmBox confirmBox = new ConfirmBox();
            ConfirmBoxBuilder builder = new ConfirmBoxBuilder(confirmBox);
            builder.Construct();
            builder.BuildSize(250, 450);
            builder.BuildTop("You are about to save the following data:");
            builder.BuildCenter("Project id: " + textBoxChangeInvoiceProjectId.Text);
            builder.BuildBottom();

            confirmBox.Show();

            if (confirmBox.IsAccepted())
            {
                database.ExecuteQuery();
            }
            
            UpdateInfo();
        }

        private void buttonChangeCustomer_Click(object sender, EventArgs e)
        {
            database.Query("UPDATE tbl_companies SET c_name = @c_name, c_address = @c_address," +
                "c_housenumber = @c_housenumber, c_code = @c_code, c_city = @c_city, c_contactperson = @c_contactperson," +
                "c_contactperson_initials = @c_contactperson_initials, c_contactperson_telephonenumber = @c_contactperson_telephonenumber," +
                "c_contactperson_faxnumber = @c_contactperson_faxnumber, c_contactperson_email = @c_contactperson_email," +
                "c_potential_customer = @c_potential_customer, c_last_contactdate = @c_last_contactdate," +
                "c_creditworthy = @c_creditworthy, c_discount = @c_discount, c_banknumber = @c_banknumber," +
                "c_credit_balance = @c_credit_balance, c_revenue = @c_revenue, c_limit = @c_limit," +
                "c_ledger = @c_ledger, c_btw_code = @c_btw_code, c_maintenance_contract = @c_maintenance_contract" +
                "WHERE c_id = @id");

            database.AddParameter("@id", selectedIndexCustomer);
            database.AddParameter("@c_name", textBoxNameChangeCustomer.Text);
            database.AddParameter("@c_address", textBoxAddressChangeCustomer.Text);
            database.AddParameter("@c_housenumber", textBoxHouseNumberChangeCustomer.Text);
            database.AddParameter("@c_code", textBoxCompanyCodeChangeCustomer.Text);
            database.AddParameter("@c_city", textBoxCityChangeCustomer.Text);
            database.AddParameter("@c_contactperson", textBoxContactpersonChangeCustomer.Text);
            database.AddParameter("@c_contactperson_initials", textBoxInitialsChangeCustomer.Text);
            database.AddParameter("@c_contactperson_telephonenumber", textBoxTelephoneChangeCustomer.Text);
            database.AddParameter("@c_contactperson_faxnumber", textBoxFaxnumberChangeCustomer.Text);
            database.AddParameter("@c_contactperson_email", textBoxEmailChangeCustomer.Text);
            database.AddParameter("@c_potential_customer", checkBoxPotentialCustomerChangeCustomer.Checked ? 1 : 0);
            database.AddParameter("@c_last_contactdate", textBoxLastContactDateChangeCustomer.Text);
            database.AddParameter("@c_creditworthy", checkBoxCreditworthyChangeCustomer.Checked ? 1 : 0);
            database.AddParameter("@c_discount", textBoxDiscountChangeCustomer.Text);
            database.AddParameter("@c_banknumber", textBoxBanknumberChangeCustomer.Text);
            database.AddParameter("@c_credit_balance", textBoxCreditBalanceChangeCustomer.Text);
            database.AddParameter("@c_revenue", textBoxRevenueChangeCustomer.Text);
            database.AddParameter("@c_limit", textBoxLimitChangeCustomer.Text);
            database.AddParameter("@c_ledger", textBoxLedgerChangeCustomer.Text);
            database.AddParameter("@c_btw_code", textBoxVATCodeChangeCustomer.Text);
            database.AddParameter("@c_maintenance_contract", textBoxMaintenanceContractChangeCustomer.Text);

            database.ExecuteQuery();
        }

        private void SettingDataChangedCompanies(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                if (row.Selected)
                {
                    bool creditWorthyChecked = false;

                    if (row.Cells[11].Value.ToString() == "1")
                    {
                        creditWorthyChecked = true;
                    }

                    selectedIndexCustomer = (int)row.Cells[0].Value;

                    textBoxNameChangeCustomer.Text = row.Cells[1].Value.ToString();
                    textBoxAddressChangeCustomer.Text = row.Cells[2].Value.ToString();
                    textBoxHouseNumberChangeCustomer.Text = row.Cells[3].Value.ToString();
                    textBoxCompanyCodeChangeCustomer.Text = row.Cells[4].Value.ToString();
                    textBoxCityChangeCustomer.Text = row.Cells[5].Value.ToString();
                    textBoxContactpersonChangeCustomer.Text = row.Cells[6].Value.ToString();
                    textBoxInitialsChangeCustomer.Text = row.Cells[7].Value.ToString();
                    textBoxTelephoneChangeCustomer.Text = row.Cells[8].Value.ToString();
                    textBoxFaxnumberChangeCustomer.Text = row.Cells[9].Value.ToString();
                    textBoxEmailChangeCustomer.Text = row.Cells[10].Value.ToString();
                    checkBoxAddCustomerCompanyCreditworthy.Checked = creditWorthyChecked;
                    textBoxDiscountChangeCustomer.Text = row.Cells[12].Value.ToString();
                    textBoxBanknumberChangeCustomer.Text = row.Cells[13].Value.ToString();
                    textBoxCreditBalanceChangeCustomer.Text = row.Cells[14].Value.ToString();
                    textBoxRevenueChangeCustomer.Text = row.Cells[15].Value.ToString();
                    textBoxLimitChangeCustomer.Text = row.Cells[16].Value.ToString();
                    textBoxLedgerChangeCustomer.Text = row.Cells[17].Value.ToString();
                    textBoxVATCodeChangeCustomer.Text = row.Cells[18].Value.ToString();
                    textBoxMaintenanceContractChangeCustomer.Text = row.Cells[19].Value.ToString();

                    tabControlFinance.SelectTab(tabPageChangeCustomer);
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
            database.Query("DELETE * FROM tbl_customers WHERE c_id = @id;");

            database.AddParameter("@id", selectedIndexCustomer);

            database.ExecuteQuery();
        }

        private void buttonBackInvoice_Click(object sender, EventArgs e)
        {
            tabControlFinance.SelectTab(tabPageInvoices);
        }

        private void buttonDeleteInvoice_Click(object sender, EventArgs e)
        {
            database.Query("DELETE * FROM tbl_invoices WHERE invoice_id = @id;");

            database.AddParameter("@id", selectedIndexInvoice);

            database.ExecuteQuery();
        }
    }
}
