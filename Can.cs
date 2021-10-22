using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    public abstract class Can
    {
        double Price;
        string Name;

        public Can(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}
