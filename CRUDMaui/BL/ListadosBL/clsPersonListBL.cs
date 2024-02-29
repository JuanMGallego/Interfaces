using DAL.ListadosDAL;
using Entities;

namespace BL.ListadosBL
{
    public class clsPersonListBL
    {
        public static async Task<List<clsPerson>> PersonsListBL()
        {
            DateTime today = DateTime.Now;
            List<clsPerson> personsList;

            // Obtén la lista completa de personas desde el DAL
            personsList = await clsPersonListDAL.PersonsListDAL();

            // Verifica si hoy es viernes o sábado
            if (today.DayOfWeek == DayOfWeek.Friday || today.DayOfWeek == DayOfWeek.Saturday)
            {
                //Filtra la lista para devolver solo personas mayores de edad
                personsList = personsList.Where(person => CalculateAge(person.fechaNac) >= 18).ToList();
            }

            return personsList;
        }

        // Método para calcular la edad basada en la fecha de nacimiento
        private static int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }


        public async static Task<clsPerson> DetailsBL(int id)
        {
            clsPerson person = await clsPersonListDAL.DetailsDAL(id);
            return person;
        }
    }
}