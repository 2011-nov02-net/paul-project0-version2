using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.Library
{
    public partial class Product
    {
        public Product()
        {
            Inventories = new HashSet<Inventory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int StoreId { get; set; }
        public decimal? Price { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Store Store { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
