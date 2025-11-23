using Microsoft.EntityFrameworkCore;
using Zoo.Domain.Contexts;
using Zoo.Data.Mappings;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Animal> Animais { get; set; }
    public DbSet<Cuidado> Cuidados { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AnimalMap).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}