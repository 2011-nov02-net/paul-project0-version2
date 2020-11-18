using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Model
{
    public partial class Order
    {
        public Order()
        {
        }

        public Order(Customer customer)
        {
        }

        public Order(int customerId, int storeId, DateTime date, int id)
        {
            CustomerId = customerId;
            StoreId = storeId;
            Date = date;
            Id = id;
            
        }

        public Order(int customerId, int storeId, DateTime date, object orderNumber, decimal orderTotal)
        {
            CustomerId = customerId;
            StoreId = storeId;
            Date = date;
            OrderNumber = orderNumber;
            OrderTotal = orderTotal;
        }

        public Order(Customer customer, int customerId, DateTime date, int id, string status, List<OrderItem> orderItem) : this(customer)
        {
        }

        public Order(Customer customer, int customerId, List<OrderItem> items, DateTime date, object orderNumber, decimal orderTotal) : this(customer)
        {
            CustomerId = customerId;
            Items = items;
            Date = date;
            OrderNumber = orderNumber;
            OrderTotal = orderTotal;
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Status { get; set; }
        public byte[] CreatedAt { get; set; }

        public virtual Customer Customer { get; set; }
        public int StoreId { get; set; }
        public DateTime Date { get; set; }
        [NotMapped]
        public List<OrderItem> OrderItem { get; set; }
        public decimal OrderTotal { get; set; }
        [NotMapped]
        public List<OrderItem> Items { get; }
        public object OrderNumber { get; }
    }
}
