namespace Unidad07_EjercicioPrueba.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
    private async void OnTabbedPageButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PaginaTabbed());
    }
}