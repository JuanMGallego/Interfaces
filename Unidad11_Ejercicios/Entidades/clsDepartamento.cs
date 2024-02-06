namespace Entidades
{
    public class clsDepartamento
    {

        #region atributos
        private int id;
        private string nombre;

        #endregion

        #region constructores

        public clsDepartamento()
        {

        }

        public clsDepartamento(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
        #endregion

        #region propiedades
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        #endregion

    }
}
