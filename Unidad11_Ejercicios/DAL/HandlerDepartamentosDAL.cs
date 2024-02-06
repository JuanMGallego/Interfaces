using Entidades;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using DAL.Conexion;

namespace DAL
{
    public class HandlerDepartamentosDAL 
    {
        public async Task<HttpStatusCode> insertaDepartamentoDAL(clsDepartamento departamento)

        {

            HttpClient mihttpClient = new HttpClient();

            string datos;

            HttpContent contenido;

            string miCadenaUrl = clsMyConexion.getUriBase();

            Uri miUri = new Uri($"{miCadenaUrl}Departamentos");

            //Usaremos el Status de la respuesta para comprobar si ha borrado

            HttpResponseMessage miRespuesta = new HttpResponseMessage();

            try

            {

                datos = JsonConvert.SerializeObject(departamento);

                contenido = new StringContent(datos, Encoding.UTF8, "application/json");

                miRespuesta = await mihttpClient.PostAsync(miUri, contenido);

            }

            catch (Exception ex)

            {

                throw ex;

            }

            return miRespuesta.StatusCode;

        }
    }
}
