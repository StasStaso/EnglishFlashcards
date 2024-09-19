using FlashCard.Host.Data.Configurations;
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
        public DbSet<StatusModel> Status { get; set; }
        public DbSet<FlashCardModel> FlashCards { get; set; }
        //public DbSet<ExampleModel> Examples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FlashCardConfiguration());
            modelBuilder.ApplyConfiguration(new StatusModelConfiguration());
            modelBuilder.ApplyConfiguration(new WordDbModelConfiguration());
        }
    }
}
