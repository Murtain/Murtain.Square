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
using Murtain.Square.SDK.Focus;

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

            var starFocus = focusRepository.FirstOrDefault(x => x.Status == Status.Focus && x.CreateTime > DateTime.Today);

            if (starFocus == null)
            {
                var nextFocus = focusRepository.Sources.OrderBy(x => x.Status).ThenBy(x => x.Id).FirstOrDefault(x => x.Status == Status.Normal && x.CreateTime > DateTime.Today);
                if (nextFocus != null)
                {
                    nextFocus.Status = Status.Focus;
                    await focusRepository.UpdatePropertyAsync(nextFocus, x => new { x.Status });
                } 
            }
        }

        public async Task FocusToggleCompletedAsync(long id)
        {
            var focuses = focusRepository.Sources.Where(x => x.CreateTime > DateTime.Today).OrderBy(x => x.Status).ThenBy(x => x.Id);
            var focus = await focusRepository.FirstOrDefaultAsync(x => x.Id == id);

            if (focus == null)
            {
                throw new UserFriendlyException(FOCUS_COMPLETED_RETURN_CODE.FOCUS_NOT_EXSIT);
            }

            if (focus.Status == Status.Focus)
            {
                var f = focuses.FirstOrDefault(x => x.Id != focus.Id && x.Status == Status.Normal);

                if (f != null)
                {
                    f.Status = Status.Focus;
                    await focusRepository.UpdatePropertyAsync(f, x => new { x.Status });
                }

            }

            focus.Status = focus.Status == Status.Completed ? Status.Normal : Status.Completed;

            await focusRepository.UpdatePropertyAsync(focus, x => new { x.Status });

        }

        public async Task FocusRemoveAsync(long id)
        {
            var focus = await focusRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (focus == null)
            {
                throw new UserFriendlyException(FOCUS_REMOVE_RETURN_CODE.FOCUS_NOT_EXSIT);
            }

            await focusRepository.RemoveAsync(focus);
        }

        public async Task FocusStarAsync(long id)
        {

            var focuses = focusRepository.Sources.Where(x => x.CreateTime > DateTime.Today);
            var focus = focuses.FirstOrDefault(x => x.Id == id);

            if (focus == null)
            {
                throw new UserFriendlyException(FOCUS_COMPLETED_RETURN_CODE.FOCUS_NOT_EXSIT);
            }

            if (focus.Status == Status.Normal)
            {
                foreach (var f in focuses.Where(x => x.Id != focus.Id && x.Status == Status.Focus))
                {
                    f.Status = Status.Normal;
                    await focusRepository.UpdatePropertyAsync(f, x => new { x.Status });
                }

            }

            focus.Status = focus.Status == Status.Normal ? Status.Focus : Status.Normal;

            await focusRepository.UpdatePropertyAsync(focus, x => new { x.Status });


        }

        public async Task<List<Domain.Entities.Focus>> GetFocusAsync()
        {
            var focuses = await focusRepository.GetAsync(x => x.CreateTime > DateTime.Today);
            return focuses.OrderBy(x => x.Status).ThenBy(x => x.Id).ToList();
        }
        public async Task<Domain.Entities.Focus> GetFocusStarAsync()
        {
            return await focusRepository.FirstOrDefaultAsync(x => x.Status == Status.Focus && x.CreateTime > DateTime.Today);
        }

    }
}
