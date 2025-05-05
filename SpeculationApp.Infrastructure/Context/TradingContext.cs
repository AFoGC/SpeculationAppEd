using Microsoft.EntityFrameworkCore;
using SpeculationApp.Infrastructure.Configuration;
using SpeculationApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Infrastructure.Context
{
    public class TradingContext : DbContext
    {
        public DbSet<Convertation> Convertations { get; set; } = null!;
        public DbSet<Currency> Currencies { get; set; } = null!;
        public DbSet<Operation> Operations { get; set; } = null!;
        public DbSet<OperationType> OperationTypes { get; set; } = null!;
        public DbSet<Pair> Pairs { get; set; } = null!;

        public TradingContext()
        {

        }

        public TradingContext(DbContextOptions options) : base(options)
        {

        }

        public TradingContext(DbContextOptions<TradingContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlite("Datasource=C:\\Users\\sirko\\source\\repos\\SpeculationApp\\SpeculationApp.Wpf\\bin\\Debug\\net7.0-windows\\Films.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConvertationConfiguration());
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
            modelBuilder.ApplyConfiguration(new OperationConfiguration());
            modelBuilder.ApplyConfiguration(new OperationTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PairConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
