using Autofac;
using Autofac.Integration.Mvc;
using DiaryMVC.Services;
using DiaryMVC.Services.Impl;

namespace DiaryMVC.IoC.Modules
{
    public class MvcModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<NoteService>().As<INoteService>();
            builder.RegisterType<MemoService>().As<IMemoService>();
            builder.RegisterType<TaskService>().As<ITaskService>();
            builder.RegisterType<MeetingService>().As<IMeetingService>();
        }
    }
}