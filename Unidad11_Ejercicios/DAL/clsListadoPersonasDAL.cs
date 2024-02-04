using DAL.Conexion;
using Entidades;
using Newtonsoft.Json;

namespace DAL
{

    public class clsListadoPersonasDAL
    {

        public async Task<List<clsPersona>> ListadoPersonasDAL()
        {

            //Pido la cadena de la Uri al método estático

            string miCadenaUrl = clsMyConexion.getUriBase();

            Uri miUri = new Uri($"{miCadenaUrl}Personas");

            List<clsPersona> listadoPersonas = new List<clsPersona>();

            HttpClient mihttpClient;

            HttpResponseMessage miCodigoRespuesta;

            string textoJsonRespuesta;

            //Instanciamos el cliente Http

            mihttpClient = new HttpClient();

            try
            {

                miCodigoRespuesta = await mihttpClient.GetAsync(miUri);

                if (miCodigoRespuesta.IsSuccessStatusCode)
                {

                    textoJsonRespuesta = await mihttpClient.GetStringAsync(miUri);

                    mihttpClient.Dispose();

                    listadoPersonas = JsonConvert.DeserializeObject<List<clsPersona>>(textoJsonRespuesta);

                }

            }
            catch (Exception ex)
            {

                throw ex;

            }

            return listadoPersonas;

        }

    }

}


