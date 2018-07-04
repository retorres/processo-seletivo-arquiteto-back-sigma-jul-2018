using GP.CommandSide.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GP.CommandSide.Infra.Ef.Maps
{
    public class ModeloMap
       : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.ToTable("Modelo");

            builder
                .HasKey(b => b.ModeloId);

            builder
                .Property(t => t.ModeloId)
                .HasColumnName("ModeloId")
                .ValueGeneratedNever()
                .IsRequired();

            builder
                .Ignore(b => b.DomainEvents);

            builder
                .Property(b => b.MarcaId)
                .HasColumnName("MarcaId")
                .IsRequired();

            builder
                .Property(b => b.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(200)
                .IsRequired();

            builder
                .HasOne(b => b.Marca)
                .WithMany(b => b.Modelos)
                .HasForeignKey(b => b.MarcaId);




            //builder
            //    .HasOne(typeof(Marca), nameof(Modelo.Marca))
            //    .WithMany(nameof(Marca.Modelos))
            //    .HasForeignKey("MarcaId");

            //IMutableNavigation partsNav = builder.Metadata.FindNavigation(nameof(Marca.Modelos));
            //partsNav.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
