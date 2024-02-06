using DAL;
using Ejercicio03CRUD.ViewModels.Utilis;
using Entidades;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ejercicio03CRUD.ViewModels
{
    class ListadoDepartamentosVM : clsVMBase
    {
        public DelegateCommand NavigateEditInsertCommand { get; }

        private ObservableCollection<clsDepartamento> _listadoDepartamentos;

        public ObservableCollection<clsDepartamento> ListadoDepartamentos
        {
            get { return _listadoDepartamentos; }
            set
            {
                _listadoDepartamentos = value;
                OnPropertyChanged();
            }
        }

        public ListadoDepartamentosVM()
        {
            NavigateEditInsertCommand = new DelegateCommand(NavigateEditInsert);
            ListadoDepartamentos = new ObservableCollection<clsDepartamento>();
            _ = CargarListadoDepartamentos();
        }

        private async Task CargarListadoDepartamentos()
        {
            var departamentosDAL = new clsListadoDepartamentosDAL();
            var listaDepartamentos = await departamentosDAL.ListadoDepartamentosDAL();
            foreach (var persona in listaDepartamentos)
            {
                ListadoDepartamentos.Add(persona);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void NavigateEditInsert()
        {
            await Shell.Current.GoToAsync("editarInsertarDepartamentoPage");
        }
    }
}
