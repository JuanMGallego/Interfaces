using Ejercicio03CRUD.ViewModels.Utilis;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UI.DAL;
using UI.DAL.Conexion;
using UI.Models;

namespace UI.ViewModels
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
            var listaPersonas = await personasDAL.getPersonasDAL();
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
