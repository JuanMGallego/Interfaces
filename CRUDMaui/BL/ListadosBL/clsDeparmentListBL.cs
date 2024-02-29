using Entities;
using System.Collections.ObjectModel;

namespace BL.ListadosBL
{
    public class clsDeparmentListBL
    {

        public async static Task<ObservableCollection<clsDepartament>> DepartmentsListBL()
        {
            ObservableCollection<clsDepartament> list = await DAL.ListadosDAL.clsDepartamentListDAL.DepartmentsListDAL();
            return list;
        }

        public async static Task<clsDepartament> DetailsBL(int id)
        {

            clsDepartament departament = await DAL.ListadosDAL.clsDepartamentListDAL.DetailsDAL(id);

            return departament;

        }
    }
}
