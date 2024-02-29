using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;
using BL.ListadosBL;
using BL.ManejadorasBL;
using Entities;
using System;
using System.Collections.ObjectModel;

namespace CRUDMaui.ViewModel
{
    class DepartmentsListVM : clsVMBase
    {
        #region Attributes
        private ObservableCollection<clsDepartament> listDepartments;
        private DelegateCommand addCommand;
        private DelegateCommand editCommand;
        private DelegateCommand deleteCommand;
        private clsDepartament selectedDepartament;
        #endregion

        #region Properties

        public clsDepartament SelectedDepartament
        {
            get { return selectedDepartament; }
            set
            {
                if (selectedDepartament != value)
                {
                    selectedDepartament = value;
                    NotifyPropertyChanged(nameof(SelectedDepartament));
                    editCommand.RaiseCanExecuteChanged();
                    deleteCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public ObservableCollection<clsDepartament> ListDepartments
        {
            get { return listDepartments; }
            set
            {
                if (listDepartments != value)
                {
                    listDepartments = value;
                    NotifyPropertyChanged(nameof(ListDepartments));
                    NotifyPropertyChanged(nameof(IsLoading));
                }
            }
        }
        public DelegateCommand AddCommand
        {
            get => addCommand;
        }
        public DelegateCommand DeleteCommand
        {
            get => deleteCommand;
        }
        public DelegateCommand EditCommand
        {
            get => editCommand;
        }

        public bool IsLoading => listDepartments == null || listDepartments.Count == 0;
        #endregion

        #region Constructores

        public DepartmentsListVM()
        {
            LoadDepartments();
            addCommand = new DelegateCommand(AddDepartament);
            deleteCommand = new DelegateCommand(Delete, CanDeleteDepartment);
            editCommand = new DelegateCommand(AddDepartament, CanEditDepartment);
        }
        #endregion
        #region Metodos
        private async void LoadDepartments()
        {
            ListDepartments = new ObservableCollection<clsDepartament>(await clsDeparmentListBL.DepartmentsListBL());
        }

        private async void AddDepartament()
        {

            await NavigateToInsertEditPage();

        }
        private async void Delete()
        {

            await DeleteDepartment();

        }

        private async Task NavigateToInsertEditPage()
        {
            if (selectedDepartament == null)
            {
                await Shell.Current.GoToAsync("editDeparment");
            }
            else
            {
                await Shell.Current.GoToAsync($"editDeparment?id={selectedDepartament.ID}");
            }
        }
        private async Task DeleteDepartment()
        {

            bool confirm = await Application.Current.MainPage.DisplayAlert("Eliminar Departamento", $"¿Está seguro de eliminar el departamento {SelectedDepartament.nombre}?", "Sí", "No");

            if (confirm)
            {
                bool deleted = await clsDeparmentHandlerBL.DeleteDepartmentBL(selectedDepartament.ID);

                if (deleted)
                {
                    await Application.Current.MainPage.DisplayAlert("Éxito", $"Departamento {selectedDepartament.nombre} eliminado con éxito.", "Aceptar");
                    LoadDepartments(); // Vuelve a cargar la lista después de eliminar
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Error al intentar eliminar el departamento.", "Aceptar");
                }
            }
        }
        private bool CanDeleteDepartment()
        {
            return selectedDepartament != null;
        }
        private bool CanEditDepartment()
        {
            return selectedDepartament != null;
        }
        #endregion

    }
}