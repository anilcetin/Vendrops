using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class VendropsContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID =postgres;Password=12345;Server=localhost;Port=5432;Database=VendropsDb; Integrated Security = true; Pooling = true; ");
        }

        public DbSet<User> users { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
}
