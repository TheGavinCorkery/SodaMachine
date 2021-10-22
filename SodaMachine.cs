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
            CalculateTransaction(customerPayment, selectedSoda, customer);
            UserInterface.OutputText("Transaction Complete");
        }

        private void CalculateTransaction(List<Coin> customerPayment, Can selectedCan, Customer customer)
        {
            double totalPaymentValue = TotalCoinValue(customerPayment);
            if(totalPaymentValue < selectedCan.Price)
            {
                double changeValue = DetermineChange(totalPaymentValue, selectedCan.Price);
                List<Coin>customerChange = GatherChange(changeValue);
                if (customerChange == null)
                {
                    UserInterface.OutputText($"Dispensing {totalPaymentValue} back to customer");
                    customer.AddCoinsIntoWallet(customerPayment);
                    ReturnInventory(selectedCan);
                }
                else
                {
                    DepositCoinsIntoRegister(customerPayment);
                    customer.AddCoinsIntoWallet(customerChange);
                    customer.AddCanToBackPack(selectedCan);
                    UserInterface.EndMessage(selectedCan, changeValue);
                }
            }else if (totalPaymentValue == selectedCan.Price){
                DepositCoinsIntoRegister(customerPayment);
                customer.AddCanToBackPack(selectedCan);
                UserInterface.EndMessage(selectedCan, 0);
            }else
            {
                UserInterface.OutputText("You do not have enough money to purchase this item, returning payment now.");
                customer.AddCoinsIntoWallet(customerPayment);
                ReturnInventory(selectedCan);
            }
        }

        private void ReturnInventory(Can selectedCan)
        {
            inventory.Add(selectedCan);
        }

        private List<Coin> GatherChange(double changeValue)
        {
            List<Coin> changeList = new List<Coin>();
            while(changeValue > 0)
            {
                if (changeValue >= .25 || RegisterHasCoin("quarter"))
                {
                    changeList.Add(GetCoinFromRegister("quarter"));
                    changeValue -= .25;
                }
                else if (changeValue >= .10 || RegisterHasCoin("dime"))
                {
                    changeList.Add(GetCoinFromRegister("dime"));
                    changeValue -= .10;
                }
                else if (changeValue >= .05 || RegisterHasCoin("nickle"))
                {
                    changeList.Add(GetCoinFromRegister("nickle"));
                    changeValue -= .05;
                }
                else if (changeValue >= .01 || RegisterHasCoin("penny"))
                {
                    changeList.Add(GetCoinFromRegister("penny"));
                    changeValue -= .01;
                }else if (changeValue == 0)
                {
                    break;
                }
                else
                {
                    UserInterface.OutputText("Error: Machine does not have enough change to complete transaction");
                    DepositCoinsIntoRegister(changeList);
                    changeList = null;
                }
            }
            return changeList;
        }

        private void DepositCoinsIntoRegister(List<Coin> coins)
        {
            foreach(Coin coin in coins)
            {
                register.Add(coin);
            }
        }

        private Coin GetCoinFromRegister(string coinName)
        {
            foreach(Coin coin in register)
            {
                if(coin.Name == coinName)
                {
                    register.Remove(coin);
                    return coin;
                }
            }
            return null;
        }

        private bool RegisterHasCoin(string coinName)
        {
            foreach(Coin coin in register)
            {
                if (coin.Name == coinName)
                {
                    return true;
                }
            }
            return false;
        }

        private void BeginTransaction(Customer customer)
        {
            bool willProceed = UserInterface.DisplayWelcome();
            if (willProceed == true)
            {
                Transaction(customer);
            }
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
            return Math.Round(paidAmount - cost, 2);
        }
    }
}
