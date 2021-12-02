using KanbanMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KanbanMVC.Controllers
{
    public class BoardController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetBoardList()
        {
            return PartialView("_GetBoardList", EntityRepository.Boards);
        }

        [HttpGet]
        public ActionResult GetBoard(int id)
        {
            var board = EntityRepository.Boards.SingleOrDefault(b => b.Id == id);

            return PartialView("_GetBoard", board);
        }

        [HttpGet]
        public ActionResult DisplayBoard(int id)
        {
            var board = EntityRepository.Boards.SingleOrDefault(b => b.Id == id);

            return View(board);
        }

        [HttpGet]
        public ActionResult DeleteBoard(int id)
        {
            EntityRepository.DeleteBoard(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateBoard(int id, string title)
        {
            EntityRepository.UpdateBoard(id, title);

            return RedirectToAction("DisplayBoard", new {id});
        }

        [HttpPost]
        public ActionResult CreateBoard(string title)
        {
            var id = EntityRepository.CreateBoard(title);

            return RedirectToAction("DisplayBoard", new { id });
        }
    }
}