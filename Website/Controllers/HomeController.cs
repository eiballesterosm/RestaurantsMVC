using Data.Models;
using Data.Services;
using System.Collections.Generic; 
using System.Web.Mvc;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        IRestaurantData db;
        public HomeController()
        {
            db = new InMemoryRestaurantData();
        }

        public ActionResult Index()
        {   
            IEnumerable<Restaurant> restaurants = db.GetAll();
            //return View(restaurants);
            return View(db.GetAll());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}