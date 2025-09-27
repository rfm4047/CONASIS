using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using CONASIS.BDL;

namespace CONASIS.DAL
{
    public class DAL_Plantel
    {
        private readonly string connectionString;
        private readonly Conexion conexion;

        public DAL_Plantel(string connectionString)
        {
            this.connectionString = connectionString;
            
        }
        public DAL_Plantel()
        {
            conexion = new Conexion();
        }
        // CREATE
        public int AGREGAR(Plantel plantel)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_Plantel_CRUD", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Accion", "AGREGAR");
                cmd.Parameters.AddWithValue("@nomplantel", plantel.NomPlantel);
                cmd.Parameters.AddWithValue("@applantel", plantel.ApPlantel);
                cmd.Parameters.AddWithValue("@amplantel", plantel.AmPlantel);
                cmd.Parameters.AddWithValue("@generoplantel", plantel.GeneroPlantel);
                cmd.Parameters.AddWithValue("@ciplantel", plantel.CIPlantel);
                cmd.Parameters.AddWithValue("@extplantel", plantel.ExtPlantel);
                cmd.Parameters.AddWithValue("@telfplantel", plantel.TelfPlantel);
                cmd.Parameters.AddWithValue("@fechanacplantel", plantel.FechaNacPlantel);
                cmd.Parameters.AddWithValue("@direccionplantel", plantel.DireccionPlantel);
                cmd.Parameters.AddWithValue("@especialidadplantel", plantel.EspecialidadPlantel);
                cmd.Parameters.AddWithValue("@itemplantel", plantel.ItemPlantel);
                cmd.Parameters.AddWithValue("@rdaplantel", plantel.RdaPlantel);
                cmd.Parameters.AddWithValue("@estadoplantel", plantel.EstadoPlantel);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()); // Devuelve ID insertado
            }
        }

        // UPDATE
        public void MODIFICAR(Plantel plantel)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_Plantel_CRUD", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Accion", "MODIFICAR");
                cmd.Parameters.AddWithValue("@codplantel", plantel.CodPlantel);
                cmd.Parameters.AddWithValue("@nomplantel", plantel.NomPlantel);
                cmd.Parameters.AddWithValue("@applantel", plantel.ApPlantel);
                cmd.Parameters.AddWithValue("@amplantel", plantel.AmPlantel);
                cmd.Parameters.AddWithValue("@generoplantel", plantel.GeneroPlantel);
                cmd.Parameters.AddWithValue("@ciplantel", plantel.CIPlantel);
                cmd.Parameters.AddWithValue("@extplantel", plantel.ExtPlantel);
                cmd.Parameters.AddWithValue("@telfplantel", plantel.TelfPlantel);
                cmd.Parameters.AddWithValue("@fechanacplantel", plantel.FechaNacPlantel);
                cmd.Parameters.AddWithValue("@direccionplantel", plantel.DireccionPlantel);
                cmd.Parameters.AddWithValue("@especialidadplantel", plantel.EspecialidadPlantel);
                cmd.Parameters.AddWithValue("@itemplantel", plantel.ItemPlantel);
                cmd.Parameters.AddWithValue("@rdaplantel", plantel.RdaPlantel);
                cmd.Parameters.AddWithValue("@estadoplantel", plantel.EstadoPlantel);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void ELIMINAR(int codPlantel)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_Plantel_CRUD", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", "ELIMINAR");
                cmd.Parameters.AddWithValue("@codplantel", codPlantel);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // READ ALL
        public List<Plantel> GetAll()
        {
            var list = new List<Plantel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_Plantel_CRUD", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", "MOSTRAR");

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new Plantel
                        {
                            CodPlantel = Convert.ToInt32(dr["codplantel"]),
                            NomPlantel = dr["nomplantel"].ToString(),
                            ApPlantel = dr["applantel"].ToString(),
                            AmPlantel = dr["amplantel"].ToString(),
                            GeneroPlantel = dr["generoplantel"].ToString(),
                            CIPlantel = dr["ciplantel"].ToString(),
                            ExtPlantel = dr["extplantel"].ToString(),
                            TelfPlantel = dr["telfplantel"].ToString(),
                            FechaNacPlantel = Convert.ToDateTime(dr["fechanacplantel"]),
                            DireccionPlantel = dr["direccionplantel"].ToString(),
                            EspecialidadPlantel = dr["especialidadplantel"].ToString(),
                            ItemPlantel = dr["itemplantel"].ToString(),
                            RdaPlantel = dr["rdaplantel"].ToString(),
                            EstadoPlantel = dr["estadoplantel"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        // READ ONE
        public Plantel GetById(int codPlantel)
        {
            Plantel plantel = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_Plantel_CRUD", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", "BUSCAR");
                cmd.Parameters.AddWithValue("@codplantel", codPlantel);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        plantel = new Plantel
                        {
                            CodPlantel = Convert.ToInt32(dr["codplantel"]),
                            NomPlantel = dr["nomplantel"].ToString(),
                            ApPlantel = dr["applantel"].ToString(),
                            AmPlantel = dr["amplantel"].ToString(),
                            GeneroPlantel = dr["generoplantel"].ToString(),
                            CIPlantel = dr["ciplantel"].ToString(),
                            ExtPlantel = dr["extplantel"].ToString(),
                            TelfPlantel = dr["telfplantel"].ToString(),
                            FechaNacPlantel = Convert.ToDateTime(dr["fechanacplantel"]),
                            DireccionPlantel = dr["direccionplantel"].ToString(),
                            EspecialidadPlantel = dr["especialidadplantel"].ToString(),
                            ItemPlantel = dr["itemplantel"].ToString(),
                            RdaPlantel = dr["rdaplantel"].ToString(),
                            EstadoPlantel = dr["estadoplantel"].ToString()
                        };
                    }
                }
            }
            return plantel;
        }

        public DataTable ListarPlanteles()
        {
            return conexion.EjecutarSP("sp_ListarPlanteles");
        }

    }
}


