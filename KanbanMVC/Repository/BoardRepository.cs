using KanbanMVC.DAL;
using KanbanMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KanbanMVC.Repository
{
    public class BoardRepository
    {
        public static int DeleteBoard(int id)
        {
            return BoardManagement.DeleteBoard(id);
        }

        public static int UpdateBoard(int id, string title)
        {
            return BoardManagement.UpdateBoard(id, title);
        }

        public static int? CreateBoard(string title)
        {
            return BoardManagement.CreateBoard(title);
        }

        public static Board ReadBoard(int id)
        {
            var boardDB = BoardManagement.ReadBoard(id);

            return new Board() { Id = boardDB.Id, Title = boardDB.Title };
        }

        public static List<Board> ReadAllBoards()
        {
            var boardsDB = BoardManagement.ReadAllBoards();
            var boards = new List<Board>();

            foreach (var boardDB in boardsDB)
            {
                boards.Add(new Board() { Id = boardDB.Id, Title = boardDB.Title });
            }

            return boards;
        }
    }
}