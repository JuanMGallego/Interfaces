namespace Ejercicio03CRUD
{
    public partial class MainPage : ContentPage
    { 

        public MainPage()
        {
            InitializeComponent();
        }

        private void NavegarAListadoPersonas(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//ListadoPersonasPage");
        }

        private void NavegarAListadoDepartamentos(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//ListadoDepartamentosPage");
        }
    }
}
