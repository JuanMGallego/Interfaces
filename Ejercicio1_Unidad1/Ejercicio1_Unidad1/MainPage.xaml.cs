namespace Ejercicio1_Unidad1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
                Button boton3 = new Button
            {
                Text = "Boton 3",
                BackgroundColor = Color.FromArgb("#0000FF"),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 200,
                HeightRequest = 70,
                FontFamily = "Verdana",
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
                BorderColor = Color.FromArgb("#FFFF00")
            };
        }
    }
}