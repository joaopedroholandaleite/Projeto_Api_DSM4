
using System.Globalization;
using System.Net.Http.Json;
using aula10.App_Code.ConnectFactory;
using aula10.Models;

namespace aula10.App_Code.DAO
{
    public class WeatherDAO
    {
        private readonly OpenMeteoServices _services;

        public WeatherDAO(OpenMeteoServices services)
        {
            _services = services;
        }

        public async Task<WeatherResponse?> ConsultarClimaAtualAsync(
             double latitude,
            double longitude)
        {
            string lat = latitude.ToString(CultureInfo.InvariantCulture);
            string lon = longitude.ToString(CultureInfo.InvariantCulture);

            var resposta = await _services.WeatherClient
                .GetFromJsonAsync<WeatherResponse>(
                   $"forecast?latitude={lat}&longitude={lon}" +
"&current=temperature_2m,relative_humidity_2m,wind_speed_10m,weather_code" +
"&daily=temperature_2m_max,temperature_2m_min" +
"&timezone=America/Sao_Paulo"
                );

            return resposta;
        }
    }
}
