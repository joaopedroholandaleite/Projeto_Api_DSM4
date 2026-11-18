
using System.Net.Http.Json;
using aula10.App_Code.ConnectFactory;
using aula10.App_Code.Mod;

namespace aula10.App_Code.DAO
{
    public class IlhaDAO
    {
        private readonly OnePieceServices _services;

        public IlhaDAO(OnePieceServices services)
        {
            _services = services;
        }

        public async Task<List<Ilha>> ListarIlhasAsync()
        {
            var todasIlhas = new List<Ilha>();

            int pagina = 1;
            const int limite = 20;

            while (true)
            {
                var ilhas = await _services.HttpClient
                    .GetFromJsonAsync<List<Ilha>>(
                        $"api/islands?page={pagina}&limit={limite}"
                    );

                if (ilhas == null || ilhas.Count == 0)
                {
                    break;
                }

                todasIlhas.AddRange(ilhas);

                if (ilhas.Count < limite)
                {
                    break;
                }

                pagina++;
            }

            return todasIlhas
                .OrderBy(i => i.NomeExibicao)
                .ToList();
        }
    }
}
