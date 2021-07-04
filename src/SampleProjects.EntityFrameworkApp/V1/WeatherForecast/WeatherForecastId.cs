using System;
using System.ComponentModel;
using System.Text.Json.Serialization;
using Xtz.StronglyTyped.BuiltinTypes.Ids;
using Xtz.StronglyTyped.TypeConverters;

namespace SampleProjects.EntityFrameworkApp.V1.WeatherForecast
{
    // TODO: Replace by decorated class
    [JsonConverter(typeof(StronglyTypedJsonConverter<WeatherForecastId>))]
    [TypeConverter(typeof(TypeConverter<WeatherForecastId, Guid>))]
    public class WeatherForecastId : GuidId
    {
        public WeatherForecastId(Guid value)
            : base(value)
        {
        }

        public WeatherForecastId(string value)
            : base(Guid.Parse(value))
        {
        }

        public WeatherForecastId()
        {
        }

        public static explicit operator WeatherForecastId(Guid value)
        {
            return new WeatherForecastId(value);
        }

        public static explicit operator WeatherForecastId(string value)
        {
            return new WeatherForecastId(value);
        }

        public static implicit operator Guid(WeatherForecastId stronglyTyped)
        {
            return stronglyTyped.Value;
        }

        public static implicit operator string(WeatherForecastId stronglyTyped)
        {
            return stronglyTyped?.ToString();
        }
    }
}