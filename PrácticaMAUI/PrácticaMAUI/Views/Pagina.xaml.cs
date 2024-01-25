namespace PrácticaMAUI.Views;

public partial class Pagina : ContentPage
{
	public Pagina()
	{
		InitializeComponent();
	}

    private void IrAPagina2(object sender, EventArgs e)
    {
        // Crear una instancia de la Página2
        Pagina2 pagina2 = new Pagina2();

        // Envolver la Página2 en un NavigationPage para habilitar la navegación
        NavigationPage navigationPage = new NavigationPage(pagina2);

        // Hacer push de la Página2 en la pila de navegación
        Navigation.PushAsync(navigationPage);
    }

}