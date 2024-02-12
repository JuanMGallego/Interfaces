using Ejercicio03CRUD.ViewModels.Utilis;
using Entidades;
using Newtonsoft.Json;
using UI.DAL.Conexion;

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

        private async Task CargarListadoPersonas()
        {
            var personasDAL = new clsListadoPersonasDAL();
            var listaPersonas = await personasDAL.getPersonasDAL();

            foreach (var persona in listaPersonas)
            {
                // Mapear clsPersona a clsPersonaModel
                var personaModel = new clsPersonaModel
                {
                    Id = persona.Id,
                    Nombre = persona.Nombre,
                    Apellidos = persona.Apellidos
                };

                ListadoPersonas.Add(personaModel);
            }
        }

        private async Task CargarListadoDepartamentos()
        {
            // Pido la cadena de la Uri al método estático
            string miCadenaUrl = clsMyConexion.getUriBase();

            Uri miUri = new Uri($"{miCadenaUrl}Departamentos");

            List<clsDepartamento> listaDepartamentos = new List<clsDepartamento>();

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

                    listaDepartamentos = JsonConvert.DeserializeObject<List<clsDepartamento>>(textoJsonRespuesta);

                    // Añadir los departamentos al listado observable
                    foreach (var departamento in listaDepartamentos)
                    {
                        ListadoDepartamentos.Add(departamento);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
