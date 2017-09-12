using Murtain.Domain.Services;
using Murtain.Square.SDK.Sentence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murtain.Square.Application
{
    public interface ISentenceApplicationService : IApplicationService
    {

        Task<Sentence> GetSentenceRandomAsync();
        Task SentenceFavoriteAsync(SentenceFavoriteAsyncRequest input);
    }
}
