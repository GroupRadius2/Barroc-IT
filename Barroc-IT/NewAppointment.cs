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
    public partial class NewAppointment : Form
    {
        private Database database;
        Development dev;

        public NewAppointment(Development dev)
        {
            InitializeComponent();
            this.dev = dev;
            database = Database.GetInstance();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            database.Query("SELECT COUNT(*) FROM tbl_appointments");
            int countAppointmentId = (int)database.ExecuteQuery();

            database.Query("INSERT INTO tbl_appointments(appiontment_id, project_id, a_date, a_time_of, c_name)VALUES(@id, @p_id, @a_date, @a_time_of , @c_name);");
            database.AddParameter("@id", ++countAppointmentId);
            database.AddParameter("@p_id", Projecttbx.Text);
            database.AddParameter("@a_date", Datetbx.Text);
            database.AddParameter("@a_time_of", Timetbx.Text);
            database.AddParameter("@c_name", Nametbx.Text);
            database.ExecuteQuery();

            Database.GetInstance().QueryInDatagridView("Select tbl_projects.p_name , c_name, a_date , a_time_of FROM tbl_appointments, tbl_projects WHERE tbl_appointments.project_id = tbl_projects.project_id;", dev.dataGridViewAppointments);

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
