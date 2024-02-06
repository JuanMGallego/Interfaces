using Ejercicio03CRUD.ViewModels.Utilis;

namespace Ejercicio03CRUD.ViewModels
{
    public class MainVM : clsVMBase
    {
        public DelegateCommand NavigateListadosCommand { get; }

        public MainVM()
        {
            NavigateListadosCommand = new DelegateCommand(NavigateListados);
        }

        private async void NavigateListados()
        {
            await Shell.Current.GoToAsync("//ListadoPersonasPage");
        }
    }
}
