using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CONASIS.DAL
{
    public class DAL_JuntaEsc
    {
        private Conexion cnx = new Conexion();
        DataTable table = new DataTable();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader leer;

        public DataTable Mostrar()
        {
            cmd.Connection = cnx.ObtenerConexion();
            cnx.AbrirConexion();
            cmd.CommandText = "PA_CARGARJUNTAESCOLAR";
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            table.Load(leer);
            cnx.CerrarConexion();
            return table;
        }
        public void InsertarJuntaEsc(int codrepje, string nombrerje, string apprje,string apmrje, string cirje, 
                                        string extrje, string telfrje, string cargorje)
        {
            cmd.Connection = cnx.ObtenerConexion();
            cnx.AbrirConexion();
            cmd.CommandText = "PA_AGREGARJUNTAESC";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codrepje", codrepje);
            cmd.Parameters.AddWithValue("@nombrerje",nombrerje);
            cmd.Parameters.AddWithValue("@apprje", apprje);
            cmd.Parameters.AddWithValue("@apmrje", apmrje);
            cmd.Parameters.AddWithValue("@cirje", cirje);
            cmd.Parameters.AddWithValue("@extrje", extrje);
            cmd.Parameters.AddWithValue("@telfrje", telfrje);
            cmd.Parameters.AddWithValue("@cargorje", cargorje);

            cmd.ExecuteNonQuery();
            cnx.CerrarConexion();
            cmd.Parameters.Clear();
        }

    }
}
