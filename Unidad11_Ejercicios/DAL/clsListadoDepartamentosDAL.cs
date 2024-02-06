using DAL.Conexion;
using Entidades;
using Newtonsoft.Json;

namespace DAL
{
    public class clsListadoDepartamentosDAL
    {

        public async Task<List<clsDepartamento>> ListadoDepartamentosDAL()
        {

            //Pido la cadena de la Uri al método estático

            string miCadenaUrl = clsMyConexion.getUriBase();

            Uri miUri = new Uri($"{miCadenaUrl}Departamentos");

            List<clsDepartamento> listadoDepartamentos = new List<clsDepartamento>();

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

                    listadoDepartamentos = JsonConvert.DeserializeObject<List<clsDepartamento>>(textoJsonRespuesta);

                }

            }
            catch (Exception ex)
            {

                throw ex;

            }

            return listadoDepartamentos;

        }

    }
}
