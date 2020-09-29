using DiaryDAL.Entities;
using System.Collections.Generic;

namespace DiaryMVC.Services
{
    public interface INoteService
    {
        List<Note> GetNotes();
    }
}
