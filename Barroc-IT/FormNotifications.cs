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

        public FormNotifications()
        {
            InitializeComponent();
            database = Database.GetInstance();
        }

        public FormNotifications(Department department)
        {
            InitializeComponent();

            this.department = department.ToString();
            database = Database.GetInstance();
        }

        public void SentMessage(Department department, string title, string message)
        {
            database.Query("SELECT COUNT(*) FROM tbl_messages;");
            int countOfMessages = (int)database.ExecuteQuery();

            database.Query("INSERT INTO tbl_messages(message_id, department, message, m_subject) SET message_id = @message_id, department = @department, message = @message, m_subject = @m_subject;");

            database.AddParameter("@message_id", ++countOfMessages);
            database.AddParameter("@department", department.ToString());
            database.AddParameter("@message", message);
            database.AddParameter("@m_subject", title);
            database.ExecuteQuery();
        }

        public void ReceiveMessages()
        {
            database.QueryInDatagridView("SELECT m_subject FROM tbl_messages;",
                dataGridViewAllNotifications);
        }

        private void dataGridViewAllNotifications_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewAllNotifications.Rows)
            {
                if (row.Selected)
                {
                    if (row.Cells[0].Value != null)
                    {
                        richTextBoxMessage.Text = row.Cells["message"].Value.ToString();
                    }
                }
            }
        }
    }
}
