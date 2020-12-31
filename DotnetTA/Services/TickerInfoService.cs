using DotnetTA.Models;
using DotnetTA.Repositories;
using DotnetTA.Repositories.Interfaces;
using DotnetTA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetTA.Services
{
    public class TickerInfoService : ITickerInfoService
    {
        private readonly ITickerInfoRepository tickerInfoRepository;

        public TickerInfoService(ITickerInfoRepository tickerInfoRepository) 
        {
            this.tickerInfoRepository = tickerInfoRepository;
        }

        public async Task<IEnumerable<Tickers>> GetTickersAsync() 
        {
            return await this.tickerInfoRepository.GetAllTickers();
        }

        public async Task InsertTickerAsync(string ticker) 
        {
            await this.tickerInfoRepository.InsertTicker(ticker);
        }

        public async Task<IEnumerable<TickerDailyInfo>> GetDailyInfoByTickerAsync(string ticker)
        {
            return await this.tickerInfoRepository.GetDailyInfoByTicker(ticker);
        }

        public async Task InsertDailyInfoAsync(TickerDailyInfo tickerDailyInfo)
        {
            await this.tickerInfoRepository.InsertDailyInfo(tickerDailyInfo);
        }
    }
}
