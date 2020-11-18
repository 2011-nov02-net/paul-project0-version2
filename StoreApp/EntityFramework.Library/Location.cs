using System;
using System.Collections.Generic;

#nullable disable

namespace Model
{
    public partial class Location
    {
        public Location()
        {
            Stores = new HashSet<Store>();
        }

        public Location(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
    }
}
