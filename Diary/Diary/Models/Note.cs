using System;

namespace DiaryMVC.Models
{
    //TODO: validation
    public class Note
    {
        //todo: should be nullable??
        public int Id { get; set; }

        public string Title { get; set; }

        public NoteType Type { get; set; }

        public DateTime DateTime { get; set; }

        public DateTime? DueDateTime { get; set; }

        public string Place { get; set; }

        public bool Done { get; set; }
    }
}