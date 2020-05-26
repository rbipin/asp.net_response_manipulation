using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OutputFormatter.API;
using OutputFormatter.Controllers;
using System;

namespace OutputFormatter.Controllers
{
    [ApiController]
    [Route("weather")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastController()
        {

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

        [HttpGet("qubeccanada")]
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
