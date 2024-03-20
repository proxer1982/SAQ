using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAQ.Domain.Entities;

namespace SAQ.Infrastructure.Persistence.Context.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            List<User> usersInit = new List<User>();
            usersInit.Add(new User { UserId = Guid.Parse("be302144-78b1-4736-9b73-a81ec1516bc0"), RoleId = 1, UserName = "admin@satrack.com", Password="$2a$11$FESTHupDa2VTtFluIsXleeiyi/eRRsj968GWBzu2zw3dsecJK1R9e", FirstName = "Administrador", LastName = "", Alias = "Admin", TeamId = 1, PositionId = 1, UserCreated = Guid.Parse("be302144-78b1-4736-9b73-a81ec1516bc0") }); // pass '123AA'

            entity.ToTable(nameof(User));

            entity.HasKey(e => e.UserId);
            entity.Property(x => x.UserId).ValueGeneratedNever();

            entity.Property(e => e.UserName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Password).IsRequired().HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(150);
            entity.Property(e => e.LastName).HasMaxLength(150);
            entity.Property(e => e.PositionId).IsRequired();

            entity.Property(e => e.UrlImage).HasColumnType("text").IsUnicode();
            entity.Property(e => e.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Status).HasDefaultValueSql("(1)");
            entity.Property(e => e.SoftSkills).HasDefaultValueSql("('false')");

            entity.HasOne(e => e.Rol).WithMany().HasForeignKey(e => e.RoleId).IsRequired();
            entity.HasOne(e => e.Career).WithMany().HasForeignKey(e => e.CareerId);
            entity.HasOne(e => e.Position).WithMany().HasForeignKey(e => e.PositionId);
            entity.HasOne(e => e.Team).WithMany().HasForeignKey(e => e.TeamId);
            entity.HasMany(e => e.Study).WithOne().HasForeignKey(e => e.UserId);
            entity.HasMany(e => e.Notes).WithOne().HasForeignKey(e => e.UserId);

            entity.HasMany(e => e.UserTopics).WithOne().HasForeignKey(e => e.UserId);


            entity.HasData(usersInit);
        }
    }
}
