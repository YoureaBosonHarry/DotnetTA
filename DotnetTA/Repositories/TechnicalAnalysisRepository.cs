using Dapper;
using DotnetTA.Models;
using DotnetTA.Repositories.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetTA.Repositories
{
    public class TechnicalAnalysisRepository : ITechnicalAnalysisRepository
    {
        private readonly string connectionString;

        public TechnicalAnalysisRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<IEnumerable<RsiModel>> GetRSIAsync()
        {
            using (var conn = new NpgsqlConnection(this.connectionString))
            {
                var results = await conn.QueryAsync<RsiModel>("TechnicalIndicators.GetDailyRsi",commandType: System.Data.CommandType.StoredProcedure);
                return results;
            }
        }

        public async Task InsertRSIByTickerAsync(RsiModel rsiModel)
        {
            using (var conn = new NpgsqlConnection(this.connectionString))
            {
                var sqlParams = new DynamicParameters();
                sqlParams.Add("_Ticker", rsiModel.Ticker);
                sqlParams.Add("_DateAdded", rsiModel.DateAdded);
                sqlParams.Add("_TwoDayRsi", rsiModel.TwoDayRsi);
                sqlParams.Add("_SixDayRsi", rsiModel.SixDayRsi);
                sqlParams.Add("_FourteenDayRsi", rsiModel.FourteenDayRsi);
                await conn.ExecuteAsync("TechnicalIndicators.InsertDailyRsi", sqlParams, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task InsertSMAByTickerAsync(SMA sma)
        {
            using (var conn = new NpgsqlConnection(this.connectionString))
            {
                var sqlParams = new DynamicParameters();
                sqlParams.Add("_Ticker", sma.Ticker);
                sqlParams.Add("_DateAdded", sma.DateAdded);
                sqlParams.Add("_FiftyDaySMA", sma.FiftyDaySMA);
                sqlParams.Add("_TwoHundredDaySMA", sma.TwoHundredDaySMA);
                await conn.ExecuteAsync("TechnicalIndicators.InsertDailyRsi", sqlParams, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
