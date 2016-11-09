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
            
            //Time
            Database.GetInstance().Query("UPDATE tbl_appointments SET a_time_of = @a_time_of WHERE appiontment_id = @appointment_id;");

            string pr;
            pr = Timetbx.Text;

            Database.GetInstance().AddParameter("@appointment_id", dev.GetSelectedIndexAppointment());
            Database.GetInstance().AddParameter("@a_time_of", pr);

            Database.GetInstance().ExecuteQuery();

            this.Hide();
            //Name
            Database.GetInstance().Query("UPDATE tbl_appointments SET c_name = @c_name WHERE appiontment_id = @appointment_id;");

            string Nm;
            Nm = Nametbx.Text;

            Database.GetInstance().AddParameter("@appointment_id", dev.GetSelectedIndexAppointment());
            Database.GetInstance().AddParameter("@c_name", Nm);

            Database.GetInstance().ExecuteQuery();

            Database.GetInstance().QueryInDatagridView("Select tbl_projects.p_name , c_name, a_date , a_time_of FROM tbl_appointments, tbl_projects WHERE tbl_appointments.project_id = tbl_projects.project_id", dev.dataGridViewAppointments);

            this.Hide();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
