using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CONASIS.DAL
{
    public class DAL_Docente
    {
        private Conexion cnx = new Conexion();
        DataTable table = new DataTable();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader leer;

        public DataTable Mostrar()
        {
            SqlDataAdapter da = new SqlDataAdapter("PA_MOSTRAR_DOCENTES", cnx.ObtenerConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }



        public void InsertarDocente(int idplantelf,string CargaHDocente, string HrPLanillaDocente)

        {
            cmd.Connection = cnx.ObtenerConexion();
            cnx.AbrirConexion();
            cmd.CommandText = "PA_AGREGARDOCENTE";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idplantelf", idplantelf);
            cmd.Parameters.AddWithValue("@horaplanilla", HrPLanillaDocente);
            cmd.Parameters.AddWithValue("@cargahorariadocente", CargaHDocente);
      
            

            cmd.ExecuteNonQuery();
            cnx.CerrarConexion();
            cmd.Parameters.Clear();
        }

        public void EditarDocente(string CargaHDocente, string HrPLanillaDocente, int idplantelf)

        {
            cmd.Connection = cnx.ObtenerConexion();
            cnx.AbrirConexion();
            cmd.CommandText = "PA_EDITARDOCENTE";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@horaplanilla", HrPLanillaDocente);
            cmd.Parameters.AddWithValue("@cargahorariadocente", CargaHDocente);
            cmd.Parameters.AddWithValue("@idplantelf", idplantelf);



            cmd.ExecuteNonQuery();
            cnx.CerrarConexion();
            cmd.Parameters.Clear();
        }

        public string UltimocodigoPlantel()
        {
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = cnx.ObtenerConexion();
            cnx.AbrirConexion();
            cmd2.CommandText = "PA_ULTIMOCODPLANTEL";
            cmd2.CommandType = CommandType.StoredProcedure;
            leer = cmd2.ExecuteReader();
            if (leer.Read())
            {
                return leer["codplantel"].ToString();
            }
            else
            {
                return "null";

            }
            cnx.CerrarConexion();
            cmd2.Parameters.Clear();
        }
    }
}
