

using System.Collections.Generic;
using CoffeeApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeApplication.Context
{
   
        public class CoffeeDbContext : DbContext
        {
            public DbSet<Menu> menus { get; set; }

        public DbSet<App> Apps { get; set; }

        public DbSet<About> Abouts { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Service> services { get; set; }

        public DbSet<Abone> Abones { get; set; }

       
     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-7TSL0VJ\\SQLEXPRESS;Database=CoffeeDb;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }
}
