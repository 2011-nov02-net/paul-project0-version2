using System;
using System.Collections.Generic;

#nullable disable

namespace Model
{
    public partial class OrderItem
    {
        public int _Quantity;

        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public int Quantities { get; set; }

        public int Quantity
        {
            get { return _Quantity; }
            set
            {
                if (value > 0)
                    _Quantity = value;
                else
                    throw new ArgumentOutOfRangeException("SaleQuantity", "Sale Quantity must be greater than zero");
            }
        }
        
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

        public OrderItem(int productId, int quantity)
        {
            this.ProductId = productId;
            this.Quantity = quantity;
        }

        public OrderItem(int id, string name, decimal price, int quantity)
        {
            this.ProductId = id;
            this.ProductName = name;
            this.Price = price;
            this.Quantities = quantity;
        }

        public OrderItem()
        {
        }
    }
}
