using Ejercicio03CRUD.ViewModels.Utilis;
using DAL;
using System.Windows.Input;
using Entidades;

namespace Ejercicio03CRUD.ViewModels
{
    public class EditarInsertarDepartamentoVM : clsVMBase
    {
        private int _id = 0;
        private string _NombreDepartamento;

        public string Nombre
        {
            get { return _NombreDepartamento; }
            set
            {
                _NombreDepartamento = value;
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

            clsDepartamento oDepartamento = new clsDepartamento(_id, _NombreDepartamento);

            var editarDepartamentosDAL = new HandlerDepartamentosDAL();

            await editarDepartamentosDAL.insertaDepartamentoDAL(oDepartamento);

            await Shell.Current.GoToAsync("//ListadoDepartamentosPage");

        }
    }
}
