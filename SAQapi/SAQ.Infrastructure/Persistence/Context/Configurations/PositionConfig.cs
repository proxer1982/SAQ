using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAQ.Domain.Entities;

namespace SAQ.Infrastructure.Persistence.Context.Configurations
{
    public class PositionConfig : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> entity)
        {
            List<Position> _positionInit = new List<Position>();

            _positionInit.Add(new Position() { PositionId = 1, Title = "Administrador", Status = 1 });
            _positionInit.Add(new Position() { PositionId = 2, Title = "Lider de equipo", Status = 1 });
            _positionInit.Add(new Position() { PositionId = 3, Title = "Desarrollador III", Status = 1 });
            _positionInit.Add(new Position() { PositionId = 4, Title = "Desarrollador II", Status = 1 });
            _positionInit.Add(new Position() { PositionId = 5, Title = "Desarrollador I", Status = 1 });


            entity.ToTable(nameof(Position));
            entity.HasKey(e => e.PositionId);

            entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Status).HasDefaultValueSql("(1)");

            entity.HasData(_positionInit);
        }
    }
}
