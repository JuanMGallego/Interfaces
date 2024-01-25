using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class clsDepartamento
    {
        public int ID { get; set; } = 0;
        public string nombre { get; set; } = "";

        public clsDepartamento() { }
        public clsDepartamento(int ID, string nombre)
        {
            this.ID = ID;
            this.nombre = nombre;
        }
    }
}
