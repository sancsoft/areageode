using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AreaGeode.Library.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AreaGeode.API.Controllers
{
    [Route("api/[controller]")]
    public class AreaGeodeController : Controller
    {
        // GET api/areaCode
        [HttpGet("{areaCode}", Name ="GetAreaGeode")]
        public AreaGeodeView Get(int areaCode)
        {
            return new AreaGeodeView { AreaCode = areaCode, StateAbbr = "OH", StateName = "Ohio", CountryAbbr = "US" };
        }
    }
}
