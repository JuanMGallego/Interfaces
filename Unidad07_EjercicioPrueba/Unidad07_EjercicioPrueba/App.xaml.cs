using Unidad07_EjercicioPrueba.Views;

namespace Unidad07_EjercicioPrueba
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
    }
}   