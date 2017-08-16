using Murtain.Domain.UnitOfWork;
using Murtain.Square.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murtain.Square.Core
{
    public interface IFocusManager : IUnitOfWorkService
    {
        Task FocusAddAsync(Domain.Entities.Focus focus);
        Task FocusRemoveAsync(long id);
        Task FocusToggleCompletedAsync(long id);
        Task FocusStarAsync(long id);
        Task<IEnumerable<Focus>> GetFocusAsync();
    }
}
