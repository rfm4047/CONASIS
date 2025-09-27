using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CONASIS.DAL
{
    public class Conexion
    {
        private readonly SqlConnection cn;

        // 🔹 Constructor: obtiene la cadena desde app.config
        public Conexion()
        {
            string cnString = ConfigurationManager.ConnectionStrings["cnxAsistencia"].ConnectionString;
            cn = new SqlConnection(cnString);
        }

        // 🔹 Abre conexión
        public void AbrirConexion()
        {
            if (cn.State == ConnectionState.Closed)
                cn.Open();
        }

        // 🔹 Cierra conexión
        public void CerrarConexion()
        {
            if (cn.State == ConnectionState.Open)
                cn.Close();
        }

        // 🔹 Retorna la conexión (por si necesitas pasarla a otra clase)
        public SqlConnection ObtenerConexion()
        {
            return cn;
        }

        // 🔹 Ejecuta un procedimiento almacenado que devuelve un DataTable
        public DataTable EjecutarSP(string nombreSP, List<SqlParameter> parametros = null)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(nombreSP, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (parametros != null)
                        cmd.Parameters.AddRange(parametros.ToArray());

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        AbrirConexion(); // 🔹 abrir antes de usar
                        da.Fill(dt);
                        CerrarConexion(); // 🔹 cerrar después
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar SP: " + ex.Message);
            }
        }

        // 🔹 Ejecuta un procedimiento almacenado que solo inserta/actualiza/elimina (sin devolver datos)
        public int EjecutarSPNonQuery(string nombreSP, List<SqlParameter> parametros = null)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(nombreSP, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parametros != null)
                        cmd.Parameters.AddRange(parametros.ToArray());

                    AbrirConexion();
                    int filas = cmd.ExecuteNonQuery();
                    CerrarConexion();
                    return filas; // 🔹 filas afectadas
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar SP (NonQuery): " + ex.Message);
            }
        }


        // 🔹 Ejecuta un procedimiento que devuelve un valor escalar (ej. COUNT, MAX, etc.)
        public object EjecutarSPScalar(string nombreSP, List<SqlParameter> parametros = null)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(nombreSP, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parametros != null)
                        cmd.Parameters.AddRange(parametros.ToArray());

                    AbrirConexion();
                    object result = cmd.ExecuteScalar();
                    CerrarConexion();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar SP (Scalar): " + ex.Message);
            }
        }

    }
}
