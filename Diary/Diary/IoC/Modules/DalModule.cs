using Autofac;
using DiaryDAL.Entities;
using DiaryDAL.Repositories;
using DiaryDAL.Strategies.InitializationStrategies;
using System.Data.Entity;

namespace DiaryMVC.IoC.Modules
{
    public class DalModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(CreateNoteRepository).As<INoteRepository>();
        }

        private INoteRepository CreateNoteRepository(IComponentContext componentContext)
        {
            var connection = GetConnection();
            //TODO question, is it really okay to create one DbContext for a class? Should be, pretty sure, but hmm...
            var context = new DiaryDbContext(connection);

#if DEBUG
            var initializer = new DiaryDbDebugInitializer();
            Database.SetInitializer<DiaryDbContext>(initializer);
            context.Database.Initialize(false);
#endif
            var noteRepository = new NoteRepository(context);
            return noteRepository;
        }

        private string GetConnection()
        {
            // TODO get from web config
            var connection = "vladSidorovDiaryDb";
            return connection;
        }
    }
}