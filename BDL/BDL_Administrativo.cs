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
    
        public class BDL_Administrativo
        {
            private readonly AdministrativoDAL dal = new AdministrativoDAL();

            public DataTable ListarAdministrativoConPlantel()
            {
                return dal.GetAdministrativosConPlantel();
            }
             public (int idAdm, string CPlant) AgregarAdministrativo(Administrativo administrativo)
             {
                return dal.AGREGAR(administrativo);
             }
             public int ObtenerSiguienteCodigo()
             {
                return dal.ObtenerSiguienteCodigo();
             }
            public AdministrativoFull ObtenerPorId( int idAdministrativo)
            {
                return dal.GetById(idAdministrativo);
            }
            public DataTable BuscarPorNombre(string nombre)
            {
                return dal.BuscarPorNombre(nombre);
            }

       

    }
}
   

