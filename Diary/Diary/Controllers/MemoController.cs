using DiaryMVC.Mappers;
using DiaryMVC.Models;
using DiaryMVC.Services;
using System.Web.Mvc;

namespace DiaryMVC.Controllers
{
    public class MemoController : Controller
    {
        private readonly IMemoService _memoService;
        private readonly INoteService _noteService;

        public MemoController(IMemoService memoService, INoteService noteService)
        {
            _memoService = memoService;
            _noteService = noteService;
        }

        public ActionResult Create()
        {
            ViewData["created"] = false;
            var emptyModel = new MemoModel();

            return PartialView("Diary/Memo/CreateForm", emptyModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MemoModel model)
        {
            bool created;

            if (ModelState.IsValid)
            {
                created = _memoService.Create(model);
            }
            else {
                created = false;
            }

            ViewData["created"] = created;

            return PartialView("Diary/Memo/CreateForm", model);
        }

        public ActionResult Update(int id)
        {
            ViewData["updated"] = false;
            var note = _noteService.Get(id);
            var model = MemoMapper.Map(note);

            return PartialView("Diary/Memo/UpdateForm", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(MemoModel model)
        {
            bool updated;

            if (ModelState.IsValid)
            {
                updated = _memoService.Update(model);
            }
            else
            {
                updated = false;
            }

            ViewData["updated"] = updated;

            return PartialView("Diary/Memo/UpdateForm", model);
        }
    }
}