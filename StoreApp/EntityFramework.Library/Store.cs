using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.Library
{
    public partial class Store
    {
        public Store()
        {
            Inventories = new HashSet<Inventory>();
            Products = new HashSet<Product>();
            StorePeriods = new HashSet<StorePeriod>();
        }

        public int Id { get; set; }
        public int? LocationId { get; set; }
        public string StoreName { get; set; }
        public byte[] CreatedAt { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<StorePeriod> StorePeriods { get; set; }
    }
}
