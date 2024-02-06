using Ejercicio03CRUD.ViewModels.Utilis;
using System.Windows.Input;

namespace Ejercicio03CRUD.ViewModels
{
    public class EditarInsertarDepartamentoVM : clsVMBase
    {
        private int _id;
        private string _nombre;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                NotifyPropertyChanged();
            }
        }

        public string Nombre
        {
            get => _nombre;
            set
            {
                _nombre = value;
                NotifyPropertyChanged();
            }
        }

        public DelegateCommand GuardarCommand { get; }

        public EditarInsertarDepartamentoVM()
        {
            GuardarCommand = new DelegateCommand(Guardar);

        }

        private void Guardar()
        {
            // Aquí puedes utilizar Id y Nombre para guardar el departamento
            Console.WriteLine($"ID: {Id}, Nombre: {Nombre}");

        }
    }
}
