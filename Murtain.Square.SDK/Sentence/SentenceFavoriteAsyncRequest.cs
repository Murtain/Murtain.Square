using Murtain.SDK.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Murtain.Square.SDK.Sentence
{
    /// <summary>
    /// 名言收藏
    /// </summary>
    public class SentenceFavoriteAsyncRequest
    {
        /// <summary>
        /// 名字
        /// </summary>
        public string FamousName { get; set; }
        /// <summary>
        /// 名言
        /// </summary>
        public string FamousSaying { get; set; }
    }

    public enum SENTENCE_FAVORITE_RETURN_CODE
    {
        /// <summary>
        /// 名言收藏失败
        /// </summary>
        [Description("名言收藏失败")]
        [HttpCorresponding(HttpStatusCode.BadRequest)]
        SENTENCE_FAVORITE_FAILED,
    }
}
