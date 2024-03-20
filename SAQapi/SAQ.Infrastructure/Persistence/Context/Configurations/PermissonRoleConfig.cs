using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAQ.Domain.Entities;

namespace SAQ.Infrastructure.Persistence.Context.Configurations
{
    public class PermissonRoleConfig : IEntityTypeConfiguration<PermissonRole>
    {
        public void Configure(EntityTypeBuilder<PermissonRole> entity)
        {
            List<PermissonRole> _initPermisson = new List<PermissonRole>();
            _initPermisson.Add(new PermissonRole() { PermissonRoleId = 1, PermissonId = 1, RoleId=1 });
            _initPermisson.Add(new PermissonRole() { PermissonRoleId = 2, PermissonId = 2, RoleId=1 });
            _initPermisson.Add(new PermissonRole() { PermissonRoleId = 3, PermissonId = 1, RoleId=2 });
            _initPermisson.Add(new PermissonRole() { PermissonRoleId = 4, PermissonId = 1, RoleId=3 });

            entity.ToTable(nameof(PermissonRole));
            entity.HasKey(e => e.PermissonRoleId);

            entity.Property(e => e.Status).HasDefaultValueSql("(1)");

            entity.HasOne(e => e.Role).WithMany(e => e.PermissonRoles).HasForeignKey(e => e.RoleId);
            entity.HasOne(e => e.Permisson).WithMany(e => e.PermissonRoles).HasForeignKey(e => e.PermissonId);

            entity.HasData(_initPermisson);
        }
    }
}
