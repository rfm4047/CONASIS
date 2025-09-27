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
    public class BDL_HorarioGeneral
    {
        private DAL_HorarioGeneral dal = new DAL_HorarioGeneral();

        public DataTable Listar()
        {
            return dal.Listar();
        }
    }
}
