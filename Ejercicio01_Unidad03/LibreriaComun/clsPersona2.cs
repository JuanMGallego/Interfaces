namespace LibreriaComun
{
    public class clsPersona2
    {
        #region atributos
        String nombre;
        String apellidos;
        #endregion

        #region constructores
        public clsPersona2()
        {
            nombre = "";
            apellidos = "";
        }

        public clsPersona2(string nombre, String apellidos)
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