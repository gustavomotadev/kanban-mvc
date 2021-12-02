using KanbanMVC.DAL;
using KanbanMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KanbanMVC.Repository
{
    public class EntityRepository
    {
        public static List<Board> Boards { get; set; } = new List<Board>();

        public static List<Column> Columns { get; set; } = new List<Column>();

        public static List<Note> Notes { get; set; } = new List<Note>();

        public static void FillTestData()
        {
            Boards.Add(new Board() { Id = 1, Title = "Project ABC" });
            Boards.Add(new Board() { Id = 2, Title = "Project DEF" });
            Boards.Add(new Board() { Id = 3, Title = "Project GHI" });
            Columns.Add(new Column() { Id = 1, BoardId = 1, Title = "Backlog" });
            Columns.Add(new Column() { Id = 2, BoardId = 1, Title = "Development" });
            Columns.Add(new Column() { Id = 3, BoardId = 1, Title = "Done" });
            Notes.Add(new Note() { Id = 1, ColumnId = 1, Title = "Fix Bug #1", Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum sed ullamcorper ligula. Vestibulum et volutpat ipsum. Nunc rhoncus tristique venenatis." });
            Notes.Add(new Note() { Id = 2, ColumnId = 1, Title = "UX", Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum sed ullamcorper ligula. Vestibulum et volutpat ipsum. Nunc rhoncus tristique venenatis." });
            Notes.Add(new Note() { Id = 3, ColumnId = 1, Title = "Unit Tests", Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum sed ullamcorper ligula. Vestibulum et volutpat ipsum. Nunc rhoncus tristique venenatis." });
            Notes.Add(new Note() { Id = 4, ColumnId = 2, Title = "Views", Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum sed ullamcorper ligula. Vestibulum et volutpat ipsum. Nunc rhoncus tristique venenatis." });
            Notes.Add(new Note() { Id = 5, ColumnId = 2, Title = "Controllers", Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum sed ullamcorper ligula. Vestibulum et volutpat ipsum. Nunc rhoncus tristique venenatis." });
            Notes.Add(new Note() { Id = 6, ColumnId = 3, Title = "Models", Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum sed ullamcorper ligula. Vestibulum et volutpat ipsum. Nunc rhoncus tristique venenatis." });
        }

        public static void FillRepository()
        {
            FillTestData();
            ReadAllBoards();
        }

        /* BOARD */

        public static int DeleteBoard(int id)
        {
            var affected = BoardManagement.DeleteBoard(id);

            if (affected > 0)
            {
                var board = Boards.SingleOrDefault(b => b.Id == id);
                var board_columns = Columns.Where(c => c.BoardId == id);

                foreach (var column in board_columns)
                {
                    Notes.RemoveAll(n => n.ColumnId == column.Id);
                }
                Columns.RemoveAll(c => c.BoardId == id);
                Boards.Remove(board);
            }

            return affected;
        }

        public static int UpdateBoard(int id, string title)
        {
            var affected = BoardManagement.UpdateBoard(id, title);

            if (affected > 0) Boards.SingleOrDefault(b => b.Id == id).Title = title;

            return affected;
        }

        public static int? CreateBoard(string title)
        {
            var id = BoardManagement.CreateBoard(title);

            if (id != null) Boards.Add(new Board() { Id = (int) id, Title = title });

            return id;
        }

        public static Board GetBoard(int id)
        {
            return Boards.SingleOrDefault(b => b.Id == id);
        }

        public static List<Board> GetAllBoards()
        {
            return Boards;
        }

        public static Board ReadBoard(int id)
        {
            var boardDB = BoardManagement.ReadBoard(id);

            var boardRepo = Boards.FirstOrDefault(b => b.Id == id);
            if (boardRepo != null)
            {
                boardRepo.Title = boardDB.Title;
            }
            else Boards.Add(new Board() { Id = boardDB.Id, Title = boardDB.Title });

            return boardDB;
        }

        public static List<Board> ReadAllBoards()
        {
            var boardsDB = BoardManagement.ReadAllBoards();

            foreach (var boardDB in boardsDB)
            {
                var boardRepo = Boards.FirstOrDefault(b => b.Id == boardDB.Id);
                if (boardRepo != null)
                {
                    boardRepo.Title = boardDB.Title;
                }
                else Boards.Add(new Board() { Id = boardDB.Id, Title = boardDB.Title });
            }

            return Boards;
        }

        /* COLUMN */

        public static int CreateColumn(int boardId, string title)
        {
            if (Boards.Any(b => b.Id == boardId))
            {
                var id = Columns.Max(c => c.Id) + 1;

                Columns.Add(new Column() { Id = id, Title = title, BoardId = boardId });

                return id;
            }
            else return -1;
        }

        public static void DeleteColumn(int id)
        {
            var column = Columns.SingleOrDefault(c => c.Id == id);

            Notes.RemoveAll(n => n.ColumnId == id);

            Columns.Remove(column);
        }

        public static void UpdateColumn(int id, string title)
        {
            var column = Columns.SingleOrDefault(c => c.Id == id);

            column.Title = title;
        }

        /* NOTE */

        public static int CreateNote(int columnId, string title, string text)
        {
            if (Columns.Any(c => c.Id == columnId))
            {
                var id = Notes.Max(n => n.Id) + 1;

                Notes.Add(new Note() { Id = id, Title = title, Text = text, ColumnId = columnId });

                return id;
            }
            else return -1;
        }

        public static void DeleteNote(int id)
        {
            var note = Notes.SingleOrDefault(n => n.Id == id);

            Notes.Remove(note);
        }

        public static void UpdateNote(int id, string title, string text)
        {
            var note = Notes.SingleOrDefault(n => n.Id == id);

            note.Title = title;
            note.Text = text;
        }
    }
}