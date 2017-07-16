using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AreaGeode.Library.Models;
using AreaGeode.Library.DAL;

namespace AreaGeode.API.Controllers
{
    [Route("api/[controller]")]
    public class AreaGeodeController : Controller
    {
        IConfiguration _configuration;
        public AreaGeodeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Get geolocation information for an Area Code in the US or Canada
        /// </summary>
        /// <param name="areaCode">area code in US or Canada</param>
        /// <response code="200">geolocation info for area code</response>
        /// <response code="404">area code not found</response>
        /// <response code="500">general error</response>
        [HttpGet("{areaCode}", Name ="GetAreaGeode")]
        public AreaGeodeView Get(int areaCode)
        {
            AreaGeodeViewReposiitory repo = new AreaGeodeViewReposiitory(_configuration);
            AreaGeodeView o = repo.Find(areaCode);
            if (o == null)
            {
                throw new HttpException("Area Code not found", System.Net.HttpStatusCode.NotFound);
            }
            return o;
        }
    }
}
