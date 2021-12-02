using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KanbanMVC.DAL
{
    public class DataBaseHelper
    {
        public static string ConnectionString { get; } = 
            "Integrated Security=SSPI;Persist Security Info=False;" +
            "Initial Catalog=KanbanMVC;Data Source=MIR-0544";

        public static object ExecuteScalarQuery(string query)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            var result = command.ExecuteScalar();

            command.Dispose();
            connection.Dispose();

            return result;
        }

        public static SqlDataReader ExecuteReaderQuery(string query)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            var result = command.ExecuteReader(CommandBehavior.CloseConnection); //connection will be closed on closing SqlDataReader

            command.Dispose();
            //connection.Dispose(); //connection will be closed on closing SqlDataReader

            return result;
        }
    }
}