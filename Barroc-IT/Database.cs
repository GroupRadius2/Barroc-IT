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
        private static SqlDataAdapter adapter;
        private static SqlConnection connection;
        private static SqlCommand command;

        private Database()
        {
            connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\App_Data\ReBarroc.mdf;Integrated Security=True;Connect Timeout=30";
            adapter = new SqlDataAdapter();
            connection = new SqlConnection(connectionString);
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
