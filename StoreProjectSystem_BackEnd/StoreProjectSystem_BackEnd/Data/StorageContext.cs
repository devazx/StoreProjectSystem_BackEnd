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
                .HasOne(x => x.UserInputStore)
                .WithMany(y => y.StoredProducts)
                .HasForeignKey(x => x.UserInputStoreID)
                .OnDelete(DeleteBehavior.Restrict);
                
                
        }

        public DbSet<User> user { get; set; }
        public DbSet<EndProduct> endProduct { get; set; }
    }
}
