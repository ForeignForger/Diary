using DiaryDAL.Entities;
using DiaryDAL.Strategies.InitializationStrategies;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DiaryDAL.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly DiaryDbContext _context;

        public NoteRepository(DiaryDbContext context)
        {
            _context = context;
        }

        List<Note> INoteRepository.GetNotes()
        {
            var notes = _context.Notes.ToList();

            return notes;
        }
    }
}
