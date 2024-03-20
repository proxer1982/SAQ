using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAQ.Domain.Entities;

namespace SAQ.Infrastructure.Persistence.Context.Configurations
{
    internal class StudyConfig : IEntityTypeConfiguration<Study>
    {
        public void Configure(EntityTypeBuilder<Study> entity)
        {
            entity.ToTable(nameof(Study));

            entity.HasKey(e => e.StudyId);
            entity.Property(x => x.StudyId).ValueGeneratedOnAdd();

            entity.Property(e => e.StudyName).IsRequired().HasMaxLength(150);
            entity.Property(e => e.Status).HasDefaultValueSql("(1)"); // 1 terminado, 2 en progreso, 3  sin terminar y 0 elimiando
        }
    }
}
