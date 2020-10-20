using DiaryDAL.Entities;
using DiaryMVC.Models;
using System;
using System.Collections.Generic;

namespace DiaryMVC.Services
{
    public interface INoteService
    {
        List<Note> GetNotes(DateTime? from, DateTime? to, List<NoteTypeModel> noteTypes);

        bool CreateNote(NoteModel noteModel);

        bool DeleteNote(int id);

        bool UpdateNote(NoteModel noteModel);

        bool SetNoteStatus(int id, bool done);
    }
}
