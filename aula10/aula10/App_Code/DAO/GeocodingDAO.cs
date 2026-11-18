
using System.Net.Http.Json;
using aula10.App_Code.ConnectFactory;
using aula10.Models;

namespace aula10.App_Code.DAO
{
    public class GeocodingDAO
    {
        private readonly OpenMeteoServices _services;

        public GeocodingDAO(OpenMeteoServices services)
        {
            _services = services;
        }

        public async Task<GeocodingLocation?> BuscarLocalizacaoAsync(
            string nomeCidade,
            string nomeEstado)
        {
            string cidade = Uri.EscapeDataString(nomeCidade);

            var resposta = await _services.GeocodingClient
                .GetFromJsonAsync<GeocodingResponse>(
                    $"search?name={cidade}&count=10&language=pt&format=json&countryCode=BR"
                );

            return resposta?.Results?
                .FirstOrDefault(local =>
                    string.Equals(
                        local.Admin1,
                        nomeEstado,
                        StringComparison.OrdinalIgnoreCase
                    )
                );
        }
    }
}
