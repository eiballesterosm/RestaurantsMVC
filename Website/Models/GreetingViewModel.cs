using Data.Models;
using System.Collections.Generic;

namespace Website.Models
{
    public class GreetingViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }
}