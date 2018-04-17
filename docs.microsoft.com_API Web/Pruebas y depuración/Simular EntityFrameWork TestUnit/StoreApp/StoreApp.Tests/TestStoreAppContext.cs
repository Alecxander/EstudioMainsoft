using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApp.Models;

namespace StoreApp.Tests
{
    class TestStoreAppContext : IStoreAppContext
    {
        public TestStoreAppContext()
        {
            this.Products = new TestProductDbSet();
        }
        public DbSet<Product> Products { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void Dispose()
        {
            
        }

        public void MarkAsModified(Product item)
        {
            
        }
    }
}
