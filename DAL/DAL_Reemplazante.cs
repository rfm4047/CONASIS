using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CONASIS.BDL;
using System.Data;
using System.Data.SqlClient;

namespace CONASIS.DAL
{
    public class DAL_Reemplazante
    {
        private readonly Conexion conexion = new Conexion();

        public DataTable Listar()
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "LISTAR")
            };
            return conexion.EjecutarSP("sp_Reemplazante_CRUD", parametros);
        }

        public BDL_Reemplazante Agregar(string nombre, string apPaterno, string apMaterno)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "AGREGAR"),
                new SqlParameter("@nomreemp", nombre),
                new SqlParameter("@appaternoreemp", apPaterno),
                new SqlParameter("@apmaternoreemp", apMaterno)
            };

            DataTable dt = conexion.EjecutarSP("sp_Reemplazante_CRUD", parametros);

            if (dt.Rows.Count > 0)
            {
                return new BDL_Reemplazante
                {
                    CodReemplazante = Convert.ToInt32(dt.Rows[0]["codreemplazante"]),
                    CReemp = dt.Rows[0]["creemp"].ToString(),
                    NomReemp = dt.Rows[0]["nomreemp"].ToString(),
                    ApPaternoReemp = dt.Rows[0]["appaternoreemp"].ToString(),
                    ApMaternoReemp = dt.Rows[0]["apmaternoreemp"].ToString()
                };
            }

            throw new Exception("No se pudo agregar el reemplazante.");
        }

        public BDL_Reemplazante Modificar(int cod, string nombre, string apPaterno, string apMaterno)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "MODIFICAR"),
                new SqlParameter("@codreemplazante", cod),
                new SqlParameter("@nomreemp", nombre),
                new SqlParameter("@appaternoreemp", apPaterno),
                new SqlParameter("@apmaternoreemp", apMaterno)
            };

            DataTable dt = conexion.EjecutarSP("sp_Reemplazante_CRUD", parametros);

            if (dt.Rows.Count > 0)
            {
                return new BDL_Reemplazante
                {
                    CodReemplazante = Convert.ToInt32(dt.Rows[0]["codreemplazante"]),
                    CReemp = dt.Rows[0]["creemp"].ToString(),
                    NomReemp = dt.Rows[0]["nomreemp"].ToString(),
                    ApPaternoReemp = dt.Rows[0]["appaternoreemp"].ToString(),
                    ApMaternoReemp = dt.Rows[0]["apmaternoreemp"].ToString()
                };
            }

            throw new Exception("No se pudo modificar el reemplazante.");
        }

        public void Eliminar(int cod)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "ELIMINAR"),
                new SqlParameter("@codreemplazante", cod)
            };

            conexion.EjecutarSP("sp_Reemplazante_CRUD", parametros);
        }
    }

}
