using System.Text.Json.Serialization;

namespace Models
{
    public class clsMensajeUsuario
    {
        #region atributos
        private string usuario;
        private string mensaje;

        #endregion

        #region constructores

        public clsMensajeUsuario()
        {

        }

        public clsMensajeUsuario(string usuario, string mensaje)
        {
            this.usuario = usuario;
            this.mensaje = mensaje;
        }
        #endregion

        #region propiedades

        [JsonPropertyName("Usuario")]
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        [JsonPropertyName("Mensaje")]
        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }

        #endregion
    }
}