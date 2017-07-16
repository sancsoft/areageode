using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using AreaGeode.Library.Models;

namespace AreaGeode.Library.DAL
{
    public class AreaGeodeViewReposiitory
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
    }
}
