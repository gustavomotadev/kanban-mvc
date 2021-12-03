using KanbanMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KanbanMVC.Controllers
{
    public class ColumnController : Controller
    {
        [HttpGet]
        public ActionResult GetColumnList(int boardId)
        {
            var columns = ColumnRepository.ReadColumnsInBoard(boardId);

            return PartialView("_GetColumnList", columns);
        }

        [HttpPost]
        public ActionResult CreateColumn(int boardId, string title)
        {
            var id = ColumnRepository.CreateColumn(boardId, title);

            if (id != null) return RedirectToAction("DisplayBoard", "Board", new { id = boardId });
            else return RedirectToAction("Index", "Board");
        }

        [HttpGet]
        public ActionResult DeleteColumn(int id)
        {
            var column = ColumnRepository.ReadColumn(id);

            if (column != null)
            {
                var boardId = column.BoardId;
                ColumnRepository.DeleteColumn(id);

                return RedirectToAction("DisplayBoard", "Board", new { id = boardId });
            }
            else return RedirectToAction("Index", "Board");
        }

        [HttpPost]
        public ActionResult UpdateColumn(int id, string title)
        {
            var column = ColumnRepository.ReadColumn(id);

            if (column != null)
            {
                var boardId = column.BoardId;
                ColumnRepository.UpdateColumn(id, title);
                return RedirectToAction("DisplayBoard", "Board", new { id = boardId });
            }
            else return RedirectToAction("Index", "Board");
        }
    }
}