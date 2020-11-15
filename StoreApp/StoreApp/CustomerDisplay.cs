using StoreLibrary;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace StoreApp
{
    class CustomerDisplay
    {
        public void CustomerChoice()
        {
            while (true)
            {
                string customerChoice;
                Console.WriteLine("\nWelcome Shopper" +
                                "\n1. Register" +
                                "\n2. Display Stores" +
                                "\n3. Add Item" +
                                "\n4. Remove Item" +
                                "\n5. Display Orders" +
                                "\n6. Checkout" +
                                "\n(Press any 'q' to Exit )\n");
                Console.Write("\nSelect the right option you want: ");
                customerChoice = Console.ReadLine();
                Customer customer = new Customer();
                if (customerChoice == "1")
                {

                    customer.AddCustomer();
                    

                }

                else if (customerChoice == "2")
                {
                    customer.DisplayStores();
                    
                }

                else if (customerChoice == "3")
                {
                    customer.AddItem();
                    

                }

                else if (customerChoice == "4")
                {
                    customer.RemoveItem();
                    

                }

                else if (customerChoice == "5")
                {
                    customer.DisplayOrders();
                   

                }

                else if (customerChoice == "6")
                {
                    customer.CheckOut();
                   

                }

                else if (customerChoice == "q")
                {
                    Console.WriteLine("\nHit any key and GoodBye!\n");
                    break;

                }
            }
        }
    }
}
