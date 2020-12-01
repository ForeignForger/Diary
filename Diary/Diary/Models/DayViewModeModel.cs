using System;
using System.Collections.Generic;

namespace DiaryMVC.Models
{
    public class DayViewModeModel
    {
        public DateTime SelectedDate {get; set;}

        public List<NoteModel> Notes { get; set; }
    }
}