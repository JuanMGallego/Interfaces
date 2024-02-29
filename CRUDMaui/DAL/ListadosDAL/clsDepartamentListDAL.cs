using Entities;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace DAL.ListadosDAL
{
    public class clsDepartamentListDAL
    {
        /// <summary>
        /// Devuelve una lista de departamentos de la API
        /// </summary>
        /// <returns></returns>
        public async static Task<ObservableCollection<clsDepartament>> DepartmentsListDAL()
        {
            string APIURL = clsMyConexion.getAPI();
            Uri uri = new Uri(APIURL+"/Departamentos");

            ObservableCollection<clsDepartament> departmentList = new ObservableCollection<clsDepartament>();
            HttpClient client = new HttpClient();
            HttpResponseMessage message;
            string JSONAnswer;

            try
            {
                message = await client.GetAsync(uri);
                if (message.IsSuccessStatusCode)
                {
                    JSONAnswer = await client.GetStringAsync(uri);
                    departmentList = JsonConvert.DeserializeObject<ObservableCollection<clsDepartament>>(JSONAnswer);

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return departmentList;
        }
        /// <summary>
        /// Devuelve los detalles del departamento cuyo id sea introducido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async static Task<clsDepartament> DetailsDAL(int id)
        {

            string APIURL = clsMyConexion.getAPI();
            Uri uri = new Uri(APIURL+"/Departamentos/"+id);

            clsDepartament department = new clsDepartament();
            HttpClient client = new HttpClient();
            HttpResponseMessage message;
            string JSONAnswer;

            try
            {
                message = await client.GetAsync(uri);

                if (message.IsSuccessStatusCode)
                {
                    JSONAnswer = await client.GetStringAsync(uri);
                    department = JsonConvert.DeserializeObject<clsDepartament>(JSONAnswer);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return department;


        }
    }
}
