using Murtain.SDK.Attributes;
using Murtain.SDK.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Murtain.Square.SDK.Focus
{
    public class GetFocusAsyncRequest
    {

    }

    public enum FETCH_FOCUS_RETURN_CODE
    {
        /// <summary>
        /// 任务清单查询失败
        /// </summary>
        [Description("任务清单查询失败")]
        [HttpCorresponding(HttpStatusCode.BadRequest)]
        FOCUS_FETCH_FAILED
    }

    public class GetFocusSample : IJsonSampleModel
    {
        public object GetErrorSampleModel()
        {
            return new ResponseContentModel(FETCH_FOCUS_RETURN_CODE.FOCUS_FETCH_FAILED, "api/foucs");
        }

        public object GetRequestSampleModel()
        {
            return null;
        }

        public object GetResponseSampleModel()
        {
            return new List<SDK.Domain.Focus> {
                new SDK.Domain.Focus(1,"Don't let perfection become procrastination. Do it now.",Domain.Status.Completed),
                new SDK.Domain.Focus(2,"The wisest mind has something yet to learn.",Domain.Status.Normal),
                new SDK.Domain.Focus(3,"Develop success from failures. Discouragement and failure are two of the surest stepping stones to success.",Domain.Status.Expired),
                new SDK.Domain.Focus(4,"Optimism is a happiness magnet. If you stay positive, good things and good people will be drawn to you.",Domain.Status.Normal),

            };
        }
    }
}
