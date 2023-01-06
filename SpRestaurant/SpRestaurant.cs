using SpRestaurant.Hardware;
using SpRestaurant.Models;
using SpRestaurant.Services.CookingService;
using SpRestaurant.Services.PaymentService;
using SpRestaurant.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpRestaurant
{
    public class SpRestaurant
    {
        private readonly IMachine _iMachine;
        private readonly PaymentService _paymentService = new PaymentService();
        private readonly CookingService _cookingService = new CookingService();
        Dictionary<string, Func<OrderItem, double>> dict;

        public SpRestaurant()
        {
            _iMachine = new HpPrinter();
            dict = new Dictionary<string, Func<OrderItem, double>>
            {
                { Constants.CheeseBurger, CalculateCheeseBurgerMenu },
                { Constants.Drink, CalculateDrink },
                { Constants.CheeseBurgerMenu, CalculateCheeseBurger }
            };
        }
        public void ExecuteOrder(Order order,
            PaymentDetails paymentDetails, bool printReceipt)
        {

            CalculateAmount(order);
            _paymentService.Charge(paymentDetails, order);

            _cookingService.Prepare(order);

            if (printReceipt)
            {
                PrintReceipt(order);
            }
        }

        private double CalculateDrink(OrderItem item)
        {
            var setsOfThree = item.Quantity / 3;
            return (item.Quantity - setsOfThree) * item.Price;
        }

        private double CalculateCheeseBurger(OrderItem item)
        {
            return item.Price * item.Quantity;
        }
        private double CalculateCheeseBurgerMenu(OrderItem item)
        {
            return item.Price * item.Quantity * 0.9;
        }

        private void CalculateAmount(Order order)
        {
            //is is ClassDrink , is 
            var total = order.Items.Sum(item => dict[item.ItemId](item));
            order.TotalAmount = total;
        }

        private void PrintReceipt(Order order)
        {
            string customerEmail = order.CustomerEmail;
            if (!string.IsNullOrEmpty(customerEmail))
            {
                var receipt = new Receipt
                {
                    Title = "Receipt for your order placed on " + DateTime.Now,
                    Body = "Your order details: \n "
                };
                foreach (var orderItem in order.Items)
                {
                    receipt.Body += orderItem.Quantity + " of item " + orderItem.ItemId;
                }

                try
                {
                    _iMachine.Print(receipt);
                }
                catch (Exception ex)
                {
                    Logger.Error("Problem sending notification email", ex);
                }

            }
        }
    }
}
