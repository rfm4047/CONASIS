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
    public class DAL_Plantel
    {
        private Conexion cnx = new Conexion();
        DataTable table = new DataTable();
        SqlCommand cmd = new SqlCommand();

        public void AgregarPlantel(string NombrePlantel, string ApPaternoPlantel, string ApMaternoPlantel, string GeneroPlantel,
            string CiPlantel, string ExtensionPlantel, string TelfPlantel, DateTime FechaNacPlantel, string DireccionPlantel,
            string EspecialidadPlantel, string ItemPlantel, string RdaPlantel)

        {
            cmd.Connection = cnx.ObtenerConexion();
            cnx.AbrirConexion();
            cmd.CommandText = "PA_GuardarPlantel";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nomplantel", NombrePlantel);
            cmd.Parameters.AddWithValue("@applantel", ApPaternoPlantel);
            cmd.Parameters.AddWithValue("@amplantel", ApMaternoPlantel);
            cmd.Parameters.AddWithValue("@generoplantel", GeneroPlantel);
            cmd.Parameters.AddWithValue("@ciplantel", CiPlantel);
            cmd.Parameters.AddWithValue("@extplantel", ExtensionPlantel);
            cmd.Parameters.AddWithValue("@telfplantel", TelfPlantel);
            cmd.Parameters.AddWithValue("@fechanacplantel", FechaNacPlantel);
            cmd.Parameters.AddWithValue("@direccionplantel", DireccionPlantel);
            cmd.Parameters.AddWithValue("@especialidadplantel", EspecialidadPlantel);
            cmd.Parameters.AddWithValue("@itemplantel", ItemPlantel);
            cmd.Parameters.AddWithValue("@rdaplantel", RdaPlantel);
           
            cmd.ExecuteNonQuery();
            cnx.CerrarConexion();
            cmd.Parameters.Clear();
        }

        public void editarPlantel(string NombrePlantel, string ApPaternoPlantel, string ApMaternoPlantel, string GeneroPlantel,
            string CiPlantel, string ExtensionPlantel, string TelfPlantel, DateTime FechaNacPlantel, string DireccionPlantel,
            string EspecialidadPlantel, string ItemPlantel, string RdaPlantel, int CodPlantel)

        {
            cmd.Connection = cnx.ObtenerConexion();
            cnx.AbrirConexion();
            cmd.CommandText = "PA_ModificarPlantel";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nomplantel", NombrePlantel);
            cmd.Parameters.AddWithValue("@applantel", ApPaternoPlantel);
            cmd.Parameters.AddWithValue("@amplantel", ApMaternoPlantel);
            cmd.Parameters.AddWithValue("@generoplantel", GeneroPlantel);
            cmd.Parameters.AddWithValue("@ciplantel", CiPlantel);
            cmd.Parameters.AddWithValue("@extplantel", ExtensionPlantel);
            cmd.Parameters.AddWithValue("@telfplantel", TelfPlantel);
            cmd.Parameters.AddWithValue("@fechanacplantel", FechaNacPlantel);
            cmd.Parameters.AddWithValue("@direccionplantel", DireccionPlantel);
            cmd.Parameters.AddWithValue("@especialidadplantel", EspecialidadPlantel);
            cmd.Parameters.AddWithValue("@itemplantel", ItemPlantel);
            cmd.Parameters.AddWithValue("@rdaplantel", RdaPlantel);
            cmd.Parameters.AddWithValue("@codplantel", CodPlantel);

            cmd.ExecuteNonQuery();
            cnx.CerrarConexion();
            cmd.Parameters.Clear();
        }


    }
}
