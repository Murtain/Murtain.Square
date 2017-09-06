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
                throw new UserFriendlyException(FOCUS_COMPLETED_RETURN_CODE.FOCUS_NOT_EXSIT);
            }

            if (focus.Status == Status.Normal || focus.Status == Status.Focus)
            {
                focus.Status = Status.Completed;
            }

            if (focus.Status == Status.Completed)
            {
                focus.Status = Status.Normal;
            }
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


            var focuses = focusRepository.Sources.Where(x => x.CreateTime > DateTime.Today).OrderByDescending(x => x.CreateTime);
            var focus = focuses.FirstOrDefault(x => x.Id == id);

            if (focus == null)
            {
                throw new UserFriendlyException(FOCUS_COMPLETED_RETURN_CODE.FOCUS_NOT_EXSIT);
            }

            focus.Status = focus.Status == Status.Normal ? Status.Focus : Status.Normal;

            await focusRepository.UpdatePropertyAsync(focus, x => new { x.Status });

            foreach (var f in focuses.Where(x => x.Id != focus.Id))
            {
                if (focus.Status == Status.Focus && f.Status == Status.Focus)
                {
                    f.Status = Status.Normal;
                }

                await focusRepository.UpdatePropertyAsync(f, x => new { x.Status });
            }

            if (focus.Status == Status.Normal)
            {
                var f = focuses.OrderByDescending(x => x.CreateTime).FirstOrDefault(x => x.Id != focus.Id && focus.Status == Status.Normal);

                f.Status = Status.Focus;
                f.CreateTime = DateTime.Now;
                await focusRepository.UpdatePropertyAsync(f, x => new { x.Status });
            }

        }

        public async Task<List<Domain.Entities.Focus>> GetFocusAsync()
        {
            var focuses = await focusRepository.GetAsync(x => x.CreateTime > DateTime.Today);

            return focuses.OrderByDescending(x => x.CreateTime).ToList();
        }
    }
}
