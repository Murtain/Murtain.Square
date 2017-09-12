using Murtain.EntityFramework;
using Murtain.Square.Domain.Entities;
using Murtain.Square.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murtain.Square.Infrastructure.Repositories
{
    
    public class SentenceRepository : Repository<Sentence>, ISentenceRepository
    {
        public SentenceRepository(IEntityFrameworkDbContextProvider<ModelsContainer> dbContextProvider)
            : base(dbContextProvider)
        {

        }
    }
}
