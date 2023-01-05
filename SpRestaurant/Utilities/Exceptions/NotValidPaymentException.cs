namespace SpRestaurant.Utilities.Exceptions
{
    public class NotValidPaymentException : OrderException
    {
        public NotValidPaymentException(string message)
            :base(message)
        {
        }
    }
}