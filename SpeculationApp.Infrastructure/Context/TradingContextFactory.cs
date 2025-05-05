using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Infrastructure.Context
{
    public class TradingContextFactory : IDesignTimeDbContextFactory<TradingContext>
    {
        public TradingContextFactory()
        {

        }

        public TradingContext CreateDbContext(string[] args)
        {
            string connectionString = "Datasource="; //+ "C:\\Users\\sirko\\source\\repos\\SpeculationApp\\SpeculationApp.Wpf\\bin\\Debug\\net7.0-windows\\Films.db";
            SqliteConnection connection = new SqliteConnection(connectionString);

            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            var opt = optionsBuilder.UseSqlite(connection).Options;
            TradingContext tradingContext = new TradingContext(opt);

            return tradingContext;
        }
    }
}
