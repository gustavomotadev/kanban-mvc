using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KanbanMVC.DAL
{
    public class ColumnManagement
    {
        public static int? CreateColumn(string title, int boardId)
        {
            string insertQuery = $"INSERT INTO [dbo].[Column] ([Title],[BoardId]) OUTPUT Inserted.Id VALUES ('{title}',{boardId})";

            return (int?)DataBaseHelper.ExecuteScalarQuery(insertQuery);
        }

        public static int UpdateColumn(int id, string title)
        {
            string updateQuery = $"UPDATE [dbo].[Column] SET [Title] = '{title}' WHERE Id = {id} SELECT @@ROWCOUNT";

            var result = DataBaseHelper.ExecuteScalarQuery(updateQuery);

            return (result == null) ? 0 : (int)result;
        }

        public static int DeleteBoard(int id)
        {
            string deleteQuery = $"DELETE FROM [dbo].[Column] WHERE Id = {id} SELECT @@ROWCOUNT";

            var result = DataBaseHelper.ExecuteScalarQuery(deleteQuery);

            return (result == null) ? 0 : (int)result;
        }

        public static dynamic ReadBoard(int id)
        {
            string readQuery = $"SELECT * FROM [dbo].[Column] WHERE Id = {id}";

            var dataReader = DataBaseHelper.ExecuteReaderQuery(readQuery);

            dynamic result;

            if (dataReader.HasRows)
            {
                dataReader.Read();
                result = new
                {
                    Id = Convert.ToInt32(dataReader["Id"]),
                    Title = dataReader["Title"].ToString(),
                    BoardId = Convert.ToInt32(dataReader["BoardId"])
                };
            }
            else result = null;

            dataReader.Dispose();

            return result;
        }

        public static List<dynamic> ReadAllBoards()
        {
            string readQuery = $"SELECT * FROM [dbo].[Column]";

            var dataReader = DataBaseHelper.ExecuteReaderQuery(readQuery);

            var result = new List<dynamic>();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    result.Add(new
                    {
                        Id = Convert.ToInt32(dataReader["Id"]),
                        Title = dataReader["Title"].ToString(),
                        BoardId = Convert.ToInt32(dataReader["BoardId"])
                    });
                }
            }

            dataReader.Dispose();

            return result;
        }
    }
}