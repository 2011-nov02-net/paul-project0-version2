using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.Library
{
    public partial class Location
    {
        public Location()
        {
            Stores = new HashSet<Store>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
    }
}
