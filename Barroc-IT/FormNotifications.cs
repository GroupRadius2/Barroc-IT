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
    public partial class FormNotifications : Form
    {
        private string department;
        private Database database;
        private int selectedIndexMessage;

        public FormNotifications()
        {
            InitializeComponent();
            database = Database.GetInstance();
            selectedIndexMessage = 1;
            department = "Finance";
        }

        public FormNotifications(Department department)
        {
            InitializeComponent();

            this.department = GetDepartment(department);

            this.department = department.ToString();
            database = Database.GetInstance();
        }

        public string GetDepartment(Department department)
        {
            string departmentInString;

            switch (department)
            {
                case Department.Finance:
                    departmentInString = "Finance";
                    break;
                case Department.Sales:
                    departmentInString = "Sales";
                    break;
                case Department.Development:
                    departmentInString = "Development";
                    break;
                default:
                    departmentInString = null;
                    break;
            }

            return departmentInString;
        }

        public void SendMessage(Department department, string title, string message)
        {
            database.Query("SELECT COUNT(*) FROM tbl_messages;");
            int countOfMessages = (int)database.ExecuteQuery();

            database.Query("INSERT INTO tbl_messages(message_id, department, message, m_subject) SET message_id = @message_id, department = @department, message = @message, m_subject = @m_subject;");

            database.AddParameter("@message_id", ++countOfMessages);
            database.AddParameter("@department", GetDepartment(department));
            database.AddParameter("@message", message);
            database.AddParameter("@m_subject", title);
            database.ExecuteQuery();
        }

        public void ReceiveMessages()
        {
            database.QueryInDatagridView("SELECT m_subject FROM tbl_messages WHERE department = '" + department + "';",
                dataGridViewAllNotifications);
        }

        private void dataGridViewAllNotifications_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewAllNotifications.Rows)
            {
                int counter = 0;
                if (row.Selected)
                {
                    counter++;
                    selectedIndexMessage = counter;
                    if (row.Cells[0].Value != null)
                    {
                        database.Query("SELECT message FROM tbl_messages WHERE message_id = @message_id;");
                        database.AddParameter("@message_id", counter);
                        richTextBoxMessage.Text = database.ExecuteQuery().ToString();
                    }
                }
            }
        }

        private void buttonSendMessage_Click(object sender, EventArgs e)
        {
            FormMessage message = new FormMessage();
            message.Show();
        }
    }
}
