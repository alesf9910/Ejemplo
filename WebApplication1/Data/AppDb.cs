using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace WebApplication1.Data
{
    public class AppDb : IdentityDbContext<User>
    {
        public DbSet<Store> Stores { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<StoreProduct> StoreProducts { get; set; }

        public AppDb(DbContextOptions<AppDb> options): base(options) { 
        
        }
    }
}
