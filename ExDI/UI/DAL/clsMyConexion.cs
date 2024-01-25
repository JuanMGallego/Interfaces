using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.DAL
{
    /// <summary>
    /// Clase para tener la conexión con la API
    /// </summary>
    public static class clsMyConexion
    {
        public static string getUriBase()
        {
            return "https://localhost/API/";
        }
    }
}
