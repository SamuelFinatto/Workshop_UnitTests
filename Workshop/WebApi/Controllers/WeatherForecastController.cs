using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Workshop.Helpers;

namespace Workshop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly Tools _tools;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, Tools tools)
        {
            _logger = logger;
            _tools = tools;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> GetForecasts()
        {
            return _tools. GetRandomForecasts();
        }

        [HttpGet("permission")]
        public IEnumerable<string> GetPermissions(IEnumerable<int> permissions)
        {
            return _tools.GetUserPermission(permissions);
        }
    }
}
