using Entities;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CRUDMaui.Models
{
    public class clsPersonDeparment : clsPerson
    {
        #region Attributes
        private string departmentName;
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Constructors
        public clsPersonDeparment()
        { }

        public clsPersonDeparment(clsPerson person)
        {
            this.idDepartamento = person.idDepartamento;
            this.nombre = person.nombre;
            this.apellidos = person.apellidos;
            this.direccion = person.direccion;
            this.fechaNac = person.fechaNac;
            this.foto = person.foto;
            this.id = person.id;
            this.telefono = person.telefono;
        }
        #endregion

        #region Properties
        public string DepartmentName
        {
            get { return departmentName; }
            set { departmentName = value; }
        }

        public clsPerson Person { get; internal set; }
        #endregion

        /// <summary>
        /// Devuelve el nombre del departamento, nota devuelve debe ser Task para no romper asincronía
        /// </summary>
        /// <returns></returns>
        public async Task BuscaNombre()
        {
            clsDepartament departamento;
            departamento = await BL.ListadosBL.clsDeparmentListBL.DetailsBL(this.idDepartamento);
            if (departamento != null)
            {
                this.departmentName = departamento.nombre;
                OnPropertyChanged(nameof(DepartmentName));
            }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
