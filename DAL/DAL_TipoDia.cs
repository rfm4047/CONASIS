using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CONASIS.DAL
{
    public class DAL_TipoDia
    {
        private Conexion cnx = new Conexion();

        public DataTable Mostrar()
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "MOSTRAR")
            };

            return cnx.EjecutarSP("sp_TipoDia_CRUD", parametros);
        }
    }
}
