namespace PlacasSolares.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

	async void onClick(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new Gestion());
	}

    private void Pista_Clicked(object sender, EventArgs e)
    {

    }
}