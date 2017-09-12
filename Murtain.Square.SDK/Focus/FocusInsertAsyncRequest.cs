using Murtain.SDK.Attributes;
using Murtain.SDK.Models;
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
    public class FocusInsertAsyncRequest
    {
        /// <summary>
        /// 任务内容
        /// </summary>
        [Required]
        [MaxLength(40)]
        public string Content { get; set; }
    }

    public enum FOCUS_INSERT_RETURN_CODE
    {
        /// <summary>
        /// 已过期
        /// </summary>
        [Description("任务添加失败")]
        [HttpCorresponding(HttpStatusCode.BadRequest)]
        FOCUS_ADD_FAILED
    }

    public class FocusInsertAsyncSample : IJsonSampleModel
    {
        public object GetErrorSampleModel()
        {
            return new ResponseContentModel(FOCUS_INSERT_RETURN_CODE.FOCUS_ADD_FAILED, "api/foucs");
        }

        public object GetRequestSampleModel()
        {
            return null;
        }

        public object GetResponseSampleModel()
        {
            return null;
        }
    }
}
