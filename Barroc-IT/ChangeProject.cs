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
        DateTime dateValue = new DateTime();
        int intValue = new int();
        public ChangeProject(Development dev)
        {
            InitializeComponent();
            this.dev = dev;
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            if ((DateTime.TryParse(StartDatetbx.Text, out dateValue)) && (DateTime.TryParse(EndDatetbx.Text, out dateValue)) && (int.TryParse(Progressiontbx.Text , out intValue)) && intValue <101 && intValue > 0)
            {
            //Start date
            Database.GetInstance().Query("UPDATE tbl_projects SET p_start_date = @p_start_date WHERE project_id = @project_id;");
            DateTime Sd;
            DateTime.TryParse(StartDatetbx.Text, out Sd);

            Database.GetInstance().AddParameter("project_id", dev.GetSelectedIndexProject());
            Database.GetInstance().AddParameter("@p_start_date", Sd);

            Database.GetInstance().ExecuteQuery();
 
            //EndDate
            Database.GetInstance().Query("UPDATE tbl_projects SET p_end_date = @p_end_date WHERE project_id = @project_id;");
            DateTime Ed;
            DateTime.TryParse(EndDatetbx.Text, out Ed);

            Database.GetInstance().AddParameter("project_id", dev.GetSelectedIndexProject());
            Database.GetInstance().AddParameter("@p_end_date", Ed);

            Database.GetInstance().ExecuteQuery();

            
            //Progression
            Database.GetInstance().Query("UPDATE tbl_projects SET p_progression = @p_progression WHERE project_id = @project_id;");

            string pr;
            pr = Progressiontbx.Text;

            Database.GetInstance().AddParameter("@project_id", dev.GetSelectedIndexProject());
            Database.GetInstance().AddParameter("@p_progression", pr);

            Database.GetInstance().ExecuteQuery();
            //Name
            Database.GetInstance().Query("UPDATE tbl_projects SET p_name = @p_name WHERE project_id = @project_id;");

            string Nm;
            Nm = Nametbx.Text;

            Database.GetInstance().AddParameter("@project_id", dev.GetSelectedIndexProject());
            Database.GetInstance().AddParameter("@p_name", Nm);

            Database.GetInstance().ExecuteQuery();

            Database.GetInstance().QueryInDatagridView("Select tbl_companies.c_name, p_name, p_status, p_start_date, p_end_date, p_progression FROM tbl_projects, tbl_companies WHERE tbl_projects.company_id = tbl_companies.c_id;", dev.dataGridViewProjects);
            this.Hide();

            //Checkbox
            Database.GetInstance().Query("UPDATE tbl_projects SET p_status = @p_status WHERE project_id = @project_id;");

            string Cb;
            if(Statuscbx.Checked)
            {
                Cb = "True";
            }
            else
            {
                Cb = "false";
            }

            Database.GetInstance().AddParameter("@project_id", dev.GetSelectedIndexProject());
            Database.GetInstance().AddParameter("@p_status", Cb);

            Database.GetInstance().ExecuteQuery();

            Database.GetInstance().QueryInDatagridView("Select tbl_companies.c_name, p_name, p_status, p_start_date, p_end_date, p_progression FROM tbl_projects, tbl_companies WHERE tbl_projects.company_id = tbl_companies.c_id;", dev.dataGridViewProjects);
            Database.GetInstance().QueryInDatagridView("Select tbl_companies.c_name, p_name, p_status, p_start_date, p_end_date, p_progression FROM tbl_projects, tbl_companies WHERE tbl_projects.company_id = tbl_companies.c_id;", dev.dataGridViewProjectProgress);

            this.Hide();
            }
            else
            {
                if (!(DateTime.TryParse(StartDatetbx.Text, out dateValue)))
                {
                    MessageBox.Show("The startdate is not valid");
                }
                if(!(DateTime.TryParse(EndDatetbx.Text, out dateValue)))
                {
                    MessageBox.Show("The enddate is not valid");
                }
                if(!(int.TryParse(Progressiontbx.Text , out intValue)) || intValue < 101 || intValue > 0)
                {
                    MessageBox.Show("The progression is not valid, Please enter a number between 0 and 100.");
                }
                
            }
            
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Statuscbx_CheckedChanged(object sender, EventArgs e)
        {
            if (Statuscbx.Checked)
            {
                Statuscbx.Text = "Project is active";
            }
            else
            {
                Statuscbx.Text = "Project is inactive";
            }
        }
    }
}
