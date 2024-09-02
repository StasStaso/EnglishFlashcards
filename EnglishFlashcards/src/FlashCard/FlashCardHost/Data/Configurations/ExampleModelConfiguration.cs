using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlashCard.Host.Data.Configurations
{
    public class ExampleModelConfiguration : IEntityTypeConfiguration<ExampleModel>
    {
        public void Configure(EntityTypeBuilder<ExampleModel> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Word)
                .WithMany(w => w.Examples)
                .HasForeignKey(e => e.WordId);
        }
    }
}
