using DiaryMVC.Models;
using DiaryMVC.Services;
using System.Web.Mvc;

namespace DiaryMVC.Controllers
{
    public class MemoController : Controller
    {
        private readonly IMemoService _memoService;
        public MemoController(IMemoService memoService)
        {
            _memoService = memoService;
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
            //TODO check
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
    }
}