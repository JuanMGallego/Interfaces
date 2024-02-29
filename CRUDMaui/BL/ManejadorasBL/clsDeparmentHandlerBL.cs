using DAL.ManejadorasDAL;
using Entities;

namespace BL.ManejadorasBL
{
    public class clsDeparmentHandlerBL
    {
        public async static Task<bool> SaveDepartmentBL(clsDepartament department)
        {
            return await clsDeparmentHandlerDAL.SaveDepartmentDAL(department);
        }

        public async static Task<bool> DeleteDepartmentBL(int departmentId)
        {
            try
            {
                return await clsDeparmentHandlerDAL.DeleteDepartmentDAL(departmentId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la capa de lógica de negocio al intentar eliminar el departamento: {ex.Message}");
            }
        }
    }
}
