using System;
using System.Collections.Generic;

#nullable disable

namespace Model
{
    public partial class Product
    {
        private Product product;
        private int? productId;
        private int stock;
        private int? storeId;

        public Product()
        {
            Inventories = new HashSet<Inventory>();
        }

        public Product(string name, int id, decimal? price, string status)
        {
            Name = name;
            Id = id;
            Price = price;
            Status = status;
        }

        public Product(Product product, int? productId, int stock, Store store, int? storeId)
        {
            this.product = product;
            this.productId = productId;
            this.stock = stock;
            Store = store;
            this.storeId = storeId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int StoreId { get; set; }
        public decimal? Price { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Store Store { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public int Stock { get; set; }
    }
}
