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

namespace Murtain.Square.Models
{
    /// <summary>
    /// 天气信息
    /// </summary>
    public class Weather
    {
        /// <summary>
        /// 城市
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 天气
        /// </summary>
        public string weather { get; set; }
        /// <summary>
        /// 温度
        /// </summary>
        public string temp { get; set; }
    }

    /// <summary>
    /// 天气查询服务返回结果
    /// </summary>
    public class FetchWeatherResponse
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public Weather result { get; set; }
        /// <summary>
        /// 状态码
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 附加消息
        /// </summary>
        public string msg { get; set; }
    }

    public enum FETCH_WEATHER_RETURN_CODE
    {
        /// <summary>
        /// 天气查询失败
        /// </summary>
        [Description("天气查询失败")]
        [HttpCorresponding(HttpStatusCode.Forbidden)]
        FETCH_WEATHER_FAILED,
        /// <summary>
        /// 天气查询数据服务不可用
        /// </summary>
        [Description("天气查询数据服务不可用")]
        [HttpCorresponding(HttpStatusCode.Forbidden)]
        FETCH_WEATHER_NOT_UNAVAILABLE,
    }

    public enum FETCH_WEATHER_AUTO_RETURN_CODE
    {
        /// <summary>
        /// 查询客户端IP城市失败
        /// </summary>
        [Description("查询客户端IP城市失败")]
        [HttpCorresponding(HttpStatusCode.Forbidden)]
        FETCH_CLIENT_IP_CITY_FALIED,
        /// <summary>
        /// 查询客户端天气失败
        /// </summary>
        [Description("查询客户端天气失败")]
        [HttpCorresponding(HttpStatusCode.Forbidden)]
        FETCH_CLIENT_CITY_WEATHER_FALIED
    }

    public class FetchWeatherSample : IJsonSampleModel
    {
        public object GetErrorSampleModel()
        {
            return new ResponseContentModel(FETCH_WEATHER_RETURN_CODE.FETCH_WEATHER_NOT_UNAVAILABLE, "api/weather");
        }

        public object GetRequestSampleModel()
        {
            return null;
        }

        public object GetResponseSampleModel()
        {
            return new Weather
            {
                city = "上海",
                weather = "多云",
                temp = "24"
            };
        }
    }

    public class FetchWeatherAutoSample : IJsonSampleModel
    {
        public object GetErrorSampleModel()
        {
            return new ResponseContentModel(FETCH_WEATHER_AUTO_RETURN_CODE.FETCH_CLIENT_IP_CITY_FALIED, "api/weather");
        }

        public object GetRequestSampleModel()
        {
            return null;
        }

        public object GetResponseSampleModel()
        {
            return new Weather
            {
                city = "上海",
                weather = "多云",
                temp = "24"
            };
        }
    }
}