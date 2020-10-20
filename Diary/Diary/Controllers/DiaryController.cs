using DiaryMVC.Mappers;
using DiaryMVC.Models;
using DiaryMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        public ActionResult GetDiaryContent(string mode, string from, string to, List<string> noteTypes)
        {
            ActionResult result;
            var viewMode = DiaryViewMode.GetMode(mode);

            if (viewMode != null)
            {
                DateTime? fromDate = string.IsNullOrEmpty(from) ? (DateTime?)null : DateTime.Parse(from);
                DateTime? toDate = string.IsNullOrEmpty(to) ? (DateTime?)null : DateTime.Parse(to);
                noteTypes = noteTypes == null ? new List<string>() : noteTypes;
                var noteTypeModels = noteTypes.Select(type => (NoteTypeModel)Enum.Parse(typeof(NoteTypeModel), type, true)).ToList();

                if (viewMode.Equals(DiaryViewMode.List))
                {
                    result = RenderListView(fromDate, toDate, noteTypeModels);
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

        private ActionResult RenderListView(DateTime? from, DateTime? to, List<NoteTypeModel> noteTypes)
        {
            var notes = _noteService.GetNotes(from, to, noteTypes);
            notes = notes.OrderBy(note => note.DateTime).ToList();
            var noteModels = NoteMapper.Map(notes);
            var list = new ListViewModeModel()
            {
                Notes = noteModels
            };

            return PartialView("Diary/ViewModes/List", list);
        }
    }
}