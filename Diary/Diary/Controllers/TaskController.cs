using DiaryMVC.Models;
using DiaryMVC.Services;
using System.Web.Mvc;

namespace DiaryMVC.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService meetingService)
        {
            _taskService = meetingService;
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

        private void Validate(TaskModel model)
        {
            if (model != null && model.DateTime >= model.DueDateTime)
            {
                ModelState.AddModelError(nameof(model.DueDateTime), "Due date should be greater than Date field");
            }
        }
    }
}