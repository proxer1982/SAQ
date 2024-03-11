using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAQ.Domain.Entities;

namespace SAQ.Infrastructure.Persistence.Context.Configurations
{
    internal class WorkConfig : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> entity)
        {
            entity.ToTable(nameof(Work));
            entity.HasKey(e => e.WorkId);

            entity.Property(e => e.Description).IsRequired().HasMaxLength(100);
            entity.Property(e => e.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Status).HasDefaultValueSql("(1)");

            entity.HasOne(e => e.Topic).WithMany(e => e.Works).HasForeignKey(e => e.TopicId);
        }
    }
}
