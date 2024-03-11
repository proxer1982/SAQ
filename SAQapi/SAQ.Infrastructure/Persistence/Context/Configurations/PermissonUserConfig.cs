using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAQ.Domain.Entities;

namespace SAQ.Infrastructure.Persistence.Context.Configurations
{
    public class PermissonUserConfig : IEntityTypeConfiguration<PermissonUser>
    {
        public void Configure(EntityTypeBuilder<PermissonUser> entity)
        {
            entity.ToTable(nameof(PermissonUser));
            entity.HasKey(e => e.PermissonUserId);

            entity.Property(e => e.Status).HasDefaultValueSql("(1)");

            entity.HasOne(e => e.User).WithMany(e => e.PermissonUsers).HasForeignKey(e => e.UserId);
            entity.HasOne(e => e.Permisson).WithMany(e => e.PermissonUsers).HasForeignKey(e => e.PermissonId);
        }
    }
}
