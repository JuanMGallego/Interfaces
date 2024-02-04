using System.Windows.Input;

namespace Ejercicio03CRUD.ViewModels
{
    public class MainVM
    {
        public ICommand ChangePageCommand { get; }

        public MainVM()
        {
            ChangePageCommand = new Command(ChangePage);
        }

        private async void ChangePage()
        {
            await Shell.Current.GoToAsync("//personas");
        }

    }
}
