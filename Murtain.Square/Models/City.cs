using Murtain.SDK;
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
    public class City
    {
        /// <summary>
        /// 国家
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string province { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string city { get; set; }
    }


    public enum FETCH_CITY_RETURN_CODE
    {
        /// <summary>
        /// 无效的IP地址
        /// </summary>
        [Description("无效的IP地址")]
        [HttpCorresponding(HttpStatusCode.BadRequest)]
        INVALID_IP_ADDRESS,

        /// <summary>
        /// 查询不到匹配的城市
        /// </summary>
        [Description("查询不到匹配的城市")]
        [HttpCorresponding(HttpStatusCode.NotFound)]
        CANT_FOUND_MATCH_CITY,

        /// <summary>
        /// 新浪城市查询服务不可用
        /// </summary>
        [Description("新浪城市查询服务不可用")]
        [HttpCorresponding(HttpStatusCode.Forbidden)]
        SINA_CITY_QUERY_SERVICE_NOT_UNAVAILABLE,


    }
    public class FetchCitySample : IJsonSampleModel
    {
        public object GetErrorSampleModel()
        {
            return new ResponseContentModel(FETCH_CITY_RETURN_CODE.SINA_CITY_QUERY_SERVICE_NOT_UNAVAILABLE, "api/weather/city");
        }

        public object GetRequestSampleModel()
        {
            return null;
        }

        public object GetResponseSampleModel()
        {
            return new City
            {
                country = "中国",
                city = "上海",
                province = "上海"
            };
        }
    }
}