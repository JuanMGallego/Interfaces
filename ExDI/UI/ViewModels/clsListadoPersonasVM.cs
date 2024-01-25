using PrácticaMAUI.ViewModels.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModels
{

    /// <summary>
    /// Clase para utilizar los datos proporcionados por la DAL, bindearlos y hacer comandos para usarlos en la vista.
    /// </summary>
    public class clsListadoPersonasVM : clsVMBase
    {

        private string nombre { get; set; } = string.Empty;
        private string apellidos { get; set; } = string.Empty;

        public clsListadoPersonasVM() { }


        //Comando para sumar los fallos, mandar el toast y si se ha llegado a 3 fallos enviar un alert para que el usuario decida si repetir o salir del juego.

    }
}
