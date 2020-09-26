using System.Collections.Generic;
using DiaryDAL.Entities;
using DiaryDAL.Repositories;

namespace DiaryMVC.Services
{
    public interface INoteService
    {
        List<Note> GetNotes();
    }
}