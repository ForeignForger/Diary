using DiaryDAL.Entities;
using System;
using System.Collections.Generic;

namespace DiaryDAL.Repositories
{
    public interface INoteRepository
    {
        List<Note> GetAll(DateTime? from, DateTime? to, NoteType noteTypeMask);

        Note Create(Note note);

        bool Delete(int id);

        bool Update(Note note);

        bool SetStatus(int id, bool done);
    }
}
