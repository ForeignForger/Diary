using DiaryMVC.IoC;
using System.Web.Mvc;
using System.Web.Routing;

namespace DiaryMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            InitializeIoc();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private void InitializeIoc()
        {
            var autofacInitializer = new AutofacInitializer();
            autofacInitializer.Initialize();
        }
    }
}
