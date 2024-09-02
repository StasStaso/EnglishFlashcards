using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FlashCard.Host.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        {
        }

        public DbSet<WordDbModel> Words { get; set; }
        public DbSet<StatusModel> StatusModels { get; set; }
        public DbSet<ExampleModel> FlashCards { get; set; }
        public DbSet<ExampleModel> Examples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
