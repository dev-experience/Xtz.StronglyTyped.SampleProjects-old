using System;
using System.Linq;
using SampleProjects.EntityFrameworkApp.V1.WeatherForecast;
using Xtz.StronglyTyped.BuiltinTypes.Address;

namespace SampleProjects.EntityFrameworkApp.Data
{
    internal class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.WeatherForecasts.Any())
            {
                return;
            }

            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };
            
            var rng = new Random();
            var entities = Enumerable.Range(1, 5)
                .Select(index =>
                {
                    var city = new City("Amsterdam");
                    return new WeatherForecast
                    {
                        Id = new WeatherForecastId(),
                        StructId = WeatherForecastStructId.New(),
                        City = city,
                        Date = DateTime.Now.AddDays(index),
                        TemperatureC = new DegreesCelsius(rng.Next(-20, 55)),
                        Summary = summaries[rng.Next(summaries.Length)]
                    };
                })
                .ToArray();

            context.WeatherForecasts.AddRange(entities);
            context.SaveChanges();
        }
    }
}