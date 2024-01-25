using Microsoft.Maui.Controls;
using PrácticaMAUI.ViewModels.utils;
using PrácticaMAUI.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PrácticaMAUI.ViewModels
{
    public class PaginaVM : clsVMBase
    {
        private DelegateCommand sumar;
        private string nombre { get; set; } = string.Empty; //NOMBRE
        private string apellido { get; set; } = string.Empty; //APELLIDO

        private int botonNum { get; set; } = 0;

        public PaginaVM() {

            sumar = new DelegateCommand(sumar_Execute, sumar_CanExecute);
        }
        public string Nombre{

            get { return nombre; }
            set { 

                if (nombre != value)
                {
                    nombre = value;
                    sumar.RaiseCanExecuteChanged();
                    NotifyPropertyChanged("NombreCompleto"); // TRAS CAMBIAR EL VALOR INDICAMOS QUE PROPIEDAD Función queremmos ejecutar
                }
            }
        }

        public string Apellido { 

            get {  return apellido; } 
            set 
            {
                if (apellido != value)
                {
                    apellido = value;
                    sumar.RaiseCanExecuteChanged();
                    NotifyPropertyChanged("NombreCompleto"); //Actualizar NombreCompleto
                }
            } 
        }
        public string NombreCompleto
        {
            get { return Nombre + " " + Apellido; }
        }

        public int BotonNum
        {
            get {
                
                return botonNum; 
            }

            set
            {
                if (botonNum != value){

                    botonNum = value;
                }
            }
        }

        public DelegateCommand Sumar
        {
            get { return sumar; }
        }

        public bool sumar_CanExecute()
        {
            bool can = false;
            if (nombre == string.Empty && apellido == string.Empty)
            {
                can = true;
            }
            return can;
        }

        public void sumar_Execute()
        {
            botonNum++;
            NotifyPropertyChanged("BotonNum");
        }
    }
}