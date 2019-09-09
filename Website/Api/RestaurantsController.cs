using Data.Models;
using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Website.Api
{
    public class RestaurantsController : ApiController
    {
        private readonly IRestaurantData db;
        public RestaurantsController(IRestaurantData pdb)
        {
            db = pdb;
        }

        public IEnumerable<Restaurant> Get()
        {
            List<Restaurant> restaurants = db.GetAll().ToList();
            return restaurants;
        }
    }
}
