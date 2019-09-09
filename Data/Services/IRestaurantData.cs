using Data.Models;
using System.Collections.Generic;

namespace Data.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant GetById(int id);
        void Add(Restaurant restaurant);
        void Update(Restaurant restaurant);
    }
}
