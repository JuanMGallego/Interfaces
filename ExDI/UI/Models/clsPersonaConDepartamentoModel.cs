using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.DAL;

namespace UI.Models
{
    public class clsPersonaModel
    {
        #region constructores
        //Constructor por defecto
        public clsPersonaModel()
        {
            Id = 0;
            Nombre = "";
            Apellidos = "";
            Departamentos = new ObservableCollection<clsListadoDepartamentosDAL>();
        }

        //Constructor por parametros

        public clsPersonaModel(int Id, string Nombre, string Apellidos, ObservableCollection<clsListadoDepartamentosDAL> Departamentos)
        {

            this.Id = Id;
            this.Nombre = Nombre;
            this.Apellidos = Apellidos;
            this.Departamentos = Departamentos;
        }

        public clsPersonaModel(clsPersonaModel p)
        {

            this.Id = p.Id;
            this.Nombre = p.Nombre;
            this.Apellidos = p.Apellidos;
            this.Departamentos = new ObservableCollection<clsListadoDepartamentosDAL>(p.Departamentos);
        }
        #endregion

        #region Propiedades autoimplementadas

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public ObservableCollection<clsListadoDepartamentosDAL> Departamentos { get; set; }

        #endregion
    }
}
