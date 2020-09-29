using DiaryDAL.Entities;
using DiaryDAL.Strategies.InitializationStrategies;
using System.Collections.Generic;
using System.Data.Entity;
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

        //TODO move all datacontext settings and creating to separate place, maybe IoC
        private DiaryDbContext CreateContext()
        {
            var context = new DiaryDbContext(_connection);

#if DEBUG
            var initializer = new DiaryDbDebugInitializer();
            Database.SetInitializer<DiaryDbContext>(initializer);
            context.Database.Initialize(false);
#endif
            return context;
        }
    }
}
