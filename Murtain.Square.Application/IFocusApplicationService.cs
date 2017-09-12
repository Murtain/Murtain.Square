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
        Task FocusAddAsync(string content);
        Task FocusRemoveAsync(long id);
        Task FocusToggleCompletedAsync(long id);
        Task FocusStarAsync(long id);
        Task<List<SDK.Focus.Focus>> GetFocusAsync();
        Task<SDK.Focus.Focus> GetFocusStarAsync();
    }
}
