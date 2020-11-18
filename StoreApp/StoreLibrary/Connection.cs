using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;




namespace StoreLibrary
{
    public class Connection
    {
        static DbContextOptions<project0Context> s_dbContextOptions ;

        public OwnerRepo Owner { get; set; }

        public CustomerRepo Customers;
        public OrderRepo Orders { get; set; }

        public Customer CurrentCustomer { get; set; } = null;
        public Store CurrentLocation { get; set; } = null;
        public List<OrderItem> SalesList { get; set; } = new List<OrderItem>();



        public Connection()
        {
            using var logStream = new StreamWriter("ef-logs.txt");
            var optionsBuilder = new DbContextOptionsBuilder<project0Context>();
            optionsBuilder.UseSqlServer(GetConnectionString());
            optionsBuilder.LogTo(logStream.WriteLine, LogLevel.Information);
            s_dbContextOptions = optionsBuilder.Options;

            Owner = new OwnerRepo(s_dbContextOptions);
            Customers = new CustomerRepo(s_dbContextOptions);
            Orders = new OrderRepo(s_dbContextOptions);
        }

        public void AddCustomer(string firstName, string lastName)
        {
            Customers.AddCustomer(firstName, lastName);
        }

        public List<Customer> GetAllCustomers()
        {
            return new List<Customer>(Customers.GetCustomers());
        }

        public void SetCurrentCustomer(int id) => CurrentCustomer = Customers.SearchCustomer(id);

        public string ShowCurrentCustomer() => CurrentCustomer?.ToString() ?? "No Customer Currently Selected";

        public Customer GetCustomer(int id) => Customers.SearchCustomer(id);



        public void AddStore(string name) => Owner.AddStore(name);

        public List<Store> GetAllStore() => new List<Store>(Owner.GetAllStore());

        public void AddLocation(string name) => Owner.AddLocation(name);

        public List<Location> GetAllLocations() => new List<Location>(Owner.GetAllLocations());

        public void SetCurrentLocation(int id) => CurrentLocation = Owner.GetStore(id);

        public string ShowCurrentLocation() => CurrentLocation?.ToString() ?? "No Location Currently Selected";


        public ICollection<Inventory> GetStoreInventory() => Owner.GetStoreInventory(CurrentLocation);

        public bool AddStoreInventory(int productId, int stock) => Owner.AddStoreInventory(CurrentLocation, productId, stock);

        public bool AddStoreInventory(Product product, int stock) => Owner.AddStoreInventory(CurrentLocation, product, stock);

        public bool AddStoreNewInventory(string name, string status, decimal price, int stock)
        {
            CreateProduct(name, status, price, stock);
            var product = Owner.GetProduct(name);
            return Owner.AddStoreInventory(CurrentLocation, product, stock);
        }
        public bool IsProduct(string name) => Owner.IsProduct(name);

        public Product GetProduct(string name) => Owner.GetProduct(name);

        public void CreateProduct(string name, string status, decimal price, int stock) => Owner.AddProduct(name, status, price, stock);

        public List<Order> AllOrders => Orders.GetAllOrders();

        public List<Order> AllOrdersByCustomer => Orders.GetAllOrdersByCustomer(CurrentCustomer.Id);

        public List<Order> AllOrdersByLocation => Orders.GetAllOrdersByCustomer(CurrentLocation.Id);

        public decimal GetOrderTotal(int orderId) => Orders.GetOrderTotal(orderId);

        public void AddOrder()
        {
            Orders.AddOrder(CurrentCustomer, CurrentLocation, SalesList);
            // clear out the sales list
            SalesList = new List<OrderItem>();
        }

        public Order GetOrder(int orderId) => Orders.GetOrder(orderId);

        public void AddSaleToOrder(OrderItem sale) => SalesList.Add(sale);

        public List<OrderItem> GetCurrentOrderSales() => new List<OrderItem>(SalesList);

        public static string GetConnectionString()
        {
            string path = "C:/Users/aj/Desktop/GetConnectionString.json";
            string json;
            try
            {
                json = File.ReadAllText(path);

            }
            catch (IOException)
            {
                Console.WriteLine($"required file {path} not found, should just be the connection string in qoutes.");
                throw;
            }
            string connectionString = JsonSerializer.Deserialize<string>(json);
            return connectionString;

        }

    }
}
