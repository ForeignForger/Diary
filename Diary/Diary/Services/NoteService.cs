using DiaryDAL.Entities;
using DiaryDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiaryMVC.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }
        public List<Note> GetNotes()
        {
            var notes = _noteRepository.GetNotes();
            return notes;
        }

    }
}