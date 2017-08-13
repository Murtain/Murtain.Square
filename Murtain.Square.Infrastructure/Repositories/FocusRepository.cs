using Murtain.Domain.Repositories;
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
    public class FocusRepository : Repository<Focus>, IFocusRepository
    {
        public FocusRepository(IEntityFrameworkDbContextProvider<ModelsContainer> dbContextProvider)
            : base(dbContextProvider)
        {

        }
    }
}
