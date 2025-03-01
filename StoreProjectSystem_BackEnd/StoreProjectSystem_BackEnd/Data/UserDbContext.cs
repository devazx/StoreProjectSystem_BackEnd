using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreProjectSystem_BackEnd.Models;

namespace StoreProjectSystem_BackEnd.Data
{
    public class UserDbContext : IdentityDbContext<IdentityUser>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
        public DbSet<User> user { get; set; }
        public DbSet<EndProduct> endProduct { get; set; }
    }
}
