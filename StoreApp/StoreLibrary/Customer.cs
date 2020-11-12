using System;
using System.Collections.Generic;
using System.Text;


namespace StoreLibrary
{
	/// <summary>
	/// Here Customer should register first before he/she can do something.
	/// Customer can add and remove item, display items inside the cart and checkout.
	/// </summary>
	public class Customer
	{
		string Name;
		int ID;
		private int customersID = 1;
		public Customer(string name)
        {
			this.Name = name;
			this.ID = customersID++;
		}
		public void AddCustomer()
		{

			List<Customer> customer = new List<Customer>();
			Console.WriteLine("Enter Full Name: ");
			string name = Console.ReadLine();
			customer.Add(new Customer(name));
			Console.WriteLine("Customer Added");
		}

		public void AddItem()
        {

        }

		public void RemoveItem()
        {

        }

		public void DisplayCart()
        {

        }

		public void CheckOut()
        {

        }


	}
}
