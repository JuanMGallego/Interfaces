using System.Text;
using DAL.ListadosDAL;
using Entities;
using Newtonsoft.Json;

namespace DAL.ManejadorasDAL
{
    public class clsPersonHandlerDAL
    {
        /// <summary>
        /// Guarda en la API la persona que se introduce como parametro y si ya existía se modifica
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async static Task<bool> SavePersonDAL(clsPerson person)
        {
            string APIURL = clsMyConexion.getAPI();
            Uri uri;

            HttpClient client = new HttpClient();
            string JSONContent = JsonConvert.SerializeObject(person);
            StringContent content = new StringContent(JSONContent, Encoding.UTF8, "application/json");

            HttpResponseMessage message;

            try
            {
                if (await PersonExistsAsync(person.id))
                {
                    // Si el ID existe, realiza una actualización
                    uri = new Uri(APIURL + "/Personas/" + person.id);
                    message = await client.PutAsync(uri, content);
                }
                else
                {
                    // Si el ID no existe, realiza una inserción
                    uri = new Uri(APIURL + "/Personas");
                    message = await client.PostAsync(uri, content);
                }
                string responseContent = await message.Content.ReadAsStringAsync();
                Console.WriteLine($"Response Content: {responseContent}");
                return message.IsSuccessStatusCode;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Método que comprueba si la persona existe para hacer o bien el insert o el update
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        private async static Task<bool> PersonExistsAsync(int personId)
        {
            try
            {
                List<clsPerson> personList = await clsPersonListDAL.PersonsListDAL();
                return personList.Any(p => p.id == personId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async static Task<bool> DeletePersonDAL(int personId)
        {
            string APIURL = clsMyConexion.getAPI();
            Uri uri = new Uri(APIURL + "/Personas/" + personId);

            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage message = await client.DeleteAsync(uri);

                return message.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
