using System;
using System.IO;
using System.Linq.Expressions;
using System.Text.Json;
using System.Threading;
using EntityFramework.Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StoreLibrary;

namespace StoreApp
{
    class MainDisplay
    {
        static DbContextOptions<project0Context> s_dbContextOptions;

        static void Main(string[] args)
        {
            using var logStream = new StreamWriter("ef-logs.txt");
            var optionsBuilder = new DbContextOptionsBuilder<project0Context>();
            optionsBuilder.UseSqlServer(GetConnectionString());
            optionsBuilder.LogTo(logStream.WriteLine, LogLevel.Information);
            s_dbContextOptions = optionsBuilder.Options;

            Console.WriteLine("Welcome!");
            MainDisplay display = new MainDisplay();
            display.Display();

        }

        static string GetConnectionString()
        {
            string path = "C:/Users/aj/Desktop/GetConnectionString.json";
            string json;
            try
            {
                json = File.ReadAllText(path);

            }
            catch(IOException)
            {
                Console.WriteLine($"required file {path} not found, should just be the connection string in qoutes.");
                throw;
            }
            string connectionString = JsonSerializer.Deserialize<string>(json);
            return connectionString;

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
