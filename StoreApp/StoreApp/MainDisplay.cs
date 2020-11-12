using System;
using System.Linq.Expressions;
using System.Threading;
using StoreLibrary;

namespace StoreApp
{
    class MainDisplay
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");
            MainDisplay display = new MainDisplay();
            display.Display();
        }

        public void Display()
        {
            Console.WriteLine("1. Customer or 2. Store Manager");
            string pick;
            pick = Console.ReadLine();
            bool shopMore = true;
            do
            {
                switch (pick)
                {
                    case "1":
                        CustomerDisplay customerDisplay = new CustomerDisplay();
                        Console.WriteLine("Customer's POV");
                        customerDisplay.CustomerChoice();
                        break;

                    case "2":
                        OwnerDisplay ownerDisplay = new OwnerDisplay();
                        Console.WriteLine("Owner's POV");
                        ownerDisplay.OwnersChoice();
                        
                        break;

                    default:
                        Console.WriteLine("GoodBye!");
                        break;

                }
                string choice;
                Console.WriteLine("\n\nDo you want to shop more? Press \"1\" for Yes or \"0\" For No");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    shopMore = true;
                    Console.Clear();
                }
                else if (choice == "2")
                {
                    shopMore = false;

                }
                else
                {
                    Console.WriteLine("Bye!");
                    shopMore = false;
                }
            } while (shopMore);
        }
    }
}
