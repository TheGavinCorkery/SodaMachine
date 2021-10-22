using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Wallet
    {
        public List<Coin> Coins;
        public double totalValue;

        public Wallet()
        {
            FillWallet();
        }

        public void FillWallet()
        {
            int quartersNeeded = 9;
            int dimesNeeded = 15;
            int nicklesNeeded = 20;
            int pennyNeeded = 25;

            for (int i = 0; i < pennyNeeded; i++)
            {
                if(i < quartersNeeded)
                {
                    Coins.Add(new Quarter());
                    totalValue += .25;
                }
                if (i < dimesNeeded)
                {
                    Coins.Add(new Dime());
                    totalValue += .10;
                }
                if (i < nicklesNeeded)
                {
                    Coins.Add(new Nickle());
                    totalValue += .05;
                }
                Coins.Add(new Penny());
                totalValue += .01;
            }
        }
    }
}
