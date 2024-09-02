using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlashCard.Host.Data.Configurations
{
    public class WordDbModelConfiguration : IEntityTypeConfiguration<WordDbModel>
    {
        public void Configure(EntityTypeBuilder<WordDbModel> builder)
        {
            builder.HasKey(x => x.WordId);

            builder.HasMany(w => w.Examples)
                .WithOne(e => e.Word)
                .HasForeignKey(w => w.WordId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
