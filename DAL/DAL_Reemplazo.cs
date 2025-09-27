using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CONASIS.DAL
{
    public class DAL_Reemplazo
    {
        private readonly Conexion conexion = new Conexion();


        // === CRUD con nombres genéricos (para la BDL) ===

        public int Agregar(int idPlantelSolicita, int? idReemplazante, int? idPlantelReemplazante,
              DateTime fechaSolicitud, DateTime fechaInicio, DateTime fechaFin, int idMotivo)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@IdPlantelSolicita", SqlDbType.Int) { Value = idPlantelSolicita },
                new SqlParameter("@IdReemplazante", SqlDbType.Int) { Value = (object)idReemplazante ?? DBNull.Value },
                new SqlParameter("@IdPlantelReemplazante", SqlDbType.Int) { Value = (object)idPlantelReemplazante ?? DBNull.Value },
                new SqlParameter("@FechaSolicitud", SqlDbType.Date) { Value = fechaSolicitud.Date },
                new SqlParameter("@FechaInicio", SqlDbType.Date) { Value = fechaInicio.Date },
                new SqlParameter("@FechaFin", SqlDbType.Date) { Value = fechaFin.Date },
                new SqlParameter("@IdMotivo", SqlDbType.Int) { Value = idMotivo }
            };

            object res = conexion.EjecutarSPScalar("sp_AgregarReemplazo", parametros);
            if (res == null || res == DBNull.Value) throw new Exception("No se pudo obtener el id del reemplazo insertado.");
            return Convert.ToInt32(res);
        }

        public int Modificar(int idReemplazo, int idPlantelSolicita, int? codReemplazante, int? codPlantelReemplazante,
                      DateTime fechaSolicitud, DateTime fechaInicio, DateTime fechaFin, int idMotivo)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@IdReemplazo", SqlDbType.Int) { Value = idReemplazo },
                new SqlParameter("@IdPlantelSolicita", SqlDbType.Int) { Value = idPlantelSolicita },
                new SqlParameter("@CodReemplazante", SqlDbType.Int) { Value = (object)codReemplazante ?? DBNull.Value },
                new SqlParameter("@CodPlantelReemplazante", SqlDbType.Int) { Value = (object)codPlantelReemplazante ?? DBNull.Value },
                new SqlParameter("@FechaSolicitud", SqlDbType.Date) { Value = fechaSolicitud.Date },
                new SqlParameter("@FechaInicio", SqlDbType.Date) { Value = fechaInicio.Date },
                new SqlParameter("@FechaFin", SqlDbType.Date) { Value = fechaFin.Date },
                new SqlParameter("@IdMotivo", SqlDbType.Int) { Value = idMotivo }
            };

            return conexion.EjecutarSPNonQuery("sp_ModificarReemplazo", parametros);
        }


        public int Eliminar(int idReemplazo)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@IdReemplazo", SqlDbType.Int) { Value = idReemplazo }
            };

            return conexion.EjecutarSPNonQuery("sp_EliminarReemplazo", parametros);
        }

        public DataTable Listar()
        {
            return conexion.EjecutarSP("sp_ListarReemplazos");
        }

        public DataTable ListarPersonasReemplazo()
        {
            return conexion.EjecutarSP("sp_ListarPersonasReemplazo");
        }
    }
}
