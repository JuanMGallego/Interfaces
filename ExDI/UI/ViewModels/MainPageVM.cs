using Ejercicio03CRUD.ViewModels.Utilis;
using System.Collections.ObjectModel;
using UI.DAL;
using UI.Models;

namespace UI.ViewModels
{
    class MainPageVM : clsVMBase
    {
        private ObservableCollection<clsPersonaConDepartamentoModel> _listadoPersonas;
        private int _numeroIntentos;
        private int _numeroAciertos;

        public MainPageVM()
        {
            ListadoPersonas = new ObservableCollection<clsPersonaConDepartamentoModel>();
            NumeroIntentos = 3;
            NumeroAciertos = 0;
            ComprobarCommand = new DelegateCommand(Comprobar);
            CargarListado();
        }

        public ObservableCollection<clsPersonaConDepartamentoModel> ListadoPersonas
        {
            get { return _listadoPersonas; }
            set
            {
                _listadoPersonas = value;
                NotifyPropertyChanged();
            }
        }

        public DelegateCommand ComprobarCommand { get; }

        public DelegateCommand ReiniciarCommand { get; }

        public Page Pagina { get; set; }

        public int NumeroIntentos
        {
            get { return _numeroIntentos; }
            set
            {
                _numeroIntentos = value;
                NotifyPropertyChanged();
            }
        }

        public int NumeroAciertos
        {
            get { return _numeroAciertos; }
            set
            {
                _numeroAciertos = value;
                NotifyPropertyChanged();
            }
        }

        private async void CargarListado()
        {
            var personasDAL = new clsListadoPersonasDAL();
            var departamentosDAL = new clsListadoDepartamentosDAL();
            var listaPersonas = await personasDAL.getPersonasDAL();
            var listaDepartamentos = await departamentosDAL.getDepartamentosDAL();

            foreach (var persona in listaPersonas)
            {
                var personaModel = new clsPersonaConDepartamentoModel(persona.Id, persona.Nombre, persona.Apellidos, persona.IdDepartamento, listaDepartamentos);

                ListadoPersonas.Add(personaModel);
            }
        }

        public async void Comprobar()
        {
            foreach (var persona in ListadoPersonas)
            {
                if (persona.DepartamentoSeleccionado.Id == persona.IdDepartamento)
                {
                    NumeroAciertos++;
                }
            }

            NumeroIntentos--;

            if (NumeroAciertos == ListadoPersonas.Count)
            {
                
                var respuesta = await Application.Current.MainPage.DisplayAlert("Has ganado", "¿Quieres volver a jugar?", "Sí", "No");
                if (respuesta)
                {
                    Reiniciar();
                }
                else
                {
                    System.Environment.Exit(0);
                }
            }
            else if (NumeroIntentos == -1)
            {
                bool respuesta = await Application.Current.MainPage.DisplayAlert("Has perdido", "¿Quieres volver a jugar?", "Sí", "No");
                if (respuesta)
                {
                    Reiniciar();
                }
                else
                {
                    System.Environment.Exit(0);
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Resultado", $"Has acertado {NumeroAciertos} de {ListadoPersonas.Count}. Te quedan {NumeroIntentos} intentos.", "OK");
            }
        }

        public void Reiniciar()
        {
            NumeroIntentos = 3;
            NumeroAciertos = 0;
        }
    }
}
