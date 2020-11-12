using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp
{
    class OwnerDisplay
    {
        public void OwnersChoice()
        {

            string ownerChoice;
            Console.WriteLine("\nWelcome Owner" +
                            "\n1. Register" +
                            "\n2. Add Product" +
                            "\n3. Show Customer" +
                            "\n4. Show Transaction History" +
                            "\n5 Search Customer by Name" +
                            "\n(Press any key to Exit)");
            Console.Write("\nSelect the right option you want:");
            ownerChoice = Console.ReadLine();
          
            if (ownerChoice == "1")
            {

                

            }

            else if (ownerChoice == "2")
            {
                
            }

            else if (ownerChoice == "3")
            {
                

            }

            else if (ownerChoice == "4")
            {
                

            }

            else if (ownerChoice == "5")
            {
                
            }

            else
            {
                Console.WriteLine("Hit any key and GoodBye!");
            }

        }
    }
}
