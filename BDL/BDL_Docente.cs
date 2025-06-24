using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CONASIS.DAL;
using System.Data;
using System.Data.SqlClient;

namespace CONASIS.BDL
{
    public class BDL_Docente
    {
        Conexion cnx = new Conexion();
        private DAL_Docente doc = new DAL_Docente();

        public DataTable mostrarDocente()
        {
          DataTable tabla = new DataTable();
         tabla = doc.Mostrar();
         return tabla;

        }

        public DataTable MostrarDocentes()
        {
            DataTable tabla = new DataTable();

            try
            {
                cnx.AbrirConexion();

                SqlCommand comando = new SqlCommand("PA_MOSTRAR_DOCENTES", cnx.ObtenerConexion());
                comando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(comando);
                da.Fill(tabla);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar docentes. " + ex.Message);
            }
            finally
            {
                cnx.CerrarConexion();
            }

            return tabla;
        }
    

        public void agregarDocente(int idplantelf, string CargaHDocente, string HrPLanillaDocente)
        {
            doc.InsertarDocente(Convert.ToInt32(idplantelf), CargaHDocente, HrPLanillaDocente);
        }

        public void editarDocente(string CargaHDocente, string HrPLanillaDocente, int idplantelf)
        {
            doc.EditarDocente(CargaHDocente, HrPLanillaDocente, Convert.ToInt32(idplantelf));
        }

        public string ultimocodigoplantel()
        {
            return doc.UltimocodigoPlantel();
        }

        public DataTable obtenerDocenteCompleto(int iddocente)
        {
            DataTable tabla = new DataTable();

            try
            {
                cnx.AbrirConexion();

                SqlCommand comando = new SqlCommand("PA_OBTENER_DOCENTE_COMPLETO", cnx.ObtenerConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@iddocente", iddocente);

                SqlDataAdapter da = new SqlDataAdapter(comando);
                da.Fill(tabla);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los datos completos del docente. " + ex.Message);
            }
            finally
            {
                cnx.CerrarConexion();
            }

            return tabla;
        }


    }


}
