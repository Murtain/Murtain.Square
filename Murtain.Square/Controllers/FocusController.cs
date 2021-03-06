﻿using Murtain.SDK.Attributes;
using Murtain.Square.Application;
using Murtain.Square.SDK.Focus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Murtain.Square.Controllers
{
    /// <summary>
    /// 任务清单
    /// </summary>
    public class FocusController : ApiController
    {
        private readonly IFocusApplicationService focusApplicationService;
        public FocusController(IFocusApplicationService focusApplicationService)
        {
            this.focusApplicationService = focusApplicationService;
        }

        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/focus")]
        [ReturnCode(typeof(FOCUS_INSERT_RETURN_CODE))]
        [JsonSample(typeof(FocusInsertAsyncSample))]
        public async Task FocusAddAsync([FromBody] FocusInsertAsyncRequest input)
        {
            await focusApplicationService.FocusAddAsync(input.Content);
        }
        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/focus/{id}")]
        public async Task FocusRemoveAsync(long id)
        {
            await focusApplicationService.FocusRemoveAsync(id);
        }
        /// <summary>
        /// 标记/取消标记任务完成状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/focus-complete/{id}")]
        public async Task FocusToggleCompletedAsync(long id)
        {
            await focusApplicationService.FocusToggleCompletedAsync(id);
        }
        /// <summary>
        /// 星标任务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/focus-star/{id}")]
        public async Task FocusStarAsync(long id)
        {
            await focusApplicationService.FocusStarAsync(id);
        }
        /// <summary>
        /// 获取任务清单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/focus")]
        [ReturnCode(typeof(FOCUS_FETCH_RETURN_CODE))]
        [JsonSample(typeof(FocusFetchAsyncSample))]
        public async Task<List<SDK.Focus.Focus>> GetFocusAsync()
        {
            return await focusApplicationService.GetFocusAsync();
        }
        /// <summary>
        /// 获取星标任务
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/focus-star")]
        public async Task<SDK.Focus.Focus> GetFocusStarAsync()
        {
            return await focusApplicationService.GetFocusStarAsync();
        }
    }
}
