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
            var columns = EntityRepository.Columns.Where(c => c.BoardId == boardId).ToList();

            return PartialView("_GetColumnList", columns);
        }

        [HttpPost]
        public ActionResult CreateColumn(int boardId, string title)
        {
            var id = EntityRepository.CreateColumn(boardId, title);

            if (id != -1) return RedirectToAction("DisplayBoard", "Board", new { id = boardId });
            else return RedirectToAction("Index", "Board");
        }

        [HttpGet]
        public ActionResult DeleteColumn(int id)
        {
            var boardId = EntityRepository.Columns.SingleOrDefault(c => c.Id == id).BoardId;

            EntityRepository.DeleteColumn(id);

            return RedirectToAction("DisplayBoard", "Board", new {id = boardId});
        }

        [HttpPost]
        public ActionResult UpdateColumn(int id, string title)
        {
            var boardId = EntityRepository.Columns.SingleOrDefault(c => c.Id == id).BoardId;

            EntityRepository.UpdateColumn(id, title);

            return RedirectToAction("DisplayBoard", "Board", new { id = boardId });
        }
    }
}