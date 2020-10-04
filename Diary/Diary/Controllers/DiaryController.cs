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

        //TODO add filtering here?
        public ActionResult GetDiaryContent(string mode)
        {
            ActionResult result;
            var viewMode = DiaryViewMode.GetMode(mode);

            if (viewMode != null)
            {
                if (viewMode.Equals(DiaryViewMode.List))
                {
                    result = RenderListView();
                }
                else
                {
                    //todo error? empty result?
                    result = new EmptyResult();
                }
            }
            else
            {
                result = new EmptyResult();
            }

            return result;
        }

        private ActionResult RenderListView()
        {
            var notes = _noteService.GetNotes();
            var noteModels = NoteMapper.Map(notes);
            var list = new ListViewModeModel()
            {
                Notes = noteModels
            };

            return PartialView("Diary/ViewModes/List", list);
        }
    }
}