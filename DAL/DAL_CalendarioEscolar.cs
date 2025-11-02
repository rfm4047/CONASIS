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

        public DataTable MostrarPorGestion(int codGestion)
        {
            try
            {
                var parametros = new List<SqlParameter>
                {
                    new SqlParameter("@Accion", "MOSTRAR"),
                    new SqlParameter("@cod_gestion", codGestion)
                };

                return cnx.EjecutarSP("sp_CalendarioEscolar_CRUD", parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar calendario escolar: " + ex.Message);
            }
        }

        public void Agregar(DateTime fecha, int cod_tipodia, string motivo, int cod_gestion)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "AGREGAR"),
                new SqlParameter("@fecha", fecha),
                new SqlParameter("@cod_tipodia", cod_tipodia),
                new SqlParameter("@motivo", motivo ?? (object)DBNull.Value),
                new SqlParameter("@cod_gestion", cod_gestion)
            };
            cnx.EjecutarSPNonQuery("sp_CalendarioEscolar_CRUD", parametros);
        }

        public void Modificar(int cod_calendario, DateTime fecha, int cod_tipodia, string motivo)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "MODIFICAR"),
                new SqlParameter("@cod_calendario", cod_calendario),
                new SqlParameter("@fecha", fecha),
                new SqlParameter("@cod_tipodia", cod_tipodia),
                new SqlParameter("@motivo", motivo ?? (object)DBNull.Value)
            };
            cnx.EjecutarSPNonQuery("sp_CalendarioEscolar_CRUD", parametros);
        }

        public void Eliminar(int cod_calendario)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "ELIMINAR"),
                new SqlParameter("@cod_calendario", cod_calendario)
            };
            cnx.EjecutarSPNonQuery("sp_CalendarioEscolar_CRUD", parametros);
        }

        public DataTable Buscar(int cod_calendario)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "BUSCAR"),
                new SqlParameter("@cod_calendario", cod_calendario)
            };
            return cnx.EjecutarSP("sp_CalendarioEscolar_CRUD", parametros);
        }
        public void ModificarPorRango(DateTime fechaInicio, DateTime fechaFin, int cod_tipodia, string motivo, int cod_gestion)
        {
            try
            {
                string query = @"
                    UPDATE Calendario_Escolar
                    SET cod_tipodia = @cod_tipodia,
                        motivo = @motivo
                    WHERE fecha BETWEEN @inicio AND @fin
                      AND cod_gestion = @cod_gestion";

                using (SqlCommand cmd = new SqlCommand(query, cnx.ObtenerConexion()))
                {
                    cmd.Parameters.AddWithValue("@cod_tipodia", cod_tipodia);
                    cmd.Parameters.AddWithValue("@motivo", motivo);
                    cmd.Parameters.AddWithValue("@inicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@fin", fechaFin);
                    cmd.Parameters.AddWithValue("@cod_gestion", cod_gestion);

                    cnx.AbrirConexion();
                    cmd.ExecuteNonQuery();
                    cnx.CerrarConexion();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el tipo de día por rango: " + ex.Message);
            }
        }
        public void InsertarDesdeTipoDia(int codGestion, int codTipoDia, DateTime fechaInicio, DateTime fechaFin, string motivo)
        {
            try
            {
                for (DateTime fecha = fechaInicio; fecha <= fechaFin; fecha = fecha.AddDays(1))
                {
                    var parametros = new List<SqlParameter>
                    {
                        new SqlParameter("@Accion", "AGREGAR"),
                        new SqlParameter("@fecha", fecha),
                        new SqlParameter("@cod_tipodia", codTipoDia),
                        new SqlParameter("@motivo", motivo),
                        new SqlParameter("@cod_gestion", codGestion)
                    };

                    cnx.EjecutarSPNonQuery("sp_CalendarioEscolar_CRUD", parametros);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar en Calendario_Escolar: " + ex.Message);
            }
        }
        public void Eliminarpordia(int codCalendario)
        {
            try
            {
                var parametros = new List<SqlParameter>
                {
                    new SqlParameter("@Accion", "ELIMINAR"),
                    new SqlParameter("@cod_calendario", codCalendario)
                };

                cnx.EjecutarSPNonQuery("sp_CalendarioEscolar_CRUD", parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar día del calendario: " + ex.Message);
            }
        }

    }
}
