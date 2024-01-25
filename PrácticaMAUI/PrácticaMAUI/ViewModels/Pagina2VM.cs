using Entidades;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrácticaMAUI.ViewModels
{
    public class Pagina2VM
    {
        public Pagina2VM()
        {
            // Llama al método TaskList y espera la lista.
            TaskList().Wait();
        }

        public List<clsDepartamento> DepartamentosList { get; private set; }

        public async Task TaskList()
        {
            // Asigna la lista devuelta por el método DepartmentsListDAL a la propiedad DepartamentosList.
            DepartamentosList = await List.DepartmentsListDAL();
        }
    }
}