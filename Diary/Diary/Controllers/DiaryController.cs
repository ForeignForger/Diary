using DiaryDAL.Repositories;
using DiaryMvc.Mappers;
using DiaryMVC.Models;
using DiaryMVC.Services;
using System.Web.Mvc;

namespace DiaryMVC.Controllers
{
    public class DiaryController : Controller
    {
        public ActionResult Index()
        {
            var connection = "vladSidorovDiaryDb";
            var noteRepository = new NoteRepository(connection);
            var noteService = new NoteService(noteRepository);
            var noteDatas = noteService.GetNotes();
            var noteModels = NoteMapper.Map(noteDatas);

            var diaryModel = new Diary()
            {
                Notes = noteModels
            };

            return View(diaryModel);
        }
    }
}