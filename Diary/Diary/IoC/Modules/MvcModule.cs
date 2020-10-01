using Autofac;
using Autofac.Integration.Mvc;
using DiaryMVC.Services;

namespace DiaryMVC.IoC.Modules
{
    public class MvcModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<NoteService>().As<INoteService>();
        }
    }
}