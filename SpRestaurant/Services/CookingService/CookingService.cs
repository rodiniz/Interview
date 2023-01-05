using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpRestaurant.Models;
using SpRestaurant.Models.MenuItems;

namespace SpRestaurant.Services.CookingService
{
    public class CookingService
    {
        private readonly Dictionary<string, MenuItem> restaurantMenu = new Dictionary<string, MenuItem>
        {
            { Constants.Drink, new Drink()},
            { Constants.CheeseBurger, new CheeseBurger()},
            { Constants.CheeseBurgerMenu, new CheeseBurgerMenu()}
        };

        public void Prepare(Order order)
        {
            foreach (var item in order.Items)
            {
                var menuItem = restaurantMenu[item.ItemId];
                if (menuItem is CheeseBurgerMenu || menuItem is CheeseBurger)
                {
                    menuItem.GetIngredients();
                    menuItem.Cook();
                    menuItem.SendToClient();

                }
                else if (menuItem is Drink)
                {
                    menuItem.SendToClient();
                }
            }
        }
    }
}
