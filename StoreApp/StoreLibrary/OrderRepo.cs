using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace StoreLibrary
{
   public class OrderRepo
    {
        private readonly DbContextOptions<project0Context> _dbContext;

        public OrderRepo(DbContextOptions<project0Context> contextOptions)
        {
            _dbContext = contextOptions;
        }

        public void AddOrder(Customer customer, Store location, ICollection<OrderItem> items)
        {
            // get the context of the db
            using var context = new project0Context(_dbContext);

            // create list converting from Library.Sale to DatabaseModel.Sale
            var dbItems = new List<OrderItem>();
            decimal orderTotal = 0.0m;

            foreach (var item in items)
            {
                // need the product details
                var dbProduct = context.Products.First(p => p.Id == item.ProductId);
                var dbItem = new OrderItem()
                {
                    ProductId = item.ProductId,
                    ProductName = dbProduct.Name,
                    Price = (decimal)dbProduct.Price,
                    Quantity = item.Quantities,
                };
                // add to the sum of the order total
               orderTotal += item.Quantity * item.Price;

                // add the sale to the running list
                dbItems.Add(dbItem);

                // remove the amount from the inventory of the store
                var locationInventory = context.Inventories.First(i => i.StoreId == location.Id && i.ProductId == item.ProductId);
                locationInventory.Stock -= item.Quantity;
                context.Inventories.Update(locationInventory);
                context.SaveChanges();
            }

            // create the classes
            var order = new Order()
            {
                CustomerId = customer.Id,
                StoreId = location.Id,
                Date = DateTime.Now,
                OrderItem = dbItems
            };

            // calculate total
            order.OrderTotal = orderTotal;
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public List<Order> GetAllOrders()
        {
            // get the context of the db
            using var context = new project0Context(_dbContext);

            var dbOrders = context.Orders.ToList();

            return dbOrders.Select(o => new Order(o.CustomerId, o.StoreId, o.Date, o.OrderNumber, o.OrderTotal)).ToList();
        }

        public List<Order> GetAllOrdersByCustomer(int customerId)
        {
            
            using var context = new project0Context(_dbContext);

            
            var dbCustomerOrders = context.Orders.Where(o => o.CustomerId == customerId).ToList();
            return dbCustomerOrders.Select(o => new Order(o.CustomerId, o.StoreId, o.Date, o.OrderNumber, o.OrderTotal)).ToList();
        }

        public List<Order> GetAllOrdersByStore(int storeID)
        {
            
            using var context = new project0Context(_dbContext);

            
            var dbStoreOrders = context.Orders.Where(o => o.StoreId == storeID).ToList();
            return dbStoreOrders.Select(o => new Order(o.CustomerId, o.StoreId, o.Date, o.OrderNumber, o.OrderTotal)).ToList();
        }


        public decimal GetOrderTotal(int orderId)
        {
            
            using var context = new project0Context(_dbContext);

            var list = context.OrderItems.Where(oi => oi.OrderId == orderId).ToList();

            decimal sum = 0;

            foreach (var item in list)
            {
                sum += item.Price * item.Quantity;
            }

            return sum;
        }

        public Order GetOrder(int orderId)
        {
            
            using var context = new project0Context(_dbContext);

            
            var dbOrder = context.Orders.FirstOrDefault(o => o.Id == orderId);

            
            var dbItems = context.OrderItems.Where(oi => oi.OrderId == orderId).ToList();

            
            var items = new List<OrderItem>();

            foreach (var item in dbItems)
            {
                items.Add(new OrderItem(item.ProductId, item.ProductName, item.Price, item.Quantity));
            }

            return new Order(dbOrder.Customer, dbOrder.CustomerId, items, dbOrder.Date, dbOrder.OrderNumber, dbOrder.OrderTotal);
        }
    }
}
