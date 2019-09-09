using Data.Models;
using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData db;
        public RestaurantsController(IRestaurantData pdb)
        {
            db = pdb;
        }

        // GET: Restaurants
        public ActionResult Index()
        {
            return View(db.GetAll());
        }

        public ActionResult Details(int id)
        {
            try
            {
                Restaurant restaurant = db.GetById(id);
                if (restaurant == null)
                {
                    //return new HttpNotFoundResult("Restaurant Not Found");
                    return View("NotFound");
                }

                return View(restaurant);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Restaurant restaurant)
        {
            if (string.IsNullOrEmpty(restaurant.Name))
            {
                ModelState.AddModelError(nameof(restaurant.Name), "The name is requeired");
            }

            if (ModelState.IsValid)
            {
                db.Add(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
                //return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.GetById(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (string.IsNullOrEmpty(restaurant.Name))
            {
                ModelState.AddModelError(nameof(restaurant.Name), "The name is requeired");
            }

            if (ModelState.IsValid)
            {
                db.Update(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }

            return View();
        }
    }
}