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
            this.dataGridViewAppointments.DefaultCellStyle.Font = new Font("Tahoma", 16);
            this.dataGridViewAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCompanies.DefaultCellStyle.Font = new Font("Tahoma", 16);
            this.dataGridViewCompanies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewProjects.DefaultCellStyle.Font = new Font("Tahoma", 16);
            this.dataGridViewProjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProjectProgress.DefaultCellStyle.Font = new Font("Tahoma", 16);
            this.dataGridViewProjectProgress.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        
            //DatagridView appointments
            Database.GetInstance().QueryInDatagridView("Select project_id, c_name, a_date , a_time_of FROM tbl_appointments", dataGridViewAppointments);
            dataGridViewAppointments.Columns[0].HeaderCell.Value = "Project id";
            dataGridViewAppointments.Columns[1].HeaderCell.Value = "Name";
            dataGridViewAppointments.Columns[2].HeaderCell.Value = "Date";
            dataGridViewAppointments.Columns[3].HeaderCell.Value = "Time";
            
            //DatagridView Projects
            Database.GetInstance().QueryInDatagridView("Select company_id, p_name, p_status, p_start_date, p_end_date, p_progression FROM tbl_projects", dataGridViewProjects);
            dataGridViewProjects.Columns[0].HeaderCell.Value = "Company";
            dataGridViewProjects.Columns[1].HeaderCell.Value = "Project";
            dataGridViewProjects.Columns[2].HeaderCell.Value = "Status";
            dataGridViewProjects.Columns[3].HeaderCell.Value = "Start date";
            dataGridViewProjects.Columns[4].HeaderCell.Value = "End date";
            dataGridViewProjects.Columns[5].HeaderCell.Value = "Progression (In %)";
            
            //DatagridView Project progress
            Database.GetInstance().QueryInDatagridView("Select p_name, p_progression, p_status , p_start_date, p_end_date  FROM tbl_projects", dataGridViewProjectProgress);
            dataGridViewProjectProgress.Columns[0].HeaderCell.Value = "Project";
            dataGridViewProjectProgress.Columns[1].HeaderCell.Value = "Progress (In %)";
            dataGridViewProjectProgress.Columns[2].HeaderCell.Value = "Status";
            dataGridViewProjectProgress.Columns[3].HeaderCell.Value = "Startdate";
            dataGridViewProjectProgress.Columns[4].HeaderCell.Value = "Enddate";
            
            //DatagridView Companies
            Database.GetInstance().QueryInDatagridView("Select c_name, c_address, c_housenumber,c_code,c_city,c_contactperson_first_name, c_contactperson_last_name, c_contactperson_initials,c_contactperson_telephone_number,c_contactperson_faxnumber, c_contactperson_email, c_potential_customer, c_last_contact_date, c_creditworthy, c_revenue, c_limit, c_ledger, c_btw_code, c_maintenance_contract  FROM tbl_companies ", dataGridViewCompanies);
            dataGridViewCompanies.Columns[0].HeaderCell.Value = "Name";
            dataGridViewCompanies.Columns[1].HeaderCell.Value = "Address";
            dataGridViewCompanies.Columns[2].HeaderCell.Value = "Housenumber";
            dataGridViewCompanies.Columns[3].HeaderCell.Value = "Code";
            dataGridViewCompanies.Columns[4].HeaderCell.Value = "City";
            dataGridViewCompanies.Columns[5].HeaderCell.Value = "First name";
            dataGridViewCompanies.Columns[6].HeaderCell.Value = "Last name";
            dataGridViewCompanies.Columns[7].HeaderCell.Value = "initials";
            dataGridViewCompanies.Columns[8].HeaderCell.Value = "Telephone number";
            dataGridViewCompanies.Columns[9].HeaderCell.Value = "Faxnumber";
            dataGridViewCompanies.Columns[10].HeaderCell.Value = "Email";
            dataGridViewCompanies.Columns[11].HeaderCell.Value = "Potentional customer";
            dataGridViewCompanies.Columns[12].HeaderCell.Value = "Last contact date";
            dataGridViewCompanies.Columns[13].HeaderCell.Value = "Creditworthy";
            dataGridViewCompanies.Columns[14].HeaderCell.Value = "Revenue";
            dataGridViewCompanies.Columns[15].HeaderCell.Value = "Limit";
            dataGridViewCompanies.Columns[16].HeaderCell.Value = "Ledger";
            dataGridViewCompanies.Columns[17].HeaderCell.Value = "BTW Code";
            dataGridViewCompanies.Columns[18].HeaderCell.Value = "Maintenance contract";


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
            FormLogin formlogin = new FormLogin();
            formlogin.Show();
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

            foreach(DataGridViewRow row in dataGridViewAppointments.Rows)
            {
                if(row.Selected)
                {
                    selectedIndexAppointment = counter;

                    ChangeAppointment changeappointment = new ChangeAppointment(this);
                    changeappointment.Show();
                    changeappointment.Projecttbx.Text= row.Cells[0].Value.ToString();
                    changeappointment.Nametbx.Text = row.Cells[1].Value.ToString();
                    changeappointment.Datetbx.Text = row.Cells[2].Value.ToString();
                    changeappointment.Timetbx.Text = row.Cells[3].Value.ToString();
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
                    changeProject.StartDatetbx.Text = row.Cells[0].Value.ToString();
                    changeProject.EndDatetbx.Text = row.Cells[1].Value.ToString();
                    changeProject.Progressiontbx.Text = row.Cells[2].Value.ToString();
                    
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

        private void button2_Click(object sender, EventArgs e)
        {
            NewAppointment newAppointment = new NewAppointment(this);
            newAppointment.Show();
        }
    }
}
