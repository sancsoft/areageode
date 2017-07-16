using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AreaGeode.Library.Models;
using AreaGeode.Library.DAL;

namespace AreaGeode.API.Controllers
{
    /// <summary>
    /// Get the cities and geolocations associated with an area code
    /// </summary>
    [Route("api/[controller]")]
    public class AreaGeodeCityController : Controller
    {
        IConfiguration _configuration;

        /// <summary>
        /// Construct with configuration so we can make repos
        /// </summary>
        /// <param name="configuration"></param>
        public AreaGeodeCityController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Get a list of cities and their geolocations associated with an area code
        /// </summary>
        /// <param name="areaCode">3-digit area code in US or Canada</param>
        /// <returns>List of cities associated with the areacode and their geolocation info</returns>
        [HttpGet("{areaCode}", Name = "GetAreaGeodeCities")]
        public List<AreaGeodeCityView> Get(int areaCode)
        {
            AreaGeodeCityViewReposiitory repo = new AreaGeodeCityViewReposiitory(_configuration);
            return repo.FindByAreaCode(areaCode).ToList();
        }
    }
}
