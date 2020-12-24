using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetTA.Repositories
{
    public class TickerRepository
    {
        private readonly string connectionString;

        public TickerRepository(string connectionString) {
            this.connectionString = connectionString;
        }

        public async Task GetAllTickers()
        {
            using (var sql = new SqlConnection(this.connectionString)){ 
            }
        }
    }
}
