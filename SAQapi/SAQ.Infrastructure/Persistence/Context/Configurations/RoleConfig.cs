using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAQ.Domain.Entities;

namespace SAQ.Infrastructure.Persistence.Context.Configurations
{
    public class RoleConfig : IEntityTypeConfiguration<Role>

    {
        public void Configure(EntityTypeBuilder<Role> entity)
        {
            List<Role> roleInit = new List<Role>();
            roleInit.Add(new Role() { RoleId = 1, Description = "Administrador" });
            roleInit.Add(new Role() { RoleId = 2, Description = "Mentor" });
            roleInit.Add(new Role() { RoleId = 3, Description = "Colaborador" });

            entity.ToTable(nameof(Role));
            entity.HasKey(e => e.RoleId);

            entity.Property(e => e.Description).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Status).HasDefaultValueSql("(1)");

            entity.HasData(roleInit);
        }
    }
}
