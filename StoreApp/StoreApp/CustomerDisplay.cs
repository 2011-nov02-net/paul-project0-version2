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
            
            string customerChoice;
            Console.WriteLine("\nWelcome Shopper" +
                            "\n1. Register" +
                            "\n2. Add Item" +
                            "\n3. Remove item" +
                            "\n4. Display Items" +
                            "\n5. Checkout" +
                            "\n(Press any key to Exit)");
            Console.Write("\nSelect the right option you want:");
            customerChoice = Console.ReadLine();
            var customer = RuntimeHelpers.GetUninitializedObject(typeof(Customer)) as Customer;
            if (customerChoice == "1")
            {

                customer.AddCustomer();
                
            }

            else if (customerChoice == "2")
            {
                customer.AddItem();
                
            }

            else if (customerChoice == "3")
            {
                customer.RemoveItem();

            }

            else if (customerChoice == "4")
            {
                customer.DisplayCart();

            }

            else if (customerChoice == "5")
            {
                customer.CheckOut();

            }

            else
            {
                Console.WriteLine("Hit any key and GoodBye!");
            }

        }
    }
}
