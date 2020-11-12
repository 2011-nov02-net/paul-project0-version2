using System;
using System.Collections.Generic;
using System.Text;


namespace StoreLibrary
{
    public class Owner : IProducts
    {
        //Fields
        internal string StoreID { get; }

        internal string Name { get; set; }

        private Dictionary<Items, int> inventory;

        private Dictionary<Items, int> Inventory { get => inventory; set => inventory = value; }

        internal static int storeID = 1;

        //Constructor
        public Owner(string name)
        {
            this.Name = name;
            this.StoreID = storeID.ToString();
            storeID++;
        }

        public void SearchCustomer(string name)
        {
            //search customer by name
        }

        public void AddProduct()
        {
            throw new NotImplementedException();
        }

        public void SellProduct()
        {
            throw new NotImplementedException();
        }

    }




}