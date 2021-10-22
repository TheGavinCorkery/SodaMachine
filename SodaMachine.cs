using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class SodaMachine
    {
        List<Coin> register = new List<Coin>();
        List<Can> inventory = new List<Can>();

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

        private void Transaction(Customer customer)
        {
            string selectedSodaName = UserInterface.SodaSelection();
            Can selectedSoda = GetSodaFromInventory(selectedSodaName);
            List<Coin> customerPayment = customer.GatherCoinsFromWallet(selectedSoda);
        }

        private void CalculateTransaction(List<Coin> coins, Can can, Customer customer)
        {
            double canCost = can.Price;
            double coinTotal = TotalCoinValue(coins);
            
            if(customer.wallet.totalValue >= canCost)
            {
                BeginTransaction(customer);
            }else if (customer.wallet.totalValue < canCost){
                Console.WriteLine("Insufficent coins");
            }
        }
        private void BeginTransaction(Customer customer)
        {
            Transaction(customer);
        }

        private Can GetSodaFromInventory(string s)
        {
            Can selectedCan = null;
            foreach (Can can in inventory)
            {if (can.Name == s) { selectedCan = can; inventory.Remove(can); }}
            return selectedCan;
        }

        private double TotalCoinValue(List<Coin> coins)
        {
            double coinTotal = 0.0;
            foreach (Coin coin in coins) { coinTotal += coin.Value; }
            return coinTotal;
        }

        private double DetermineChange(double paidAmount, double cost)
        {
            if (paidAmount == cost){return 0.0;}
            else if (paidAmount > cost)
            {
                double diff = paidAmount - cost;
                return diff;
            }else {return 0.0;}
        }
    }
}
