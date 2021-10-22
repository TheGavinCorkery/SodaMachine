using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    public static class UserInterface
    {
        public static string SimulationMainMenu()
        {
            //Main menu prompting user to choose an option
            bool invalidUserSelection = true;
            string userInput;
            while (invalidUserSelection)
            {
                Console.WriteLine("Simulation Menu\n"
                                  + "Press -1- to begin transaction\n"
                                  + "Press -2- to check wallet for coins\n"
                                  + "Press -3- to check backpack for cans\n"
                                  + "Press -4- to terminate simulation");
                userInput = Console.ReadLine();
                invalidUserSelection = ValidateMainMenu(userInput);
                if(invalidUserSelection == true)
                {
                    return userInput;
                }
                else
                {
                    Console.WriteLine("Invalid Input Try Again.");
                }
            }
        }

        public static bool ValidateMainMenu(string userInput)
        {
            //Validation function that checks if 'user_input' argument is an int 1-4.
        }

        public static void DisplayCustomerWalletInfo(double totalValue)
        {
            //Display what is remaining in Customer Wallet
        }

        public static void DisplayWelcome()
        {
            //Asks user if they would like to make a purchase
        }

        public static void OutputText(string text)
        {
            Console.WriteLine(text);
        }

        public static void ClearConsole()
        {
            //Clears console
        }

        public static void ContinuePrompt(string text)
        {
            //validates a yes or no response
        }

        public static void SodaSelection(List<Can> inventory)
        {
            //Displays the inventory of sodas and allows for selection
        }

        public static void ValidateCanChoice(string selection)
        {
            //Validates User Can selection
        }

        public static void GetUniqueCanNames(List<Can> inventory)
        {
            //Loops through inventory to create a list of all distinct types of sodas available.
        }

        public static void DisplayCanCost(Can selectedCan)
        {
            //Displays the cost of the can as the user puts coins in.
        }

        public static void DisplayPaymentValue(Coin customerPayment)
        {
            //Displays the value of selected coins as customer is choosing coins to deposit
        }

        public static void CoinSelection()
        {
            //Prompts user to choose which coins to deposit and passes their selection in validate_coin_selection
        }

        public static void EndMessage(string sodaName, double changeAmount)
        {
            //Closing message for the user.
        }
    }
}
