using System.Collections.ObjectModel;
using System.Text;
using DAL.ListadosDAL;
using Entities;
using Newtonsoft.Json;

namespace DAL.ManejadorasDAL
{
    public class clsDeparmentHandlerDAL
    {
        /// <summary>
        /// Si el departamento no existe se inserta y si existe se modifica
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public async static Task<bool> SaveDepartmentDAL(clsDepartament department)
        {
            string APIURL = clsMyConexion.getAPI();
            Uri uri;

            HttpClient client = new HttpClient();
            string JSONContent = JsonConvert.SerializeObject(department);
            StringContent content = new StringContent(JSONContent, Encoding.UTF8, "application/json");

            HttpResponseMessage message;

            try
            {
                if (await DepartmentExistsAsync(department.ID))
                {
                    // Si el ID existe, realiza una actualización
                    uri = new Uri(APIURL + "/Departamentos/" + department.ID);
                    message = await client.PutAsync(uri, content);
                }
                else
                {
                    // Si el ID no existe, realiza una inserción
                    uri = new Uri(APIURL + "/Departamentos");
                    message = await client.PostAsync(uri, content);
                }

                return message.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Comprueba si el departamento existe para saber si modificarlo o insertarlo
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        private async static Task<bool> DepartmentExistsAsync(int departmentId)
        {
            try
            {
                ObservableCollection<clsDepartament> departmentList = await clsDepartamentListDAL.DepartmentsListDAL();

                // Verificar si el ID existe en la lista
                return departmentList.Any(d => d.ID == departmentId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Elimina un departamento según su ID
        /// </summary>
        /// <param name="departmentId">ID del departamento a eliminar</param>
        /// <returns>True si la operación se realiza con éxito, False de lo contrario</returns>
        public async static Task<bool> DeleteDepartmentDAL(int departmentId)
        {
            string APIURL = clsMyConexion.getAPI();
            Uri uri = new Uri(APIURL + "/Departamentos/" + departmentId);

            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage message = await client.DeleteAsync(uri);

                return message.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}