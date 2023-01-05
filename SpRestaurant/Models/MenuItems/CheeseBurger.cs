using System.Collections.Generic;

namespace SpRestaurant.Models.MenuItems
{
    public class CheeseBurger : MenuItem
    {
        private readonly List<string> ingredients = new List<string>();
        public override void GetIngredients()
        {
            ingredients.Add("Bread");
            ingredients.Add("Ham");
            ingredients.Add("Salad");
            ingredients.Add("Fries");
        }

        public override void Cook()
        {
            // Do some magic
        }

        public override void SendToClient()
        {
            // Send Burger to client
        }
    }
}
