using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CodingChallengeAPI.Models;

namespace CodingChallengeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        public IOptions<ApplicationSettings> _applicationSettings { get; }

        public ApiContext _apiContext;

        public HomeController(ILogger<HomeController> logger, IOptions<ApplicationSettings> applicationSettings, ApiContext apiContext)
        {
            _logger = logger;
            _applicationSettings = applicationSettings;
            _apiContext = apiContext;
        }                

        [HttpGet("getASum/{x}/{y}")]
        public int getASum(int x, int y)
        {
            var result = x + y;
            _apiContext.SaveOperation("getASum", result);
            return result;
        }

        [HttpGet("getAProduct/{a}")]
        public int getAProduct(int a)
        {
            var result = a * 2;
            _apiContext.SaveOperation("getASum", result);
            return result;
        }

        [HttpGet("getAPower/{s}")]
        public double getAPower(int s)
        {
            var result = Math.Pow(s, 2);
            _apiContext.SaveOperation("getASum", result);
            return result;
        }


        [HttpGet("operations")]
        public List<Operation> GetOperations()
        {
            return _apiContext.Operations.ToList<Operation>();
        }
    }
}
