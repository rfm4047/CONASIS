using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CONASIS.DAL
{
    public class DAL_Asignacion
    {
        private Conexion cnx = new Conexion();

        public int Insertar(string dia, TimeSpan horaInicio, TimeSpan horaFin, int idmateria, int idcurso, int iddocente)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "AGREGAR"),
                new SqlParameter("@dia", dia),
                new SqlParameter("@horainicio", horaInicio),
                new SqlParameter("@horafin", horaFin),
                new SqlParameter("@idmateriaf", idmateria),
                new SqlParameter("@idcursof", idcurso),
                new SqlParameter("@iddocentef", iddocente)
            };

            object result = cnx.EjecutarSPScalar("sp_Asignacion_CRUD", parametros);
            return Convert.ToInt32(result);
        }

        public void Modificar(int codasignacion, string dia, TimeSpan horaInicio, TimeSpan horaFin, int idmateria, int idcurso, int iddocente)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "MODIFICAR"),
                new SqlParameter("@codasignacion", codasignacion),
                new SqlParameter("@dia", dia),
                new SqlParameter("@horainicio", horaInicio),
                new SqlParameter("@horafin", horaFin),
                new SqlParameter("@idmateriaf", idmateria),
                new SqlParameter("@idcursof", idcurso),
                new SqlParameter("@iddocentef", iddocente)
            };

            cnx.EjecutarSPNonQuery("sp_Asignacion_CRUD", parametros);
        }

        public void Eliminar(int codasignacion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "ELIMINAR"),
                new SqlParameter("@codasignacion", codasignacion)
            };

            cnx.EjecutarSPNonQuery("sp_Asignacion_CRUD", parametros);
        }

        public DataTable Mostrar()
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "MOSTRAR")
            };

            return cnx.EjecutarSP("sp_Asignacion_CRUD", parametros);
        }

        public DataTable Buscar(int codasignacion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "BUSCAR"),
                new SqlParameter("@codasignacion", codasignacion)
            };

            return cnx.EjecutarSP("sp_Asignacion_CRUD", parametros);
        }
    }
}
