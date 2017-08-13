using Murtain.Domain.Entities;
using Murtain.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murtain.Square.Infrastructure
{
    public class Repository<TEntity> : Repository<ModelsContainer, TEntity, long>
        where TEntity : class, IEntity<long>
    {
        public Repository(IEntityFrameworkDbContextProvider<ModelsContainer> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }

    public class Repository<TEntity, TPrimaryKey> : Repository<ModelsContainer, TEntity, TPrimaryKey>
    where TEntity : class, IEntity<TPrimaryKey>
    {
        public Repository(IEntityFrameworkDbContextProvider<ModelsContainer> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
