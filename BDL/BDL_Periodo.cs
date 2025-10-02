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
    public class BDL_Periodo
    {
        private DAL_Periodo dal = new DAL_Periodo();

        public DataTable Mostrar(int codGestion)
        {
            return dal.Mostrar(codGestion);
        }

        public bool Agregar(string tipo, string nombre, DateTime fechaini, DateTime fechafin, int codGestion)
        {
            return dal.Agregar(tipo, nombre, fechaini, fechafin, codGestion);
        }

        public bool Modificar(int codPeriodo, string tipo, string nombre, DateTime fechaini, DateTime fechafin, int codGestion)
        {
            return dal.Modificar(codPeriodo, tipo, nombre, fechaini, fechafin, codGestion);
        }

        public bool Eliminar(int codPeriodo)
        {
            return dal.Eliminar(codPeriodo);
        }

        public DataTable Buscar(int codPeriodo)
        {
            return dal.Buscar(codPeriodo);
        }
    }
}
