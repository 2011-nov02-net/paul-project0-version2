using System;
using System.Collections.Generic;
using System.Text;


namespace StoreLibrary
{
	/// <summary>
	/// Summary description for Transaction
	/// </summary>
	public class Transaction
	{
		//Fields
		internal decimal Price { get; }

		internal DateTime Date { get; }

		internal string Product { get; }

		internal string ProductID { get; }



		//Constructor
		public Transaction(string itemName, string itemID, decimal price, DateTime date)
		{

			this.Product = itemName;
			this.ProductID = itemID;
			this.Price = price;
			this.Date = date;

		}
	}
}