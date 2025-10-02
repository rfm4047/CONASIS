using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CONASIS.DAL
{
    public class DAL_HorarioAdministrativo
    {
        private Conexion cnx = new Conexion();

        // Mostrar todos
        public DataTable Mostrar()
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "MOSTRAR")
            };
            return cnx.EjecutarSP("sp_HorarioAdministrativo_CRUD", parametros);
        }

        // Agregar
        public void Agregar(int idadm, string diaSemana, TimeSpan horaEntrada, TimeSpan horaSalida, TimeSpan? recesoInicio, TimeSpan? recesoFin, int toleranciaMinutos)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "AGREGAR"),
                new SqlParameter("@idadm", idadm),
                new SqlParameter("@diaSemana", diaSemana),
                new SqlParameter("@horaEntrada", horaEntrada),
                new SqlParameter("@horaSalida", horaSalida),
                new SqlParameter("@horaRecesoInicio", (object)recesoInicio ?? DBNull.Value),
                new SqlParameter("@horaRecesoFin", (object)recesoFin ?? DBNull.Value),
                new SqlParameter("@toleranciaMinutos", toleranciaMinutos)
            };

            cnx.EjecutarSPNonQuery("sp_HorarioAdministrativo_CRUD", parametros);
        }

        // Editar
        public void Modificar(int idhorarioadm, int idadm, string diaSemana, TimeSpan horaEntrada, TimeSpan horaSalida, TimeSpan? recesoInicio, TimeSpan? recesoFin, int toleranciaMinutos)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "MODIFICAR"),
                new SqlParameter("@idhorarioadm", idhorarioadm),
                new SqlParameter("@idadm", idadm),
                new SqlParameter("@diaSemana", diaSemana),
                new SqlParameter("@horaEntrada", horaEntrada),
                new SqlParameter("@horaSalida", horaSalida),
                new SqlParameter("@horaRecesoInicio", (object)recesoInicio ?? DBNull.Value),
                new SqlParameter("@horaRecesoFin", (object)recesoFin ?? DBNull.Value),
                new SqlParameter("@toleranciaMinutos", toleranciaMinutos)
            };

            cnx.EjecutarSPNonQuery("sp_HorarioAdministrativo_CRUD", parametros);
        }

        // Eliminar
        public void Eliminar(int idhorarioadm)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "ELIMINAR"),
                new SqlParameter("@idhorarioadm", idhorarioadm)
            };

            cnx.EjecutarSPNonQuery("sp_HorarioAdministrativo_CRUD", parametros);
        }

        // Buscar
        public DataTable Buscar(int idhorarioadm)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "BUSCAR"),
                new SqlParameter("@idhorarioadm", idhorarioadm)
            };

            return cnx.EjecutarSP("sp_HorarioAdministrativo_CRUD", parametros);
        }
        public DataTable MostrarResumen()
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "RESUMEN")
            };
            return cnx.EjecutarSP("sp_HorarioAdministrativo_CRUD", parametros);
        }
        public void EliminarTodos(int idadm)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "ELIMINAR_TODOS"),
                new SqlParameter("@idadm", idadm)
            };

            cnx.EjecutarSPNonQuery("sp_HorarioAdministrativo_CRUD", parametros);
        }

    }
}
