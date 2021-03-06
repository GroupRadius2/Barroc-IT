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
    public partial class MessageNewProject : Form
    {
        private bool saved;
        private Sales_dash sales;

        public MessageNewProject(Sales_dash sales)
        {
            InitializeComponent();
            this.sales = sales;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveProject_Click(object sender, EventArgs e)
        {
            saved = true;

            Database.GetInstance().Query("SELECT COUNT(*) FROM tbl_projects");
            int countOfProjectId = (int)Database.GetInstance().ExecuteQuery();

            Database.GetInstance().Query("INSERT INTO tbl_projects(project_id, p_company_name, p_customer_name, p_name, p_start_date, p_end_date, p_cost, p_terms) " +
                "VALUES(@project_id, @p_company_name, @p_customer_name, @p_name, @p_start_date, @p_end_date, @p_cost, @p_terms)");
            Database.GetInstance().AddParameter("@project_id", ++countOfProjectId);
            Database.GetInstance().AddParameter("@p_company_name", sales.textBoxC_Name.Text);
            Database.GetInstance().AddParameter("@p_customer_name", sales.textBoxCustomerName.Text);
            Database.GetInstance().AddParameter("@p_name", sales.textBoxP_Name.Text);
            Database.GetInstance().AddParameter("@p_start_date", sales.textBoxBeginDate.Text);
            Database.GetInstance().AddParameter("@p_end_date", sales.textBoxEndDate.Text);
            Database.GetInstance().AddParameter("@p_cost", sales.textBoxCost.Text);
            Database.GetInstance().AddParameter("@p_terms", sales.textBoxTerms.Text);

            Database.GetInstance().ExecuteQuery();

            sales.tabControlSales.SelectedTab = sales.tabTemplateProjects;
            sales.UpdateInfo();
        }
         public bool IsSaved()
        {
            return saved;
        }
    }
}
