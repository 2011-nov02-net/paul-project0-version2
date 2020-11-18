using StoreLibrary;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace StoreApp
{
    public class Displays
    {
        public static Connection connection = new Connection();

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
               
                if (customerChoice == "1")
                {

                    Console.Clear();
                    Console.WriteLine("Please enter your first name");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Please enter your last name");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Customer Added");
                    connection.AddCustomer(firstName, lastName);
                    continue;
                    

                }

                else if (customerChoice == "2")
                {
                    Console.Clear();

                    
                }

                else if (customerChoice == "3")
                {
                    //customer.AddItem();
                    

                }

                else if (customerChoice == "4")
                {
                    //customer.RemoveItem();
                    

                }

                else if (customerChoice == "5")
                {
                    //customer.DisplayOrders();
                   

                }

                else if (customerChoice == "6")
                {
                    //customer.CheckOut();
                   

                }

                else if (customerChoice == "q")
                {
                    Console.WriteLine("\nHit any key and GoodBye!\n");
                    break;

                }
            }
        }

        public void OwnersChoice()
        {

            while (true)
            {
                string ownerChoice;
                Console.WriteLine("\nWelcome Owner" +
                                "\n1. Register" +
                                "\n2. Add or Remove Product" +
                                "\n3. Show all Customers" +
                                "\n4. Show Transaction History" +
                                "\n5. Search Customer by Name" +
                                "\n6. Show Inventory" +
                                "\n(Press 'q' key to Exit)\n");
                Console.Write("\nSelect the right option you want: ");
                ownerChoice = Console.ReadLine();

                if (ownerChoice == "1")
                {

                    // owner.Register();

                }

                else if (ownerChoice == "2")
                {
                    var input = Console.ReadLine();
                    Console.WriteLine(" 1. Add or 2. Remove");
                    switch (input)
                    {
                        case "1":
                            //owner.AddProduct();
                            Console.WriteLine("Product Added");
                            break;

                        case "2":
                            // owner.RemoveProduct();
                            Console.WriteLine("Product Removed");
                            break;
                    }
                }

                else if (ownerChoice == "3")
                {

                    Console.Clear();
                    var customers = connection.GetAllCustomers();

                    foreach (var c in customers)
                    {
                        Console.WriteLine("First Name\t|Last Name\t | Customer ID");
                        Console.WriteLine($"{c.FirstName,16}|{c.LastName,16}| {c.Id}");
                        Console.WriteLine("----------------------------------------------");
                    }

                }



                else if (ownerChoice == "4")
                {
                    // owner.DisplayTransaction();

                }

                else if (ownerChoice == "5")
                {
                    // owner.SearchCustomer();
                }

                else if (ownerChoice == "6")
                {
                    //owner.DisplayInventory();
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
