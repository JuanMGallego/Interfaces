using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class clsPerson
    {
        public int id { get; set; } = 0;
        public string nombre { get; set; } = "";
        public string apellidos { get; set; } = "";
        public string telefono { get; set; } = "";
        public string direccion { get; set; } = "";
        public string foto { get; set; } = "";
        public DateTime fechaNac { get; set; }
        public int idDepartamento { get; set; } = 0;

        public clsPerson()
        {
            fechaNac = DateTime.Now;
        }

        public clsPerson(int id, string nombre, string apellidos, DateTime fechaNacimiento, string direccion, string telefono, string foto, int idDepartamento)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.telefono = telefono;
            this.direccion = direccion;
            this.foto = foto;
            this.fechaNac = fechaNacimiento;
            this.idDepartamento = idDepartamento;
        }
    }
}
