using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class List
    {
        public async static Task<List<clsDepartamento>> DepartmentsListDAL()//CONSTRUCTOR VM
        {
            string APIURL = clsMyConexion.getAPI();
            Uri uri = new Uri(APIURL + "/Departamentos");

            List<clsDepartamento> departmentList = new List<clsDepartamento>();
            HttpClient client = new HttpClient();
            HttpResponseMessage message;
            string JSONAnswer;

            try
            {
                message = await client.GetAsync(uri);
                if (message.IsSuccessStatusCode)
                {
                    JSONAnswer = await client.GetStringAsync(uri);
                    departmentList = JsonConvert.DeserializeObject<List<clsDepartamento>>(JSONAnswer);

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return departmentList;
        }
    }
}
