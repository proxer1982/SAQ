using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAQ.Domain.Entities;

namespace SAQ.Infrastructure.Persistence.Context.Configurations
{
    public class PermissonMenuConfig : IEntityTypeConfiguration<PermissonMenu>
    {
        public void Configure(EntityTypeBuilder<PermissonMenu> entity)
        {
            List<PermissonMenu> permissonMenuInit = new List<PermissonMenu>();
            permissonMenuInit.Add(new PermissonMenu() { PermissionMenuId = 1, MenuId = 1, PermissonId = 1, Status = 1 });
            permissonMenuInit.Add(new PermissonMenu() { PermissionMenuId = 2, MenuId = 1, PermissonId = 2, Status = 1 });
            permissonMenuInit.Add(new PermissonMenu() { PermissionMenuId = 3, MenuId = 2, PermissonId = 2, Status = 1 });
            permissonMenuInit.Add(new PermissonMenu() { PermissionMenuId = 4, MenuId = 3, PermissonId = 2, Status = 1 });
            permissonMenuInit.Add(new PermissonMenu() { PermissionMenuId = 5, MenuId = 4, PermissonId = 2, Status = 1 });
            permissonMenuInit.Add(new PermissonMenu() { PermissionMenuId = 6, MenuId = 5, PermissonId = 2, Status = 1 });

            entity.ToTable(nameof(PermissonMenu));
            entity.HasKey(e => e.PermissionMenuId);

            entity.Property(e => e.Status).HasDefaultValueSql("(1)");
            entity.Property(e => e.MenuId).IsRequired();

            //entity.HasOne(e => e.).WithMany(e => e.PermissionMenus).HasForeignKey(e => e.MenuId);
            entity.HasOne(e => e.Permisson).WithMany().HasForeignKey(e => e.PermissonId);

            entity.HasData(permissonMenuInit);
        }
    }
}
