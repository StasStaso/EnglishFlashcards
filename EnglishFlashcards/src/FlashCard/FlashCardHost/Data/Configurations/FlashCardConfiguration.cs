using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlashCard.Host.Data.Configurations
{
    public class FlashCardConfiguration : IEntityTypeConfiguration<FlashCardModel>
    {
        public void Configure(EntityTypeBuilder<FlashCardModel> builder)
        {
            builder.HasKey(fc => new { fc.WordId, fc.StatusId });

            builder.HasOne(fc => fc.Word)
                .WithMany()
                .HasForeignKey(fc => fc.WordId);

            builder.HasOne(fc => fc.Status)
                .WithMany()
                .HasForeignKey(fc => fc.StatusId);

            builder.HasKey(x => x.WordId);

            builder.HasKey(x => x.StatusId);
        }
    }
}
