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
        private clsDepartamento departamento;

        public ObservableCollection<clsDepartamento> ListadoDepartamentos
        {
            get { return _listadoDepartamentos; }
            set
            {
                _listadoDepartamentos = value;
                NotifyPropertyChanged();
            }
        }

        public clsDepartamento Departamento
        {
            get { return departamento; }
            set
            {
                departamento = value;
                NotifyPropertyChanged(nameof(Departamento));
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
            ListadoDepartamentos.Clear();

            var departamentosDAL = new clsListadoDepartamentosDAL();
            var listaDepartamentos = await departamentosDAL.ListadoDepartamentosDAL();
            foreach (var persona in listaDepartamentos)
            {
                ListadoDepartamentos.Add(persona);
            }
        }

        private async void NavigateEditInsert()
        {

            if (selectedDepartament == null)
            {
                await Shell.Current.GoToAsync($"editDeparment?id={selectedDepartament.ID}");
            }
            else
            {
                
            }
            await Shell.Current.GoToAsync("editarInsertarDepartamentoPage");
        }
    }
}
