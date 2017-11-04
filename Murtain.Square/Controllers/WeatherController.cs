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
    /// 天气查询
    /// </summary>
    public class WeatherController : ApiController
    {
        /// <summary>
        /// 根据IP查询城市信息
        /// </summary>
        /// <param name="ip">ip（220.248.56.150）</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/city/{ip}")]
        [ReturnCode(typeof(FETCH_CITY_RETURN_CODE))]
        [JsonSample(typeof(FetchCitySample))]
        public async Task<City> FetchCityAsync(string ip)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync("http://int.dpool.sina.com.cn/iplookup/iplookup.php?format=json&ip=" + ip);


                if (string.IsNullOrEmpty(response))
                {
                    return null;
                }

                if (response == "-3")
                {
                    throw new UserFriendlyException(FETCH_CITY_RETURN_CODE.INVALID_IP_ADDRESS);
                }

                if (response == "-2")
                {
                    throw new UserFriendlyException(FETCH_CITY_RETURN_CODE.CANT_FOUND_MATCH_CITY);
                }

                return JsonConvert.DeserializeObject<City>(response);


            }
            catch (WebException)
            {
                throw new UserFriendlyException(FETCH_CITY_RETURN_CODE.SINA_CITY_QUERY_SERVICE_NOT_UNAVAILABLE);
            }
        }
        /// <summary>
        /// 天气查询
        /// </summary>
        /// <param name="city_name">城市（"上海"，"芜湖"）</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/weather/{city_name}")]
        [ReturnCode(typeof(FETCH_WEATHER_RETURN_CODE))]
        [JsonSample(typeof(FetchWeatherSample))]
        public async Task<Weather> FetchWeatherAsync(string city_name)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "APPCODE 1eab80f810ec47688398a4b50a4e2b48");
                var response = await client.GetStringAsync("http://jisutqybmf.market.alicloudapi.com/weather/query?city=" + city_name);

                if (string.IsNullOrEmpty(response))
                {
                    return null;
                }

                var resp = JsonConvert.DeserializeObject<FetchWeatherResponse>(response);

                if (resp == null || resp.status != "0")
                {
                    throw new UserFriendlyException(FETCH_WEATHER_RETURN_CODE.FETCH_WEATHER_FAILED);
                }

                return resp.result;

            }
            catch (WebException)
            {
                throw new UserFriendlyException(FETCH_WEATHER_RETURN_CODE.FETCH_WEATHER_NOT_UNAVAILABLE);
            }
        }

        /// <summary>
        /// 天气查询(IP地址定位)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/weather")]
        [ReturnCode(typeof(FETCH_WEATHER_AUTO_RETURN_CODE))]
        [JsonSample(typeof(FetchWeatherAutoSample))]
        public async Task<Weather> FetchWeatherAutoAsync()
        {
            string cityName = string.Empty;
            try
            {
                var ip = GetIp();
                var city = await FetchCityAsync(ip);
                cityName = city?.city;
            }
            catch (Exception)
            {
                throw new UserFriendlyException(FETCH_WEATHER_AUTO_RETURN_CODE.FETCH_CLIENT_IP_CITY_FALIED);
            }

            try
            {
                var weather = await FetchWeatherAsync(cityName);
                return weather;
            }
            catch (Exception)
            {
                throw new UserFriendlyException(FETCH_WEATHER_AUTO_RETURN_CODE.FETCH_CLIENT_CITY_WEATHER_FALIED);
            }
        }


        public static string GetIp()
        {
            string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }

            return result;
        }
    }
}
