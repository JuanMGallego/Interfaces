namespace Unidad5Ejercicio4_Calendario
{

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            entradaDatePicker.MinimumDate = DateTime.Now;
            salidaDatePicker.Date = DateTime.Now.AddDays(1);
        }

        private void EntradaDateSelected(object sender, DateChangedEventArgs e)
        {
            
            salidaDatePicker.MinimumDate = e.NewDate.AddDays(1);
        }

        private void SalidaDateSelected(object sender, DateChangedEventArgs e)
        {

            entradaDatePicker.MaximumDate = salidaDatePicker.Date;
        }
    }
}