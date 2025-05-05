using SpeculationApp.Domain.Repositories;
using SpeculationApp.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TradingContext _dbContext;

        public UnitOfWork(TradingContext dbContext)
        {
            _dbContext = dbContext;

            Currencies = new CurrencyRepository(_dbContext);
            Pairs = new PairRepository(_dbContext);
            Convertations = new ConvertationRepository(_dbContext);
            Operations = new OperationRepository(_dbContext);
            OperationTypes = new OperationTypeRepository(_dbContext);
        }

        public ICurrencyRepository Currencies { get; }
        public IPairRepository Pairs { get; }
        public IConvertationRepository Convertations { get; }
        public IOperationRepository Operations { get; }
        public IOperationTypeRepository OperationTypes { get; }

        public void Complete()
        {
            _dbContext.SaveChanges();
        }
    }
}
