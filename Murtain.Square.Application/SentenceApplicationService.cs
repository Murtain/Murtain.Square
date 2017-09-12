using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Murtain.Web.Exceptions;
using System.Net;
using Murtain.Square.Core;
using Murtain.Square.SDK.Sentence;
using Murtain.AutoMapper;

namespace Murtain.Square.Application
{
    public class SentenceApplicationService : ISentenceApplicationService
    {
        private ISentenceManager sentenceManager;

        public SentenceApplicationService(ISentenceManager sentenceManager)
        {
            this.sentenceManager = sentenceManager;
        }


        public async Task<Sentence> GetSentenceRandomAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync("http://api.avatardata.cn/MingRenMingYan/Random?key=f6b68de085ca48cca0d018c82f01c9cc");

                if (string.IsNullOrEmpty(response))
                {
                    return null;
                }

                var resp = JsonConvert.DeserializeObject<SentenceFetchResponse>(response);

                if (resp.error_code != 0 || resp == null)
                {
                    throw new UserFriendlyException(SENTENCE_FETCH_RETURN_CODE.AVATAR_DATA_FETCH_FAMOUS_FAILED);
                }

                return resp.result;
            }
            catch (WebException)
            {
                throw new UserFriendlyException(SENTENCE_FETCH_RETURN_CODE.AVATAR_DATA_FETCH_FAMOUS_NOT_UNAVAILABLE);
            }
        }

        public async Task SentenceFavoriteAsync(SentenceFavoriteAsyncRequest input)
        {
            await sentenceManager.SentenceFavoriteAsync(input.MapTo<Domain.Entities.Sentence>());
        }
    }
}
