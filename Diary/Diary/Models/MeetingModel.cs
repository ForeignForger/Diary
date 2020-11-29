using System;
using System.ComponentModel.DataAnnotations;

namespace DiaryMVC.Models
{
    public class MeetingModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime DateTime { get; set; }

        [Required(ErrorMessage = "Due date is required")]
        public DateTime DueDateTime { get; set; }

        [Required(ErrorMessage = "Place is required")]
        public string Place { get; set; }

        public bool Done { get; set; }
    }
}