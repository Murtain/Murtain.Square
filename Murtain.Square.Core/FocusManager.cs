using Murtain.Domain.UnitOfWork;
using Murtain.Square.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Murtain.Square.Domain.Entities;
using Murtain.Web.Exceptions;
using Murtain.Square.SDK;
using Murtain.Square.SDK.Domain;

namespace Murtain.Square.Core
{
    public class FocusManager : IFocusManager
    {
        private readonly IFocusRepository focusRepository;

        public FocusManager(IFocusRepository focusRepository)
        {
            this.focusRepository = focusRepository;
        }

        public async Task FocusAddAsync(Domain.Entities.Focus focus)
        {
            await focusRepository.AddAsync(focus);
        }

        public async Task FocusToggleCompletedAsync(long id)
        {
            var focus = await focusRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (focus == null)
            {
                throw new UserFriendlyExceprion(FOCUS_COMPLETED_RETURN_CODE.FOCUS_NOT_EXSIT);
            }

            if (focus.Status == Status.Normal)
            {
                focus.Status = Status.Completed;
            }

            if (focus.Status == Status.Completed || focus.Status == Status.Focus)
            {
                focus.Status = Status.Completed;
            }
            await focusRepository.UpdatePropertyAsync(focus, x => new { x.Status });
        }

        public async Task FocusRemoveAsync(long id)
        {
            var focus = await focusRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (focus == null)
            {
                throw new UserFriendlyExceprion(FOCUS_REMOVE_RETURN_CODE.FOCUS_NOT_EXSIT);
            }

            await focusRepository.RemoveAsync(focus);
        }

        public async Task FocusStarAsync(long id)
        {
            var focus = await focusRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (focus == null)
            {
                throw new UserFriendlyExceprion(FOCUS_COMPLETED_RETURN_CODE.FOCUS_NOT_EXSIT);
            }

            focus.Status = Status.Normal;
            await focusRepository.UpdatePropertyAsync(focus, x => new { x.Status });
        }

        public async Task<IEnumerable<Domain.Entities.Focus>> GetFocusAsync()
        {
            var focuses = await focusRepository.GetAsync(x => x.CreateTime > DateTime.Today);

            return focuses.OrderBy(x => x.Status).ToList();
        }
    }
}
