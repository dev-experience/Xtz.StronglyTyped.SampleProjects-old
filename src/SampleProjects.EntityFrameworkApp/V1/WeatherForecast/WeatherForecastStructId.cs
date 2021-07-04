using System;
using System.ComponentModel;
using System.Text.Json.Serialization;
using Xtz.StronglyTyped;
using Xtz.StronglyTyped.TypeConverters;

namespace SampleProjects.EntityFrameworkApp.V1.WeatherForecast
{
    //[StrongType(typeof(Guid))]
    //public partial struct WeatherForecastStructId
    //{
    //    public static WeatherForecastStructId New()
    //    {
    //        return new WeatherForecastStructId(Guid.NewGuid());
    //    }
    //}

    // TODO: Replace by decorated struct
    [JsonConverter(typeof(StronglyTypedJsonConverter<WeatherForecastStructId>))]
    [TypeConverter(typeof(TypeConverter<WeatherForecastStructId, Guid>))]
    public partial struct WeatherForecastStructId : IStronglyTyped<Guid>
    {
        public Guid Value { get; }

        public WeatherForecastStructId(Guid value)
        {
            Value = value;
        }

        public WeatherForecastStructId(string value)
            : this(Guid.Parse(value))
        {
        }

        public static WeatherForecastStructId New()
        {
            return new WeatherForecastStructId(Guid.NewGuid());
        }

        public override string ToString()
        {
            return $"{Value:D}";
        }

        public static explicit operator WeatherForecastStructId(Guid value)
        {
            return new WeatherForecastStructId(value);
        }

        public static explicit operator WeatherForecastStructId(string value)
        {
            return new WeatherForecastStructId(value);
        }

        public static implicit operator Guid(WeatherForecastStructId stronglyTyped)
        {
            return stronglyTyped.Value;
        }

        public static implicit operator string(WeatherForecastStructId stronglyTyped)
        {
            return stronglyTyped.ToString();
        }
    }
}