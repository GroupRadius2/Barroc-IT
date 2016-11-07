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
    public partial class ChangeAppointment : Form
    {
        private Development dev;

        public ChangeAppointment(Development dev)
        {
            InitializeComponent();
            this.dev = dev;
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            //Date
            Database.GetInstance().Query("UPDATE tbl_appointments SET a_date = @a_date WHERE appiontment_id = @appointment_id;");

            DateTime dt;
            DateTime.TryParse(Datetbx.Text, out dt);
            

            Database.GetInstance().AddParameter("@appointment_id", dev.GetSelectedIndexAppointment());
            Database.GetInstance().AddParameter("@a_date", dt);

            Database.GetInstance().ExecuteQuery();

            Database.GetInstance().QueryInDatagridView("SELECT a_date, a_time_of FROM tbl_appointments;", dev.dataGridViewAppointments);
            
            //Time
            Database.GetInstance().Query("UPDATE tbl_appointments SET a_time_of = @a_time_of WHERE appiontment_id = @appointment_id;");

            string pr;
            pr = Timetbx.Text;

            Database.GetInstance().AddParameter("@appointment_id", dev.GetSelectedIndexAppointment());
            Database.GetInstance().AddParameter("@a_time_of", pr);

            Database.GetInstance().ExecuteQuery();

            Database.GetInstance().QueryInDatagridView("Select project_id, c_name, a_date , a_time_of FROM tbl_appointments", dev.dataGridViewAppointments);

            this.Hide();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
