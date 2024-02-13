using Ejercicio03CRUD.ViewModels.Utilis;
using System.Collections.ObjectModel;
using UI.DAL;
using UI.Models;

namespace UI.ViewModels
{
    class MainPageVM : clsVMBase
    {
        private ObservableCollection<clsPersonaModel> _listadoPersonas;

        public MainPageVM()
        {
            ListadoPersonas = new ObservableCollection<clsPersonaModel>();
            CargarListadoPersonas();
        }

        public ObservableCollection<clsPersonaModel> ListadoPersonas
        {
            get { return _listadoPersonas; }
            set
            {
                _listadoPersonas = value;
                NotifyPropertyChanged();
            }
        }

        private async void CargarListadoPersonas()
        {
            var personasDAL = new clsListadoPersonasDAL();
            var listaPersonas = await personasDAL.getPersonasDAL();

            foreach (var persona in listaPersonas)
            {
                // Mapear clsPersona a clsPersonaModel
                var personaModel = new clsPersonaModel
                {
                    Nombre = persona.Nombre,
                    Apellidos = persona.Apellidos
                    Departamentos = persona.Departamentos
                };

                ListadoPersonas.Add(personaModel);
            }
        }
    }
}
