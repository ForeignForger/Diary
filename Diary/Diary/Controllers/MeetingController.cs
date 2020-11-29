using DiaryMVC.Models;
using DiaryMVC.Services;
using System.Web.Mvc;

namespace DiaryMVC.Controllers
{
    public class MeetingController : Controller
    {
        private readonly IMeetingService _meetingService;
        public MeetingController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        public ActionResult Create()
        {
            ViewData["created"] = false;
            var emptyModel = new MeetingModel();
            return PartialView("Diary/Meeting/CreateForm", emptyModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MeetingModel model)
        {
            bool created;
            Validate(model);

            if (ModelState.IsValid)
            {
                created = _meetingService.Create(model);
            }
            else
            {
                created = false;
            }

            ViewData["created"] = created;
            return PartialView("Diary/Meeting/CreateForm", model);
        }

        private void Validate(MeetingModel model)
        {
            if (model != null && model.DateTime >= model.DueDateTime)
            {
                ModelState.AddModelError(nameof(model.DueDateTime), "Due date should be greater than Date field");
            }
        }
    }
}