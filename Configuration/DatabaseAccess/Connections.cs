using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.DatabaseAccess
{
    public class Connections
    { 
        public string connectionString;
        public SqlConnection connection;
        public Connections()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
            OpenDatabaseConnection();
        }
        public void OpenDatabaseConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                connection.Open();
            }
            catch (SqlException exception)
            {
                throw exception;
            }
        }
        public void CloseDatabaseConnection()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
        }

    }
}