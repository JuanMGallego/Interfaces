using Ejercicio03CRUD.ViewModels.Utilis;
using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.DAL.Conexion;

namespace UI.DAL
{
    public class clsListadoDepartamentosDAL : clsVMBase
    {

        public async Task<List<clsDepartamento>> getDepartamentosDAL()

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
