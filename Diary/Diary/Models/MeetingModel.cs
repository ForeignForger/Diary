using System;

namespace DiaryMVC.Models
{
    public class MeetingModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DateTime { get; set; }

        public DateTime DueDateTime { get; set; }

        public string Place { get; set; }

        public bool Done { get; set; }
    }
}