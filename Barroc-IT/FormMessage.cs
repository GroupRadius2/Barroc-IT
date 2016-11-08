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
    public partial class FormMessage : Form
    {
        private FormNotifications notifications;

        public FormMessage(FormNotifications notifications)
        {
            InitializeComponent();
            this.notifications = notifications;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            Department department;

            switch(comboBoxDepartments.SelectedItem.ToString().ToUpper())
            {
                case "FINANCE":
                    department = Department.Finance;
                    break;
                case "SALES":
                    department = Department.Sales;
                    break;
                case "DEVELOPMENT":
                    department = Department.Development;
                    break;
                default:
                    department = Department.Finance;
                    break;
            }

            notifications.SendMessage(department, textBoxSubject.Text, richTextBoxMessage.Text);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
