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

}