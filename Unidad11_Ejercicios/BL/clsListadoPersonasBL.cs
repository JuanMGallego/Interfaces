using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Entidades;

namespace BL
{
    public class ClsListadosPersonasBL
    {

        DateTime fechaActual = DateTime.Now;

        private ListadoPersonasDAL personasDAL = new ListadoPersonasDAL();

        public int CalcularEdad(DateTime fechaNacimiento, DateTime fechaActual)
        {
            int edad = fechaActual.Year - fechaNacimiento.Year;

            // Ajustamos la edad si aún no ha llegado su cumpleaños este año
            if (fechaNacimiento > fechaActual.AddYears(-edad))
            {
                edad--;
            }

            return edad;
        }

        public async Task<List<clsPersona>> ObtenerListadoPersonasAsync()
        {
            // Obtener lista de personas desde DAL
            var listaPersonas = await personasDAL.ObtenerListadoPersonasAsync();

            // Aplicar regla de negocio: Mostrar solo personas mayores de 18 los viernes y sábados
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday || DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
            {
                listaPersonas = new List<clsPersona>(listaPersonas.Where(p => CalcularEdad(p.FechaNac, fechaActual) > 18));
            }

            return listaPersonas;
        }
    }
}