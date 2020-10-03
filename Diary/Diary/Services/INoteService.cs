using DiaryDAL.Entities;
using DiaryMVC.Models;
using System.Collections.Generic;

namespace DiaryMVC.Services
{
    public interface INoteService
    {
        List<Note> GetNotes();

        bool CreateNote(NoteModel noteModel);

        bool DeleteNote(int id);

        bool UpdateNote(NoteModel noteModel);

        bool SetNoteStatus(int id, bool done);
    }
}
