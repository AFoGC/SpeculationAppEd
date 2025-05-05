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
    public class OperationTypeConfiguration : IEntityTypeConfiguration<OperationType>
    {
        public void Configure(EntityTypeBuilder<OperationType> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.Name)
                .HasColumnName("Name")
                .UsePropertyAccessMode(PropertyAccessMode.Property)
                .IsRequired();

            builder.Property(e => e.IsIncrease)
                .HasColumnName("IsIncrease")
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
