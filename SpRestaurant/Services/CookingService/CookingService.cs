using SpRestaurant.Models;
using SpRestaurant.Models.MenuItems;
using System.Collections.Generic;

namespace SpRestaurant.Services.CookingService
{
    public class CookingService
    {
        private readonly Dictionary<string, MenuItem> _restaurantMenu = new Dictionary<string, MenuItem>
        {
            { Constants.Drink, new Drink()},
            { Constants.CheeseBurger, new CheeseBurger()},
            { Constants.CheeseBurgerMenu, new CheeseBurgerMenu()}
        };

        public void Prepare(Order order)
        {
            foreach (var item in order.Items)
            {
                var menuItem = _restaurantMenu[item.ItemId];
                switch (menuItem)
                {
                    case CheeseBurgerMenu _:
                    case CheeseBurger _:
                        menuItem.GetIngredients();
                        menuItem.Cook();
                        menuItem.SendToClient();
                        break;
                    case Drink _:
                        menuItem.SendToClient();
                        break;
                }
            }
        }
    }
}
