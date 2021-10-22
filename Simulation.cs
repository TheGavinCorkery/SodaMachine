using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Simulation
    {
        public void Simulate()
        {
            Customer customer = new Customer();
            SodaMachine sodaMachine = new SodaMachine();
            bool willProceed = true;
            while(willProceed == true)
            {
                string userOption = UserInterface.SimulationMainMenu();
                if(Int32.Parse(userOption) == 1)
                {
                    sodaMachine.BeginTransaction(customer);
                }
                else if (Int32.Parse(userOption) == 2)
                {
                    customer.CheckCoinsInWallet();
                }
                else if (Int32.Parse(userOption) == 3)
                {
                    customer.CheckCansInBackpack();
                }
                else
                {
                    willProceed = false;
                }

            }
        }
    }
}
