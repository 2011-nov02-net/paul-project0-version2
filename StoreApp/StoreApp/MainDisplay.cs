using System;
using System.IO;
using System.Linq.Expressions;
using System.Text.Json;
using System.Threading;
using Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StoreLibrary;


namespace StoreApp
{
    class MainDisplay
    {

        public static Connection connection = new Connection();

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
                        Console.WriteLine("Customer's POV");
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
                                }

                                else if (customerChoice == "2")
                                {
                                    Console.Clear();
                                    connection.GetAllStore();
                                }

                                else if (customerChoice == "3")
                                {
                                    //additem
                                    Console.Clear();
                                    Console.WriteLine("Ordering");
                                    
                                    //add item
                                    

                                }

                                else if (customerChoice == "4")
                                {
                                    //customer.RemoveItem();


                                }

                                else if (customerChoice == "5")
                                {
                                    //show order
                                    Console.Clear();
                                    Console.WriteLine("My Orders");
                                    connection.GetCurrentOrderSales();

                                }

                                else if (customerChoice == "6")
                                {
                                    //customer.CheckOut();
                                    Console.Clear();
                                    connection.AddOrder();
                                    Console.WriteLine("Enter the order id");
                                    int id = Int32.Parse(Console.ReadLine());
                                    connection.GetOrderTotal(id);

                                }

                                else if (customerChoice == "q")
                                {
                                    Console.WriteLine("\nHit any key and GoodBye!\n");
                                    break;

                                }
                            }
                        
                        break;

                    case "2":
                        Console.WriteLine("Owner's POV");
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

                                //Register store
                                Console.Clear();
                                Console.WriteLine("Please enter the name of the store");
                                string StoreName = Console.ReadLine();
                                connection.AddStore(StoreName);
                                Console.WriteLine("Please enter the location name");
                                string LocationName = Console.ReadLine();
                                connection.AddLocation(LocationName);
                                Console.WriteLine("Please Enter the product details");
                                Console.WriteLine("Please Enter the product Name");
                                string name = Console.ReadLine();
                                Console.WriteLine("Please Enter the product status(in stock, out of stock)");
                                string status = Console.ReadLine();
                                Console.WriteLine("Please Enter the product Price");
                                decimal price = Decimal.Parse(Console.ReadLine());
                                Console.WriteLine("Please Enter the number of products");
                                int stock = Int32.Parse(Console.ReadLine());
                                connection.CreateProduct(name, status, price, stock);
                            }

                            else if (ownerChoice == "2")
                            {
                                Console.Clear();
                                
                                Console.WriteLine(" Add Product");
                                
                                        //owner.AddProduct();
                                        Console.WriteLine("Please enter the location name");
                                        string LocationName = Console.ReadLine();
                                        connection.AddLocation(LocationName);
                                        Console.WriteLine("Please Enter the product details");
                                        Console.WriteLine("Please Enter the product Name");
                                        string name = Console.ReadLine();
                                        Console.WriteLine("Please Enter the product status(in stock, out of stock)");
                                        string status = Console.ReadLine();
                                        Console.WriteLine("Please Enter the product Price");
                                        decimal price = Decimal.Parse(Console.ReadLine());
                                        Console.WriteLine("Please Enter the number of products");
                                        int stock = Int32.Parse(Console.ReadLine());
                                        connection.CreateProduct(name, status, price, stock);
                                        Console.WriteLine("Product Added");
                                       

                                   
                                
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
                                Console.Clear();
                                Console.WriteLine("Please enter the order ID");
                                int orderId = Int32.Parse(Console.ReadLine());
                                connection.GetOrderTotal(orderId);

                            }

                            else if (ownerChoice == "5")
                            {
                                // owner.SearchCustomer();
                                Console.Clear();
                                Console.WriteLine("Please enter the customer's id");
                                Console.WriteLine("Searching....");
                                int id = Int32.Parse(Console.ReadLine());
                                connection.GetCustomer(id);
                            }

                            else if (ownerChoice == "6")
                            {
                                //owner.DisplayInventory();
                                Console.Clear();
                                Console.WriteLine("Store's Invetory");
                                connection.GetStoreInventory();
                            }

                            else if (ownerChoice == "q")
                            {
                                Console.WriteLine("\nHit any key and GoodBye!\n");
                                break;
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("\nGoodBye!");
                        break;

                }
                string choice;
                Console.WriteLine("\n\nDo you want to shop more? Press \"1\" for Yes or \"0\" For No: ");
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
