namespace Unidad5Ejercicio1_HolaMundo

{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {

            string result = await DisplayPromptAsync("Pregunta", "¿Cómo te apellidas?");
            await DisplayAlert("Saludo", "Hola " + nombre.Text + " " + result, "OK");
        }
    }
}