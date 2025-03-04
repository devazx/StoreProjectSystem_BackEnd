using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreProjectSystem_BackEnd.Models;

namespace StoreProjectSystem_BackEnd.Data
{
    public class StorageContext : IdentityDbContext<IdentityUser>
    {
        public StorageContext(DbContextOptions<StorageContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<EndProduct>()
                .HasOne(EndProd => EndProd.UserInputStore)
                .WithMany(user => user.StoredProducts)
                .HasForeignKey(endprod => endprod.UserInputStoreID)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<User> user { get; set; }
        public DbSet<EndProduct> endProduct { get; set; }
    }
}
