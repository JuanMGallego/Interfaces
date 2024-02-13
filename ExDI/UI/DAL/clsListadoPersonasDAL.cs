using Ejercicio03CRUD.ViewModels.Utilis;
using Entidades;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using UI.DAL.Conexion;

namespace UI.DAL
{
    public class clsListadoPersonasDAL : clsVMBase
    {
        public async Task<ObservableCollection<clsPersona>> getPersonasDAL()

        {

            string miCadenaUrl = clsMyConexion.getUriBase();

            Uri miUri = new Uri($"{miCadenaUrl}Personas");

            ObservableCollection<clsPersona> listadoPersonas = new ObservableCollection<clsPersona>();

            HttpClient mihttpClient;

            HttpResponseMessage miCodigoRespuesta;

            string textoJsonRespuesta;

            mihttpClient = new HttpClient();

            try
            {

                miCodigoRespuesta = await mihttpClient.GetAsync(miUri);

                if (miCodigoRespuesta.IsSuccessStatusCode)

                {

                    textoJsonRespuesta = await mihttpClient.GetStringAsync(miUri);

                    mihttpClient.Dispose();

                    listadoPersonas = JsonConvert.DeserializeObject<ObservableCollection<clsPersona>>(textoJsonRespuesta);

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
