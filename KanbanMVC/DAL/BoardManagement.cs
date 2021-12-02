using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KanbanMVC.DAL
{
    public class BoardManagement
    {
        public static int? CreateBoard(string title)
        {
            string insertQuery = $"INSERT INTO [dbo].[Board] ([Title]) OUTPUT Inserted.Id VALUES ('{title}')";

            return (int?) DataBaseHelper.ExecuteScalarQuery(insertQuery);
        }

        public static int UpdateBoard(int id, string title)
        {
            string updateQuery = $"UPDATE [dbo].[Board] SET [Title] = '{title}' WHERE Id = {id} SELECT @@ROWCOUNT";

            var result = DataBaseHelper.ExecuteScalarQuery(updateQuery);

            return (result == null) ? 0 : (int) result;
        }

        public static int DeleteBoard(int id)
        {
            string deleteQuery = $"DELETE FROM [dbo].[Board] WHERE Id = {id} SELECT @@ROWCOUNT";

            var result = DataBaseHelper.ExecuteScalarQuery(deleteQuery);

            return (result == null) ? 0 : (int)result;
        }

        public static dynamic ReadBoard(int id)
        {
            string readQuery = $"SELECT * FROM [dbo].[Board] WHERE Id = {id}";

            var dataReader = DataBaseHelper.ExecuteReaderQuery(readQuery);

            dynamic result;

            if (dataReader.HasRows)
            {
                dataReader.Read();
                result = new {Id = Convert.ToInt32(dataReader["Id"]),
                    Title = dataReader["Title"].ToString()};
            }
            else result = null;

            dataReader.Dispose();

            return result;
        }

        public static List<dynamic> ReadAllBoards()
        {
            string readQuery = $"SELECT * FROM [dbo].[Board]";

            var dataReader = DataBaseHelper.ExecuteReaderQuery(readQuery);

            var result = new List<dynamic>();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    result.Add(new
                    {
                        Id = Convert.ToInt32(dataReader["Id"]),
                        Title = dataReader["Title"].ToString()
                    });
                }
            }

            dataReader.Dispose();

            return result;
        }
    }
}