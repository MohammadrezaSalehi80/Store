using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities.Cart;
using Store.Domain.Entities.HomePage;
using Store.Domain.Entities.Product;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Application.Interfaces.Context
{
    public interface IDataBaseContext
    {
        DbSet<Users> Users { get; set; }
        DbSet<Roles> Roles { get; set; }
        DbSet<UserRoles> UserRoles { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductFeature> ProductFeatures { get; set; }
        DbSet<ProductImage> ProductImages { get; set; }
        DbSet<Slider> sliders { get; set; }
        DbSet<Cart> Carts { get; set; }
        DbSet<CartItem> CartItems { get; set; }


        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default(CancellationToken));

        public int SaveChanges(bool acceptAllChangesOnSuccess);

        public int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken
            = default(CancellationToken));

    }
}
