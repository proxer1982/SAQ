using Microsoft.EntityFrameworkCore;

using SAQ.Domain.Entities;

using System.Reflection;

namespace SAQ.Infrastructure.Persistence.Context
{
    public class SAQContext : DbContext
    {
        public DbSet<Career> Careers { get; set; }
        public DbSet<CareerPosition> CareersPosition { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Permisson> Permissons { get; set; }
        public DbSet<PermissonMenu> PermissonsMenu { get; set; }
        public DbSet<PermissonRole> PermissonsRol { get; set; }
        public DbSet<PermissonUser> PermissonsUser { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<TopicWork> TopicsWork { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserTopic> UsersTopic { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Study> Studies { get; set; }

        public SAQContext()
        {

        }
        public SAQContext(DbContextOptions<SAQContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
