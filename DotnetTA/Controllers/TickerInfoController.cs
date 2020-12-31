using DotnetTA.Models;
using DotnetTA.Services;
using DotnetTA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotnetTA.Controllers
{
    [ApiController]
    [Route("TickerInfo")]
    public class TickerInfoController : ControllerBase
    {
        private readonly ITickerInfoService tickerInfoService;

        public TickerInfoController(ITickerInfoService tickerInfoService)
        {
            this.tickerInfoService = tickerInfoService;
        }

        [HttpGet]
        [Route("GetTickers")]
        public async Task<ActionResult<IEnumerable<Tickers>>> GetTickersAsync()
        {
            return Ok(await this.tickerInfoService.GetTickersAsync());
        }

        [HttpPost]
        [Route("InsertTicker")]
        public async Task<ActionResult> InsertTickerAsync([FromQuery]string ticker) 
        {
            await this.tickerInfoService.InsertTickerAsync(ticker);
            return Ok();
        }

        [HttpGet]
        [Route("GetDailyInfoByTicker")]
        public async Task<ActionResult<IEnumerable<TickerDailyInfo>>> GetDailyInfoByTickerAsync([FromQuery]string ticker)
        {
            return Ok(await this.tickerInfoService.GetDailyInfoByTickerAsync(ticker));
        }

        [HttpPost]
        [Route("InsertDailyInfo")]
        public async Task<ActionResult<IEnumerable<TickerDailyInfo>>> GetDailyInfoByTickerAsync([FromBody] TickerDailyInfo tickerDailyInfo)
        {
            await this.tickerInfoService.InsertDailyInfoAsync(tickerDailyInfo);
            return Ok();
        }
    }
}
