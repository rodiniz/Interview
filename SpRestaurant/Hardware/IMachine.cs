using SpRestaurant.Models;

namespace SpRestaurant.Hardware
{
    public interface IMachine
    {
        void Print(Receipt item);
        void Fax(Receipt item);
        void Scan(Receipt item);

    }
}
