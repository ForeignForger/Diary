using DiaryDAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DiaryDAL.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly string _connection;

        public NoteRepository(string connection)
        {
            _connection = connection;
        }

        List<Note> INoteRepository.GetNotes()
        {
            List<Note> notes;

            using (var context = CreateContext())
            {
                notes = context.Notes.ToList();
            }

            return notes;
        }

        private DiaryDbContext CreateContext()
        {
            var context = new DiaryDbContext(_connection);
            return context;
        }
    }
}
