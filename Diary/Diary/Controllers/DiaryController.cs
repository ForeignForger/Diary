using System.Web.Mvc;

namespace DiaryMVC.Controllers
{
    public class DiaryController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}