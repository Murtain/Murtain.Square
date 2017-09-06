using Murtain.Square.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Murtain.Square.SDK;
using Murtain.AutoMapper;
using AutoMapper;
using Murtain.Square.SDK.Domain;

namespace Murtain.Square.Application
{
    public class FocusApplicationService : IFocusApplicationService
    {
        private readonly IFocusManager focusManager;

        public FocusApplicationService(IFocusManager focusManager)
        {
            this.focusManager = focusManager;
        }

        public async Task FocusAddAsync(string content)
        {
            await focusManager.FocusAddAsync(new Domain.Entities.Focus
            {
                Content = content,
                Status = SDK.Domain.Status.Normal
            });
        }

        public async Task FocusToggleCompletedAsync(long id)
        {
            await focusManager.FocusToggleCompletedAsync(id);
        }

        public async Task FocusRemoveAsync(long id)
        {
            await focusManager.FocusRemoveAsync(id);
        }

        public async Task FocusStarAsync(long id)
        {
            await focusManager.FocusStarAsync(id);
        }

        public async Task<List<SDK.Domain.Focus>> GetFocusAsync()
        {
            var focuses = await focusManager.GetFocusAsync();
            return focuses.MapTo<List<SDK.Domain.Focus>>();
        }

        public async Task<Focus> GetFocusStarAsync()
        {
            var focus = await focusManager.GetFocusStarAsync();

            if (focus == null)
            {
                return null;
            }
            return focus.MapTo<SDK.Domain.Focus>();
        }
    }
}
