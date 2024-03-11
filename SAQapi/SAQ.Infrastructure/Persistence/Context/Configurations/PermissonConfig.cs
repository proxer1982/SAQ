using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAQ.Domain.Entities;

namespace SAQ.Infrastructure.Persistence.Context.Configurations
{
    public class PermissonConfig : IEntityTypeConfiguration<Permisson>
    {
        public void Configure(EntityTypeBuilder<Permisson> entity)
        {
            List<Permisson> _initPermissons = new List<Permisson>();
            _initPermissons.Add(new Permisson() { PermissonId = 1, Description = "Visualizar información general" });
            _initPermissons.Add(new Permisson() { PermissonId = 2, Description = "Editar información de usuarios" });

            entity.ToTable(nameof(Permisson));
            entity.HasKey(e => e.PermissonId);

            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.Status).HasDefaultValueSql("(1)");

            entity.HasData(_initPermissons);
        }
    }
}
