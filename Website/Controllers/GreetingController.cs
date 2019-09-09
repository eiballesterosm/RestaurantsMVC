using System.Web.Mvc;
using Website.Models;

namespace Website.Controllers
{
    public class GreetingController : Controller
    {
        // GET: Greeting
        public ActionResult Index()
        {
            string name = Request.QueryString["name"];
            GreetingViewModel model = new GreetingViewModel();
            model.Name = name ?? "With out name";
            return View(model);
        }
    }
} 