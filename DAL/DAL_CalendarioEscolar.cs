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
    public class DAL_CalendarioEscolar
    {
        private Conexion cnx = new Conexion();

        public DataTable Mostrar()
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "MOSTRAR"),
                
            };
            return cnx.EjecutarSP("sp_CalendarioEscolar_CRUD", parametros);

        }

        public DataTable MostrarPorGestion(int cod_gestion)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "MOSTRAR"),
                new SqlParameter("@cod_gestion", cod_gestion)
            };
            return cnx.EjecutarSP("sp_CalendarioEscolar_CRUD", parametros);
        }

        public void Agregar(DateTime fecha, int idtipodia, string motivo, int cod_gestion)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "AGREGAR"),
                new SqlParameter("@fecha", fecha),
                new SqlParameter("@idtipodia", idtipodia),
                new SqlParameter("@motivo", motivo ?? (object)DBNull.Value),
                new SqlParameter("@cod_gestion", cod_gestion)
            };
            cnx.EjecutarSPNonQuery("sp_CalendarioEscolar_CRUD", parametros);
        }

        public void Modificar(int idcalendario, DateTime fecha, int idtipodia, string motivo)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "MODIFICAR"),
                new SqlParameter("@idcalendario", idcalendario),
                new SqlParameter("@fecha", fecha),
                new SqlParameter("@idtipodia", idtipodia),
                new SqlParameter("@motivo", motivo ?? (object)DBNull.Value)
            };
            cnx.EjecutarSPNonQuery("sp_CalendarioEscolar_CRUD", parametros);
        }

        public void Eliminar(int idcalendario)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "ELIMINAR"),
                new SqlParameter("@idcalendario", idcalendario)
            };
            cnx.EjecutarSPNonQuery("sp_CalendarioEscolar_CRUD", parametros);
        }

        public DataTable Buscar(int idcalendario)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "BUSCAR"),
                new SqlParameter("@idcalendario", idcalendario)
            };
            return cnx.EjecutarSP("sp_CalendarioEscolar_CRUD", parametros);
        }
    }
}
