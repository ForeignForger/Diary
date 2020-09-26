using DiaryDAL.Entities;
using System.Collections.Generic;

namespace DiaryDAL.Repositories
{
    interface INoteRepository
    {
        List<Note> GetNotes();
    }
}
