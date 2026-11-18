using System.Text.Json.Serialization;

namespace aula10.App_Code.Mod
{
    public class Estado
    {
        private int aEST_INT_ID = 0;        
        private string aEST_STR_DESCRICAO = string.Empty;
        private string aEST_STR_SIGLA = string.Empty;

        public Estado() {
            ESTINTID = 0;
            ESTSTRDESCRICAO = string.Empty;
            ESTSTRSIGLA = string.Empty;
        }

        [JsonPropertyName("id")]
        public int ESTINTID { get => aEST_INT_ID; set => aEST_INT_ID = value; }
        [JsonPropertyName("nome")]
        public string ESTSTRDESCRICAO { get => aEST_STR_DESCRICAO; set => aEST_STR_DESCRICAO = value; }
        [JsonPropertyName("sigla")]
        public string ESTSTRSIGLA { get => aEST_STR_SIGLA; set => aEST_STR_SIGLA = value; }
    }
}
