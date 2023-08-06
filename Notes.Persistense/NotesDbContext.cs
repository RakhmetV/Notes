using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfacies;
using Notes.Domain;
using Notes.Persistense.EntityTypeConfiguration;

namespace Notes.Persistense
{
    public class NotesDbContext : DbContext, INoteDbContext
    {
        public DbSet<Note> Notes { get; set; }
        public NotesDbContext(DbContextOptions<NotesDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NoteConfigurations());
            base.OnModelCreating(modelBuilder);
        

        }
    }
}
