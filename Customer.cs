using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Customer
    {
        Wallet wallet = new Wallet();
        Backpack backpack = new Backpack();

        public List<Coin> GatherCoinsFromWallet(Can can)
        {
            return null;
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

        }
    }
}
