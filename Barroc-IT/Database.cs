using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barroc_IT
{
    class Database
    {
        private static string connectionString;
        private static Database instance;

        private Database()
        {
            connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\michael\Documents\Radius College\N4 Applicatieontwikkelaar\Leerjaar 2\Project\Barroc\Bouwfase\Barroc-IT\DatabaseBarrocIT.accdb";
        }

        public static Database GetInstace()
        {
            if (instance == null)
            {
                instance = new Database();
            }

            return instance;
        }
    }
}
