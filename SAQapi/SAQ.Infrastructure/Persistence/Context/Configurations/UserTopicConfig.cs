using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAQ.Domain.Entities;

namespace SAQ.Infrastructure.Persistence.Context.Configurations
{
    public class UserTopicConfig : IEntityTypeConfiguration<UserTopic>
    {
        public void Configure(EntityTypeBuilder<UserTopic> entity)
        {
            entity.ToTable(nameof(UserTopic));
            entity.HasKey(e => e.UserTopicId);

            entity.Property(e => e.Status).HasDefaultValueSql("(1)");
            entity.Property(e => e.Score).HasDefaultValueSql("(0)");
            entity.Property(e => e.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");


            entity.HasOne(e => e.Topic).WithMany(e => e.UserTopics).HasForeignKey(e => e.TopicId);
        }
    }
}
