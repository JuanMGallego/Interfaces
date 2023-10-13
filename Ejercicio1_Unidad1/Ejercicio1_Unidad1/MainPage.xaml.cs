namespace Ejercicio1_Unidad1
{
    public partial class MainPage : ContentPage
    {
        Boolean buttonExists = false;

        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento para boton2 que genera boton3 y comprueba que no exista ya.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCounterClickedButton2(object sender, EventArgs e)
        {
            
            if (buttonExists == false)
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
                    BorderColor = Color.FromArgb("#FFFF00"),
                    IsEnabled = true,
                    
                };

                buttonExists = true;

            }

            

        }



        private void OnCounterClickedButton3(object sender, EventArgs e)
        {

            if (buttonExists == false)
            {

                boton2.Text = "Crear controles en tiempo de ejecución mola";
                boton2.WidthRequest = 1000;
                buttonExists = true;

            }

        }

    }

}