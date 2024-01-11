using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HandlerPersonasDAL
    {
        private readonly string apiUrl = "https://crudnervion.azurewebsites.net/api/personas";

        public async Task<List<clsPersona>> ObtenerPersonasAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(apiUrl);
                return JsonConvert.DeserializeObject<List<clsPersona>>(response);
            }
        }

    }
}
