using Ejercicio03CRUD.ViewModels;
using Ejercicio03CRUD.Views;

namespace Ejercicio03CRUD
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            await Shell.Current.GoToAsync("MainPage");

            base.OnStart();
        }

    }
}
