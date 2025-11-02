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
        private readonly Conexion conexion = new Conexion();

        public int Agregar(int cod_gestion, int cod_cattipo, string descripcion, DateTime fechaInicio, DateTime fechaFin)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "AGREGAR"),
                new SqlParameter("@cod_gestion", cod_gestion),
                new SqlParameter("@cod_cattipo", cod_cattipo),
                new SqlParameter("@descripcion", (object)descripcion ?? DBNull.Value),
                new SqlParameter("@fecha_inicio", fechaInicio),
                new SqlParameter("@fecha_fin", fechaFin)
            };

            object result = conexion.EjecutarSPScalar("sp_TipoDia_CRUD", parametros);
            if (result == null || result == DBNull.Value) return 0;
            return Convert.ToInt32(result);
        }

        public int Modificar(int cod_tipodia, int cod_gestion, int cod_cattipo, string descripcion, DateTime fechaInicio, DateTime fechaFin)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "MODIFICAR"),
                new SqlParameter("@cod_tipodia", cod_tipodia),
                new SqlParameter("@cod_gestion", cod_gestion),
                new SqlParameter("@cod_cattipo", cod_cattipo),
                new SqlParameter("@descripcion", (object)descripcion ?? DBNull.Value),
                new SqlParameter("@fecha_inicio", fechaInicio),
                new SqlParameter(" @fecha_fin", fechaFin)
            };

            return conexion.EjecutarSPNonQuery("sp_TipoDia_CRUD", parametros);
        }

        public int Eliminar(int cod_tipodia)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "ELIMINAR"),
                new SqlParameter("@cod_tipodia", cod_tipodia)
            };

            return conexion.EjecutarSPNonQuery("sp_TipoDia_CRUD", parametros);
        }

        public DataTable MostrarPorGestion(int cod_gestion)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "BUSCAR"),
                new SqlParameter("@cod_gestion", cod_gestion)
            };

            return conexion.EjecutarSP("sp_TipoDia_CRUD", parametros);
        }
    }

}


