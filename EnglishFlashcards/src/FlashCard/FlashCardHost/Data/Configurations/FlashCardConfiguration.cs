using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlashCard.Host.Data.Configurations
{
    public class FlashCardConfiguration : IEntityTypeConfiguration<FlashCardModel>
    {
        public void Configure(EntityTypeBuilder<FlashCardModel> builder)
        {
            builder.HasKey(fc => fc.Id);

            builder.HasOne(f => f.Status)
                .WithMany()
                .HasForeignKey(f => f.StatusId);

            builder.HasOne(f => f.Word)
                .WithMany()
                .HasForeignKey(x => x.WordId);
        }
    }
}
