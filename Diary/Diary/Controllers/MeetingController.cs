using DiaryMVC.Mappers;
using DiaryMVC.Models;
using DiaryMVC.Services;
using System.Web.Mvc;

namespace DiaryMVC.Controllers
{
    public class MeetingController : Controller
    {
        private readonly IMeetingService _meetingService;
        private readonly INoteService _noteService;

        public MeetingController(IMeetingService meetingService, INoteService noteService)
        {
            _meetingService = meetingService;
            _noteService = noteService;
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

        public ActionResult Update(int id)
        {
            ViewData["updated"] = false;
            var note = _noteService.Get(id);
            var model = MeetingMapper.Map(note);

            return PartialView("Diary/Meeting/UpdateForm", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(MeetingModel model)
        {
            bool updated;
            Validate(model);

            if (ModelState.IsValid)
            {
                updated = _meetingService.Update(model);
            }
            else
            {
                updated = false;
            }

            ViewData["updated"] = updated;

            return PartialView("Diary/Meeting/UpdateForm", model);
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