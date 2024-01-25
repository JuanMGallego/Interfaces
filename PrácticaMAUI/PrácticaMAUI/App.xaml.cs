using PrácticaMAUI.Views;

namespace PrácticaMAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Pagina();
        }
    }
}
