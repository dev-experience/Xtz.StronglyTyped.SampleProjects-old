using System;
using Xtz.StronglyTyped.BuiltinTypes.Address;

namespace SampleProjects.EntityFrameworkApp.V1.WeatherForecast
{
    public class WeatherForecast
    {
        public WeatherForecastId Id { get; set; }

        public WeatherForecastStructId StructId { get; set; }

        public City City { get; set; }

        public DateTime Date { get; set; }

        public DegreesCelsius TemperatureC { get; set; }

        public string Summary { get; set; }
    }
}
