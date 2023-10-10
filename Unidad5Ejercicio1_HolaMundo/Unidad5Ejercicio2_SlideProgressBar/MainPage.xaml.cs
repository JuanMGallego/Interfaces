namespace Unidad5Ejercicio2_SlideProgressBar
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            double newValue = e.NewValue;
            progressBar.Progress = newValue / 100;
        }
    }
}