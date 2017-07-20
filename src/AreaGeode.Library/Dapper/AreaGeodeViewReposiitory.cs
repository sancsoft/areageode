using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using AreaGeode.Library.Models;
using AreaGeode.Library.DAL;

namespace AreaGeode.Library.Dapper
{
    public class AreaGeodeViewReposiitory : IAreaGeodeViewRepository
    {
        private readonly IDbConnection _db;

        public AreaGeodeViewReposiitory(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration["Database:ConnectionString"]);
        }
        public AreaGeodeView Find(int areaCode)
        {
            return _db.QuerySingleOrDefault<AreaGeodeView>("SELECT * FROM AreaGeodesView WHERE AreaCode=@AreaCode", new { AreaCode = areaCode });
        }
        public IEnumerable<AreaGeodeView> FindByState(string stateAbbr)
        {
            return _db.Query<AreaGeodeView>("SELECT * FROM AreaGeodesView WHERE StateAbbr=@StateAbbr", new { StateAbbr = stateAbbr });
        }
    }
}
