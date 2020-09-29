using System;
using System.ComponentModel.DataAnnotations;

namespace DiaryDAL.Entities
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public NoteType Type { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public DateTime? DueDateTime { get; set; }

        public string Place { get; set; }

        public bool Done { get; set; }
    }
}
