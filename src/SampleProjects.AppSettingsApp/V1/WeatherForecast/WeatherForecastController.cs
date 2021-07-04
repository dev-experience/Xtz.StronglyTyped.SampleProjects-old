using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SampleProjects.AppSettingsApp.Settings;

namespace SampleProjects.AppSettingsApp.V1.WeatherForecast
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IOptions<AppSettings> _appSettings;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(
            IOptions<AppSettings> appSettings,
            ILogger<WeatherForecastController> logger)
        {
            _appSettings = appSettings;
            _logger = logger;

            _logger.LogInformation($"{nameof(AppSettings)}:\nCity = {_appSettings.Value.City}\nSchemaId = {_appSettings.Value.SchemaId}\nAdministratorEmail = {_appSettings.Value.AdministratorEmail}\nInstanceId = {_appSettings.Value.InstanceId}");
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5)
                .Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }
    }
}
