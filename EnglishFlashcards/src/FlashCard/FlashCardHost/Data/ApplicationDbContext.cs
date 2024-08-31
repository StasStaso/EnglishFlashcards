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
        public DbSet<StatusModel> Status { get; set; }
        public DbSet<FlashCardModel> FlashCards { get; set; }
    }
}
