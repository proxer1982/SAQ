using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAQ.Domain.Entities;

namespace SAQ.Infrastructure.Persistence.Context.Configurations
{
    public class CareerConfig : IEntityTypeConfiguration<Career>
    {
        public void Configure(EntityTypeBuilder<Career> entity)
        {
            entity.ToTable(nameof(Career));
            entity.HasKey(e => e.CareerId);

            entity.Property(e => e.Title).IsRequired().HasMaxLength(60);
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Status).HasDefaultValueSql("(1)");
            entity.HasMany(e => e.CareerPositions).WithOne().HasForeignKey(e => e.CareerId);
        }

    }
}
