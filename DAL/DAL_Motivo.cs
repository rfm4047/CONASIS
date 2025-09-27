using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CONASIS.BDL;

namespace CONASIS.DAL
{
    public class DAL_Motivo
    {
        private readonly Conexion conexion = new Conexion();

        // 🔹 LISTAR
        public DataTable Listar()
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "LISTAR")
            };

            return conexion.EjecutarSP("sp_Motivo_CRUD", parametros);
        }

        // 🔹 AGREGAR
        public BDL_Motivo Agregar(string motivo)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "AGREGAR"),
                new SqlParameter("@motivo", motivo)
            };

            DataTable dt = conexion.EjecutarSP("sp_Motivo_CRUD", parametros);

            if (dt.Rows.Count > 0)
            {
                return new BDL_Motivo
                {
                    CodMotivo = Convert.ToInt32(dt.Rows[0]["CodMotivo"]),
                    CMot = dt.Rows[0]["CMot"].ToString(),
                    Motivo = dt.Rows[0]["Motivo"].ToString()
                };
            }

            throw new Exception("No se pudo agregar el motivo.");
        }

        // 🔹 MODIFICAR
        public BDL_Motivo Modificar(int codMotivo, string motivo)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "MODIFICAR"),
                new SqlParameter("@codmotivo", codMotivo),
                new SqlParameter("@motivo", motivo)
            };

            DataTable dt = conexion.EjecutarSP("sp_Motivo_CRUD", parametros);

            if (dt.Rows.Count > 0)
            {
                return new BDL_Motivo
                {
                    CodMotivo = Convert.ToInt32(dt.Rows[0]["CodMotivo"]),
                    CMot = dt.Rows[0]["CMot"].ToString(),
                    Motivo = dt.Rows[0]["Motivo"].ToString()
                };
            }

            throw new Exception("No se pudo modificar el motivo.");
        }

        // 🔹 ELIMINAR
        public void Eliminar(int codMotivo)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>
        {
            new SqlParameter("@Accion", "ELIMINAR"),
            new SqlParameter("@codmotivo", codMotivo)
        };

                Conexion conexion = new Conexion();
                conexion.EjecutarSPNonQuery("sp_Motivo_CRUD", parametros);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("FK_Reemplazo_Motivo"))
                {
                    throw new Exception("⚠ No se puede eliminar el motivo porque ya está siendo utilizado en reemplazos.");
                }
                else
                {
                    throw;
                }
            }

        }

    }

}
