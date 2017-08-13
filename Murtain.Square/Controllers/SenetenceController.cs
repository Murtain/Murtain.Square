using Murtain.SDK.Attributes;
using Murtain.Square.Models;
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
        /// <summary>
        /// 获取一条名人名言（随机）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/senetences/random")]
        [ReturnCode(typeof(FETCH_SENTENCE_RETURN_CODE))]
        [JsonSample(typeof(SentenceSample))]
        public async Task<Sentence> GetAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync("http://api.avatardata.cn/MingRenMingYan/Random?key=f6b68de085ca48cca0d018c82f01c9cc");

                if (string.IsNullOrEmpty(response))
                {
                    return null;
                }

                var resp = JsonConvert.DeserializeObject<SentenceResponse>(response);

                if (resp.error_code != 0 || resp == null)
                {
                    throw new UserFriendlyExceprion(FETCH_SENTENCE_RETURN_CODE.AVATAR_DATA_FETCH_FAMOUS_FAILED);
                }

                return resp.result;
            }
            catch (WebException)
            {
                throw new UserFriendlyExceprion(FETCH_SENTENCE_RETURN_CODE.AVATAR_DATA_FETCH_FAMOUS_NOT_UNAVAILABLE);
            }
        }
    }
}