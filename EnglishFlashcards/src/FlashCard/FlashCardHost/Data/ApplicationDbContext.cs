using Microsoft.EntityFrameworkCore;

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
    }
}
