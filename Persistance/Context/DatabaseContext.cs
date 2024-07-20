using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Context;
using Store.Domain.Entities.Product;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistance.Context
{
    public class DatabaseContext : DbContext, IDataBaseContext
    {
        public DatabaseContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>().HasData
                (new Roles() { Id = 1, Name = "Admin" },
                new Roles() { Id = 2, Name = "Operator" },
                new Roles() { Id = 3, Name = "Customer" }
                );


            modelBuilder.Entity<Users>().HasQueryFilter(p => !p.IsRemoved);

        }
    }
}
