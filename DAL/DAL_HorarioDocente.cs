using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CONASIS.DAL
{
    public class DAL_HorarioDocente
    {
        private Conexion conexion = new Conexion();

        // Mostrar todos los horarios
        public DataTable Mostrar()
        {
            return conexion.EjecutarSP("sp_HorarioDocente_CRUD",
                new List<SqlParameter> { new SqlParameter("@Accion", "SELECT") });
        }

        // Insertar
        public int Insertar(int iddocente, int codmateria, int codcurso, int codparalelo, string diaSemana,
                            TimeSpan horaInicio, TimeSpan horaFin, TimeSpan? horaRecesoInicio, TimeSpan? horaRecesoFin, int tolerancia)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "INSERT"),
                new SqlParameter("@iddocente", iddocente),
                new SqlParameter("@codmateria", codmateria),
                new SqlParameter("@codcurso", codcurso),
                new SqlParameter("@codparalelo", codparalelo),
                new SqlParameter("@diaSemana", diaSemana),
                new SqlParameter("@horaInicio", horaInicio),
                new SqlParameter("@horaFin", horaFin),
                new SqlParameter("@horaRecesoInicio", (object)horaRecesoInicio ?? DBNull.Value),
                new SqlParameter("@horaRecesoFin", (object)horaRecesoFin ?? DBNull.Value),
                new SqlParameter("@toleranciaMinutos", tolerancia)
            };
            return conexion.EjecutarSPNonQuery("sp_HorarioDocente_CRUD", parametros);
        }

        // Actualizar
        public int Actualizar(int idhorariodoc, int iddocente, int codmateria, int codcurso, int codparalelo, string diaSemana,
                              TimeSpan horaInicio, TimeSpan horaFin, TimeSpan? horaRecesoInicio, TimeSpan? horaRecesoFin, int tolerancia)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "UPDATE"),
                new SqlParameter("@idhorariodoc", idhorariodoc),
                new SqlParameter("@iddocente", iddocente),
                new SqlParameter("@codmateria", codmateria),
                new SqlParameter("@codcurso", codcurso),
                new SqlParameter("@codparalelo", codparalelo),
                new SqlParameter("@diaSemana", diaSemana),
                new SqlParameter("@horaInicio", horaInicio),
                new SqlParameter("@horaFin", horaFin),
                new SqlParameter("@horaRecesoInicio", (object)horaRecesoInicio ?? DBNull.Value),
                new SqlParameter("@horaRecesoFin", (object)horaRecesoFin ?? DBNull.Value),
                new SqlParameter("@toleranciaMinutos", tolerancia)
            };
            return conexion.EjecutarSPNonQuery("sp_HorarioDocente_CRUD", parametros);
        }

        // Eliminar
        public int Eliminar(int idhorariodoc)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "DELETE"),
                new SqlParameter("@idhorariodoc", idhorariodoc)
            };
            return conexion.EjecutarSPNonQuery("sp_HorarioDocente_CRUD", parametros);
        }
        public DataTable MostrarMensual()
        {
            try
            {
                return conexion.EjecutarSP("sp_HorarioDocente_Mensual");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener horario docente mensual: " + ex.Message);
            }
        }
    }
}

