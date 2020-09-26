using System.Collections.Generic;
using System.Linq;
using NoteModel = DiaryMVC.Models.Note;
using NoteData = DiaryDAL.Entities.Note;
using DiaryMVC.Mappers;
using System.Web.UI.WebControls;

namespace DiaryMvc.Mappers
{
    public static class NoteMapper
    {
        public static List<NoteModel> Map(List<NoteData> noteDatas)
        {
            var notes = noteDatas.Select(n => NoteMapper.Map(n)).ToList();
            return notes;
        }

        public static NoteModel Map(NoteData noteData)
        {
            var note = new NoteModel
            {
                Id = noteData.Id,
                Title = noteData.Title,
                Type = NoteTypeMapper.Map(noteData.Type),
                //TODO: should convert time to the time on the client maybe?
                DateTime = noteData.DateTime,
                DueDateTime = noteData.DueDateTime,
                Place = noteData.Place
            };

            return note;
        }
    }
}