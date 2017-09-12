using Murtain.SDK;
using Murtain.SDK.Attributes;
using Murtain.SDK.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Murtain.Square.SDK.Focus
{
    public class Focus
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [MaxLength(40)]
        public string Content { get; set; }
        /// <summary>
        /// 任务状态
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
    }

    /// <summary>
    /// 任务状态
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// 焦点任务
        /// </summary>
        [Description("焦点任务")]
        Focus,
        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        Normal,
        /// <summary>
        /// 已完成
        /// </summary>
        [Description("已完成")]
        Completed,
        /// <summary>
        /// 已过期
        /// </summary>
        [Description("已过期")]
        Expired,
    }

    public enum FOCUS_COMPLETED_RETURN_CODE
    {
        /// <summary>
        /// 任务不存在
        /// </summary>
        [Description("任务不存在")]
        [HttpCorresponding(HttpStatusCode.BadRequest)]
        FOCUS_NOT_EXSIT,
    }

    public enum FOCUS_REMOVE_RETURN_CODE
    {
        /// <summary>
        /// 任务不存在
        /// </summary>
        [Description("任务不存在")]
        [HttpCorresponding(HttpStatusCode.BadRequest)]
        FOCUS_NOT_EXSIT,
    }

}
