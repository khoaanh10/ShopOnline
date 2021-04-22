using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class MyDB: DbContext
    {
        public MyDB(): base("name=Haha")
        {

        }

       
        public DbSet<ProductT> ProductTs { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresss { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<SaleProduct> SaleProducts { get; set; }
        public DbSet<SellProduct> SellProducts { get; set; }
        public DbSet<SellDate> SellDates { get; set; }

    }
}
