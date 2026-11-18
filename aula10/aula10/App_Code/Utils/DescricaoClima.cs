
namespace aula10.App_Code.Utils
{
    public static class DescricaoClima
    {
        public static string ObterDescricao(int codigo)
        {
            return codigo switch
            {
                0 => "Céu limpo",
                1 => "Predominantemente limpo",
                2 => "Parcialmente nublado",
                3 => "Encoberto",
                45 or 48 => "Neblina",

                51 or 53 or 55 => "Garoa",
                56 or 57 => "Garoa congelante",

                61 => "Chuva fraca",
                63 => "Chuva moderada",
                65 => "Chuva forte",
                66 or 67 => "Chuva congelante",

                71 => "Neve fraca",
                73 => "Neve moderada",
                75 => "Neve forte",
                77 => "Grãos de neve",

                80 => "Pancadas de chuva fracas",
                81 => "Pancadas de chuva moderadas",
                82 => "Pancadas de chuva fortes",

                85 or 86 => "Pancadas de neve",

                95 => "Tempestade",
                96 or 99 => "Tempestade com granizo",

                _ => "Condição desconhecida"
            };
        }
    }
}
