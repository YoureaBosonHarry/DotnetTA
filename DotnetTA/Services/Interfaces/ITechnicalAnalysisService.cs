using DotnetTA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetTA.Services.Interfaces
{
    public interface ITechnicalAnalysisService
    {
        Task<IEnumerable<RsiModel>> GetRSIAsync();
        Task InsertRSIAsync(string ticker);
        Task InsertSMAAsync(string ticker);
    }
}
