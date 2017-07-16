using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AreaGeode.Library.Models;
using AreaGeode.Library.DAL;

namespace AreaGeode.API.Controllers
{
    [Route("api/[controller]")]
    public class AreaGeodeCityController : Controller
    {
        IConfiguration _configuration;
        public AreaGeodeCityController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET api/areaCode
        [HttpGet("{areaCode}", Name = "GetAreaGeodeCities")]
        public List<AreaGeodeCityView> Get(int areaCode)
        {
            AreaGeodeCityViewReposiitory repo = new AreaGeodeCityViewReposiitory(_configuration);
            return repo.FindByAreaCode(areaCode).ToList();
        }
    }
}
