using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeculationApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Infrastructure.Configuration
{
    public class ConvertationConfiguration : IEntityTypeConfiguration<Convertation>
    {
        public void Configure(EntityTypeBuilder<Convertation> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.BaseCurrencyId)
                .HasColumnName("BaseCurrencyId")
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.TradeCurrencyId)
                .HasColumnName("TradeCurrencyId")
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.BaseCurrencyAmount)
                .HasColumnName("BaseCurrencyAmount")
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.TradeCurrencyAmount)
                .HasColumnName("TradeCurrencyAmount")
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            //

            builder.HasOne(d => d.Pair)
                .WithMany(p => p.Convertations)
                .HasForeignKey(d => new { d.BaseCurrencyId, d.TradeCurrencyId });
        }
    }
}
