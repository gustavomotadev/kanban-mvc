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
            var notes = NoteRepository.ReadNotesInColumn(columnId);

            return PartialView("_GetNoteList", notes);
        }

        [HttpPost]
        public ActionResult CreateNote(int columnId, string title, string text)
        {
            var id = NoteRepository.CreateNote(columnId, title, text);
            var boardId = ColumnRepository.ReadColumn(columnId)?.BoardId;

            if (id != null && boardId != null) return RedirectToAction("DisplayBoard", "Board", new { id = boardId });
            else return RedirectToAction("Index", "Board");
        }

        [HttpGet]
        public ActionResult DeleteNote(int id)
        {
            var columnId = NoteRepository.ReadNote(id)?.ColumnId;
            var boardId = (columnId != null) ? ColumnRepository.ReadColumn((int) columnId)?.BoardId : null;

            if (boardId != null)
            {
                NoteRepository.DeleteNote(id);
                return RedirectToAction("DisplayBoard", "Board", new { id = boardId });
            }
            else return RedirectToAction("Index", "Board");
        }

        [HttpPost]
        public ActionResult UpdateNote(int id, string title, string text)
        {
            var columnId = NoteRepository.ReadNote(id)?.ColumnId;
            var boardId = (columnId != null) ? ColumnRepository.ReadColumn((int)columnId)?.BoardId : null;

            if (boardId != null)
            {
                NoteRepository.UpdateNote(id, title, text);
                return RedirectToAction("DisplayBoard", "Board", new { id = boardId });
            }
            else return RedirectToAction("Index", "Board");
        }
    }
}