using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpRestaurant.Models;

namespace SpRestaurant.Hardware
{
    public interface IMachine
    {
        internal interface IMachine
        {
            void Print(Receipt item);
            void Fax(Receipt item);
            void Scan(Receipt item);
        }
    }
}
