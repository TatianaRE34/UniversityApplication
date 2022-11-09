using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Configuration.DatabaseAccess
{
    public static class DbConnect
    {
        public static DataTable GetQueryData(string SQLQquery)
        {
            Connections dataAccessConnection=new Connections();
            DataTable datatable = new DataTable();
            using (SqlCommand command = new SqlCommand(SQLQquery, dataAccessConnection.connection))
            {
                command.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(command))
                {
                    sda.Fill(datatable);
                }
            }
            dataAccessConnection.CloseDatabaseConnection();
            return datatable;
        }
        public static void InsertUpdateDatabase(string SQLQquery, List<SqlParameter> parameters)
        {
            Connections dataAccessConnection = new Connections();
            using (SqlCommand command = new SqlCommand(SQLQquery, dataAccessConnection.connection))
            {
                command.CommandType = CommandType.Text;
                if (parameters != null)
                {
                    parameters.ForEach(parameter =>
                    {
                        command.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                    });
                }
                try { command.ExecuteNonQuery();}catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                
            }
            dataAccessConnection.CloseDatabaseConnection();
        }
        public static DataTable GetDataUsingCondition(string SQLQquery, List<SqlParameter> parameters)
        {
            Connections dataAccessConnection = new Connections();
            DataTable datatable = new DataTable();
            using (SqlCommand command = new SqlCommand(SQLQquery, dataAccessConnection.connection))
            {
                command.CommandType = CommandType.Text;
                if (parameters != null)
                {
                    parameters.ForEach(parameter =>
                    {
                        command.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                    });
                }
                using (SqlDataAdapter sda = new SqlDataAdapter(command))
                {
                    try {sda.Fill(datatable); }catch(Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    
                }
            }
            dataAccessConnection.CloseDatabaseConnection();
            return datatable;
        }
    }
}