using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAQ.Domain.Entities;

namespace SAQ.Infrastructure.Persistence.Context.Configurations
{
    public class TeamConfig : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> entity)
        {
            List<Team> teamsInit = new List<Team>();
            teamsInit.Add(new Team { TeamId = 1, Title = "Bonsái", Status = 1 });
            teamsInit.Add(new Team { TeamId = 2, Title = "Migration Force", Status = 1 });
            teamsInit.Add(new Team { TeamId = 3, Title = "Apache", Status = 1 });
            teamsInit.Add(new Team { TeamId = 4, Title = "Analítica", Status = 1 });
            teamsInit.Add(new Team { TeamId = 5, Title = "Rocket", Status = 1 });
            teamsInit.Add(new Team { TeamId = 6, Title = "Swat", Status = 1 });
            teamsInit.Add(new Team { TeamId = 7, Title = "Centinelas", Status = 1 });
            teamsInit.Add(new Team { TeamId = 8, Title = "Torre de Control", Status = 1 });
            teamsInit.Add(new Team { TeamId = 9, Title = "Sentinels-Tráfico", Status = 1 });
            teamsInit.Add(new Team { TeamId = 10, Title = "Mejoramiento", Status = 1 });

            entity.ToTable(nameof(Team));

            entity.HasKey(e => e.TeamId);
            entity.Property(x => x.TeamId).ValueGeneratedNever();

            entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Status).HasDefaultValueSql("(1)");

            entity.HasData(teamsInit);
        }
    }
}
