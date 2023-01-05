using System;

namespace SpRestaurant.Utilities.Exceptions
{
    public class OrderException : Exception
    {
        public OrderException(string exceptionMessage):
            base(exceptionMessage)
        {
        }

        public OrderException(string exceptionMessage, OrderException innerException) :
    base(exceptionMessage, innerException)
        {
        }
    }
}