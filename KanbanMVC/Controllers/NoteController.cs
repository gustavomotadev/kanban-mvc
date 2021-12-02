using KanbanMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KanbanMVC.Controllers
{
    public class NoteController : Controller
    {
        [HttpGet]
        public ActionResult GetNoteList(int columnId)
        {
            var notes = EntityRepository.Notes.Where(c => c.ColumnId == columnId).ToList();

            return PartialView("_GetNoteList", notes);
        }

        [HttpPost]
        public ActionResult CreateNote(int columnId, string title, string text)
        {
            var boardId = EntityRepository.Columns.SingleOrDefault(c => c.Id == columnId).BoardId;

            var id = EntityRepository.CreateNote(columnId, title, text);

            if (id != -1) return RedirectToAction("DisplayBoard", "Board", new { id = boardId });
            else return RedirectToAction("Index", "Board");
        }

        [HttpGet]
        public ActionResult DeleteNote(int id)
        {
            var columnId = EntityRepository.Notes.SingleOrDefault(n => n.Id == id).ColumnId;
            var boardId = EntityRepository.Columns.SingleOrDefault(c => c.Id == columnId).BoardId;

            EntityRepository.DeleteNote(id);

            return RedirectToAction("DisplayBoard", "Board", new { id = boardId });
        }

        [HttpPost]
        public ActionResult UpdateNote(int id, string title, string text)
        {
            var columnId = EntityRepository.Notes.SingleOrDefault(n => n.Id == id).ColumnId;
            var boardId = EntityRepository.Columns.SingleOrDefault(c => c.Id == columnId).BoardId;

            EntityRepository.UpdateNote(id, title, text);

            return RedirectToAction("DisplayBoard", "Board", new { id = boardId });
        }
    }
}