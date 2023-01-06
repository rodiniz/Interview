using SpRestaurant.Models;

namespace SpRestaurant.Hardware
{
    public class HpPrinter : IMachine
    {
        public void Print(Receipt item)
        {
            //Doing some printing            
        }

        public void Fax(Receipt item)
        {
            throw new System.NotImplementedException();
        }

        public void Scan(Receipt item)
        {
            throw new System.NotImplementedException();
        }
    }
}
