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
    public class FocusFetchAsyncRequest
    {

    }

    public enum FOCUS_FETCH_RETURN_CODE
    {
        /// <summary>
        /// 任务清单查询失败
        /// </summary>
        [Description("任务清单查询失败")]
        [HttpCorresponding(HttpStatusCode.BadRequest)]
        FOCUS_FETCH_FAILED
    }

    public class FocusFetchAsyncSample : IJsonSampleModel
    {
        public object GetErrorSampleModel()
        {
            return new ResponseContentModel(FOCUS_FETCH_RETURN_CODE.FOCUS_FETCH_FAILED, "api/foucs");
        }

        public object GetRequestSampleModel()
        {
            return null;
        }

        public object GetResponseSampleModel()
        {
            return new List<Focus> {
                new Focus{
                    key = "1",
                    Content = "Don't let perfection become procrastination. Do it now.",
                    Status = Status.Completed
                },
                new Focus{
                    key = "2",
                    Content = "The wisest mind has something yet to learn.",
                    Status = Status.Normal
                }
            };
        }
    }
}
