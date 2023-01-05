using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpRestaurant.Models;

namespace SpRestaurant.Hardware
{
    public class HpPrinter : IMachine
    {
        public void Print(Receipt receipt)
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
