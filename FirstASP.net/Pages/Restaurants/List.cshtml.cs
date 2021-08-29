using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.net.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public string MyPropString { get; private set; }
        public IEnumerable<Restaurant> Restaurants { get; private set; }

        [BindProperty(SupportsGet = true)] public string SearchTerm { get; set; }

        private readonly IConfiguration configuration;
        private readonly IRestaurantData restaurantData;

        public ListModel(IConfiguration configuration, IRestaurantData restaurantData)
        {
            this.configuration = configuration;
            this.restaurantData = restaurantData;
        }

        public void OnGet()
        {
            MyPropString = configuration["Message"];

            Restaurants = restaurantData.GetRestaurantByName(SearchTerm);
       
        }
    }
}
