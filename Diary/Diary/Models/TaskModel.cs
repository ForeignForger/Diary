using System;

namespace DiaryMVC.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DateTime { get; set; }

        public DateTime DueDateTime { get; set; }

        public bool Done { get; set; }
    }
}