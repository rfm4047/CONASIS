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
    public class BDL_TipoDia
    {
        private DAL_TipoDia dal = new DAL_TipoDia();

        public DataTable Mostrar()
        {
            return dal.Mostrar();
        }
    }
}
