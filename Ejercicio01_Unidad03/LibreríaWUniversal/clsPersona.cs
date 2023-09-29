using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreríaWUniversal
{
    public class clsPersona
    {
        #region atributos
        String nombre;
        String apellidos;
        #endregion

        #region constructores
        public clsPersona()
        {
            nombre = "";
            apellidos = "";
        }

        public clsPersona(string nombre, String apellidos)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
        }
        #endregion

        #region propiedades
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public String Direccion { get; set; }

        public String NombreCompleto
        {
            get { return $"{nombre} {apellidos}"; }
        }
        #endregion
    }
}
