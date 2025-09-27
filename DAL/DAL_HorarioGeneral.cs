using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CONASIS.DAL
{
    public class DAL_HorarioGeneral
    {
        private Conexion cnx = new Conexion();

        public DataTable Listar()
        {
            return cnx.EjecutarSP("sp_Horario_Listar");
        }
    }
}
