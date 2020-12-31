using DotnetTA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetTA.Services.Interfaces
{
    public interface ITickerInfoService
    {
        Task<IEnumerable<Tickers>> GetTickersAsync();
        Task<IEnumerable<TickerDailyInfo>> GetDailyInfoByTickerAsync(string ticker);
        Task InsertTickerAsync(string ticker);
        Task InsertDailyInfoAsync(TickerDailyInfo tickerDailyInfo);
    }
}
