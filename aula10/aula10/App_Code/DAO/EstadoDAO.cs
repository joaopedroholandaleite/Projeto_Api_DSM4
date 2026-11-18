using aula10.App_Code.Mod;
using System.Net.Http.Json;
using aula10.App_Code.ConnectFactory;

namespace aula10.App_Code.DAO
{
    public class EstadoDAO
    {

        private readonly Services _services;

        public EstadoDAO(Services services)
        {
            _services = services;
        }

        public async Task<List<Estado>> ListarEstadoAsync()
        {

            var estados = await _services.HttpClient.GetFromJsonAsync<List<Estado>>("estados");
            //Estado estado = estados[0];
            return ListEstado(estados);
        }

        private static List<Estado> ListEstado(List<Estado>? estados)
        {
            return estados?.OrderBy(e => e.ESTSTRDESCRICAO).ToList() ?? new List<Estado>();
        }
    }
}
