using DemoCore02.Core;
using System.Collections.Generic;
using System.Linq;

namespace DemoCore02.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Nanka", Location = "San Isidro", Cuisine = CuisineType.Peruvian },
                new Restaurant { Id = 2, Name = "Shogun", Location = "Huancayo", Cuisine = CuisineType.China },
                new Restaurant { Id = 3, Name = "Okami", Location = "Huancayo", Cuisine = CuisineType.China },

            };
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(x => x.Id) + 1;
            return newRestaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(x => x.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetById(int restaurantId)
        {
            return restaurants.FirstOrDefault(x => x.Id == restaurantId);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return restaurants.Where(x => string.IsNullOrEmpty(name) || x.Name.ToLower().Contains(name.ToLower()))
                .OrderBy(x => x.Name).ToList();
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var updatedRestaurant = restaurants.SingleOrDefault(x => x.Id == restaurant.Id);
            if (updatedRestaurant != null)
            {
                updatedRestaurant.Name = restaurant.Name;
                updatedRestaurant.Location = restaurant.Location;
                updatedRestaurant.Cuisine = restaurant.Cuisine;
            }
            return updatedRestaurant;
        }
    }
}
