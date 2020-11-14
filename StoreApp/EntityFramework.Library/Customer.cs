using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.Library
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] CreatedAt { get; set; }

        public virtual Order Order { get; set; }
    }
}
