using System;
using System.Collections.Generic;

#nullable disable

namespace Model
{
    public partial class Inventory
    {
        private Product prod;

        public Inventory()
        {
        }

        public Inventory(Product prod, int stock)
        {
            this.prod = prod;
            Stock = stock;
        }

        public int Id { get; set; }
        public int? StoreId { get; set; }
        public int? ProductId { get; set; }
        public int Stock { get; set; }

        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
    }
}
