using DotnetTA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetTA.Repositories.Interfaces
{
    public interface ITickerInfoRepository
    {
        Task<IEnumerable<Tickers>> GetAllTickers();
        Task<IEnumerable<TickerDailyInfo>> GetDailyInfoByTicker(string ticker);
        Task InsertTicker(string ticker);
        Task InsertDailyInfo(TickerDailyInfo tickerDailyInfo);
    }
}
