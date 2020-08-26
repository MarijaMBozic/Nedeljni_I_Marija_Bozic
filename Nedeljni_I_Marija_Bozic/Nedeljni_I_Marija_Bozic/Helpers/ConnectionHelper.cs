using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni_I_Marija_Bozic.Helpers
{
    static class ConnectionHelper
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["con"].ToString();

        public static SqlConnection GetNewConnection()
        {
            SqlConnection newConnection = new SqlConnection(connectionString);

            return newConnection;
        }
    }
}
