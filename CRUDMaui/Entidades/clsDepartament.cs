using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class clsDepartament
    {
        public int ID { get; set; }
        public string nombre { get; set; }

        public clsDepartament() { }
        public clsDepartament(int ID, string nombre)
        {
            this.ID = ID;
            this.nombre = nombre;
        }

    }
}
