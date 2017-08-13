using Murtain.Square.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Murtain.Square.SDK;
using Murtain.AutoMapper;

namespace Murtain.Square.Application
{
    public class FocusApplicationService : IFocusApplicationService 
    {
        private readonly IFocusManager focusManager;

        public FocusApplicationService(IFocusManager focusManager)
        {
            this.focusManager = focusManager;
        }

        public async Task FocusAddAsync(SDK.Domain.Focus focus)
        {
            await focusManager.FocusAddAsync(focus.MapTo<Domain.Entities.Focus>());
        }

        public async Task FocusCompletedAsync(long id)
        {
            await focusManager.FocusCompletedAsync(id);
        }

        public async Task FocusRemoveAsync(long id)
        {
            await focusManager.FocusRemoveAsync(id);
        }

        public async Task FocusStarAsync(long id)
        {
            await focusManager.FocusStarAsync(id);
        }

        public async Task<IEnumerable<SDK.Domain.Focus>> GetFocusAsync()
        {
            var focuses = await focusManager.GetFocusAsync();

            return focuses.MapTo<IEnumerable<SDK.Domain.Focus>>();
        }
    }
}
