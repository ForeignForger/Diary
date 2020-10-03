using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using DiaryMVC.Models;
using DiaryDAL.Entities;

namespace DiaryMVC.Mappers
{
    public static class NoteMapper
    {
        public static List<NoteModel> Map(List<Note> noteDatas)
        {
            var notes = noteDatas.Select(n => NoteMapper.Map(n)).ToList();
            return notes;
        }

        public static NoteModel Map(Note noteData)
        {
            var note = new NoteModel
            {
                Id = noteData.Id,
                Title = noteData.Title,
                Type = NoteTypeMapper.Map(noteData.Type),
                //TODO: should convert time to the time on the client maybe?
                DateTime = noteData.DateTime,
                DueDateTime = noteData.DueDateTime,
                Place = noteData.Place,
                Done = noteData.Done
            };

            return note;
        }
    }
}