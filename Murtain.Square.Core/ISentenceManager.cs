using Murtain.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murtain.Square.Core
{
    public interface ISentenceManager : IUnitOfWorkService
    {
        Task SentenceFavoriteAsync(Domain.Entities.Sentence sentence);
    }
}
