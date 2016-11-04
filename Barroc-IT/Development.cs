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
    public partial class Development : Form
    {
        private int selectedIndexAppointment;
        private int selectedIndexProject;
        public Development()
        {
            InitializeComponent();
            selectedIndexAppointment = 0;
            selectedIndexProject = 0;
            this.FormClosed += Development_FormClosed;
        }

        void Development_FormClosed(object sender, FormClosedEventArgs e)
        {
            Database.GetInstance().CloseConnection();
        }
        private void Development_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 16);
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.DefaultCellStyle.Font = new Font("Tahoma", 16);
            this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewProjects.DefaultCellStyle.Font = new Font("Tahoma", 16);
            this.dataGridViewProjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView4.DefaultCellStyle.Font = new Font("Tahoma", 16);
            this.dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Database.GetInstance().QueryInDatagridView("Select c_name, c_address, c_housenumber,c_code,c_city,c_contactperson_first_name, c_contactperson_last_name, c_contactperson_initials,c_contactperson_telephone_number,c_contactperson_faxnumber, c_contactperson_email, c_potential_customer, c_last_contact_date, c_creditworthy, c_revenue, c_limit, c_ledger, c_btw_code, c_maintenance_contract  FROM tbl_companies ", dataGridView2);
            Database.GetInstance().QueryInDatagridView("Select p_start_date, p_end_date, p_progression FROM tbl_projects", dataGridViewProjects);
            Database.GetInstance().QueryInDatagridView("Select a_date , a_time_of FROM tbl_appointments", dataGridView1);
            Database.GetInstance().QueryInDatagridView("Select p_progression , p_start_date, p_end_date  FROM tbl_projects", dataGridView4);
            dataGridView1.Columns[0].HeaderCell.Value = "Date";
            dataGridView1.Columns[1].HeaderCell.Value = "Time";
            dataGridViewProjects.Columns[0].HeaderCell.Value = "Start date";
            dataGridViewProjects.Columns[1].HeaderCell.Value = "End date";
            dataGridViewProjects.Columns[2].HeaderCell.Value = "Progression (In %)";
            dataGridView4.Columns[0].HeaderCell.Value = "Progress (In %)";
            dataGridView4.Columns[1].HeaderCell.Value = "Startdate";
            dataGridView4.Columns[2].HeaderCell.Value = "Enddate";
            dataGridView2.Columns[0].HeaderCell.Value = "Name";
            dataGridView2.Columns[1].HeaderCell.Value = "Address";
            dataGridView2.Columns[2].HeaderCell.Value = "Housenumber";
            dataGridView2.Columns[3].HeaderCell.Value = "Code";
            dataGridView2.Columns[4].HeaderCell.Value = "City";
            dataGridView2.Columns[5].HeaderCell.Value = "First name";
            dataGridView2.Columns[6].HeaderCell.Value = "Last name";
            dataGridView2.Columns[7].HeaderCell.Value = "initials";
            dataGridView2.Columns[8].HeaderCell.Value = "Telephone number";
            dataGridView2.Columns[9].HeaderCell.Value = "Faxnumber";
            dataGridView2.Columns[10].HeaderCell.Value = "Email";
            dataGridView2.Columns[11].HeaderCell.Value = "Potentional customer";
            dataGridView2.Columns[12].HeaderCell.Value = "Last contact date";
            dataGridView2.Columns[13].HeaderCell.Value = "Creditworthy";
            dataGridView2.Columns[14].HeaderCell.Value = "Revenue";
            dataGridView2.Columns[15].HeaderCell.Value = "Limit";
            dataGridView2.Columns[16].HeaderCell.Value = "Ledger";
            dataGridView2.Columns[17].HeaderCell.Value = "BTW Code";
            dataGridView2.Columns[18].HeaderCell.Value = "Maintenance contract";


        }


        private void label4_Click(object sender, EventArgs e)
        {
            Tabcontrol1.SelectedTab = tabPage2;
            label4.ForeColor = Color.Red;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label9.ForeColor = Color.Black;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Tabcontrol1.SelectedTab = tabPage3;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Red;
            label6.ForeColor = Color.Black;
            label9.ForeColor = Color.Black;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Tabcontrol1.SelectedTab = tabPage4;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Red;
            label9.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Tabcontrol1.SelectedTab = tabPage6;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label9.ForeColor = Color.Red;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int counter = 1;

            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if(row.Selected)
                {
                    selectedIndexAppointment = counter;

                    ChangeAppointment changeappointment = new ChangeAppointment(this);
                    changeappointment.Show();
                    changeappointment.Datetbx.Text = row.Cells[0].Value.ToString();
                    changeappointment.TimeTbx.Text = row.Cells[1].Value.ToString();
                }

                counter++;
            }
        }
        private void dataGridViewProjects_SelectionChanged_1(object sender, EventArgs e)
        {
            int counter = 1;

            foreach (DataGridViewRow row in dataGridViewProjects.Rows)
            {
                if (row.Selected)
                {
                    selectedIndexProject = counter;

                    ChangeProject changeProject = new ChangeProject(this);
                    changeProject.Show();
                    changeProject.Datetbx.Text = row.Cells[0].Value.ToString();
                }

                counter++;
            }
        }

        public int GetSelectedIndexAppointment()
        {
            return selectedIndexAppointment;
        }

        public int GetSelectedIndexProject()
        {
            return selectedIndexProject;
        }
    }
}
