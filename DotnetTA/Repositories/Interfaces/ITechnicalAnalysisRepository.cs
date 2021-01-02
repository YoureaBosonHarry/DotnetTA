using DotnetTA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetTA.Repositories.Interfaces
{
    public interface ITechnicalAnalysisRepository
    {
        Task<IEnumerable<RsiModel>> GetRSIAsync();
        Task InsertRSIByTickerAsync(RsiModel rsiModel);
    }
}
