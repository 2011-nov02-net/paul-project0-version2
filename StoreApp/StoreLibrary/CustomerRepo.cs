using Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace StoreLibrary
{
    /// <summary>
    /// Here Customer should register first before he/she can do something.
    /// Customer can add and remove item, display items inside the cart, show all stores with products and checkout.
    /// </summary>
    public class CustomerRepo
    {
        public readonly DbContextOptions<project0Context> _dbContext;
        private readonly ICollection<Customer> _customer;
        

        public CustomerRepo(ICollection<Customer> customers)
        {
            _customer = customers ?? throw new ArgumentNullException(nameof(customers));
            
        }

        public CustomerRepo(DbContextOptions<project0Context> s_dbcontextOptions)
        {
            _customer = new List<Customer>();
            _dbContext = s_dbcontextOptions;
        }

        public void AddCustomer(string FirstName, string LastName)
        {
            /*using*/ var context = new project0Context(_dbContext);
            if (FirstName.Length > 0 && LastName.Length > 0)
            {
                Customer customer = new Customer()
                {
                    FirstName = FirstName,
                    LastName = LastName
                };

                context.Add(customer);
                context.SaveChanges();
            }
        }


        public ICollection<Customer> GetCustomers()
        {
            // set up context
            using var context = new project0Context(_dbContext);

            // get all the customer from db
            var dbCustomers = context.Customers.ToList();

            // convert and return to our customer class
            return dbCustomers.Select(c => new Customer(c.FirstName, c.LastName, c.Id, c.Order)).ToList();
        }

        public Customer SearchCustomer(int id )
        {
            using var context = new project0Context(_dbContext);
            var dbCustomer = context.Customers.First(c => c.Id == id);
            return new Customer(dbCustomer.FirstName, dbCustomer.LastName, dbCustomer.Id, dbCustomer.Order) ?? null;
        }
        
    }
}
