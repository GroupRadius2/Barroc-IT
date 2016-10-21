using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

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
            connectionString = @"Data Source=MICHAELPC\MICHAEL;Initial Catalog=DatabaseBarroc;Integrated Security=True";
            adapter = new SqlDataAdapter();
            connection = new SqlConnection();
        }

        public static Database GetInstace()
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

        public object Query(string query, string parameter)
        {
            object result;

            command = new SqlCommand(query, connection);
            command.Parameters.Add(parameter);
            result = command.ExecuteScalar();

            return result;
        }
    }
}
