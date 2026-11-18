
using System.Text.Json.Serialization;

namespace aula10.App_Code.Mod
{
    public class Ilha
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public NomeIlha? Nome { get; set; }

        [JsonPropertyName("sea")]
        public string? Mar { get; set; }

        [JsonPropertyName("image_url")]
        public string? ImagemUrl { get; set; }

        [JsonIgnore]
        public string NomeExibicao =>
            Nome?.En ??
            Nome?.Romaji ??
            Nome?.Jp ??
            "Ilha sem nome";
    }

    public class NomeIlha
    {
        [JsonPropertyName("en")]
        public string? En { get; set; }

        [JsonPropertyName("jp")]
        public string? Jp { get; set; }

        [JsonPropertyName("romaji")]
        public string? Romaji { get; set; }
    }
}
