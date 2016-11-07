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
    public partial class ChangeProject : Form
    {
        private Development dev;

        public ChangeProject(Development dev)
        {
            InitializeComponent();
            this.dev = dev;
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            //Start date
            Database.GetInstance().Query("UPDATE tbl_projects SET p_start_date = @p_start_date WHERE project_id = @project_id;");
            DateTime Sd;
            DateTime.TryParse(StartDatetbx.Text, out Sd);

            Database.GetInstance().AddParameter("project_id", dev.GetSelectedIndexProject());
            Database.GetInstance().AddParameter("@p_start_date", Sd);

            Database.GetInstance().ExecuteQuery();

            Database.GetInstance().QueryInDatagridView("SELECT p_start_date, p_end_date, p_progression FROM tbl_projects;", dev.dataGridViewProjects);
            //Database.GetInstance().QueryInDatagridView("SELECT p_progression , p_start_date, p_end_date FROM tbl_projects;", dev.dataGridView4);
            //EndDate
            Database.GetInstance().Query("UPDATE tbl_projects SET p_end_date = @p_end_date WHERE project_id = @project_id;");
            DateTime Ed;
            DateTime.TryParse(EndDatetbx.Text, out Ed);

            Database.GetInstance().AddParameter("project_id", dev.GetSelectedIndexProject());
            Database.GetInstance().AddParameter("@p_end_date", Ed);

            Database.GetInstance().ExecuteQuery();

            Database.GetInstance().QueryInDatagridView("SELECT p_start_date, p_end_date, p_progression FROM tbl_projects;", dev.dataGridViewProjects);
            //Database.GetInstance().QueryInDatagridView("SELECT p_progression , p_start_date, p_end_date FROM tbl_projects;", dev.dataGridView4);
            
            //Progression
            Database.GetInstance().Query("UPDATE tbl_projects SET p_progression = @p_progression WHERE project_id = @project_id;");

            string pr;
            pr = Progressiontbx.Text;

            Database.GetInstance().AddParameter("@project_id", dev.GetSelectedIndexProject());
            Database.GetInstance().AddParameter("@p_progression", pr);

            Database.GetInstance().ExecuteQuery();

            Database.GetInstance().QueryInDatagridView("SELECT p_progression , p_start_date, p_end_date FROM tbl_projects;", dev.dataGridViewProjectProgress);
            this.Hide();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
