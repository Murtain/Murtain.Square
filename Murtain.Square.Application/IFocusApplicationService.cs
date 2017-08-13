using Murtain.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murtain.Square.Application
{
    public interface IFocusApplicationService : IApplicationService
    {
        Task FocusAddAsync(SDK.Domain.Focus focus);
        Task FocusRemoveAsync(long id);
        Task FocusCompletedAsync(long id);
        Task FocusStarAsync(long id);
        Task<IEnumerable<SDK.Domain.Focus>> GetFocusAsync();
    }
}
