using System;
using System.ComponentModel.DataAnnotations;

namespace DiaryMVC.Models
{
    public class MemoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime DateTime { get; set; }

        public bool Done { get; set; }
    }
}