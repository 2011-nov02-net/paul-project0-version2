using System;
using System.Collections.Generic;
using System.Text;

namespace StoreLibrary
{
    interface ICustomer
    {
        public void AddCustomer();


        public void DisplayStores();

        public void AddItem();

        public void RemoveItem();


        public void DisplayOrders();


        public void CheckOut();
       
    }
}
