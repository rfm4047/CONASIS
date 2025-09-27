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
    public class DocenteDAL
    {
        private readonly Conexion conexion;

        public DocenteDAL()
        {
            conexion = new Conexion();
        }
        public int ObtenerSiguienteCodigo()
        {
            int siguienteCodigo = 1;

            using (SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(iddocente),0)  FROM Docente", conexion.ObtenerConexion()))
            {
                conexion.AbrirConexion();
                siguienteCodigo = Convert.ToInt32(cmd.ExecuteScalar());
                conexion.CerrarConexion();
            }
            return siguienteCodigo;
        }

        // AGREGAR
        public (int IdDocente, string CPlant) AGREGAR(Docente docente)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Docente_CRUD", conexion.ObtenerConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", "AGREGAR");
                cmd.Parameters.AddWithValue("@idplantelf", docente.IdPlantelF);
                cmd.Parameters.AddWithValue("@horaplanilla", docente.HoraPlanilla);
                cmd.Parameters.AddWithValue("@cargahorariadocente", docente.CargaHorariaDocente);

                conexion.AbrirConexion();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int idDocente = reader["NuevoIdDocente"] != DBNull.Value
                            ? Convert.ToInt32(reader["NuevoIdDocente"])
                            : 0;

                        string cplant = reader["NuevoCplant"] != DBNull.Value
                            ? reader["NuevoCplant"].ToString()
                            : string.Empty;

                        conexion.CerrarConexion();
                        return (idDocente, cplant);
                    }
                    else
                    {
                        conexion.CerrarConexion();
                        throw new Exception("No se devolvió ningún dato del procedimiento almacenado.");
                    }
                }
            }
        }

        // MODIFICAR
        public void MODIFICAR(Docente docente)
        {  
            using (SqlCommand cmd = new SqlCommand("sp_Docente_CRUD", conexion.ObtenerConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", "MODIFICAR");
                cmd.Parameters.AddWithValue("@iddocente", docente.IdDocente);
                cmd.Parameters.AddWithValue("@idplantelf", docente.IdPlantelF);
                cmd.Parameters.AddWithValue("@horaplanilla", docente.HoraPlanilla);
                cmd.Parameters.AddWithValue("@cargahorariadocente", docente.CargaHorariaDocente);


                conexion.AbrirConexion();
                cmd.ExecuteNonQuery();
                conexion.CerrarConexion();
            }
        }

        // ELIMINAR
        public void Delete(int idDocente)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Docente_CRUD", conexion.ObtenerConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", "ELIMINAR");
                cmd.Parameters.AddWithValue("@iddocente", idDocente);

                conexion.AbrirConexion();
                cmd.ExecuteNonQuery();
                conexion.CerrarConexion();

            }
        }

        // LEER TODO
        public List<Docente> GetAll()
        {
            var list = new List<Docente>();
         
            using (SqlCommand cmd = new SqlCommand("sp_Docente_CRUD", conexion.ObtenerConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", "MOSTRAR");

                conexion.AbrirConexion();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new Docente
                        {
                            IdDocente = Convert.ToInt32(dr["iddocente"]),
                            IdPlantelF = Convert.ToInt32(dr["idplantelf"]),
                            HoraPlanilla = dr["horaplanilla"].ToString(),
                            CargaHorariaDocente = dr["cargahorariadocente"].ToString()
                        });
                    }
                }
            }
            return list;
        }
        public DataTable GetDocentesConPlantel()
        {
            
            using (SqlCommand cmd = new SqlCommand("sp_Docente_Plantel_Listar", conexion.ObtenerConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.AbrirConexion();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // LEER POR ID
        public DocenteFull GetById(int idDocente)
        {
            DocenteFull dto = null;

            using (SqlCommand cmd = new SqlCommand("sp_Docente_CRUD", conexion.ObtenerConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", "BUSCAR");
                cmd.Parameters.AddWithValue("@iddocente", idDocente);

                conexion.AbrirConexion();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {

                        dto = new DocenteFull
                        {
                            IdDocente = Convert.ToInt32(dr["iddocente"]),
                            IdPlantelF = Convert.ToInt32(dr["idplantelf"]),
                            HoraPlanilla = dr["horaplanilla"].ToString(),
                            CargaHorariaDocente = dr["cargahorariadocente"].ToString(),
                            CPlant = dr["cplant"].ToString(),
                            CodPlantel = dr["codplantel"] != DBNull.Value
                                 ? (int?)Convert.ToInt32(dr["codplantel"])
                                 : null,
                           // CodPlantel = dr["codplantel"] != DBNull.Value ? Convert.ToInt32(dr["codplantel"]) : 0,
                            NomPlantel = dr["nomplantel"].ToString(),
                            ApPlantel = dr["applantel"].ToString(),
                            AmPlantel = dr["amplantel"].ToString(),
                            CIPlantel = dr["ciplantel"].ToString(),
                            ExtPlantel = dr["extplantel"].ToString(),
                            GeneroPlantel =dr["generoplantel"].ToString(),
                            FechaNacPlantel = dr["fechanacplantel"] != DBNull.Value ? Convert.ToDateTime(dr["fechanacplantel"]) : DateTime.MinValue,
                            DireccionPlantel = dr["direccionplantel"].ToString(),
                            TelfPlantel = dr["telfplantel"].ToString(),
                            EspecialidadPlantel = dr["especialidadplantel"].ToString(),
                            ItemPlantel = dr["itemplantel"].ToString(),
                            RdaPlantel = dr["rdaplantel"].ToString(),
                            EstadoPlantel = dr["estadoplantel"].ToString()
                        };
                    }
                }
                conexion.CerrarConexion();
            }
            return dto;
        }
        public List<DocenteFull> BuscarPorNombre(string nombre)
        {
            var lista = new List<DocenteFull>();

            using (SqlCommand cmd = new SqlCommand("sp_Docente_CRUD", conexion.ObtenerConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", "BUSCAR_POR_NOMBRE");
                cmd.Parameters.AddWithValue("@nombre", nombre);

                conexion.AbrirConexion();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new DocenteFull
                        {
                            IdDocente = Convert.ToInt32(dr["iddocente"]),
                            IdPlantelF = Convert.ToInt32(dr["idplantelf"]),
                            HoraPlanilla = dr["horaplanilla"].ToString(),
                            CargaHorariaDocente = dr["cargahorariadocente"].ToString(),
                            CPlant = dr["cplant"].ToString(),
                            NomPlantel = dr["nomplantel"].ToString(),
                            ApPlantel = dr["applantel"].ToString(),
                            AmPlantel = dr["amplantel"].ToString(),
                            CIPlantel = dr["ciplantel"].ToString(),
                            GeneroPlantel = dr["generoplantel"].ToString(),
                            EstadoPlantel = dr["estadoplantel"].ToString()
                        });
                    }
                }
                conexion.CerrarConexion();
            }
            return lista;
        }

    }
}
