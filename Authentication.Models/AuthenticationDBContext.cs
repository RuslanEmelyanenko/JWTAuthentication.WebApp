using Microsoft.EntityFrameworkCore;

namespace Authentication.Models
{
    public class AuthenticationDBContext : DbContext
    {
        public AuthenticationDBContext()
        {
        }

        public AuthenticationDBContext(DbContextOptions<AuthenticationDBContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=EMELYANENKO;Database=JWTAuthenticationWebAppDB;Trusted_Connection=True;");
            }
        }
    }
}