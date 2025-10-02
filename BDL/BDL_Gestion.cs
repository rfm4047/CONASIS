using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CONASIS.DAL;
using System.Data;
using System.Data.SqlClient;

namespace CONASIS.BDL
{
    public class BDL_Gestion
    {
        private DAL_Gestion dal = new DAL_Gestion();

        public DataTable Mostrar()
        {
            return dal.Mostrar();
        }

        public int Agregar(string nom_gestion, DateTime fechaini, DateTime fechafin)
        {
            return dal.Agregar(nom_gestion, fechaini, fechafin);
        }

        public void Modificar(int cod_gestion, string nom_gestion, DateTime fechaini, DateTime fechafin)
        {
            dal.Modificar(cod_gestion, nom_gestion, fechaini, fechafin);
        }

        public void Eliminar(int cod_gestion)
        {
            dal.Eliminar(cod_gestion);
        }

        public DataTable Buscar(int cod_gestion)
        {
            return dal.Buscar(cod_gestion);
        }
        public int ObtenerUltimaGestion()
        {
            return dal.ObtenerUltimaGestion();
        }

    }
}
