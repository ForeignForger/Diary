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
            var noteDatas = _noteService.GetNotes();
            var noteModels = NoteMapper.Map(noteDatas);

            var diaryModel = new DiaryModel()
            {
                Notes = noteModels
            };

            return View(diaryModel);
        }
    }
}