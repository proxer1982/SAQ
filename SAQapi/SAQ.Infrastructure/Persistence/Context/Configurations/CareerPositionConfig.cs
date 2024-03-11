using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAQ.Domain.Entities;

namespace SAQ.Infrastructure.Persistence.Context.Configurations
{
    public class CareerPositionConfig : IEntityTypeConfiguration<CareerPosition>
    {
        public void Configure(EntityTypeBuilder<CareerPosition> entity)
        {
            entity.ToTable(nameof(CareerPosition));
            entity.HasKey(e => e.CareerPositionId);

            
            entity.HasOne(e => e.Position).WithMany(e => e.CareerPositions).HasForeignKey(e => e.PositionId);
        }
    }
}
