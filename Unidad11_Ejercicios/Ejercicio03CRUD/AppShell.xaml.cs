using Ejercicio03CRUD.Views;

namespace Ejercicio03CRUD
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("MainPage", typeof(MainPage));
            Routing.RegisterRoute("ListadoPersonasPage", typeof(ListadoPersonasPage));
            Routing.RegisterRoute("ListadoDepartamentosPage", typeof(ListadoDepartamentosPage));
            Routing.RegisterRoute("editarInsertarDepartamentoPage", typeof(EditarInsertarDepartamentoPage));
        }
    }
}
