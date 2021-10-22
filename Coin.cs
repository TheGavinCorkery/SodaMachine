using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    public abstract class Coin
    {
        public string Name;
        public double Value;

        
        public Coin(string name, double value)
        {
            this.Name = name;
            this.Value = 0.0;
        }
    }
}
