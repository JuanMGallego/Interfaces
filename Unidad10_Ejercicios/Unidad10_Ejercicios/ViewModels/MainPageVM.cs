using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unidad10_Ejercicios.ViewModels.Utilidades;

namespace Unidad10_Ejercicios.ViewModels
{
	internal class MainPageVM : clsVMBase
	{

		#region Atributos
		DelegateCommand buscarCommand;
		DelegateCommand eliminarCommand;
		List<clsPersona> listadoPersonas;
		cslPersona personaSeleccionada;
		String textoBusqueda;
		#endregion

		#region Constructores
		public MainPageVM()
		{
			listadoPersonas = listadoPersonas.listadoCompletoPersonas();
			buscarCommand = new DelegateCommand(buscarCommandExecute());
			eliminarCommand = new DelegateCommand(eliminarCommandCanExecute, eliminarCommandExecute);
		}

		#endregion

		#region Propiedades
		DelegateCommand BuscarCommand
		{
			get { return buscarCommand; }
		}

		public DelegateCommand EliminarCommand
		{
			get { return eliminarCommand; }
		}

		public List<clsPersona> ListadoPersonas
		{
			get { return listadoPersonas; }
		}

		public clsPersona PersonaSeleccionada
		{
			set { personaSeleccionada = value; }
		}

		public String textoBusqueda
		{

		}
		#endregion

		#region Comandos
		private void buscarCommandExecute()
		{
			throw new NotImplementedException();
		}

		private void eliminarCommandExecute()
		{
			listadoPersonas.Remove(personaSeleccionada);
			NotifyPropertyChanged("ListadoPersonas");
		}

		private bool eliminarCommandCanExecute()
		{

			bool habilitadoEliminar = false;

			if(personaSeleccionada != null)
			{
				habilitadoEliminar = true;
			}

			return habilitadoEliminar;

		}
		#endregion

		#region Metodos y Funciones
		#endregion

	}
}
