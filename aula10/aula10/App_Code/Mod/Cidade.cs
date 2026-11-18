using System.Text.Json.Serialization;

namespace aula10.App_Code.Mod
{
    public class Cidade
    {
        private int aCID_INT_ID = 0;
        private string aCID_STR_DESCRICAO = string.Empty;
        public Cidade()
        {
            CIDINTID = 0;
            CIDSTRDESCRICAO = string.Empty;
        }

        [JsonPropertyName("id")]
        public int CIDINTID { get => aCID_INT_ID; set => aCID_INT_ID = value; }

        [JsonPropertyName("nome")]
        public string CIDSTRDESCRICAO { get => aCID_STR_DESCRICAO; set => aCID_STR_DESCRICAO = value; }
    }
}
