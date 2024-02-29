using CRUDMaui.Views;

namespace CRUDMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainShell();
        }
    }
}