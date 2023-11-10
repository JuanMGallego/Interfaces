using JuanManuelGallegoGEx.Views;

namespace JuanManuelGallegoGEx
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Juego());
        }
    }
}