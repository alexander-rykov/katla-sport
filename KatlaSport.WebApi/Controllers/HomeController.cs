using System.Web.Mvc;

namespace KatlaSport.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return Redirect("swagger/ui/index");
        }
    }
}
