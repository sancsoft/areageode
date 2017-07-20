using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using AreaGeode.Library.Models;
using AreaGeode.Library.DAL;

namespace AreaGeode.Library.Dapper
{
    public class AreaGeodeCityViewReposiitory : IAreaGeodeCityViewRepository
    {
        private readonly IDbConnection _db;

        public AreaGeodeCityViewReposiitory(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration["Database:ConnectionString"]);
        }
        public IEnumerable<AreaGeodeCityView> FindByAreaCode(int areaCode)
        {
            return _db.Query<AreaGeodeCityView>("SELECT * FROM AreaGeodeCitiesView WHERE AreaCode=@AreaCode", new { AreaCode = areaCode });
        }
        public IEnumerable<AreaGeodeCityView> FindByCity(string cityName, string stateAbbr)
        {
            string q = "SELECT * FROM AreaGeodeCitiesView WHERE City=@City";
            if (!string.IsNullOrEmpty(stateAbbr))
            {
                q += " AND StateAbbr=@StateAbbr";
            }
            return _db.Query<AreaGeodeCityView>(q, new { City = cityName, StateAbbr = stateAbbr });
        }
    }
}
