using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAQ.Domain.Entities;

namespace SAQ.Infrastructure.Persistence.Context.Configurations
{
    public class TopicConfig : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> entity)
        {
            entity.ToTable(nameof(Topic));
            entity.HasKey(e => e.TopicId);

            entity.Property(e => e.Description).IsRequired().HasMaxLength(100);
            entity.Property(e => e.UrlLogo).HasMaxLength(250);
            entity.Property(e => e.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Status).HasDefaultValueSql("(1)");
        }
    }
}
