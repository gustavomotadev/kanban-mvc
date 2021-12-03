using KanbanMVC.DAL;
using KanbanMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KanbanMVC.Repository
{
    public class ColumnRepository
    {
        public static int DeleteColumn(int id)
        {
            return ColumnManagement.DeleteColumn(id);
        }

        public static int UpdateColumn(int id, string title)
        {
            return ColumnManagement.UpdateColumn(id, title);
        }

        public static int? CreateColumn(int boardId, string title)
        {
            return ColumnManagement.CreateColumn(title, boardId);
        }

        public static Column ReadColumn(int id)
        {
            var columnDB = ColumnManagement.ReadColumn(id);

            return new Column() { Id = columnDB.Id, Title = columnDB.Title, BoardId = columnDB.BoardId };
        }

        public static List<Column> ReadAllColumns()
        {
            var columnsDB = ColumnManagement.ReadAllColumns();
            var columns = new List<Column>();

            foreach (var columnDB in columnsDB)
            {
                columns.Add(new Column() { Id = columnDB.Id, Title = columnDB.Title, BoardId = columnDB.BoardId });
            }

            return columns;
        }

        public static List<Column> ReadColumnsInBoard(int boardId)
        {
            var columnsDB = ColumnManagement.ReadColumnsInBoard(boardId);
            var columns = new List<Column>();

            foreach (var columnDB in columnsDB)
            {
                columns.Add(new Column() { Id = columnDB.Id, Title = columnDB.Title, BoardId = columnDB.BoardId });
            }

            return columns;
        }
    }
}