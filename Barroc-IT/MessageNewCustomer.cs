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
    public partial class MessageNewCustomer : Form
    {
        private bool saved;
        private Sales_dash sales;

        public MessageNewCustomer()
        {
            InitializeComponent();
            sales = new Sales_dash();
        }

        public MessageNewCustomer(Sales_dash sales)
        {
            InitializeComponent();
            this.sales = sales;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saved = true;

            Database.GetInstance().Query("SELECT COUNT(*) FROM tbl_companies;");
            int countOfCompanyId = (int)Database.GetInstance().ExecuteQuery();

            Database.GetInstance().Query("INSERT INTO tbl_companies(c_name, c_address, c_housenumber, c_city, c_contactperson_first_name, " +
                "c_contactperson_telephone_number, c_contactperson_faxnumber, c_contactperson_email, c_contactperson_telephone_number2, c_city2, c_zipcode, c_zipcode2, c_address2) " +
                "VALUES(@c_name, @c_address, @c_housenumber, @c_city, @c_contactperson_first_name, " +
                "@c_contactperson_telephone_number, @c_contactperson_faxnumber, @c_contactperson_email, @c_contactperson_telephone_number2, @c_city2, @c_zipcode, @c_zipcode2, @c_address2)");
            Database.GetInstance().AddParameter("@c_name", sales.textBoxCompanyName.Text);
            Database.GetInstance().AddParameter("@c_address", sales.textBoxAddress1.Text);
            Database.GetInstance().AddParameter("@c_housenumber", sales.textBoxHousenumber.Text );
            Database.GetInstance().AddParameter("@c_city", sales.textBoxResidence1.Text );
            Database.GetInstance().AddParameter("@c_contactperson_first_name", sales.textBoxContactPerson.Text );
            Database.GetInstance().AddParameter("@c_contactperson_telephone_number", sales.textBoxTelephone1.Text );
            Database.GetInstance().AddParameter("@c_contactperson_faxnumber", sales.textBoxFaxnumber.Text );
            Database.GetInstance().AddParameter("@c_contactperson_telephone_number2", sales.textBoxTelephone2.Text);
            Database.GetInstance().AddParameter("@c_contactperson_email", sales.textBoxEmail.Text );
            Database.GetInstance().AddParameter("@c_zipcode", sales.textBoxZipcode2.Text);
            Database.GetInstance().AddParameter("@c_zipcode2", sales.textBoxZipcode2.Text);
            Database.GetInstance().AddParameter("@c_address2", sales.textBoxAddress2.Text);
            Database.GetInstance().AddParameter("@c_city2", sales.textBoxResidence2.Text);

            Database.GetInstance().ExecuteQuery();

            
           
        }

        public bool IsSaved()
        {
            return saved;
        }
    }
}
