using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AuthDemo.Domain.Entities.Authentication;

namespace AuthDemo.Infrastructure
{
    public class AuthDemoDbContext : IdentityDbContext<User>
    {
        public AuthDemoDbContext(DbContextOptions<AuthDemoDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
