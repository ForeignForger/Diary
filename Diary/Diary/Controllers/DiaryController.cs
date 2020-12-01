using DiaryDAL.Entities;
using DiaryMVC.Mappers;
using DiaryMVC.Models;
using DiaryMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiaryMVC.Controllers
{
    public class DiaryController : Controller
    {
        private const string _selectedDateCookie = "selectedDate";
        private const string _selectedViewMode = "viewMode";

        private readonly INoteService _noteService;

        public DiaryController(INoteService noteService)
        {
            _noteService = noteService;
        }

        public ActionResult Index()
        {
            var modeKey = GetCookie(_selectedViewMode);
            DiaryViewMode mode;

            if (string.IsNullOrEmpty(modeKey))
            {
                mode = DiaryViewMode.List;
            }
            else
            {
                mode = DiaryViewMode.GetMode(modeKey);
            }

            var diaryModel = new DiaryModel()
            {
                Mode = mode
            };

            return View(diaryModel);
        }

        [HttpPost]
        public ActionResult GetDiaryContent(string mode, string from, string to, List<string> noteTypes)
        {
            ActionResult result;
            var viewMode = DiaryViewMode.GetMode(mode);

            if (viewMode != null)
            {
                SetCookie(_selectedViewMode, viewMode.Key);
                DateTime? fromDate = string.IsNullOrEmpty(from) ? (DateTime?)null : DateTime.Parse(from).Date;
                DateTime? toDate = string.IsNullOrEmpty(to) ? (DateTime?)null : DateTime.Parse(to).Date;
                noteTypes = noteTypes == null ? new List<string>() : noteTypes;
                var noteTypeModels = noteTypes.Select(type => (NoteTypeModel)Enum.Parse(typeof(NoteTypeModel), type, true)).ToList();

                if (viewMode.Equals(DiaryViewMode.List))
                {
                    result = RenderListView(fromDate, toDate, noteTypeModels);
                }
                else if (viewMode.Equals(DiaryViewMode.Day))
                {
                    result = RenderDayView(fromDate, toDate, noteTypeModels);
                }
                else
                {
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
            var notes = _noteService.GetAll(from, to, noteTypes);
            notes = notes.OrderBy(note => note.DateTime).ToList();
            var noteModels = NoteMapper.Map(notes);
            var list = new ListViewModeModel()
            {
                Notes = noteModels
            };

            return PartialView("Diary/ViewModes/List", list);
        }

        private ActionResult RenderDayView(DateTime? from, DateTime? to, List<NoteTypeModel> noteTypes)
        {
            DateTime selectedDate;
            var selectedDateCookie = GetCookie(_selectedDateCookie);

            if (selectedDateCookie == null)
            {
                selectedDate = DateTime.Now.Date;
                SetCookie(_selectedDateCookie, selectedDate.ToString("o"));
            }
            else
            {
                selectedDate = DateTime.Parse(selectedDateCookie).Date;
            }

            List<Note> notes;

            if (from.HasValue && to.HasValue)
            {
                if (from.Value <= selectedDate && selectedDate <= to.Value)
                {
                    notes = _noteService.GetAll(selectedDate, selectedDate, noteTypes);
                }
                else
                {
                    notes = new List<Note>();
                }
            }
            else
            {
                if (!from.HasValue && !to.HasValue)
                {
                    notes = _noteService.GetAll(selectedDate, selectedDate, noteTypes);
                }
                else if (from.HasValue && from.Value <= selectedDate)
                {
                    notes = _noteService.GetAll(selectedDate, selectedDate, noteTypes);
                }
                else if (to.HasValue && to.Value >= selectedDate)
                {
                    notes = _noteService.GetAll(selectedDate, selectedDate, noteTypes);
                }
                else
                {
                    notes = new List<Note>();
                }
            }
            
            notes = notes.OrderBy(note => note.DateTime).ToList();
            var noteModels = NoteMapper.Map(notes);

            var list = new DayViewModeModel()
            {
                SelectedDate = selectedDate, 
                Notes = noteModels,
            };

            return PartialView("Diary/ViewModes/Day", list);
        }

        private void SetCookie(string key, string value)
        {
            var cookie = new HttpCookie(key, value);
            Response.Cookies.Set(cookie);
        }

        private string GetCookie(string key)
        {
            var cookie = Request.Cookies.Get(key);
            string value;

            if (cookie == null)
            {
                value = null;
            }
            else
            {
                value = cookie.Value;
            }

            return value;
        }
    }
}