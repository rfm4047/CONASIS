using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CONASIS.DAL
{
    public class DAL_Administrativo
    {
        private Conexion cnx = new Conexion();
        DataTable table = new DataTable();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader leer;

        public DataTable Mostrar()
        {
            cmd.Connection = cnx.ObtenerConexion();
            cnx.AbrirConexion();
            cmd.CommandText = "PA_CARGARADMINISTRATIVO";
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            table.Load(leer);
            cnx.CerrarConexion();
            return table;

        }

        public void AgregarAdministrativo(int idplantelf, string cargoadm)

        {
            cmd.Connection = cnx.ObtenerConexion();
            cnx.AbrirConexion();
            cmd.CommandText = "PA_AGREGARADMINISTRATIVO";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idplantelf", idplantelf);
            cmd.Parameters.AddWithValue("@cargoadm", cargoadm);

            cmd.ExecuteNonQuery();
            cnx.CerrarConexion();
            cmd.Parameters.Clear();
        }
        public void EditarAdministrativo(string cargoadm, int idplantelf)
        {
            cmd.Connection = cnx.ObtenerConexion();
            cnx.AbrirConexion();
            cmd.CommandText = "PA_EDITARADMINISTRATIVO";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("cargoadm", cargoadm);
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
            cmd2.CommandText = "PA_ULTIMOCODPLANTEL";// o realizarlo un Procedimiento
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
