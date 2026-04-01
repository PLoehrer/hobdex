using Hobdex.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Hobdex.Api.Data;
    
public class HobdexDbContext(DbContextOptions<HobdexDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Hobby> Hobbies => Set<Hobby>();
    public DbSet<EntryStatus> EntryStatuses => Set<EntryStatus>();
    public DbSet<EntryType> EntryTypes => Set<EntryType>();
    public DbSet<Entry> Entries => Set<Entry>();
    public DbSet<EntryLog> EntryLogs => Set<EntryLog>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<EntryTag> EntryTags => Set<EntryTag>();
    public DbSet<HobbyTag> HobbyTags => Set<HobbyTag>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Composite PKs for mapping tables
        modelBuilder.Entity<EntryTag>().HasKey(et => new { et.EntryId, et.TagId });
        modelBuilder.Entity<HobbyTag>().HasKey(ht => new { ht.HobbyId, ht.TagId });

        modelBuilder.Entity<HobbyTag>()
            .HasOne(ht => ht.Tag)
            .WithMany(t => t.HobbyTags)
            .HasForeignKey(ht => ht.TagId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<EntryTag>()
            .HasOne(et => et.Tag)
            .WithMany(t => t.EntryTags)
            .HasForeignKey(et => et.TagId)
            .OnDelete(DeleteBehavior.NoAction);

        // Global Query Filters for soft delete
        modelBuilder.Entity<Hobby>().HasQueryFilter(h => !h.IsDeleted);
        modelBuilder.Entity<Entry>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<EntryLog>().HasQueryFilter(el => !el.IsDeleted);

        // Seed EntryStatuses
        modelBuilder.Entity<EntryStatus>().HasData(
            new EntryStatus { Id = 1, Name = "Not Started" },
            new EntryStatus { Id = 2, Name = "In Progress" },
            new EntryStatus { Id = 3, Name = "Completed" },
            new EntryStatus { Id = 4, Name = "Abandoned" }
        );
    }
}