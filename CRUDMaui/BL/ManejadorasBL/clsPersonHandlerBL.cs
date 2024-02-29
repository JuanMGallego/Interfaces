using DAL.ManejadorasDAL;
using Entities;

namespace BL.ManejadorasBL
{
    public class clsPersonHandlerBL
    {
        public async static Task<bool> SavePersonBL(clsPerson person)
        {
            return await clsPersonHandlerDAL.SavePersonDAL(person);
        }

        public async static Task<bool> DeletePersonBL(int personId)
        {
            try
            {
                return await clsPersonHandlerDAL.DeletePersonDAL(personId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la capa de lógica de negocio al intentar eliminar la persona: {ex.Message}");
            }
        }
    }
}
