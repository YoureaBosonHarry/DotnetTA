using DotnetTA.Models;
using DotnetTA.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetTA.Controllers
{
    [ApiController]
    [Route("TechnicalAnalysis")]
    public class TechnicalAnalysisController : Controller
    {
        private readonly ITechnicalAnalysisService technicalAnalysisService;

        public TechnicalAnalysisController(ITechnicalAnalysisService technicalAnalysisService)
        {
            this.technicalAnalysisService = technicalAnalysisService;
        }

        [HttpGet]
        [Route("GetRSI")]
        public async Task<ActionResult<IEnumerable<RsiModel>>> GetRsiAsync()
        {
            return Ok(await this.technicalAnalysisService.GetRSIAsync());
        }

        [HttpPost]
        [Route("InsertRSI")]
        public async Task<ActionResult> InsertRSIAsync([FromBody]string ticker)
        {
            await this.technicalAnalysisService.InsertRSIAsync(ticker);
            return Ok();
        }

        [HttpPost]
        [Route("InsertSMA")]
        public async Task<ActionResult> InsertSMAAsync([FromBody] string ticker)
        {
            await this.technicalAnalysisService.InsertSMAAsync(ticker);
            return Ok();
        }
    }
}
