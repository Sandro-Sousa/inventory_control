using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Entities.Entites.User> Users { get; set; }
        public DbSet<Entities.Entites.Product> Products { get; set; }
    }
}
