﻿using Murtain.SDK;
using Murtain.SDK.Attributes;
using Murtain.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Web;

namespace Murtain.Square.Models
{
    public class SentenceRequest
    {

    }

    public class SentenceResponse
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

    public class Sentence
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string famous_name { get; set; }
        /// <summary>
        /// 名言
        /// </summary>
        public string famous_saying { get; set; }
    }

    public enum FETCH_SENTENCE_RETURN_CODE
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
            return new ResponseContentModel(FETCH_SENTENCE_RETURN_CODE.AVATAR_DATA_FETCH_FAMOUS_NOT_UNAVAILABLE, "api/senetences/");
        }

        public object GetRequestSampleModel()
        {
            return null;
        }

        public object GetResponseSampleModel()
        {
            return new Sentence
            {
                famous_name = "欧文",
                famous_saying = "真理惟一可靠的标准就是永远自相符合。"
            };
        }
    }
}