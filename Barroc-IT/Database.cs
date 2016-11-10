using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Barroc_IT
{
    class Database
    {
        private static string connectionString;
        private static Database instance;
        private static int version;

        private static SqlDataAdapter adapter;
        private static SqlConnection connection;
        private static SqlCommand command;
        
        private Database()
        {
            version = 11;

            try
            {
                if (!Connect())
                {
                    version = 12;
                    Connect();
                }
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        public static bool Connect()
        {
            bool state = false;

            // connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\michael\Documents\Radius College\N4 Applicatieontwikkelaar\Leerjaar 2\Project\Barroc\Bouwfase\Barroc-IT\Barroc-IT\App_Data\ReBarroc.mdf;Integrated Security=True";
            connectionString = @"Data Source=(LocalDB)\v" + version.ToString() + ".0;AttachDbFilename=|DataDirectory|\\App_Data\\ReBarroc.mdf;Integrated Security=True;Connect Timeout=30";
            adapter = new SqlDataAdapter();
            connection = new SqlConnection(connectionString);
            
            try
            {
                connection.Open();

                state = true;
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }

            return state;
        }

        public static Database GetInstance()
        {
            if (instance == null)
            {
                instance = new Database();
            }

            return instance;
        }

        public void OpenConnection()
        {
            connection.Open();
        }

        public void CloseConnection()
        {
            connection.Close();
        }

        public void Query(string query)
        {
            command = new SqlCommand(query, connection);
        }

        public void QueryInDatagridView(string query, DataGridView dataGridView)
        {
            dataGridView.Refresh();

            adapter = new SqlDataAdapter(query, connectionString);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView.DataSource = dataTable;
        }

        public void QueryInDatagridView(string query, string parameterName, object value, DataGridView dataGridView)
        {
            dataGridView.Refresh();

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.Add(new SqlParameter(parameterName, value));
            adapter = new SqlDataAdapter(cmd.CommandText, connectionString);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView.DataSource = dataTable;
        }

        public void AddParameter(string parameterName, object value)
        {
            command.Parameters.Add(new SqlParameter(parameterName, value));
        }

        public object ExecuteQuery()
        {
            object result = command.ExecuteScalar();
            
            return result;
        }
    }
}
