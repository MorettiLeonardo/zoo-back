using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zoo.Domain.Contexts;

namespace Zoo.Data.Mappings;

public class AnimalMap : IEntityTypeConfiguration<Animal>
{
    public void Configure(EntityTypeBuilder<Animal> builder)
    {
        builder.ToTable("Animais");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.Descricao)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(a => a.DataNascimento)
            .IsRequired();

        builder.Property(a => a.Especie)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.Habitat)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(a => a.PaisOrigem)
            .IsRequired()
            .HasMaxLength(80);

        builder.HasMany(a => a.Cuidados)
            .WithOne(c => c.Animal)
            .HasForeignKey(c => c.AnimalId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}