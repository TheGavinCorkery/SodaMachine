using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Customer
    {
        public Wallet wallet = new Wallet();
        public Backpack backpack = new Backpack();

        public List<Coin> GatherCoinsFromWallet(Can can)
        {
            bool willProceed = true;
            List<Coin> customerPayment = new List<Coin>();
            UserInterface.OutputText("Continue to add coins until you are ready to inser them into the machine");
            while (willProceed == true)
            {
                UserInterface.DisplayCanCost(can);
                UserInterface.DisplayPaymentValue(customerPayment);
                int coinInt = UserInterface.CoinSelection();
                string coinName = "";
                switch (coinInt)
                {
                    case 1:
                        coinName = "quarter";
                        break;
                    case 2:
                        coinName = "dime";
                        break;
                    case 3:
                        coinName = "nickle";
                        break;
                    case 4:
                        coinName = "penny";
                        break;
                    case 5:
                        coinName = "Done";
                        break;
                }
                if (coinName == "Done")
                {
                    break;
                }
                Coin paymentCoin = GetCoinFromWallet(coinName);
                if (paymentCoin != null)
                {
                    customerPayment.Add(paymentCoin);
                }else
                {
                    UserInterface.OutputText("You do not have any of these coins, try again");
                }
            }
            return customerPayment;
        }
        public Coin GetCoinFromWallet(string coinName)
        {
            foreach(var coin in wallet.Coins)
            {
                if(coinName == coin.Name)
                {
                    wallet.Coins.Remove(coin);
                    wallet.totalValue -= coin.Value;
                    return coin;
                }
            }
            return null;
        }
        public void AddCoinsIntoWallet(List<Coin> coins)
        {
           foreach(var coin in coins)
            {
                wallet.Coins.Add(coin);
                wallet.totalValue += coin.Value;
            } 
        }
        public void AddCanToBackPack(Can can)
        {
            backpack.cans.Add(can);
        }

        public void CheckCoinsInWallet()
        {
            Console.WriteLine($"You have ${wallet.totalValue} remaining.");
        }

        public void CheckCansInBackpack()
        {
            if (backpack.cans.Count <= 0)
            {
                Console.WriteLine("You have no cans in your backpack.");
            }
            else
            {
                foreach(var can in backpack.cans)
                {
                    Console.WriteLine(can.Name);
                }
            }
        }
    }
}
