using System.Collections.Generic;

namespace SpRestaurant.Models.MenuItems
{
    public class CheeseBurgerMenu : MenuItem
    {
        private Drink drink;
        private CheeseBurger cheeseBurger;
        private List<MenuItem> cheeseBurgerMenuItems;

        public override void GetIngredients()
        {
            drink = new Drink();
            cheeseBurger  = new CheeseBurger();
            cheeseBurger.GetIngredients();
            cheeseBurgerMenuItems = new List<MenuItem>(2);
        }

        public override void Cook()
        {
            cheeseBurger.Cook();
        }

        public override void SendToClient()
        {
            cheeseBurgerMenuItems.Add(drink);
            cheeseBurgerMenuItems.Add(cheeseBurger);
            // Send menu to customer
        }
    }
}
