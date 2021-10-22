using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class SodaMachine
    {
        List<Coin> register;
        List<Can> inventory;

        public SodaMachine()
        {
            FillInventory();
            FillRegister();
        }

        public void FillRegister()
        {
            for (int x = 0; x < 49; x++)
            {
                if (x < 20)
                {
                    register.Add(new Quarter());
                    register.Add(new Nickle());
                }
                if (x < 10)
                {
                    register.Add(new Dime());
                }
                register.Add(new Penny());
            }
        }
        public void FillInventory()
        {
            for (int x = 0; x < 10; x++)
            {
                inventory.Add(new RootBeer());
                inventory.Add(new Cola());
                inventory.Add(new Orange());
            }
        }
    }
}
