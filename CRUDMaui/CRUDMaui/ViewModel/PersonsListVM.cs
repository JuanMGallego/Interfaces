using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;
using BL.ListadosBL;
using Entities;
using System.Collections.ObjectModel;
using CRUDMaui.Models;
using BL.ManejadorasBL;

namespace CRUDMaui.ViewModel
{
    class PersonsListVM : clsVMBase
    {
        #region Attributes
        private ObservableCollection<clsPersonDeparment> listPersonsDepartment;
        private DelegateCommand addCommand;
        private DelegateCommand editCommand;
        private DelegateCommand deleteCommand;
        private clsPerson selectedPerson;
        #endregion

        #region Properties
        public clsPerson SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                if (selectedPerson != value)
                {
                    selectedPerson = value;
                    NotifyPropertyChanged(nameof(SelectedPerson));
                    deleteCommand.RaiseCanExecuteChanged();
                    editCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public ObservableCollection<clsPersonDeparment> ListPersonsDepartments
        {
            get { return listPersonsDepartment; }
            set
            {
                if (listPersonsDepartment != value)
                {
                    listPersonsDepartment = value;
                    NotifyPropertyChanged(nameof(ListPersonsDepartments));
                    NotifyPropertyChanged(nameof(IsLoading));
                }
            }
        }
        public DelegateCommand AddCommand
        {
            get => addCommand;
        }
        public DelegateCommand EditCommand
        {
            get => editCommand;
        }
        public DelegateCommand DeleteCommand
        {
            get => deleteCommand;
        }

        public bool IsLoading => listPersonsDepartment == null || listPersonsDepartment.Count == 0;
        #endregion
        #region Constructores
        public PersonsListVM()
        {
            Load();
            addCommand = new DelegateCommand(AddPerson);
            editCommand = new DelegateCommand(AddPerson, CanEditPerson);
            deleteCommand = new DelegateCommand(Delete, CanDeletePerson);
        }
        #endregion
        #region Métodos
        private async void Load()
        {
            List<clsPerson> personsList = new List<clsPerson>(await clsPersonListBL.PersonsListBL());
            ObservableCollection<clsPersonDeparment> updatedList = new ObservableCollection<clsPersonDeparment>();

            foreach (clsPerson person in personsList)
            {
                clsPersonDeparment nuevaPersonaDept = new clsPersonDeparment(person);
                await nuevaPersonaDept.BuscaNombre();
                updatedList.Add(nuevaPersonaDept);
            }

            ListPersonsDepartments = updatedList;
        }

        private async void AddPerson()
        {
            // Navegar a la vista de inserción
            await NavigateToInsertEditPage();
        }
        private async void Delete()
        {
            // Navegar a la vista de inserción
            await DeletePerson();
        }

        private async Task NavigateToInsertEditPage()
        {
            if (selectedPerson == null)
            {
                await Shell.Current.GoToAsync("editPerson");
            }
            else
            {
                // Navegar a la vista de edición con el nuevo ViewModel
                await Shell.Current.GoToAsync($"editPerson?id={selectedPerson.id}");
            }
        }
        private async Task DeletePerson()
        {

            bool confirm = await Application.Current.MainPage.DisplayAlert("Eliminar Persona", $"¿Está seguro de eliminar la persona {selectedPerson.nombre}?", "Sí", "No");

            if (confirm)
            {
                bool deleted = await clsPersonHandlerBL.DeletePersonBL(selectedPerson.id);

                if (deleted)
                {
                    await Application.Current.MainPage.DisplayAlert("Éxito", $"Persona {selectedPerson.nombre} eliminada con éxito.", "Aceptar");
                    Load(); // Vuelve a cargar la lista después de eliminar
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Error al intentar eliminar la persona.", "Aceptar");
                }
            }
        }

        private bool CanDeletePerson()
        {
            return selectedPerson != null;
        }
        private bool CanEditPerson()
        {
            return selectedPerson != null;
        }
        #endregion

    }
}

