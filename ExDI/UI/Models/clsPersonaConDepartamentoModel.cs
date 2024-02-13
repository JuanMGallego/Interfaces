using Entidades;
using System.Collections.ObjectModel;
using UI.DAL;

namespace UI.Models
{
    public class clsPersonaConDepartamentoModel
    {
        #region constructores
        public clsPersonaConDepartamentoModel()
        {
            Id = 0;
            Nombre = "";
            Apellidos = "";
            IdDepartamento = 0;
            Departamentos = new ObservableCollection<clsDepartamento>();
            DepartamentoSeleccionado = null;
        }

        public clsPersonaConDepartamentoModel(int Id, string Nombre, string Apellidos, int IdDepartamento, ObservableCollection<clsDepartamento> Departamentos)
        {

            this.Id = Id;
            this.Nombre = Nombre;
            this.Apellidos = Apellidos;
            this.IdDepartamento = IdDepartamento;
            this.Departamentos = Departamentos;
            DepartamentoSeleccionado = null;
        }

        public clsPersonaConDepartamentoModel(clsPersonaConDepartamentoModel p)
        {

            this.Id = p.Id;
            this.Nombre = p.Nombre;
            this.Apellidos = p.Apellidos;
            this.IdDepartamento = p.IdDepartamento;
            this.Departamentos = new ObservableCollection<clsDepartamento>(p.Departamentos);
            DepartamentoSeleccionado = p.DepartamentoSeleccionado;
        }
        #endregion

        #region Propiedades autoimplementadas

        public int Id { get; }

        public string Nombre { get; }

        public string Apellidos { get; }

        public int IdDepartamento { get; }

        public ObservableCollection<clsDepartamento> Departamentos { get; }

        public clsDepartamento DepartamentoSeleccionado { get; set; }

        #endregion
    }
}
