using Dapper;
using DotnetTA.Repositories.Interfaces;
using DotnetTA.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;
using System.Data;

namespace DotnetTA.Repositories
{
    public class TickerInfoRepository: ITickerInfoRepository
    {
        private readonly string connectionString;

        public TickerInfoRepository(string connectionString) 
        {
            this.connectionString = connectionString;
        }

        public async Task<IEnumerable<Tickers>> GetAllTickers()
        {
            using (var conn = new NpgsqlConnection(this.connectionString))
            {
                var result = await conn.QueryAsync<Tickers>("MarketData.GetTickers", commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task InsertTicker(string ticker)
        {
            using (var conn = new NpgsqlConnection(this.connectionString)) 
            {
                var sqlParams = new DynamicParameters();
                sqlParams.Add("_Ticker", ticker);
                await conn.ExecuteAsync("MarketData.InsertTicker", sqlParams, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<TickerDailyInfo>> GetDailyInfoByTicker(string ticker)
        {
            using (var conn = new NpgsqlConnection(this.connectionString))
            {
                var sqlParams = new DynamicParameters();
                sqlParams.Add("_Ticker", ticker);
                var result = await conn.QueryAsync<TickerDailyInfo>("MarketData.GetDailyInfoByTicker", sqlParams, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task InsertDailyInfo(TickerDailyInfo tickerDailyInfo) 
        {
            using (var conn = new NpgsqlConnection(this.connectionString))
            {
                var sqlParams = new DynamicParameters();
                sqlParams.Add("_Ticker", tickerDailyInfo.Ticker);
                sqlParams.Add("_DateAdded", tickerDailyInfo.DateAdded);
                sqlParams.Add("_DailyLow", tickerDailyInfo.DailyLow);
                sqlParams.Add("_DailyHigh", tickerDailyInfo.DailyHigh);
                sqlParams.Add("_DailyOpen", tickerDailyInfo.DailyOpen);
                sqlParams.Add("_DailyClose", tickerDailyInfo.DailyClose);
                sqlParams.Add("_Volume", tickerDailyInfo.Volume);
                sqlParams.Add("_AdjClose", tickerDailyInfo.AdjClose);
                await conn.ExecuteAsync("MarketData.InsertDailyInfo", sqlParams, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
