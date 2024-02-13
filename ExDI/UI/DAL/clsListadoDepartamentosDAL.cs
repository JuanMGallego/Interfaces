using Ejercicio03CRUD.ViewModels.Utilis;
using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.DAL.Conexion;

namespace UI.DAL
{
    public class clsListadoDepartamentosDAL : clsVMBase
    {
        public object Id { get; internal set; }

        public async Task<ObservableCollection<clsDepartamento>> getDepartamentosDAL()

        {

            string miCadenaUrl = clsMyConexion.getUriBase();

            Uri miUri = new Uri($"{miCadenaUrl}Departamentos");

            ObservableCollection<clsDepartamento> listadoDepartamentos = new ObservableCollection<clsDepartamento>();

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

                    listadoDepartamentos = JsonConvert.DeserializeObject<ObservableCollection<clsDepartamento>>(textoJsonRespuesta);

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
