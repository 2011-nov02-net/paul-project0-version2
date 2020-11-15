using StoreLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp
{
    class OwnerDisplay
    {
        public void OwnersChoice()
        {
            while (true)
            {
                string ownerChoice;
                Console.WriteLine("\nWelcome Owner" +
                                "\n1. Register" +
                                "\n2. Add or Remove Product" +
                                "\n3. Show Customer" +
                                "\n4. Show Transaction History" +
                                "\n5. Search Customer by Name" +
                                "\n6. Show Inventory" +
                                "\n(Press 'q' key to Exit)\n") ;
                Console.Write("\nSelect the right option you want: ");
                ownerChoice = Console.ReadLine();
                Owner owner = new Owner();
                if (ownerChoice == "1")
                {

                    owner.Register();

                }

                else if (ownerChoice == "2")
                {
                    var input = Console.ReadLine();
                    Console.WriteLine(" 1. Add or 2. Remove");
                    switch(input)
                    {
                        case "1":
                             owner.AddProduct();
                             Console.WriteLine("Product Added");
                             break;

                        case "2":
                            owner.RemoveProduct();
                            Console.WriteLine("Product Removed");
                            break;
                    }
                }

                else if (ownerChoice == "3")
                {
                    owner.DisplayCustomer();
                    
                }

                else if (ownerChoice == "4")
                {
                    owner.DisplayTransaction();

                }

                else if (ownerChoice == "5")
                {
                    owner.SearchCustomer();
                }

                else if (ownerChoice == "6")
                {
                    owner.DisplayInventory();
                }

                else if (ownerChoice == "q")
                {
                    Console.WriteLine("\nHit any key and GoodBye!\n");
                    break;
                }
            }
        }
    }
}
