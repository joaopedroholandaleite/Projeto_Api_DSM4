using aula10.App_Code.ConnectFactory;
using aula10.App_Code.Mod;
using System.Net.Http.Json;

namespace aula10.App_Code.DAO
{
    public class CidadeDAO
    {
        private readonly Services _services;

        public CidadeDAO(Services services)
        {
            _services = services;
        }

        public async Task<List<Cidade>> ListarCidadeAsync(string uf)
        {
            var cidade = await _services.HttpClient.GetFromJsonAsync<List<Cidade>>($"estados/{uf}/municipios");
            return ListCidade(cidade);
        }

        private static List<Cidade> ListCidade(List<Cidade>? cidade)
        {
            return cidade?.OrderBy(m => m.CIDSTRDESCRICAO).ToList() ?? new List<Cidade>();
        }


    }
}
