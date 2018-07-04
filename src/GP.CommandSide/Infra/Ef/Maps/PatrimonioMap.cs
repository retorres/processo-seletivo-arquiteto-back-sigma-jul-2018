using GP.CommandSide.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GP.CommandSide.Infra.Ef.Maps
{
    public class PatrimonioMap : IEntityTypeConfiguration<Patrimonio>
    {
        public void Configure(EntityTypeBuilder<Patrimonio> builder)
        {
            builder.ToTable("Patrimonio");

            builder
                .HasKey(b => b.TomboNumero);

            builder
                .Property(t => t.TomboNumero)
                .HasColumnName("TomboNumero")
                .ValueGeneratedNever()
                .IsRequired();

            builder
                .Ignore(b => b.DomainEvents);

            builder
                .Property(b => b.ModeloId)
                .HasColumnName("ModeloId")
                .IsRequired();

            builder
                .Property(b => b.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(b => b.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(500);

            builder
                .HasOne(b => b.Modelo)
                .WithMany()
                .HasForeignKey(b => b.ModeloId);
        }
    }
}
