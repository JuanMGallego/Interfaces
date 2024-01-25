namespace DAL
{
    public class clsMyConexion
    {
        /// <summary>
        /// Returnea el enlace de la API para acceder en otras clases
        /// </summary>
        /// <returns>El enlace de la API</returns>
        public static string getAPI()
        {
            return "https://crudnervion.azurewebsites.net/api";
        }
    }
}
