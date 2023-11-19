namespace PlacasSolares.Views;

public partial class Gestion : ContentPage
{

    public Gestion()
	{
		InitializeComponent();

        BindingContext = this;

        DateTime fecha = DateTime.Now;
        string mes = fecha.ToString("MMM");
        mes = char.ToUpper(mes[0]) + mes.Substring(1);
        Fecha.Text = fecha.ToString("dd ") + mes + fecha.ToString(" yyyy");

    }

    public async Task Mapa()
    {
        //Coordenadas para la ubicación en el mapa
        var coordenadas = new Location(37.5710764, -5.3979683);

        //Opciones para el lanzamiento del mapa
        var opciones = new MapLaunchOptions { Name = "La Campana" };

        //Abre el mapa de forma asíncrona con las coordenadas y opciones especificadas
        await Map.Default.OpenAsync(coordenadas, opciones);
    }

}