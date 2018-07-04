using GP.CommandSide.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GP.CommandSide.Infra.Ef.Maps
{
    public class MarcaMap
        : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.Ignore(b => b.DomainEvents);

            builder.ToTable("Marca");
            builder.HasKey(b => b.MarcaId);

            builder
                .Property(b => b.MarcaId)
                .HasColumnName("MarcaId")
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(b => b.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(b => b.DataCriacao)
                .HasColumnName("DataCriacao")
                .IsRequired();

            builder
                .HasMany(r => r.Modelos)
                .WithOne(r => r.Marca)
                .HasForeignKey(r => r.MarcaId);

            //builder.Property(r => r.Modelos).HasField("_modelos");

            var navigation = builder.Metadata.FindNavigation(nameof(Marca.Modelos));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
