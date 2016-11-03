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
        public Development()
        {
            InitializeComponent();
            
        }
        private void Development_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 16);
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.DefaultCellStyle.Font = new Font("Tahoma", 16);
            this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView3.DefaultCellStyle.Font = new Font("Tahoma", 16);
            this.dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView4.DefaultCellStyle.Font = new Font("Tahoma", 16);
            this.dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Database.GetInstance().QueryInDatagridView("Select c_name, c_address, c_housenumber,c_code,c_city,c_contactperson_first_name, c_contactperson_last_name, c_contactperson_initials,c_contactperson_telephone_number,c_contactperson_faxnumber, c_contactperson_email, c_potential_customer, c_last_contact_date, c_creditworthy, c_revenue, c_limit, c_ledger, c_btw_code, c_maintenance_contract  FROM tbl_companies ", dataGridView2);
            Database.GetInstance().QueryInDatagridView("Select p_start_date, p_end_date, p_progression FROM tbl_project", dataGridView3);
            Database.GetInstance().QueryInDatagridView("Select a_date , a_time_of FROM tbl_appiontments", dataGridView1);
            Database.GetInstance().QueryInDatagridView("Select p_progression , p_start_date, p_end_date  FROM tbl_project", dataGridView4);
            dataGridView1.Columns[0].HeaderCell.Value = "Date";
            dataGridView1.Columns[1].HeaderCell.Value = "Time";
            dataGridView3.Columns[0].HeaderCell.Value = "Start date";
            dataGridView3.Columns[1].HeaderCell.Value = "End date";
            dataGridView3.Columns[2].HeaderCell.Value = "Progression (In %)";
            dataGridView4.Columns[0].HeaderCell.Value = "Progress (In %)";
            dataGridView4.Columns[1].HeaderCell.Value = "Startdate";
            dataGridView4.Columns[2].HeaderCell.Value = "Enddate";

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

    }
}
