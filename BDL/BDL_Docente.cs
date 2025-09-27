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
        public class BDL_Docente
        {
            private readonly DocenteDAL dal = new DocenteDAL();

            public DataTable ListarDocentesConPlantel()
            {
                return dal.GetDocentesConPlantel();
            }
            public (int IdDocente, string CPlant) AgregarDocente(Docente docente)
            {
                return dal.AGREGAR(docente);
            }
            public int ObtenerSiguienteCodigo()
            {
                return dal.ObtenerSiguienteCodigo();
            }

            public DocenteFull ObtenerPorId(int idDocente)
            {
                return dal.GetById(idDocente);
            }
            public List<DocenteFull> BuscarPorNombre(string nombre)
            {
                return dal.BuscarPorNombre(nombre);
            }

    }

}


