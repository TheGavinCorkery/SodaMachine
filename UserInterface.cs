using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    static class UserInterface
    {
        static void SimulationMainMenu()
        {
            //Main menu prompting user to choose an option
        }

        static void ValidateMainMenu(string userInput)
        {
            //Validation function that checks if 'user_input' argument is an int 1-4.
        }

        static void DisplayCustomerWalletInfo(double totalValue)
        {
            //Display what is remaining in Customer Wallet
        }

        static void DisplayWelcome()
        {
            //Asks user if they would like to make a purchase
        }

        static void OutputText(string text)
        {
            Console.WriteLine(text);
        }

        static void ClearConsole()
        {
            //Clears console
        }

        static void ContinuePrompt(string text)
        {
            //validates a yes or no response
        }

        static void SodaSelection(List<Can> inventory)
        {
            //Displays the inventory of sodas and allows for selection
        }

        static void ValidateCanChoice(string selection)
        {
            //Validates User Can selection
        }

        static void GetUniqueCanNames(List<Can> inventory)
        {
            //Loops through inventory to create a list of all distinct types of sodas available.
        }

        static void DisplayCanCost(Can selectedCan)
        {
            //Displays the cost of the can as the user puts coins in.
        }

        static void DisplayPaymentValue(Coin customerPayment)
        {
            //Displays the value of selected coins as customer is choosing coins to deposit
        }

        static void CoinSelection()
        {
            //Prompts user to choose which coins to deposit and passes their selection in validate_coin_selection
        }

        static void EndMessage(string sodaName, double changeAmount)
        {
            //Closing message for the user.
        }
    }
}
