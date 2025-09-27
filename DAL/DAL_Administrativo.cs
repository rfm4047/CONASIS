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
    public class AdministrativoDAL
    {
        private readonly Conexion conexion;

        public AdministrativoDAL()
        {
            conexion = new Conexion();
        }
        public int ObtenerSiguienteCodigo()
        {
            int siguienteCodigo = 1;

            using (SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(idadm),0)  FROM Administrativo", conexion.ObtenerConexion()))
            {
                conexion.AbrirConexion();
                siguienteCodigo = Convert.ToInt32(cmd.ExecuteScalar());
                conexion.CerrarConexion();
            }
            return siguienteCodigo;
        }

        // AGREGAR
        public (int IdAdm, string CPlant) AGREGAR(Administrativo adm)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Administrativo_CRUD", conexion.ObtenerConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", "AGREGAR");
                cmd.Parameters.AddWithValue("@idplantelf", adm.IdPlantelF);
                cmd.Parameters.AddWithValue("@cargoadm", adm.CargoAdm);

                conexion.AbrirConexion();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int idAdm = reader["NuevoIdAdm"] != DBNull.Value
                            ? Convert.ToInt32(reader["NuevoIdAdm"])
                            : 0;

                        string cplant = reader["NuevoCplant"] != DBNull.Value
                            ? reader["NuevoCplant"].ToString()
                            : string.Empty;

                        conexion.CerrarConexion();
                        return (idAdm, cplant);
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
        public void MODIFICAR(Administrativo adm)
        {
            
            using (SqlCommand cmd = new SqlCommand("sp_Administrativo_CRUD", conexion.ObtenerConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Accion", "MODIFICAR");
                cmd.Parameters.AddWithValue("@idadm", adm.IdAdm);
                cmd.Parameters.AddWithValue("@idplantelf", adm.IdPlantelF);
                cmd.Parameters.AddWithValue("@cargoadm", adm.CargoAdm);

                conexion.AbrirConexion();
                cmd.ExecuteNonQuery();
                conexion.CerrarConexion();
            }
        }

        // DELETE
        public void ELIMINAR(int idAdm)
        {
            
            using (SqlCommand cmd = new SqlCommand("sp_Administrativo_CRUD", conexion.ObtenerConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", "ELIMINAR");
                cmd.Parameters.AddWithValue("@idadm", idAdm);

                conexion.AbrirConexion();
                cmd.ExecuteNonQuery();
                conexion.CerrarConexion();
            }
        }

        // LEER TODO
        public List<Administrativo> GetAll()
        {
            var list = new List<Administrativo>();

            
            using (SqlCommand cmd = new SqlCommand("sp_Administrativo_CRUD", conexion.ObtenerConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", "MOSTRAR");

                conexion.AbrirConexion();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new Administrativo
                        {
                            IdAdm = Convert.ToInt32(dr["idadm"]),
                            IdPlantelF = Convert.ToInt32(dr["idplantelf"]),
                            CargoAdm = dr["cargoadm"].ToString()
                        });
                    }
                }
            }
            return list;
        }
        public DataTable GetAdministrativosConPlantel()
        {

            using (SqlCommand cmd = new SqlCommand("sp_Administrativo_Plantel_Listar", conexion.ObtenerConexion()))
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
        // LEER POR ID (Administrativo)
        public AdministrativoFull GetById(int idAdm)
        {
            AdministrativoFull dto = null;

            using (SqlCommand cmd = new SqlCommand("sp_Administrativo_CRUD", conexion.ObtenerConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", "BUSCAR");
                cmd.Parameters.AddWithValue("@idadm", idAdm);

                conexion.AbrirConexion();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        dto = new AdministrativoFull
                        {
                            IdAdm = Convert.ToInt32(dr["idadm"]),
                            IdPlantelF = Convert.ToInt32(dr["idplantelf"]),
                            CargoAdm = dr["cargoadm"].ToString(),
                            CPlant = dr["cplant"].ToString(),

                            CodPlantel = dr["codplantel"] != DBNull.Value
                                ? (int?)Convert.ToInt32(dr["codplantel"])
                                : null,

                            NomPlantel = dr["nomplantel"].ToString(),
                            ApPlantel = dr["applantel"].ToString(),
                            AmPlantel = dr["amplantel"].ToString(),
                            CIPlantel = dr["ciplantel"].ToString(),
                            ExtPlantel = dr["extplantel"].ToString(),
                            GeneroPlantel = dr["generoplantel"].ToString(),
                            FechaNacPlantel = dr["fechanacplantel"] != DBNull.Value
                                ? Convert.ToDateTime(dr["fechanacplantel"])
                                : DateTime.MinValue,
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
        public DataTable BuscarPorNombre(string nombre)
        {
            var parametros = new List<SqlParameter>
    {
        new SqlParameter("@nombre", nombre)
    };

            return conexion.EjecutarSP("sp_Administrativo_BuscarPorNombre", parametros);
        }


    }

}
