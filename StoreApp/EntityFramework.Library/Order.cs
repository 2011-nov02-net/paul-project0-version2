using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.Library
{
    public partial class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Status { get; set; }
        public byte[] CreatedAt { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
