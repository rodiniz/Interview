using System;

namespace SpRestaurant.Models.MenuItems
{
    public class Drink : MenuItem
    {
        public override void GetIngredients()
        {
            throw new NotImplementedException();
        }

        public override void Cook()
        {
            throw new NotImplementedException();
        }

        public override void SendToClient()
        {
            // Sending a new coca-cola to client.
        }
    }
}
