
using aula10.App_Code.ConnectFactory;
using aula10.App_Code.DAO;
using aula10.App_Code.Mod;
using aula10.App_Code.Utils;

namespace aula10
{
    public partial class MainPage : ContentPage
    {
        #region Atributos

        private readonly WeatherDAO _weatherDAO;
        private readonly IlhaDAO _ilhaDAO;

        #endregion

        public MainPage()
        {
            InitializeComponent();

            // Inicializa o serviço de previsão do tempo
            var openMeteoServices = new OpenMeteoServices();
            _weatherDAO = new WeatherDAO(openMeteoServices);

            // Inicializa o serviço da API de One Piece
            var onePieceServices = new OnePieceServices();
            _ilhaDAO = new IlhaDAO(onePieceServices);

            // Carrega a lista de ilhas
            _ = CarregarIlhasAsync();
        }

        // Carrega as ilhas da API
        private async Task CarregarIlhasAsync()
        {
            try
            {
                var ilhas = await _ilhaDAO.ListarIlhasAsync();
                IlhaPicker.ItemsSource = ilhas;
            }
            catch (Exception ex)
            {
                await DisplayAlert(
                    "Erro",
                    $"Não foi possível carregar as ilhas: {ex.Message}",
                    "OK"
                );
            }
        }

        // Evento executado quando uma ilha é selecionada
        private async void IlhaPicker_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (IlhaPicker.SelectedItem is not Ilha ilha)
                return;

            // Exibe a imagem da ilha selecionada
            if (!string.IsNullOrWhiteSpace(ilha.ImagemUrl) &&
                Uri.TryCreate(ilha.ImagemUrl, UriKind.Absolute, out var imagemUri))
            {
                IlhaImage.Source = ImageSource.FromUri(imagemUri);
                IlhaImage.IsVisible = true;
            }
            else
            {
                IlhaImage.Source = null;
                IlhaImage.IsVisible = false;
            }

            // Procura as coordenadas da ilha selecionada
            var referencia = IlhaCoordenadas.Buscar(ilha.NomeExibicao);

            if (referencia == null)
            {
                await DisplayAlert(
                    "Ilha sem coordenadas",
                    $"Ainda não cadastramos uma localização de referência para {ilha.NomeExibicao}.",
                    "OK"
                );

                return;
            }

            try
            {
                LoadingIndicator.IsVisible = true;
                LoadingIndicator.IsRunning = true;

                // Consulta o clima usando as coordenadas da ilha
                var clima = await _weatherDAO.ConsultarClimaAtualAsync(
                    referencia.Latitude,
                    referencia.Longitude
                );

                if (clima == null ||
                    clima.Current == null ||
                    clima.Daily?.TemperatureMax == null ||
                    clima.Daily.TemperatureMin == null ||
                    clima.Daily.TemperatureMax.Count == 0 ||
                    clima.Daily.TemperatureMin.Count == 0)
                {
                    await DisplayAlert(
                        "Aviso",
                        "Não foi possível obter os dados meteorológicos.",
                        "OK"
                    );

                    return;
                }

                // Atualiza as informações do clima
                TemperaturaLabel.Text =
                    $"Temperatura atual: {clima.Current.Temperature} °C";

                UmidadeLabel.Text =
                    $"Umidade: {clima.Current.RelativeHumidity}%";

                VentoLabel.Text =
                    $"Vento: {clima.Current.WindSpeed} km/h";

                CondicaoLabel.Text =
                    DescricaoClima.ObterDescricao(clima.Current.WeatherCode);

                MaximaLabel.Text =
                    $"Máxima: {clima.Daily.TemperatureMax[0]} °C";

                MinimaLabel.Text =
                    $"Mínima: {clima.Daily.TemperatureMin[0]} °C";

                // Atualiza o ícone conforme a condição climática
                int codigoClima = clima.Current.WeatherCode;

                ClimaIcone.Source = codigoClima switch
                {
                    0 => "sol.png",
                    1 or 2 or 3 => "nublado.png",
                    45 or 48 => "neblina.png",
                    51 or 53 or 55 or 56 or 57 or
                    61 or 63 or 65 or 66 or 67 or
                    80 or 81 or 82 => "chuva.png",
                    71 or 73 or 75 or 77 or 85 or 86 => "neve.png",
                    95 or 96 or 99 => "tempestade.png",
                    _ => "nublado.png"
                };
            }
            catch (Exception ex)
            {
                await DisplayAlert(
                    "Erro",
                    $"Não foi possível consultar o clima da ilha.\n\n{ex.Message}",
                    "OK"
                );
            }
            finally
            {
                LoadingIndicator.IsRunning = false;
                LoadingIndicator.IsVisible = false;
            }
        }
    }
}
