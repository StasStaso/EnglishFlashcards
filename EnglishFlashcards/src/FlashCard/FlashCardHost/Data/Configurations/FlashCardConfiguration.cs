using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlashCard.Host.Data.Configurations
{
    public class FlashCardConfiguration : IEntityTypeConfiguration<FlashCardModel>
    {
        public void Configure(EntityTypeBuilder<FlashCardModel> builder)
        {
            builder.HasKey(fc => fc.Id);

            builder.HasOne(fc => fc.Word)
                .WithMany()
                .HasForeignKey(fc => fc.WordId);

            builder.HasOne(fc => fc.Status)
                .WithMany()
                .HasForeignKey(fc => fc.StatusId);
        }
    }
}
