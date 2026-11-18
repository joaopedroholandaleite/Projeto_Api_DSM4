
using System.Text.Json.Serialization;

namespace aula10.Models
{
    public class WeatherResponse
    {
        [JsonPropertyName("current")]
        public CurrentWeather? Current { get; set; }

        [JsonPropertyName("daily")]
        public DailyWeather? Daily { get; set; }
    }

    public class DailyWeather
    {
        [JsonPropertyName("temperature_2m_max")]
        public List<double>? TemperatureMax { get; set; }

        [JsonPropertyName("temperature_2m_min")]
        public List<double>? TemperatureMin { get; set; }
    }


    public class CurrentWeather
    {
        [JsonPropertyName("temperature_2m")]
        public double Temperature { get; set; }

        [JsonPropertyName("relative_humidity_2m")]
        public int RelativeHumidity { get; set; }

        [JsonPropertyName("wind_speed_10m")]
        public double WindSpeed { get; set; }

        [JsonPropertyName("weather_code")]
        public int WeatherCode { get; set; }
    }
}
