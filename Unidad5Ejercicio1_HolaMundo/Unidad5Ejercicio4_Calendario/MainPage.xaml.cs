namespace Unidad5Ejercicio4_Calendario
{

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            entradaDatePicker.MinimumDate = DateTime.Now;
            salidaDatePicker.MinimumDate = entradaDatePicker.Date;
        }

        private void EntradaDateSelected(object sender, DateChangedEventArgs e)
        {
            
            salidaDatePicker.MinimumDate = e.NewDate;
        }

        private void SalidaDateSelected(object sender, DateChangedEventArgs e)
        {
            
        }
    }
}