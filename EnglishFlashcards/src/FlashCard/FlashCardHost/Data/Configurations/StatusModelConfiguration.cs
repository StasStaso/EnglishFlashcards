using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlashCard.Host.Data.Configurations
{
    public class StatusModelConfiguration : IEntityTypeConfiguration<StatusModel>
    {
        public void Configure(EntityTypeBuilder<StatusModel> builder)
        {
            builder.HasKey(x => x.StatusId);

            builder.Property(x => x.StatusName)
                .HasMaxLength(30)
                .HasColumnName("Status");
        }
    }
}
