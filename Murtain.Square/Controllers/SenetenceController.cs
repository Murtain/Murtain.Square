using Murtain.SDK.Attributes;
using Murtain.Square.Application;
using Murtain.Square.Models;
using Murtain.Square.SDK.Sentence;
using Murtain.Web.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Murtain.Square.Controllers
{
    /// <summary>
    /// 名人名言
    /// </summary>
    public class SenetenceController : ApiController
    {

        private ISentenceApplicationService sentenceApplicationService;

        public SenetenceController(ISentenceApplicationService sentenceApplicationService)
        {
            this.sentenceApplicationService = sentenceApplicationService;
        }
        /// <summary>
        /// 获取一条名人名言（随机）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/senetences/random")]
        [ReturnCode(typeof(SENTENCE_FETCH_RETURN_CODE))]
        [JsonSample(typeof(SentenceSample))]
        public async Task<Sentence> GetSentenceRandomAsync()
        {
            return await sentenceApplicationService.GetSentenceRandomAsync();
        }

        /// <summary>
        /// 收藏/取消收藏名言
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/senetences/favorite")]
        [ReturnCode(typeof(SENTENCE_FAVORITE_RETURN_CODE))]

        public async Task SentenceFavoriteAsync([FromBody]SentenceFavoriteAsyncRequest input)
        {
            await sentenceApplicationService.SentenceFavoriteAsync(input);
        }
    }
}