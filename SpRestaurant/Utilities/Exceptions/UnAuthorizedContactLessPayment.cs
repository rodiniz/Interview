namespace SpRestaurant.Utilities.Exceptions
{
    internal class UnAuthorizedContactLessPayment : OrderException
    {
        public UnAuthorizedContactLessPayment(string message)
            : base (message)
        {
        }
    }
}