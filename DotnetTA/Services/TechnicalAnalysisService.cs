using DotnetTA.Models;
using DotnetTA.Repositories.Interfaces;
using DotnetTA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetTA.Services
{
    public class TechnicalAnalysisService : ITechnicalAnalysisService
    {
        private readonly ITechnicalAnalysisRepository technicalAnalysisRepository;
        private readonly ITickerInfoRepository tickerInfoRepository;

        public TechnicalAnalysisService(ITechnicalAnalysisRepository technicalAnalysisRepository, ITickerInfoRepository tickerInfoRepository)
        {
            this.technicalAnalysisRepository = technicalAnalysisRepository;
            this.tickerInfoRepository = tickerInfoRepository;
        }

        public async Task<IEnumerable<RsiModel>> GetRSIAsync()
        {
            return await this.technicalAnalysisRepository.GetRSIAsync();
        }

        public async Task InsertRSIAsync()
        {
            var rsiPeriods = new List<int>() { 2, 6, 14 };
            var allTickers = await this.tickerInfoRepository.GetAllTickers();
            foreach(var ticker in allTickers)
            {
                var dailyInfo = await this.tickerInfoRepository.GetDailyInfoByTicker(ticker.Ticker);
                if (!dailyInfo.Any()) continue;
                var rsiModel = new RsiModel()
                {
                    Ticker = ticker.Ticker,
                    DateAdded = dailyInfo.Last().DateAdded
                };
                foreach (var period in rsiPeriods)
                {
                    try
                    {
                        var periodAdjClose = dailyInfo.Select(i => i.AdjClose).TakeLast(period + 1);
                        var rsi = CalculateRsi(periodAdjClose);
                        if (period == 2)
                        {
                            rsiModel.TwoDayRsi = rsi;
                        }
                        else if (period == 6)
                        {
                            rsiModel.SixDayRsi = rsi;
                        }
                        else if (period == 14)
                        {
                            rsiModel.FourteenDayRsi = rsi;
                        }
                    }
                    catch (Exception) 
                    {
                        Console.WriteLine("Exception");
                    }
                    
                }
                await this.technicalAnalysisRepository.InsertRSIByTickerAsync(rsiModel);
            }
        }

        private static decimal CalculateRsi(IEnumerable<decimal> closePrices)
        {
            decimal Tolerance = 10e-20M;
            var prices = closePrices as decimal[] ?? closePrices.ToArray();

            decimal sumGain = 0;
            decimal sumLoss = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                var difference = prices[i] - prices[i - 1];
                if (difference >= 0)
                {
                    sumGain += difference;
                }
                else
                {
                    sumLoss -= difference;
                }
            }
            
            if (sumGain == 0) return 0;
            if (Math.Abs(sumLoss) < Tolerance) return 100;

            var relativeStrength = ((sumGain/(prices.Length - 1)) / (sumLoss/(prices.Length - 1)));
            return 100.0M - (100.0M / (1M + relativeStrength));
        }
    }
}
