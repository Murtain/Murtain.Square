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
    /// <summary>
    /// 实时天气
    /// </summary>
    public class WeatherRealTime
    {
        /// <summary>
        /// 城市名称
        /// </summary>
        public string city_name { get; set; }
        /// <summary>
        /// 天气详情
        /// </summary>
        public WeatherDetail weather { get; set; }
    }

    /// <summary>
    /// 天气详情
    /// </summary>
    public class WeatherDetail
    {
        /// <summary>
        /// 湿度
        /// </summary>
        public int? humidity { get; set; }
        /// <summary>
        /// 温度
        /// </summary>
        public int? temperature { get; set; }
        /// <summary>
        /// 天气（晴，多云，雨）
        /// </summary>
        public string info { get; set; }
        /// <summary>
        /// 图片资源ID
        /// </summary>
        public int? img { get; set; }
    }

    /// <summary>
    /// 天气信息
    /// </summary>
    public class Weather
    {
        /// <summary>
        /// 实时天气信息
        /// </summary>
        public WeatherRealTime realtime { get; set; }
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
        /// 错误码
        /// </summary>
        public int error_code { get; set; }
        /// <summary>
        /// 错误原因
        /// </summary>
        public string reason { get; set; }
    }

    public enum FETCH_WEATHER_RETURN_CODE
    {
        /// <summary>
        /// 阿凡达天气查询失败
        /// </summary>
        [Description("阿凡达天气查询失败")]
        [HttpCorresponding(HttpStatusCode.Forbidden)]
        AVATAR_DATA_FETCH_WEATHER_FAILED,
        /// <summary>
        /// 阿凡达天气查询数据服务不可用
        /// </summary>
        [Description("阿凡达天气查询数据服务不可用")]
        [HttpCorresponding(HttpStatusCode.Forbidden)]
        AVATAR_DATA_FETCH_WEATHER_NOT_UNAVAILABLE,
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
            return new ResponseContentModel(FETCH_WEATHER_RETURN_CODE.AVATAR_DATA_FETCH_WEATHER_NOT_UNAVAILABLE, "api/weather");
        }

        public object GetRequestSampleModel()
        {
            return null;
        }

        public object GetResponseSampleModel()
        {
            return new Weather
            {
                realtime = new WeatherRealTime
                {
                    city_name = "上海",
                    weather = new WeatherDetail
                    {
                        humidity = 54,
                        img = 1,
                        info = "多云",
                        temperature = 35
                    }
                }
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
                realtime = new WeatherRealTime
                {
                    city_name = "上海",
                    weather = new WeatherDetail
                    {
                        humidity = 54,
                        img = 1,
                        info = "多云",
                        temperature = 35
                    }
                }
            };
        }
    }
}