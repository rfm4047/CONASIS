using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CONASIS.DAL
{
    public class DAL_Periodo
    {
        private Conexion cnx = new Conexion();

        public DataTable Mostrar(int codGestion)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "MOSTRAR"),
                new SqlParameter("@cod_gestion", codGestion)
            };

            return cnx.EjecutarSP("sp_Periodo_CRUD", parametros);
        }

        public bool Agregar(string tipo, string nombre, DateTime fechaini, DateTime fechafin, int codGestion)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "AGREGAR"),
                new SqlParameter("@tipo", tipo),
                new SqlParameter("@nombre", nombre),
                new SqlParameter("@fechaini", fechaini),
                new SqlParameter("@fechafin", fechafin),
                new SqlParameter("@cod_gestion", codGestion)
            };

            return cnx.EjecutarSPNonQuery("sp_Periodo_CRUD", parametros) > 0;
        }

        public bool Modificar(int codPeriodo, string tipo, string nombre, DateTime fechaini, DateTime fechafin, int codGestion)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "MODIFICAR"),
                new SqlParameter("@cod_periodo", codPeriodo),
                new SqlParameter("@tipo", tipo),
                new SqlParameter("@nombre", nombre),
                new SqlParameter("@fechaini", fechaini),
                new SqlParameter("@fechafin", fechafin),
                new SqlParameter("@cod_gestion", codGestion)
            };

            return cnx.EjecutarSPNonQuery("sp_Periodo_CRUD", parametros) > 0;
        }

        public bool Eliminar(int codPeriodo)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "ELIMINAR"),
                new SqlParameter("@cod_periodo", codPeriodo)
            };

            return cnx.EjecutarSPNonQuery("sp_Periodo_CRUD", parametros) > 0;
        }

        public DataTable Buscar(int codPeriodo)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "BUSCAR"),
                new SqlParameter("@cod_periodo", codPeriodo)
            };

            return cnx.EjecutarSP("sp_Periodo_CRUD", parametros);
        }
    }
}

