using Ejercicio03CRUD.ViewModels.Utilis;
using Entidades;
using System.Collections.ObjectModel;
using UI.DAL;
using UI.Models;

namespace UI.ViewModels
{
    class MainPageVM : clsVMBase
    {
        private ObservableCollection<clsPersonaModel> _listadoPersonas;
        private string _resultado;
        private int _intentos;
        private bool _juegoTerminado;
        private ObservableCollection<clsDepartamento> _listadoDepartamentos;

        public MainPageVM()
        {
            ListadoPersonas = new ObservableCollection<clsPersonaModel>();
            ListadoDepartamentos = new ObservableCollection<clsDepartamento>();
            Resultado = "";
            Intentos = 3;
            JuegoTerminado = false;
            _ = CargarListadoPersonas();
            _ = CargarListadoDepartamentos();
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

        public string Resultado
        {
            get { return _resultado; }
            set
            {
                _resultado = value;
                NotifyPropertyChanged();
            }
        }

        public int Intentos
        {
            get { return _intentos; }
            set
            {
                _intentos = value;
                NotifyPropertyChanged();
            }
        }

        public bool JuegoTerminado
        {
            get { return _juegoTerminado; }
            set
            {
                _juegoTerminado = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<clsDepartamento> ListadoDepartamentos
        {
            get { return _listadoDepartamentos; }
            set
            {
                _listadoDepartamentos = value;
                NotifyPropertyChanged();
            }
        }

        

        public void ComprobarRespuestas()
        {
            // Recorrer el listado de personas y comparar el departamento seleccionado con el real
            int aciertos = 0;
            int fallos = 0;
            foreach (var persona in ListadoPersonas)
            {
                // Obtener el departamento real de la persona de la API
                var departamentoReal = await ObtenerDepartamentoDePersona(persona.Id);

                // Obtener el departamento seleccionado por el usuario del picker
                var departamentoSeleccionado = persona.DepartamentoSeleccionado;

                // Comparar los departamentos y contar los aciertos y los fallos
                if (departamentoReal.Id == departamentoSeleccionado.Id)
                {
                    aciertos++;
                }
                else
                {
                    fallos++;
                }
            }

            // Si el número de aciertos es igual al número de personas, el usuario ha ganado el juego
            if (aciertos == ListadoPersonas.Count)
            {
                Resultado = "¡Enhorabuena! Has acertado todos los departamentos.";
                JuegoTerminado = true;
            }
            // Si el número de aciertos es menor que el número de personas, el usuario ha fallado
            else
            {
                // Restar uno a los intentos y actualizar el resultado
                Intentos--;
                Resultado = $"Has acertado {aciertos} y has fallado {fallos}. Te quedan {Intentos} intentos.";

                // Si los intentos llegan a cero, el usuario ha perdido el juego
                if (Intentos == 0)
                {
                    Resultado = "Lo siento, has perdido el juego.";
                    JuegoTerminado = true;
                }
            }
        }

        public void ReiniciarJuego()
        {
            // Restablecer el valor de las propiedades Resultado, Intentos y JuegoTerminado
            Resultado = "";
            Intentos = 3;
            JuegoTerminado = false;

            // Recargar el listado de personas y el listado de departamentos
            _ = CargarListadoPersonas();
            _ = CargarListadoDepartamentos();
        }
    }
}
