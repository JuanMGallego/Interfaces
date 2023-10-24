namespace Unidad07_EjercicioPrueba.Views;

public partial class Pagina3 : ContentPage
{
	public Pagina3()
	{
		InitializeComponent();
	}
    private async void OnBackToMainPageButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}