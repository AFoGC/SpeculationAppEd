using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Infrastructure.Mapers
{
    public interface IMaper<TEntity, TModel>
    {
        TModel MapEntity(TEntity entity);
        TEntity MapModel(TModel model);
        void MapModel(TModel model, TEntity entity);
    }
}
