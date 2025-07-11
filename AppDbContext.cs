using BodyRecomp.Entities;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Ingredient> Ingredients { get; set; }

    public DbSet<FoodEntry> FoodEntries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ingredient>()
            .Property(i => i.Unit)
            .HasConversion<string>();

        modelBuilder.Entity<FoodEntry>()
            .Property(f => f.Unit)
            .HasConversion<string>();
    }
}