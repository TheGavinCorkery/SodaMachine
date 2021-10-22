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
        //Main menu prompting user to choose an option
        {
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
                if (invalidUserSelection == true)
                {
                    return userInput;
                }
                else
                {
                    Console.WriteLine("Invalid Input Try Again.");
                }
            }
            return 0;
        }

        public static bool ValidateMainMenu(string userInput)
        //Validation function that checks if 'user_input' argument is an int 1-4.
        {
            switch (userInput)
            {
                case "1":
                    return true;
                case "2":
                    return true;
                case "3":
                    return true;
                case "4":
                    return true;
                default:
                    return false;
            }
        }

        public static void DisplayCustomerWalletInfo(double totalValue)
        {
            //Display what is remaining in Customer Wallet *Currently not needed
        }

        public static bool DisplayWelcome()
        //Asks user if they would like to make a purchase
        {
            Console.WriteLine("\n Welcome to the soda machine. " +
                "We only take coins as payment. \n" +
                "Would you like to make a purchase (y/n) \n");
            string userResponse = Console.ReadLine().ToLower();
            if(userResponse == "yes" || userResponse == "y")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Please step aside to allow another customer to make a selection");
                return false;
            }
        }

        public static void OutputText(string text)
        {
            Console.WriteLine(text);
        }

        public static void ClearConsole()
        {
            Console.Clear();
        }

        public static void ContinuePrompt(string text)
        {
            //validates a yes or no response *Currently Not needed
        }

        public static int SodaSelection(List<Can> inventory)
        //Displays the inventory of sodas and allows for selection
        {
            bool invalidUserSelection = true;
            int userSelectionInt;
            List<Can> sodaOptions = GetUniqueCanNames(inventory);
            while (invalidUserSelection)
            {
                Console.WriteLine("Please choose from the following options:");
                int i = 1;
                foreach (Can can in sodaOptions)
                {
                    Console.WriteLine($"\n \t Enter -{i}- for {can.Name} : ${can.Price}");
                    i++;
                }
                string userSelection = Console.ReadLine();
                userSelectionInt = Int32.Parse(userSelection);
                invalidUserSelection = ValidateCanChoice(userSelectionInt);
                if (invalidUserSelection == true)
                {
                    return userSelectionInt;
                }
                else
                {
                    Console.WriteLine("Invalid Input Try Again.");
                }
            }
            return 0;
        }

        public static bool ValidateCanChoice(int selection)
        //Validates User Can selection
        {
            if (selection > 0 && selection < 5)
            {
                return true;
            }else
            {
                Console.WriteLine("Not a valid selection");
                return false;
            }
        }

        public static List<Can> GetUniqueCanNames(List<Can> inventory)
        //Loops through inventory to create a list of all distinct types of sodas available.
        {
            List<Can> uniqueCans = inventory.Distinct().ToList();
            return uniqueCans;
        }

        public static void DisplayCanCost(Can selectedCan)
        {
            //Displays the cost of the can as the user puts coins in.
            Console.WriteLine($"The price of a {selectedCan.Name} is ${selectedCan.Price}");
        }

        public static void DisplayPaymentValue(List<Coin> customerPayment)
        {
            //Displays the value of selected coins as customer is choosing coins to deposit
            double totalPaymentValue = 0.0;
            foreach (Coin coin in customerPayment)
            {
                totalPaymentValue += coin.Value;
            }
            Console.WriteLine($"You currently have {totalPaymentValue} in hand");
        }

        public static int CoinSelection()
        {
            //Prompts user to choose which coins to deposit and passes their selection in validate_coin_selection
            bool validatedSelection = false;
            while(validatedSelection == false)
            {
                Console.WriteLine("\nEnter -1- for Quarter");
                Console.WriteLine("\nEnter -2- for Dime");
                Console.WriteLine("\nEnter -3- for Nikel");
                Console.WriteLine("\nEnter -4- for Penny");
                Console.WriteLine("\nEnter -5- for when finished depositing payment");
                int userInput = Int32.Parse(Console.ReadLine());
                validatedSelection = ValidateCoinSelection(userInput);
                if(validatedSelection == false)
                {
                    Console.WriteLine("Not a valid selection. Please try again");
                }
                return userInput;
            }
            return 0;
        }

        public static bool ValidateCoinSelection(int input)
        {
            switch (input)
            {
                case 1:
                    return true;
                case 2:
                    return true;
                case 3:
                    return true;
                case 4:
                    return true;
                case 5:
                    return true;
            }
            return false;
        }

        public static void EndMessage(string sodaName, double changeAmount)
        {
            //Closing message for the user.
            Console.WriteLine($"Enjoy your {sodaName}");
            if (changeAmount >= 0)
            {
                Console.WriteLine($"Dispensing your {changeAmount}");
            }
        }
    }
}
