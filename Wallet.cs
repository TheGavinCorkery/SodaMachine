﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Wallet
    {
        List<Coin> Coins;
        double totalValue;

        public void FillWallet()
        {
            int quartersNeeded = 9;
            int dimesNeeded = 15;
            int nicklesNeeded = 20;
            int pennyNeeded = 25;

            int[] coinsNeeded = { quartersNeeded, dimesNeeded, nicklesNeeded, pennyNeeded };

            for (int i = 0; i < 25; i++)
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
