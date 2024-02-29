using Entities;
using Newtonsoft.Json;

namespace DAL.ListadosDAL
{
    public class clsPersonListDAL
    {
        /// <summary>
        /// Devuelve una lista de personas
        /// </summary>
        /// <returns></returns>
        public async static Task<List<clsPerson>> PersonsListDAL()
        {
            string URLAPI = clsMyConexion.getAPI();
            Uri uri = new Uri(URLAPI+"/Personas");
            List<clsPerson> persons = new List<clsPerson>();
            HttpResponseMessage message;
            HttpClient client = new HttpClient();
            string JS0NAnswer;

            message = await client.GetAsync(uri);

            if (message.IsSuccessStatusCode)
            {
                JS0NAnswer = await client.GetStringAsync(uri);
                persons = JsonConvert.DeserializeObject<List<clsPerson>>(JS0NAnswer);
            }
            return persons;
        }
        /// <summary>
        /// Devuelve los detalles de la persona cuyo ID es introducido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async static Task<clsPerson> DetailsDAL(int id)
        {

            string URLAPI = clsMyConexion.getAPI();
            Uri uri = new Uri(URLAPI+"/Personas/"+id);
            HttpClient client = new HttpClient();
            clsPerson person = new clsPerson();
            HttpResponseMessage message;
            string JSONAnswer;

            try
            {
                message = await client.GetAsync(uri);
                if (message.IsSuccessStatusCode)
                {
                    JSONAnswer = await client.GetStringAsync(uri);
                    person = JsonConvert.DeserializeObject<clsPerson>(JSONAnswer);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return person;

        }
    }
}
