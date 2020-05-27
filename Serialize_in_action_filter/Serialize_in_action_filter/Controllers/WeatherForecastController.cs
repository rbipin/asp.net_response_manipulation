using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Serialize_in_action_filter.Controllers
{
    [ApiController]
    [Route("weather")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("washington")]
        [WashingtonOuputFilter]
        public WeatherForecast GetWeatherWashington()
        {
            var rng = new Random();
            return new WeatherForecast
            {
                Date = DateTime.Now,
                Temperature = new Temperature()
                {
                    Celsius = rng.Next(-20, 55)
                },
                Summary = Summaries[rng.Next(Summaries.Length)]
            };
        }

        [HttpGet("quebeccanada")]
        [QubecCanadaOuputFilter]
        public WeatherForecast GetWeatherQubecCanada()
        {
            var rng = new Random();
            return new WeatherForecast
            {
                Date = DateTime.Now,
                Temperature = new Temperature()
                {
                    Celsius = rng.Next(-20, 55)
                },
                Summary = Summaries[rng.Next(Summaries.Length)]
            };
        }
    }
}
