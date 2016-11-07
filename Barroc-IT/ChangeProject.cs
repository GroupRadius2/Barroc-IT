﻿using System;
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
            Database.GetInstance().Query("UPDATE tbl_projects SET p_start_date = @p_start_date WHERE project_id = @project_id;");

            DateTime dt;
            DateTime.TryParse(StartDatetbx.Text, out dt);

            Database.GetInstance().AddParameter("project_id", dev.GetSelectedIndexProject());
            Database.GetInstance().AddParameter("@p_start_date", dt);

            Database.GetInstance().ExecuteQuery();

            Database.GetInstance().QueryInDatagridView("SELECT p_start_date, p_end_date, p_progression FROM tbl_projects;", dev.dataGridViewProjects);
            Database.GetInstance().QueryInDatagridView("SELECT p_progression , p_start_date, p_end_date FROM tbl_projects;", dev.dataGridView4);
            this.Hide();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
