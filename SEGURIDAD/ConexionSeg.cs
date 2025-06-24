using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CONASIS.BDL;
using System.Data.SqlClient;

namespace CONASIS.SEGURIDAD
{
    public abstract class ConexionSeg
    {
        private readonly string connectionString;

        public ConexionSeg()
        {
            connectionString = "(local)";
        }
        protected SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
