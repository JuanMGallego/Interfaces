using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Models
{
    public class clsPersona
    {
        #region constructores
        //Constructor por defecto
        public clsPersona()
        {
            Id = 0;
            Nombre = "";
            Apellidos = "";

        }

        //Constructor por parametros

        public clsPersona(int Id, string Nombre, string Apellidos)
        {

            this.Id = Id;
            this.Nombre = Nombre;
            this.Apellidos = Apellidos;
        }

        public clsPersona(clsPersona p)
        {

            this.Id = p.Id;
            this.Nombre = p.Nombre;
            this.Apellidos = p.Apellidos;
        }
        #endregion

        #region Propiedades autoimplementadas

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        #endregion
    }
}
