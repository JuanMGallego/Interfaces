using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;
using BL.ListadosBL;
using Entities;
using System.Collections.ObjectModel;

namespace CRUDMaui.ViewModel
{
    class EditPersonVM: clsVMBase, IQueryAttributable
    {
        #region Atributos
        private ObservableCollection<clsDepartament> departaments;
        private clsPerson person;
        private clsDepartament selectedDepartment;
        private DelegateCommand guardar;
        #endregion
        #region Propiedades
        public clsPerson Person
        {
            get { return person; }
            set
            {
                if (person != value)
                {
                    person = value;

                    NotifyPropertyChanged(nameof(Person));
                }
            }
        }
        public ObservableCollection<clsDepartament> Departaments
        {
            get { return departaments; }
            set
            {
                if (departaments != value)
                {
                    departaments = value;
                    NotifyPropertyChanged(nameof(Departaments));
                }
            }
        }

        public clsDepartament SelectedDepartment
        {
            get { return selectedDepartment; }
            set
            {
                if (selectedDepartment != value)
                {
                    selectedDepartment = value;
                    NotifyPropertyChanged(nameof(SelectedDepartment));
                }
            }
        }
        /// <summary>
        /// Comando para guardar la persona en la API
        /// </summary>
        public DelegateCommand Guardar
        {
            get => guardar ?? (guardar = new DelegateCommand(async () => await SavePerson()));
        }
        #endregion
        #region Constructores
        public EditPersonVM()
        {
            LoadDepartments();
            Person = new clsPerson();

        }
        #endregion
        #region Metodos
        /// <summary>
        /// Método para cargar el listado asíncronamente
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        public async Task LoadPersonDetails(int personId)
        {
            try
            {
                Person = await BL.ListadosBL.clsPersonListBL.DetailsBL(personId);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al cargar los detalles de la persona: {e.Message}");
            }
        }
        async void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> queryAttributes)
        {
            if (queryAttributes.ContainsKey("id"))
            {
                string id = queryAttributes["id"].ToString();
                Person = await BL.ListadosBL.clsPersonListBL.DetailsBL(Int32.Parse(id));

            }
        }
        /// <summary>
        /// Carga la lista de departamentos para el desplegable
        /// </summary>
        private async void LoadDepartments()
        {
            Departaments = new ObservableCollection<clsDepartament>(await clsDeparmentListBL.DepartmentsListBL());
            NotifyPropertyChanged(nameof(Departaments));
        }

        /// <summary>
        /// Método para guardar la persona en la API
        /// </summary>
        /// <returns></returns>
        public async Task SavePerson()
        {
            try
            {
                person.idDepartamento = SelectedDepartment.ID;
                await BL.ManejadorasBL.clsPersonHandlerBL.SavePersonBL(person);
                await Shell.Current.GoToAsync("listaPersonas");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al guardar la persona: {e.Message}");
            }
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}