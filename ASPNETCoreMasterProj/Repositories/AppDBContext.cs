using DomainModels;
using DomainModels.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repositories.Data;

namespace Repositories
{
    public class AppDBContext : IdentityDbContext<ApplicationUser>
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ExampleDB> ExampleDBs { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ClassName> ClassNames { get; set; }

    }
}
