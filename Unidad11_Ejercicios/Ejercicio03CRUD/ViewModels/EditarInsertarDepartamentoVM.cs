using Ejercicio03CRUD.ViewModels.Utilis;
using DAL;
using System.Windows.Input;
using Entidades;

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

        private async void Guardar()
        {
            // Aquí puedes utilizar Id y Nombre para guardar el departamento
            Console.WriteLine($"ID: {Id}, Nombre: {Nombre}");

            clsDepartamento oDepartamento = new clsDepartamento(_id, _nombre);

            var editarDepartamentosDAL = new HandlerDepartamentosDAL();

            await editarDepartamentosDAL.insertaDepartamentoDAL(oDepartamento);

        }
    }
}
