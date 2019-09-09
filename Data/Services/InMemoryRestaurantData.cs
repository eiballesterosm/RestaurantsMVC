using Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id=1, Name="Crepes and Waffles",Cuisine = CuisineType.None},
                new Restaurant{Id=2, Name="Pizza Hut",Cuisine = CuisineType.Italian},
                new Restaurant{Id=3, Name="Paris Restaurant",Cuisine = CuisineType.French}
            };
        }

        public void Add(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }

        public Restaurant GetById(int id)
        {
            return restaurants.Find(r => r.Id.Equals(id));
        }

        public void Update(Restaurant restaurant)
        {
            var existing = GetById(restaurant.Id);
            if (existing != null)
            {
                existing.Name = restaurant.Name;
                existing.Cuisine = restaurant.Cuisine;
            }
        }
    }
}
