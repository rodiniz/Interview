using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpRestaurant.Models;
using SpRestaurant.Utilities;
using SpRestaurant.Utilities.Exceptions;

namespace SpRestaurant.Services.PaymentService
{
    public class PaymentService
    {
        private void AuthorizePayment(double purchaseAmount)
        {
            if (purchaseAmount > 20) throw new UnAuthorizedContactLessPayment("Amount is too big");
            Logger.Info(string.Format("Payment for {0} has been authorized", purchaseAmount));
        }

        private void ChargeCard(PaymentDetails paymentDetails, Order order)
        {
            using (var ccMachine = new CreditCardMachine())
            {
                try
                {
                    ccMachine.CardNumber = paymentDetails.CreditCardNumber;
                    ccMachine.ExpiresMonth = paymentDetails.ExpiresMonth;
                    ccMachine.ExpiresYear = paymentDetails.ExpiresYear;
                    ccMachine.NameOnCard = paymentDetails.CardholderName;
                    ccMachine.AmountToCharge = order.TotalAmount;

                    ccMachine.Charge();
                }
                catch (RejectedCardException ex)
                {
                    throw new OrderException("The card gateway rejected the card.", ex);
                }
            }
        }

        public void Charge(PaymentDetails paymentDetails, Order order)
        {
            if (paymentDetails.PaymentMethod == PaymentMethod.ContactCreditCard)
            {
                ChargeCard(paymentDetails, order);
            }
            else if (paymentDetails.PaymentMethod == PaymentMethod.ContactLessCreditCard)
            {
                AuthorizePayment(order.TotalAmount);
                ChargeCard(paymentDetails, order);
            }
            else
            {
                throw new NotValidPaymentException("Can not charge customer");
            }
        }
    }
}
