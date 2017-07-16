﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AreaGeode.Library.Models;
using AreaGeode.Library.DAL;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        // GET api/areaCode
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
