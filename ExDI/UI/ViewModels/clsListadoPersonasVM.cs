using Ejercicio03CRUD.ViewModels.Utilis;
using Newtonsoft.Json;
using UI.DAL.Conexion;
using UI.Models;

namespace UI.ViewModels
{
    public class clsListadoPersonasVM : clsVMBase
    {
        private List<clsPersona> _personas;

        public List<clsPersona> Personas
        {
            get { return _personas; }
            set
            {
                _personas = value;
                NotifyPropertyChanged(); // Este método notifica a la interfaz de usuario que la propiedad ha cambiado
            }
        }

        public async Task CargarPersonas()
        {
            try
            {
                string miCadenaUrl = clsMyConexion.getUriBase();
                Uri miUri = new Uri($"{miCadenaUrl}Personas");

                using (HttpClient mihttpClient = new HttpClient())
                {
                    HttpResponseMessage miCodigoRespuesta = await mihttpClient.GetAsync(miUri);

                    if (miCodigoRespuesta.IsSuccessStatusCode)
                    {
                        string textoJsonRespuesta = await mihttpClient.GetStringAsync(miUri);
                        List<clsPersona> listadoPersonas = JsonConvert.DeserializeObject<List<clsPersona>>(textoJsonRespuesta);
                        Personas = listadoPersonas;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
