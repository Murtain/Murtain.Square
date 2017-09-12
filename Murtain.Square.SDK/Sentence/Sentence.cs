using Murtain.SDK;
using Murtain.SDK.Attributes;
using Murtain.SDK.Models;
using Murtain.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Web;

namespace Murtain.Square.SDK.Sentence
{

    /// <summary>
    /// 名言
    /// </summary>
    public class Sentence
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string FamousName { get; set; }
        /// <summary>
        /// 名言
        /// </summary>
        public string FamousSaying { get; set; }
    }

    /// <summary>
    /// 名言请求
    /// </summary>
    public class SentenceFetchResponse
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public Sentence result { get; set; }
        /// <summary>
        /// 错误码
        /// </summary>
        public int error_code { get; set; }
        /// <summary>
        /// 错误原因
        /// </summary>
        public string reason { get; set; }
    }

    public enum SENTENCE_FETCH_RETURN_CODE
    {

        /// <summary>
        /// 阿凡达名人名言查询失败
        /// </summary>
        [Description("阿凡达名人名言查询失败")]
        [HttpCorresponding(HttpStatusCode.BadRequest)]
        AVATAR_DATA_FETCH_FAMOUS_FAILED,

        /// <summary>
        /// 阿凡达名人名言服务不可用
        /// </summary>
        [Description("阿凡达名人名言服务不可用")]
        [HttpCorresponding(HttpStatusCode.Forbidden)]
        AVATAR_DATA_FETCH_FAMOUS_NOT_UNAVAILABLE,
    }

    public class SentenceSample : IJsonSampleModel
    {
        public object GetErrorSampleModel()
        {
            return new ResponseContentModel(SENTENCE_FETCH_RETURN_CODE.AVATAR_DATA_FETCH_FAMOUS_NOT_UNAVAILABLE, "api/senetences/");
        }

        public object GetRequestSampleModel()
        {
            return null;
        }

        public object GetResponseSampleModel()
        {
            return new Sentence
            {
                FamousName = "欧文",
                FamousSaying = "真理惟一可靠的标准就是永远自相符合。"
            };
        }
    }
}