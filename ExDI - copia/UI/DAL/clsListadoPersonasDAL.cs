using Ejercicio03CRUD.ViewModels.Utilis;
using Entidades;
using Newtonsoft.Json;
using UI.DAL.Conexion;
using UI.Models;

namespace UI.DAL
{
    public class clsListadoPersonasDAL : clsVMBase
    {
        public async Task<List<clsPersona>> getPersonasDAL()

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

        private async Task<clsDepartamento> ObtenerDepartamentoDePersona(int idPersona)
        {
            // Pido la cadena de la Uri al método estático
            string miCadenaUrl = clsMyConexion.getUriBase();

            Uri miUri = new Uri($"{miCadenaUrl}Personas/{idPersona}/Departamento");

            clsDepartamento departamento = null;

            HttpClient mihttpClient;

            HttpResponseMessage miCodigoRespuesta;

            string textoJsonRespuesta;

            // Instanciamos el cliente Http
            mihttpClient = new HttpClient();

            try
            {
                miCodigoRespuesta = await mihttpClient.GetAsync(miUri);

                if (miCodigoRespuesta.IsSuccessStatusCode)
                {
                    textoJsonRespuesta = await mihttpClient.GetStringAsync(miUri);

                    mihttpClient.Dispose();

                    departamento = JsonConvert.DeserializeObject<clsDepartamento>(textoJsonRespuesta);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return departamento;
        }
    }
}
