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
    public class DAL_Gestion
    {
        private Conexion cnx = new Conexion();

        // 🔹 Mostrar todas las gestiones
        public DataTable Mostrar()
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "MOSTRAR")
            };
            return cnx.EjecutarSP("sp_Gestion_CRUD", parametros);
        }

        // 🔹 Agregar nueva gestión
        public int Agregar(string nombre, DateTime fechaini, DateTime fechafin)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "AGREGAR"),
                new SqlParameter("@nom_gestion", nombre),
                new SqlParameter("fechaini_gestion", fechaini),
                new SqlParameter("fechafin_gestion", fechafin)
            };

            // Como el SP no devuelve nada aún, podemos modificarlo para que devuelva SCOPE_IDENTITY()
            DataTable dt = cnx.EjecutarSP("sp_Gestion_CRUD", parametros);

            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0][0]);

            else
                throw new Exception("No se pudo obtener el código de la gestión.");
        }

        // 🔹 Modificar gestión existente
        public void Modificar(int cod_gestion, string nombre, DateTime fechaini, DateTime fechafin)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "MODIFICAR"),
                new SqlParameter("@cod_gestion", cod_gestion),
                new SqlParameter("@nom_gestion", nombre),
                new SqlParameter("fechaini_gestion", fechaini),
                new SqlParameter("fechafin_gestion", fechafin)
            };
            cnx.EjecutarSPNonQuery("sp_Gestion_CRUD", parametros);
        }

        // 🔹 Eliminar gestión
        public void Eliminar(int cod_gestion)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "ELIMINAR"),
                new SqlParameter("@cod_gestion", cod_gestion)
            };
            cnx.EjecutarSPNonQuery("sp_Gestion_CRUD", parametros);
        }

        // 🔹 Buscar gestión por ID
        public DataTable Buscar(int cod_gestion)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "BUSCAR"),
                new SqlParameter("@cod_gestion", cod_gestion)
            };
            return cnx.EjecutarSP("sp_Gestion_CRUD", parametros);
        }
        public int ObtenerUltimaGestion()
        {
            var parametros = new List<SqlParameter>
    {
        new SqlParameter("@Accion", "MOSTRAR")
    };
            DataTable dt = cnx.EjecutarSP("sp_Gestion_CRUD", parametros);

            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0]["cod_gestion"]); // siempre la última por el ORDER BY
                
            else
                return 0;
        }

    }
}
