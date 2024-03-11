using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAQ.Domain.Entities;

namespace SAQ.Infrastructure.Persistence.Context.Configurations
{
    public class NoteConfig : IEntityTypeConfiguration<Note>

    {
        public void Configure(EntityTypeBuilder<Note> entity)
        {
            entity.ToTable(nameof(Note));
            entity.HasKey(e => e.NoteId);

            entity.Property(e => e.Status).HasDefaultValueSql("(1)");
            entity.Property(e => e.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
