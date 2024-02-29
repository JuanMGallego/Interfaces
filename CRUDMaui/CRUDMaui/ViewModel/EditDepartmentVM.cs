using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;
using Entities;


namespace CRUDMaui.ViewModel
{
    class EditDepartmentVM : clsVMBase, IQueryAttributable
    {
        private clsDepartament department;
        private DelegateCommand guardar;

        public clsDepartament Department
        {
            get { return department; }
            set
            {
                if (department != value)
                {
                    department = value;
                    NotifyPropertyChanged(nameof(Department));
                }
            }
        }

        public DelegateCommand Guardar
        {
            get => guardar ?? (guardar = new DelegateCommand(async () => await SaveDepartment()));
        }

        public EditDepartmentVM()
        {
            Department = new clsDepartament();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        ///
        async void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> queryAttributes)
        {
            if (queryAttributes.ContainsKey("id"))
            {
                string id = queryAttributes["id"].ToString();
                Department = await BL.ListadosBL.clsDeparmentListBL.DetailsBL(Int32.Parse(id));

            }
        }
        public async Task LoadDepartmentDetails(int departmentId)
        {
            try
            {
                Department = await BL.ListadosBL.clsDeparmentListBL.DetailsBL(departmentId);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al cargar los detalles del departamento: {e.Message}");
            }
        }
        /// <summary>
        /// Guarda un departamento en la api o lo modifica si ya existe
        /// </summary>
        /// <returns></returns>
        public async Task SaveDepartment()
        {
            try
            {
                await BL.ManejadorasBL.clsDeparmentHandlerBL.SaveDepartmentBL(Department);
                await Shell.Current.GoToAsync("listaDepartamentos");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al guardar el departamento: {e.Message}");
            }
        }
    }
}
