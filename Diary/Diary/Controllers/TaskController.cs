using DiaryMVC.Mappers;
using DiaryMVC.Models;
using DiaryMVC.Services;
using System.Web.Mvc;

namespace DiaryMVC.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly INoteService _noteService;
        public TaskController(ITaskService meetingService, INoteService noteService)
        {
            _taskService = meetingService;
            _noteService = noteService;
        }

        public ActionResult Create()
        {
            ViewData["created"] = false;
            var emptyModel = new TaskModel();
            return PartialView("Diary/Task/CreateForm", emptyModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskModel model)
        {
            bool created;
            Validate(model);

            if (ModelState.IsValid)
            {
                created = _taskService.Create(model);
            }
            else
            {
                created = false;
            }

            ViewData["created"] = created;
            return PartialView("Diary/Task/CreateForm", model);
        }

        public ActionResult Update(int id)
        {
            ViewData["updated"] = false;
            var note = _noteService.Get(id);
            var model = TaskMapper.Map(note);

            return PartialView("Diary/Task/UpdateForm", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(TaskModel model)
        {
            bool updated;
            Validate(model);

            if (ModelState.IsValid)
            {
                updated = _taskService.Update(model);
            }
            else
            {
                updated = false;
            }

            ViewData["updated"] = updated;

            return PartialView("Diary/Task/UpdateForm", model);
        }

        private void Validate(TaskModel model)
        {
            if (model != null && model.DateTime >= model.DueDateTime)
            {
                ModelState.AddModelError(nameof(model.DueDateTime), "Due date should be greater than Date field");
            }
        }
    }
}