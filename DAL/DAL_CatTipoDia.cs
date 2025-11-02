using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CONASIS.DAL
{
    public class DAL_CatTipoDia
    {
        private readonly Conexion conexion = new Conexion();

        public int Agregar(string nombre, string descripcion, bool estado)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "AGREGAR"),
                new SqlParameter("@nombre", nombre),
                new SqlParameter("@descripcion", descripcion),
                new SqlParameter("@estado", estado)
            };

            object result = conexion.EjecutarSPScalar("sp_CatTipoDia_CRUD", parametros);
            return Convert.ToInt32(result);
        }

        public int Modificar(int cod_cattipo, string nombre, bool estado)
        {
            Conexion cn = new Conexion();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@cod_cattipo", cod_cattipo),
                new SqlParameter("@nombre", nombre),
                new SqlParameter("@estado", estado)
            };

            return cn.EjecutarSPNonQuery("sp_CatTipoDia_Modificar", parametros);
        }


        public bool Eliminar(int cod_cattipo)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "ELIMINAR"),
                new SqlParameter("@cod_cattipo", cod_cattipo)
            };

            return conexion.EjecutarSPNonQuery("sp_CatTipoDia_CRUD", parametros) > 0;
        }

        public DataTable Mostrar()
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "MOSTRAR")
            };

            return conexion.EjecutarSP("sp_CatTipoDia_CRUD", parametros);
        }
    }
}
