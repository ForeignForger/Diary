using Autofac;
using Autofac.Integration.Mvc;
using DiaryMVC.IoC.Modules;
using System.Web.Mvc;

namespace DiaryMVC.IoC
{
    public class AutofacInitializer
    {
        public void Initialize() 
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new DalModule());
            builder.RegisterModule(new MvcModule());

            var container = builder.Build();
            var autofacDependencyResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(autofacDependencyResolver);
        } 
    }
}