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
            _positionInit.Add(new Position() { PositionId = 2, Title = "Lider Técnico", Status = 1 });
            _positionInit.Add(new Position() { PositionId = 3, Title = "Desarrollador 1", Status = 1 });
            _positionInit.Add(new Position() { PositionId = 4, Title = "Desarrollador 2", Status = 1 });
            _positionInit.Add(new Position() { PositionId = 5, Title = "Desarrollador 3", Status = 1 });
            _positionInit.Add(new Position() { PositionId = 6, Title = "Especialista en Pruebas QA", Status = 1 });
            _positionInit.Add(new Position() { PositionId = 7, Title = "Arquitecto", Status = 1 });
            _positionInit.Add(new Position() { PositionId = 8, Title = "Scrum Master", Status = 1 });


            entity.ToTable(nameof(Position));
            entity.HasKey(e => e.PositionId);

            entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Status).HasDefaultValueSql("(1)");

            entity.HasData(_positionInit);
        }
    }
}
