using System;
using System.Collections.Generic;

#nullable disable

namespace Model
{
    public partial class Store
    {
        public Store()
        {
            Inventories = new HashSet<Inventory>();
            Products = new HashSet<Product>();
        }

        public Store(string storeName, int id, Location location, ICollection<Inventory> inventories, ICollection<Product> products)
        {
            StoreName = storeName;
            Id = id;
            Location = location;
            Inventories = inventories;
            Products = products;
        }

        public int Id { get; set; }
        public int? LocationId { get; set; }
        public string StoreName { get; set; }
        public byte[] CreatedAt { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
