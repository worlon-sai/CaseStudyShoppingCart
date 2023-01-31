using CaseStudy_19_1_23_.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CaseStudy_19_1_23_.Context
{
    public class Cases_Context : DbContext
    {
        public Cases_Context():base("name=CaseStudy") {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Category> categories { get; set; }
        public DbSet<SubCategory> subcategories { get; set; }
        public DbSet<Products> products { get; set; }



        public DbSet<Order> orders { get; set; }



        public DbSet<Cart> carts { get; set; }

        public DbSet<WishList> wishlist { get; set; }

        public DbSet<Ordered> ordered { get; set; }



    }
}