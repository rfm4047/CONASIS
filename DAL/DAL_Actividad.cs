using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CONASIS.DAL
{
    public class DAL_Actividad
    {
        private readonly Conexion conexion = new Conexion();

        // Mostrar todas las actividades
        public DataTable Mostrar()
        {
            return conexion.EjecutarSP("sp_Actividad_CRUD",
                new List<SqlParameter> {
                    new SqlParameter("@Accion", "MOSTRAR")
                });
        }

        // Agregar una actividad
        public int Agregar(string nombre, DateTime fechaini, DateTime fechafin, int codGestion)
        {
            return conexion.EjecutarSPNonQuery("sp_Actividad_CRUD",
                new List<SqlParameter> {
                    new SqlParameter("@Accion", "AGREGAR"),
                    new SqlParameter("@nombre", nombre),
                    new SqlParameter("@fechaini", fechaini),
                    new SqlParameter("@fechafin", fechafin),
                    new SqlParameter("@cod_gestion", codGestion)
                });
        }

        // Modificar una actividad
        public int Modificar(int codActividad, string nombre, DateTime fechaini, DateTime fechafin, int codGestion)
        {
            return conexion.EjecutarSPNonQuery("sp_Actividad_CRUD",
                new List<SqlParameter> {
                    new SqlParameter("@Accion", "MODIFICAR"),
                    new SqlParameter("@cod_actividad", codActividad),
                    new SqlParameter("@nombre", nombre),
                    new SqlParameter("@fechaini", fechaini),
                    new SqlParameter("@fechafin", fechafin),
                    new SqlParameter("@cod_gestion", codGestion)
                });
        }

        // Eliminar una actividad
        public int Eliminar(int codActividad)
        {
            return conexion.EjecutarSPNonQuery("sp_Actividad_CRUD",
                new List<SqlParameter> {
                    new SqlParameter("@Accion", "ELIMINAR"),
                    new SqlParameter("@cod_actividad", codActividad)
                });
        }

        // Buscar actividad por ID
        public DataTable Buscar(int codActividad)
        {
            return conexion.EjecutarSP("sp_Actividad_CRUD",
                new List<SqlParameter> {
                    new SqlParameter("@Accion", "BUSCAR"),
                    new SqlParameter("@cod_actividad", codActividad)
                });
        }
    }
}
