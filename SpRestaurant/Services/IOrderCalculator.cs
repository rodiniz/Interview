using SpRestaurant.Models;

namespace SpRestaurant.Services
{
    public interface IOrderCalculator
    {
        double CalculateTotal(OrderItem item);
    }
}
