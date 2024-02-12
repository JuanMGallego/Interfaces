using Entidades;

namespace UI.Models
{
    public class clsPersonaModel
    {
        #region constructores
        //Constructor por defecto
        public clsPersonaModel()
        {
            Id = 0;
            Nombre = "";
            Apellidos = "";
            DepartamentoSeleccionado = null;

        }

        //Constructor por parametros

        public clsPersonaModel(int Id, string Nombre, string Apellidos, clsDepartamento DepartamentoSeleccionado)
        {

            this.Id = Id;
            this.Nombre = Nombre;
            this.Apellidos = Apellidos;
            this.DepartamentoSeleccionado = DepartamentoSeleccionado;
        }

        public clsPersonaModel(clsPersonaModel p)
        {

            this.Id = p.Id;
            this.Nombre = p.Nombre;
            this.Apellidos = p.Apellidos;
            this.DepartamentoSeleccionado = p.DepartamentoSeleccionado;
        }
        #endregion

        #region Propiedades autoimplementadas

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public clsDepartamento DepartamentoSeleccionado { get; set; }

        #endregion
    }
}
