using Microsoft.EntityFrameworkCore;
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

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default(CancellationToken));

        public int SaveChanges(bool acceptAllChangesOnSuccess);

        public int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken
            = default(CancellationToken));

    }
}
