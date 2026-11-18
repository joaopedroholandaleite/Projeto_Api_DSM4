using System.Globalization;
using System.Text;

namespace aula10.App_Code.Mod
{
    public class IlhaCoordenadas
    {
        public string NomeIlha { get; set; }
        public string LocalReferencia { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public IlhaCoordenadas(string nomeIlha, string localReferencia, double latitude, double longitude)
        {
            NomeIlha = nomeIlha;
            LocalReferencia = localReferencia;
            Latitude = latitude;
            Longitude = longitude;
        }

        // As chaves abaixo usam exatamente name.en retornado pela One Piece API.
        // As cidades são analogias climáticas/visuais para consultar o Open-Meteo, não locais canônicos.
        private static readonly Dictionary<string, IlhaCoordenadas> Ilhas =
            new(StringComparer.OrdinalIgnoreCase)
            {
                ["Vodka Kingdom"] = new("Vodka Kingdom", "Reykjavik, Islândia", 64.1466, -21.9426),
                ["Rommel Kingdom"] = new("Rommel Kingdom", "Bergen, Noruega", 60.3913, 5.3221),
                ["Flevance"] = new("Flevance", "Pripyat, Ucrânia", 51.4045, 30.0542),
                ["Sorbet Kingdom"] = new("Sorbet Kingdom", "Florianópolis, Brasil", -27.5954, -48.5480),
                ["Kano Country"] = new("Kano Country", "Guilin, China", 25.2736, 110.2900),
                ["Lulusia Kingdom"] = new("Lulusia Kingdom", "Lisboa, Portugal", 38.7223, -9.1393),
                ["Prodence Kingdom"] = new("Prodence Kingdom", "Sevilha, Espanha", 37.3891, -5.9845),
                ["Tequila Wolf"] = new("Tequila Wolf", "Roterdã, Países Baixos", 51.9244, 4.4777),
                ["Lvneel Kingdom"] = new("Lvneel Kingdom", "Estocolmo, Suécia", 59.3293, 18.0686),
                ["Oykot Kingdom"] = new("Oykot Kingdom", "Kyoto, Japão", 35.0116, 135.7681),
                ["Kumate Island"] = new("Kumate Island", "Manaus, Brasil", -3.1190, -60.0217),
                ["Kyuka Island"] = new("Kyuka Island", "Honolulu, Havaí", 21.3099, -157.8581),
                ["Island of Rare Animals"] = new("Island of Rare Animals", "Bornéu, Indonésia", 0.5000, 116.0000),
                ["Mirror Ball Island"] = new("Mirror Ball Island", "Las Vegas, EUA", 36.1699, -115.1398),
                ["Ballon Terminal"] = new("Ballon Terminal", "La Paz, Bolívia", -16.4897, -68.1193),
                ["Kutsukku Island"] = new("Kutsukku Island", "Auckland, Nova Zelândia", -36.8509, 174.7645),
                ["Applenine Island"] = new("Applenine Island", "Queenstown, Nova Zelândia", -45.0312, 168.6626),
                ["Esperia Kingdom"] = new("Esperia Kingdom", "Atenas, Grécia", 37.9838, 23.7275),
                ["Gecko Islands"] = new("Gecko Islands", "Wellington, Nova Zelândia", -41.2866, 174.7756),
                ["Namakura Island"] = new("Namakura Island", "Dakar, Senegal", 14.7167, -17.4677),
                ["Swallow Island"] = new("Swallow Island", "Vancouver, Canadá", 49.2827, -123.1207),
                ["Foodvalten"] = new("Foodvalten", "Reykjavik, Islândia", 64.1466, -21.9426),
                ["Gartel Island"] = new("Gartel Island", "Dublin, Irlanda", 53.3498, -6.2603),
                ["Raijin Island"] = new("Raijin Island", "Maracaibo, Venezuela", 10.6544, -71.6406),
                ["Goat Island"] = new("Goat Island", "Edimburgo, Escócia", 55.9533, -3.1883),
                ["Minion Island"] = new("Minion Island", "Bergen, Noruega", 60.3913, 5.3221),
                ["Guanhao"] = new("Guanhao", "Chengdu, China", 30.5728, 104.0668),
                ["Merveille"] = new("Merveille", "Manaus, Brasil", -3.1190, -60.0217),
                ["Momoiro Island"] = new("Momoiro Island", "Bangkok, Tailândia", 13.7563, 100.5018),
                ["Broc Coli Island"] = new("Broc Coli Island", "Dakar, Senegal", 14.7167, -17.4677),
                ["Boin Archipelago"] = new("Boin Archipelago", "Manaus, Brasil", -3.1190, -60.0217),
                ["Bunt Kingdom"] = new("Bunt Kingdom", "Praga, Chéquia", 50.0755, 14.4378),
                ["Kenzan Island"] = new("Kenzan Island", "Innsbruck, Áustria", 47.2692, 11.4041),
                ["Ukkari Hot-Spring Island"] = new("Ukkari Hot-Spring Island", "Beppu, Japão", 33.2795, 131.4979),
                ["Karai Bari Island"] = new("Karai Bari Island", "Marrakech, Marrocos", 31.6295, -7.9811),
                ["New Marineford"] = new("New Marineford", "Washington, EUA", 38.9072, -77.0369),
                ["Winner Island"] = new("Winner Island", "Honolulu, Havaí", 21.3099, -157.8581),
                ["Enishi"] = new("Enishi", "Kyoto, Japão", 35.0116, 135.7681),
                ["Cozia"] = new("Cozia", "Queenstown, Nova Zelândia", -45.0312, 168.6626),
                ["Baterilla"] = new("Baterilla", "Recife, Brasil", -8.0476, -34.8770),
                ["Kuraigana Island"] = new("Kuraigana Island", "Isle of Skye, Escócia", 57.2736, -6.2155),
                ["Onigashima"] = new("Onigashima", "Sapporo, Japão", 43.0618, 141.3545),
                ["God Valley"] = new("God Valley", "Kauai, Havaí", 22.0964, -159.5261),
                ["Torino Kingdom"] = new("Torino Kingdom", "Manaus, Brasil", -3.1190, -60.0217),
                ["Banaro Island"] = new("Banaro Island", "Rio de Janeiro, Brasil", -22.9068, -43.1729),
                ["Hachinosu"] = new("Hachinosu", "Port Royal, Jamaica", 17.9370, -76.8400),
                ["Cactus Island"] = new("Cactus Island", "Aswan, Egito", 24.0889, 32.8998),
                ["Sixis"] = new("Sixis", "Reykjavik, Islândia", 64.1466, -21.9426),
                ["Goa Kingdom"] = new("Goa Kingdom", "Lisboa, Portugal", 38.7223, -9.1393),
                ["Ohara"] = new("Ohara", "Oxford, Inglaterra", 51.7520, -1.2577),
                ["Mock Town"] = new("Mock Town", "Nassau, Bahamas", 25.0443, -77.3504),
                ["Karakuri Island"] = new("Karakuri Island", "Sapporo, Japão", 43.0618, 141.3545),
                ["Rusukaina"] = new("Rusukaina", "Singapura", 1.3521, 103.8198),
                ["Totto Land"] = new("Totto Land", "Colmar, França", 48.0794, 7.3585),
                ["Conomi Islands"] = new("Conomi Islands", "Okinawa, Japão", 26.2124, 127.6809),
                ["Mary Geoise"] = new("Mary Geoise", "La Paz, Bolívia", -16.4897, -68.1193),
                ["Baltigo"] = new("Baltigo", "Tamanrasset, Argélia", 22.7850, 5.5228),
                ["Elbaph"] = new("Elbaph", "Reykjavik, Islândia", 64.1466, -21.9426),
                ["Egghead"] = new("Egghead", "Singapura", 1.3521, 103.8198),
                ["Wano Country"] = new("Wano Country", "Kyoto, Japão", 35.0116, 135.7681),
                ["Whole Cake Island"] = new("Whole Cake Island", "Colmar, França", 48.0794, 7.3585),
                ["Zou"] = new("Zou", "Manaus, Brasil", -3.1190, -60.0217),
                ["Dressrosa"] = new("Dressrosa", "Sevilha, Espanha", 37.3891, -5.9845),
                ["Punk Hazard"] = new("Punk Hazard", "Reykjavik, Islândia", 64.1466, -21.9426),
                ["Fish-Man Island"] = new("Fish-Man Island", "Naha, Okinawa, Japão", 26.2124, 127.6809),
                ["Marineford"] = new("Marineford", "Washington, EUA", 38.9072, -77.0369),
                ["Impel Down"] = new("Impel Down", "Alcatraz, São Francisco, EUA", 37.8267, -122.4230),
                ["Amazon Lily"] = new("Amazon Lily", "Manaus, Brasil", -3.1190, -60.0217),
                ["Sabaody Archipelago"] = new("Sabaody Archipelago", "Okinawa, Japão", 26.2124, 127.6809),
                ["Enies Lobby"] = new("Enies Lobby", "Sevilha, Espanha", 37.3891, -5.9845),
                ["Water 7"] = new("Water 7", "Veneza, Itália", 45.4408, 12.3155),
                ["Long Ring Long Land"] = new("Long Ring Long Land", "Mongólia Interior, China", 43.8256, 111.6140),
                ["Skypiea"] = new("Skypiea", "La Paz, Bolívia", -16.4897, -68.1193),
                ["Jaya"] = new("Jaya", "Singapura", 1.3521, 103.8198),
                ["Alabasta Kingdom"] = new("Alabasta Kingdom", "Aswan, Egito", 24.0889, 32.8998),
                ["Drum Island"] = new("Drum Island", "Longyearbyen, Noruega", 78.2232, 15.6469),
                ["Little Garden"] = new("Little Garden", "Bornéu, Indonésia", 0.5000, 116.0000),
                ["Whisky Peak"] = new("Whisky Peak", "Aswan, Egito", 24.0889, 32.8998),
                ["Dawn Island"] = new("Dawn Island", "Auckland, Nova Zelândia", -36.8509, 174.7645),
                ["Loguetown"] = new("Loguetown", "Lisboa, Portugal", 38.7223, -9.1393),
                ["Syrup Village"] = new("Syrup Village", "Wellington, Nova Zelândia", -41.2866, 174.7756),
                ["Orange Town"] = new("Orange Town", "Valência, Espanha", 39.4699, -0.3763),
                ["Shells Town"] = new("Shells Town", "Lisboa, Portugal", 38.7223, -9.1393),
                ["Green Bit"] = new("Green Bit", "Manaus, Brasil", -3.1190, -60.0217),
                ["Weatheria"] = new("Weatheria", "Reykjavik, Islândia", 64.1466, -21.9426),
                ["Reverse Mountain"] = new("Reverse Mountain", "Tromsø, Noruega", 69.6492, 18.9553),
            };

        public static IlhaCoordenadas? Buscar(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return null;

            string chave = Normalizar(nome);

            return Ilhas.Values.FirstOrDefault(i => Normalizar(i.NomeIlha) == chave);
        }

        private static string Normalizar(string texto)
        {
            string semAcentos = new string(texto
                .Normalize(NormalizationForm.FormD)
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray());

            return string.Join(" ", semAcentos
                .Trim()
                .ToLowerInvariant()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries));
        }
    }
}