using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeculationApp.Infrastructure.Entities;

namespace SpeculationApp.Infrastructure.Configuration
{
    public class OperationConfiguration : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.OperationTypeId)
                .HasColumnName("OperationTypeId")
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.CurrencyId)
                .HasColumnName("CurrencyId")
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.Amount)
                .HasColumnName("Amount")
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.Date)
                .HasColumnName("Date")
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            //

            builder.HasOne(d => d.OperationType)
                .WithMany(p => p.Operations)
                .HasForeignKey(d => d.OperationTypeId);

            builder.HasOne(d => d.Currency)
                .WithMany(p => p.Operations)
                .HasForeignKey(d => d.CurrencyId);
        }
    }
}
