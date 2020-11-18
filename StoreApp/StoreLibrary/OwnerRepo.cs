using Model;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;


namespace StoreLibrary
{
 
    public class OwnerRepo : IProducts
    {
        
        private readonly ICollection<Store> _store;
        public readonly DbContextOptions<project0Context> _dbContext;


        public OwnerRepo(ICollection<Store> store)
        {
            _store = store ?? throw new ArgumentNullException(nameof(store));
        }

        public OwnerRepo(DbContextOptions<project0Context> s_dbContextOptions)
        {
            _store = new List<Store>();
            _dbContext = s_dbContextOptions;
        }

        public void AddStore(string name)
        {
            // get the context of the db
            using var context = new project0Context(_dbContext);

            if (name.Length > 0)
            {
                // create the db model to add
               Store store = new Store() { StoreName = name };

                //add location to context and save
                context.Add(store);
                context.SaveChanges();
            }
        }

        public Store GetStore(int id)
        {
            
            using var context = new project0Context(_dbContext);

            var dbStore = context.Stores.First(s => s.Id == id);

            if (dbStore == null) return null;
            return new Store(dbStore.StoreName, dbStore.Id, dbStore.Location, dbStore.Inventories, dbStore.Products );
        }

        public ICollection<Store> GetAllStore()
        {
            
            using var context = new project0Context(_dbContext);
            var dbStore = context.Stores.ToList();
            return dbStore.Select(s => new Store(s.StoreName, s.Id, s.Location, s.Inventories, s.Products)).ToList();
        }

        public void AddLocation(string name)
        {
            // get the context of the db
            using var context = new project0Context(_dbContext);

            if (name.Length > 0)
            {
                // create the db model to add
                Location location = new Location() { Name = name };

                //add location to context and save
                context.Add(location);
                context.SaveChanges();
            }
        }

        public Location GetLocation(int id)
        {
            // get the context of the db
            using var context = new project0Context(_dbContext);

            // find the location in the db that has said id
            var dbLocation = context.Locations.FirstOrDefault(l => l.Id == id);

            // check for null value
            if (dbLocation == null) return null;

            return new Location(dbLocation.Name, dbLocation.Id);
        }

        public ICollection<Location> GetAllLocations()
        {
            // set up context
            using var context = new project0Context(_dbContext);

            // get all locations from db
            var dbLocations = context.Locations.ToList();

            // convert and return
            return dbLocations.Select(l => new Location(l.Name, l.Id)).ToList();
        }


        public void AddProduct(string name, string status, decimal price, int stock)
        {
            // get the context of the db
            using var context = new project0Context(_dbContext);

            // Create the new product
            var product = new Product()
            {
                Name = name,
                Status = status,
                Price = price,
                Stock = stock,
            };

            // Add to db
            context.Products.Add(product);
            context.SaveChanges();
        }

        public bool IsProduct(string name)
        {
            // get the context of the db
            using var context = new project0Context(_dbContext);
            return context.Products.Any(p => p.Name == name);
        }

        public Product GetProduct(string name)
        {
            // get the context of the db
            using var context = new project0Context(_dbContext);
            return context.Products.FirstOrDefault(p => p.Name == name);
        }


        public Product GetProduct(int id)
        {
            // get the context of the db
            using var context = new project0Context(_dbContext);
            var dbProduct = context.Products.First(p => p.Id == id);

            return new Product(dbProduct.Name, dbProduct.Id, dbProduct.Price, dbProduct.Status);
        }

        public ICollection<Inventory> GetStoreInventory(Store store)
        {
            // set up context
            using var context = new project0Context(_dbContext);

            // get the inventory for each location
            var dbInventory = context.Inventories.Where(s => s.StoreId == store.Id).Include(s => s.Product).ToList();

            // get the products related to each
            var inventory = new List<Inventory>();

            foreach (var item in dbInventory)
            {
                // create our converted product
                Product prod = new Product(item.Product, item.ProductId, item.Stock, item.Store, item.StoreId);

                // create the new inventory
                inventory.Add(new Inventory(prod, item.Stock));
            }

            return inventory;
        }

        public bool AddStoreInventory(Store store, int productId, int stock)
        {
            
            using var context = new project0Context(_dbContext);
            
            var inventory = context.Inventories.First(i => i.StoreId == store.Id && i.ProductId == productId);

            
            try
            {
                
                inventory.Stock += stock;
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }

        public bool AddStoreInventory(Store store, Product product, int stock)
        {
            // set up context
            using var context = new project0Context(_dbContext);

            // make the new inventory
            Inventory inventory = new Inventory()
            {
                StoreId = store.Id,
                Stock = stock,
                ProductId = product.Id
            };

            context.Inventories.Add(inventory);

            // ensure that the save works successfully
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return false;
            }
            return true;
        }

        public void AddStore()
        {
            throw new NotImplementedException();
        }

        public bool AddStoreInventory()
        {
            throw new NotImplementedException();
        }


    }
}