using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KanbanMVC.DAL
{
    public class NoteManagement
    {
        public static int? CreateNote(string title, string text, int columnId)
        {
            string insertQuery = $"INSERT INTO [dbo].[Note] ([Title],[Text],[ColumnId]) OUTPUT Inserted.Id VALUES ('{title}','{text}',{columnId})";

            return (int?)DataBaseHelper.ExecuteScalarQuery(insertQuery);
        }

        public static int UpdateNote(int id, string title, string text)
        {
            string updateQuery = $"UPDATE [dbo].[Note] SET [Title] = '{title}', [Text] = '{text}' WHERE Id = {id} SELECT @@ROWCOUNT";

            var result = DataBaseHelper.ExecuteScalarQuery(updateQuery);

            return (result == null) ? 0 : (int)result;
        }

        public static int DeleteNote(int id)
        {
            string deleteQuery = $"DELETE FROM [dbo].[Note] WHERE Id = {id} SELECT @@ROWCOUNT";

            var result = DataBaseHelper.ExecuteScalarQuery(deleteQuery);

            return (result == null) ? 0 : (int)result;
        }

        public static dynamic ReadNote(int id)
        {
            string readQuery = $"SELECT * FROM [dbo].[Note] WHERE Id = {id}";

            var dataReader = DataBaseHelper.ExecuteReaderQuery(readQuery);

            dynamic result;

            if (dataReader.HasRows)
            {
                dataReader.Read();
                result = new
                {
                    Id = Convert.ToInt32(dataReader["Id"]),
                    Title = dataReader["Title"].ToString(),
                    Text = dataReader["Text"].ToString(),
                    ColumnId = Convert.ToInt32(dataReader["ColumnId"])
                };
            }
            else result = null;

            dataReader.Dispose();

            return result;
        }

        public static List<dynamic> ReadAllNotes()
        {
            string readQuery = $"SELECT * FROM [dbo].[Note]";

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
                        Text = dataReader["Text"].ToString(),
                        ColumnId = Convert.ToInt32(dataReader["ColumnId"])
                    });
                }
            }

            dataReader.Dispose();

            return result;
        }

        public static List<dynamic> ReadNotesInColumn(int columnId)
        {
            string readQuery = $"SELECT * FROM [dbo].[Note] WHERE ColumnId = {columnId}";

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
                        Text = dataReader["Text"].ToString(),
                        ColumnId = Convert.ToInt32(dataReader["ColumnId"])
                    });
                }
            }

            dataReader.Dispose();

            return result;
        }
    }
}