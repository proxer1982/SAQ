using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAQ.Domain.Entities;

namespace SAQ.Infrastructure.Persistence.Context.Configurations
{
    public class TopicWorkConfig : IEntityTypeConfiguration<TopicWork>
    {
        public void Configure(EntityTypeBuilder<TopicWork> entity)
        {
            entity.ToTable(nameof(TopicWork));
            entity.HasKey(e => e.TopicWorkId);

            entity.Property(e => e.Status).HasDefaultValueSql("((0))");
            entity.Property(e => e.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(e => e.Work).WithMany().HasForeignKey(e => e.WorkId);
            //entity.HasOne(e => e.UserTopic).WithMany(e => e.TopicWorks).HasForeignKey(e => e.UserTopicId);
        }
    }
}
