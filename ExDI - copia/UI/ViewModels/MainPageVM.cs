using System.Collections.ObjectModel;
using System.Windows.Input;
using UI.Models;
using UI.DAL;
using Ejercicio03CRUD.ViewModels.Utilis;

namespace UI.ViewModels
{
    class MainPageVM : clsVMBase
    {
        private ObservableCollection<clsPersonaModel> _listadoPersonas;
        private List<string> _listadoDepartamentos;

        private int _intentosRestantes = 3;
        private int _aciertos = 0;

        public MainPageVM()
        {
            ListadoPersonas = new ObservableCollection<clsPersonaModel>();
            ListadoDepartamentos = new List<string>();

            // Se simula la carga de departamentos
            ListadoDepartamentos.Add("Departamento1");
            ListadoDepartamentos.Add("Departamento2");

            _ = CargarListadoPersonas();
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

        public List<string> ListadoDepartamentos
        {
            get { return _listadoDepartamentos; }
            set
            {
                _listadoDepartamentos = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand ComprobarCommand { get; }

        private void Comprobar()
        {
            foreach (var persona in ListadoPersonas)
            {
                if (persona.Departamento == "DepartamentoReal")
                {
                    _aciertos++;
                }
            }

            _intentosRestantes--;

            if (_aciertos == ListadoPersonas.Count)
            {
                MostrarMensaje("¡Felicidades, has ganado!");
            }
            else if (_intentosRestantes > 0)
            {
                MostrarMensaje($"Aciertos: {_aciertos}. Intentos restantes: {_intentosRestantes}");
            }
            else
            {
                MostrarMensaje("Lo siento, has perdido. ¿Quieres volver a jugar?");
                // Aquí deberías reiniciar el juego o cerrar la aplicación según la respuesta del usuario.
            }
        }

        private async Task CargarListadoPersonas()
        {
            var personasDAL = new clsListadoPersonasDAL();
            var listaPersonas = await personasDAL.getPersonasDAL();

            foreach (var persona in listaPersonas)
            {
                var personaModel = new clsPersonaModel
                {
                    Nombre = persona.Nombre,
                    Apellidos = persona.Apellidos
                };

                ListadoPersonas.Add(personaModel);
            }
        }

        private void MostrarMensaje(string mensaje)
        {
            // Implementa la lógica para mostrar el mensaje en la interfaz (Toast, alerta, etc.)
            // ...
        }
    }
}
