using System;
using System.Collections.Generic;

#nullable disable

namespace Model
{
    public partial class Customer
    {
        public Customer()
        {
        }

        public Customer(string firstName, string lastName, int id, Order order)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] CreatedAt { get; set; }

        public virtual Order Order { get; set; }
    }
}
