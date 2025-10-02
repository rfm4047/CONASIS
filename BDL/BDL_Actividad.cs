using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CONASIS.DAL;

namespace CONASIS.BDL
{
    public class BDL_Actividad
    {
        private readonly DAL_Actividad dal = new DAL_Actividad();

        public DataTable Mostrar()
        {
            return dal.Mostrar();
        }

        public bool Agregar(string nombre, DateTime fechaini, DateTime fechafin, int codGestion)
        {
            return dal.Agregar(nombre, fechaini, fechafin, codGestion) > 0;
        }

        public bool Modificar(int codActividad, string nombre, DateTime fechaini, DateTime fechafin, int codGestion)
        {
            return dal.Modificar(codActividad, nombre, fechaini, fechafin, codGestion) > 0;
        }

        public bool Eliminar(int codActividad)
        {
            return dal.Eliminar(codActividad) > 0;
        }

        public DataTable Buscar(int codActividad)
        {
            return dal.Buscar(codActividad);
        }
    }
}
