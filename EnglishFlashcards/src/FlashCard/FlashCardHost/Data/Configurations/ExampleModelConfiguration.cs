using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlashCard.Host.Data.Configurations
{
    public class ExampleModelConfiguration : IEntityTypeConfiguration<ExampleModel>
    {
        public void Configure(EntityTypeBuilder<ExampleModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(e => e.Word)
                .WithMany(w => w.Examples)
                .HasForeignKey(e => e.WordId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
