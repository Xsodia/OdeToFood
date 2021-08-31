using System.Linq;
using System.Collections.Generic;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Boogey's land", Cuisine = CuisineType.Italian, Location = "Morocco"},
                new Restaurant {Id = 2, Name = "Boogey's Nihao", Cuisine = CuisineType.Asian, Location = "Morocco"},
                new Restaurant {Id = 3, Name = "Boogey's Escobar", Cuisine = CuisineType.Mexican, Location = "USA"}
            };
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant GetRestaurantById(int Id)
        {
            return restaurants.SingleOrDefault(r => r.Id == Id);
        }

        public Restaurant AddRestaurant(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            
            Restaurant restaurant = GetRestaurantById(updatedRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            Restaurant restaurant = GetRestaurantById(id);
            if(restaurant != null)
            {
                restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public int GetRestaurantsCount()
        {
            return restaurants.Count();
        }
    }
}
