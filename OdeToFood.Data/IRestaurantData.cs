using System;
using System.Collections.Generic;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantByName(string name);
        Restaurant GetRestaurantById(int Id);
        Restaurant AddRestaurant(Restaurant newRestaurant);
        Restaurant Update(Restaurant updatedRestaurant);
        public Restaurant Delete(int id);
        int Commit();
        int GetRestaurantsCount();
    }
}
