using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONASIS.DAL
{


    public class DAL_Institucion
    {
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        private Conexion cnx = new Conexion();
        SqlCommand cmd = new SqlCommand();

        public DataTable Mostrar()
        {
            cmd.Connection = cnx.ObtenerConexion();
            cnx.AbrirConexion();
            cmd.CommandText = "CargarInst";
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            tabla.Load(leer);
            cnx.CerrarConexion();
            return tabla;

        }
        public bool Modificar(
    string nominst, string dptoinst, string nivelinst, string turnoinst,
    string nservicioinst, string nprogramainst, string nsieinst, string mejorarinst,
    string direccioninst, string nucleoescinst, string subdistinst, string uvinst,
    string mzinst, string distedinst, string distmuninst, string telfuniedinst,
    string telfdirectorainst, int codinst)
        {
            using (SqlConnection conexion = cnx.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("ModificarInstitucion", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nominst", nominst);
                    cmd.Parameters.AddWithValue("@dptoinst", dptoinst);
                    cmd.Parameters.AddWithValue("@nivelinst", nivelinst);
                    cmd.Parameters.AddWithValue("@turnoinst", turnoinst);
                    cmd.Parameters.AddWithValue("@nservicioinst", nservicioinst);
                    cmd.Parameters.AddWithValue("@nprogramainst", nprogramainst);
                    cmd.Parameters.AddWithValue("@nsieinst", nsieinst);
                    cmd.Parameters.AddWithValue("@mejorarinst", mejorarinst);
                    cmd.Parameters.AddWithValue("@direccioninst", direccioninst);
                    cmd.Parameters.AddWithValue("@nucleoescinst", nucleoescinst);
                    cmd.Parameters.AddWithValue("@subdistinst", subdistinst);
                    cmd.Parameters.AddWithValue("@uvinst", uvinst);
                    cmd.Parameters.AddWithValue("@mzinst", mzinst);
                    cmd.Parameters.AddWithValue("@distedinst", distedinst);
                    cmd.Parameters.AddWithValue("@distmuninst", distmuninst);
                    cmd.Parameters.AddWithValue("@telfuniedinst", telfuniedinst);
                    cmd.Parameters.AddWithValue("@telfdirectorainst", telfdirectorainst);
                    cmd.Parameters.AddWithValue("@codinst", codinst);

                    conexion.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }
    }
}
