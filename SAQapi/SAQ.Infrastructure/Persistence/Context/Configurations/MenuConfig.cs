using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAQ.Domain.Entities;

namespace SAQ.Infrastructure.Persistence.Context.Configurations
{
    public class SubmenuConfig : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> entity)
        {
            List<Menu> menuInit = new List<Menu>();
            menuInit.Add(new Menu() { MenuId = 1, Title = "DashBoard", Icon = "dashboard", Parent = 0, Url = "dashboard", Order = 0 });
            menuInit.Add(new Menu() { MenuId = 2, Title = "Usuarios", Icon = "group", Parent = 0, Url = "", Order = 2 });
            menuInit.Add(new Menu() { MenuId = 3, Title = "Nuevo usuario", Icon = "", Parent = 2, Url = "usuarios/nuevo_usuario", Order = 3 });
            menuInit.Add(new Menu() { MenuId = 4, Title = "Usuarios activos", Icon = "", Parent = 2, Url = "/usuarios", Order = 1 });
            menuInit.Add(new Menu() { MenuId = 5, Title = "Usuarios inactivos", Icon = "", Parent = 2, Url = "/usuarios/inactivos", Order = 2 });

            entity.ToTable(nameof(Menu));
            entity.HasKey(e => e.MenuId);

            entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Url).IsRequired();
            entity.Property(e => e.Parent);
            entity.Property(e => e.Icon).HasMaxLength(40);
            entity.Property(e => e.Status).HasDefaultValueSql("(1)");

            entity.HasMany(e => e.PermissionMenus).WithOne().HasForeignKey(e => e.MenuId);

            entity.HasData(menuInit);
        }

    }

}
