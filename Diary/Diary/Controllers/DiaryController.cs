using DiaryMVC.Mappers;
using DiaryMVC.Models;
using DiaryMVC.Services;
using System.Web.Mvc;

namespace DiaryMVC.Controllers
{
    public class DiaryController : Controller
    {
        private readonly INoteService _noteService;

        public DiaryController(INoteService noteService)
        {
            _noteService = noteService;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}