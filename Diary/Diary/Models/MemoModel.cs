using System;

namespace DiaryMVC.Models
{
    public class MemoModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DateTime { get; set; }

        public bool Done { get; set; }
    }
}