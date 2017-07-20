using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AreaGeode.Library.Models;
using AreaGeode.Library.DAL;

namespace AreaGeode.API.Controllers
{
    /// <summary>
    /// Web API controller to support gettng area code geolocation
    /// information by area code
    /// </summary>
    [Route("api/[controller]")]
    public class AreaGeodeController : Controller
    {
        IAreaGeodeViewRepository _repo;

        /// <summary>
        /// Construct with the configuration so that we can create repos
        /// </summary>
        /// <param name="repo"></param>
        public AreaGeodeController(IAreaGeodeViewRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Get geolocation information for an Area Code in the US or Canada
        /// </summary>
        /// <param name="areaCode">area code in US or Canada</param>
        /// <response code="200">geolocation info for area code</response>
        /// <response code="404">area code not found</response>
        /// <response code="500">general error</response>
        [HttpGet("{areaCode}")]
        public AreaGeodeView Get(int areaCode)
        {
            //AreaGeodeViewReposiitory repo = new AreaGeodeViewReposiitory(_configuration);
            AreaGeodeView o = _repo.Find(areaCode);
            if (o == null)
            {
                throw new HttpException("Area Code not found", System.Net.HttpStatusCode.NotFound);
            }
            return o;
        }

        /// <summary>
        /// Get the geolocation information for all area codes within a state or province
        /// </summary>
        /// <param name="stateAbbr">Two character state identifier</param>
        /// <returns>list of area geodes in the state</returns>
        [HttpGet]
        public List<AreaGeodeView> Get([FromQuery]string stateAbbr)
        {
            return _repo.FindByState(stateAbbr).ToList();
        }
    }
}
