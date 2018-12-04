using DataRelation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DataRelation.DAL
{
    public class OrderContext : DbContext
    {
        public DbSet<Material> materials { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<User> Users { get; set; }

    }
}