using KanbanMVC.DAL;
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
            return PartialView("_GetBoardList", BoardRepository.ReadAllBoards());
        }

        [HttpGet]
        public ActionResult GetBoard(int id)
        {
            var board = BoardRepository.ReadBoard(id);

            return PartialView("_GetBoard", board);
        }

        [HttpGet]
        public ActionResult DisplayBoard(int id)
        {
            var board = BoardRepository.ReadBoard(id);

            return View(board);
        }

        [HttpGet]
        public ActionResult DeleteBoard(int id)
        {
            var affected = BoardRepository.DeleteBoard(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateBoard(int id, string title)
        {
            var affected = BoardRepository.UpdateBoard(id, title);

            if (affected > 0) return RedirectToAction("DisplayBoard", new {id});
            else return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CreateBoard(string title)
        {
            var id = BoardRepository.CreateBoard(title);

            if (id != null) return RedirectToAction("DisplayBoard", new { id });
            else return RedirectToAction("Index");
        }
    }
}