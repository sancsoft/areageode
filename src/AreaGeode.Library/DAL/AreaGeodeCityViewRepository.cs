using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using AreaGeode.Library.Models;

namespace AreaGeode.Library.DAL
{
    public class AreaGeodeCityViewReposiitory
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
    }
}
