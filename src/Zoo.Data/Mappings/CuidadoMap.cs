using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zoo.Domain.Contexts;

namespace Zoo.Data.Mappings;

public class CuidadoMap : IEntityTypeConfiguration<Cuidado>
{
    public void Configure(EntityTypeBuilder<Cuidado> builder)
    {
        builder.ToTable("Cuidados");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Descricao)
            .HasMaxLength(300);

        builder.Property(c => c.Frequencia)
            .IsRequired();

        builder.Property(c => c.AnimalId)
            .IsRequired();

        builder.HasOne(c => c.Animal)
            .WithMany(a => a.Cuidados)
            .HasForeignKey(c => c.AnimalId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}