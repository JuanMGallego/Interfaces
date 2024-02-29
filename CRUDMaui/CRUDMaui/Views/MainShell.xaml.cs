namespace CRUDMaui.Views;

public partial class MainShell : Shell
{
	public MainShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("editPerson", typeof(EditPerson));
        Routing.RegisterRoute("editDeparment", typeof(EditDeparment));
        Routing.RegisterRoute("listaDepartamentos", typeof(DeparmentsListPage));
        Routing.RegisterRoute("listaPersonas", typeof(PersonsListPage));
    }
}