using DiaryDAL.Entities;
using System.Collections.Generic;

namespace DiaryDAL.Repositories
{
    public interface INoteRepository
    {
        List<Note> GetNotes();

        Note CreateNote(Note note);

        bool DeleteNote(int id);

        bool UpdateNote(Note note);

        bool SetNoteStatus(int id, bool done);
    }
}
