using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
        IAreaGeodeCityViewRepository _repo;

        /// <summary>
        /// Construct with configuration so we can make repos
        /// </summary>
        /// <param name="repo"></param>
        public AreaGeodeCityController(IAreaGeodeCityViewRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Get a list of cities and their geolocations associated with an area code
        /// </summary>
        /// <param name="areaCode">3-digit area code in US or Canada</param>
        /// <response code="200">list of objects with cities and geolocation info for area code, empty if no macthing results found</response>
        /// <response code="500">general error</response>
        /// <returns>List of cities associated with the areacode and their geolocation info</returns>
        [HttpGet("{areaCode}", Name = "GetAreaGeodeCities")]
        public List<AreaGeodeCityView> Get(int areaCode)
        {
            return _repo.FindByAreaCode(areaCode).ToList();
        }

        /// <summary>
        /// Get geolocation information for all area codes associated with a city and optional state/province
        /// </summary>
        /// <param name="cityName">name of the city</param>
        /// <param name="stateAbbr">state or province identifier- optional</param>
        /// <returns></returns>
        [HttpGet]
        public List<AreaGeodeCityView> GetByCity([FromQuery]string cityName, [FromQuery]string stateAbbr="")
        {
            return _repo.FindByCity(cityName,stateAbbr).ToList();
        }

    }
}
