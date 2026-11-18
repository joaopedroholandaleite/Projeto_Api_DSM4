
using System.Text.Json.Serialization;

namespace aula10.Models
{
    public class GeocodingResponse
    {
        [JsonPropertyName("results")]
        public List<GeocodingLocation>? Results { get; set; }
    }

    public class GeocodingLocation
    {

        [JsonPropertyName("admin1")]
        public string? Admin1 { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }
    }
}
