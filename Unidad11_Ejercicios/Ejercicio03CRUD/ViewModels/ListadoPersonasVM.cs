using DAL;
using Ejercicio03CRUD.ViewModels.Utilis;
using Entidades;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ejercicio03CRUD.ViewModels
{
    class ListadoPersonasVM : clsVMBase
    {
        private ObservableCollection<clsPersona> _listadoPersonas;

        public ObservableCollection<clsPersona> ListadoPersonas
        {
            get { return _listadoPersonas; }
            set
            {
                _listadoPersonas = value;
                OnPropertyChanged();
            }
        }

        public ListadoPersonasVM()
        {
            ListadoPersonas = new ObservableCollection<clsPersona>();
            _ = CargarListadoPersonas();
        }

        private async Task CargarListadoPersonas()
        {
            var personasDAL = new clsListadoPersonasDAL();
            var listaPersonas = await personasDAL.ListadoPersonasDAL();
            foreach (var persona in listaPersonas)
            {
                ListadoPersonas.Add(persona);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
