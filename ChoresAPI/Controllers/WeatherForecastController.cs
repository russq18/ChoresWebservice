using System;
using System.Collections.Generic;
using System.Linq;
using ChoresAPI.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ChoresAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        #region Constructor and fields for DI
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        #endregion

        [HttpGet]
        [Authorize(Policy = Policies.OnlyParents)]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("only-parents")]
        [Authorize(Policy = Policies.OnlyParents)]
        public IActionResult OnlyParents()
        {
            var message = $"Hello from {nameof(OnlyParents)}";
            return new ObjectResult(message);
        }

        [HttpGet("anyone")]
        public IActionResult Anyone()
        {
            var message = $"Hello from {nameof(Anyone)}";
            return new ObjectResult(message);
        }

        [HttpGet("only-authenticated")]
        [Authorize]
        public IActionResult OnlyAuthenticated()
        {
            var message = $"Hello from {nameof(OnlyAuthenticated)}";
            return new ObjectResult(message);
        }

        [HttpGet("only-children")]
        [Authorize(Policy = Policies.OnlyChildren)]
        public IActionResult OnlyChildren()
        {
            var message = $"Hello from {nameof(OnlyChildren)}";
            return new ObjectResult(message);
        }
    }
}
