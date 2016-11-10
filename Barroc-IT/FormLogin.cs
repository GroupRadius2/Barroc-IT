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
        private Database database;

        public FormLogin()
        {
            InitializeComponent();
            this.Show();
            database = Database.GetInstance();
            SetUp();
        }

        public void SetUp()
        {
            database.CloseConnection();
            database.OpenConnection();

            CreateAccount("Finance", "abc");
            CreateAccount("Sales", "def");
            CreateAccount("Development", "ghi");
        }

        public void CreateAccount(string user, string passwordInSHA1Hash)
        {
            database.Query("SELECT COUNT(*) FROM tbl_accounts");
            int countOfAccounts = (int)database.ExecuteQuery();

            database.Query("INSERT INTO tbl_accounts(a_id, a_username, a_password) VALUES(@a_id ,@a_username, @a_password);");
            database.AddParameter("@a_id", ++countOfAccounts);
            database.AddParameter("@a_username", user);
            database.AddParameter("@a_password", passwordInSHA1Hash);

            database.ExecuteQuery();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            CheckLogin();
        }

        private void buttonLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckLogin();
            }
        }

        private void CheckLogin()
        {
            //database.Query("SELECT HASHBYTES('SHA', @a_password)");
            //database.AddParameter("@a_password", textBoxPassword.Text);

            database.Query("SELECT COUNT(*) FROM tbl_accounts WHERE a_username = @a_username AND a_password = @a_password;");
            database.AddParameter("@a_username", comboBoxDepartments.SelectedItem.ToString());
            database.AddParameter("@a_password", textBoxPassword.Text);

            MessageBox.Show(comboBoxDepartments.SelectedItem.ToString());
            MessageBox.Show(textBoxPassword.Text);
            MessageBox.Show(((int)database.ExecuteQuery()).ToString());

            if ((int)database.ExecuteQuery() > 0)
            {
                switch (comboBoxDepartments.SelectedItem.ToString().ToUpper())
                {
                    case "FINANCE":
                        MessageBox.Show("Finance");
                        FormFinance finance = new FormFinance();
                        finance.Show();
                        break;
                    case "SALES":
                        Sales_dash sales = new Sales_dash();
                        sales.Show();
                        break;
                    case "DEVELOPMENT":
                        Development dev = new Development();
                        dev.Show();
                        break;
                    default:
                        break;
                }
            }
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckLogin();
            }
        }
    }   
}
