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
    public class DAL_JuntaEsc
    {
        private readonly Conexion conexion = new Conexion();

        // 🔹 AGREGAR
        public (int nuevoId, string nuevoCodigo) Agregar(JuntaEscolar junta)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "AGREGAR"),
                new SqlParameter("@nomje", junta.NomJe),
                new SqlParameter("@appaternoje", junta.ApPaternoJe),
                new SqlParameter("@apmaternoje", junta.ApMaternoJe),
                new SqlParameter("@cije", junta.CiJe),
                new SqlParameter("@extje", junta.ExtJe),
                new SqlParameter("@telfje", junta.TelfJe ?? (object)DBNull.Value),
                new SqlParameter("@estado", junta.Estado ?? "ACTIVO"),
                new SqlParameter("@codcargo", junta.CodCargo)
            };

            DataTable dt = conexion.EjecutarSP("sp_JuntaEscolar_CRUD", parametros);
            if (dt.Rows.Count > 0)
            {
                return (
                    Convert.ToInt32(dt.Rows[0]["NuevoId"]),
                    dt.Rows[0]["NuevoCodigo"].ToString()
                );
            }
            return (0, null);
        }

        // 🔹 MODIFICAR
        public bool Modificar(JuntaEscolar junta)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "MODIFICAR"),
                new SqlParameter("@codje", junta.CodJe),
                new SqlParameter("@nomje", junta.NomJe),
                new SqlParameter("@appaternoje", junta.ApPaternoJe),
                new SqlParameter("@apmaternoje", junta.ApMaternoJe),
                new SqlParameter("@cije", junta.CiJe),
                new SqlParameter("@extje", junta.ExtJe),
                new SqlParameter("@telfje", junta.TelfJe ?? (object)DBNull.Value),
                new SqlParameter("@estado", junta.Estado),
                 new SqlParameter("@codcargo", junta.CodCargo)
            };
            return conexion.EjecutarSPNonQuery("sp_JuntaEscolar_CRUD", parametros) > 0;
        }

        // 🔹 ELIMINAR
        public bool Eliminar(int codje)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "ELIMINAR"),
                new SqlParameter("@codje", codje)
            };
            return conexion.EjecutarSPNonQuery("sp_JuntaEscolar_CRUD", parametros) > 0;
        }

        // 🔹 LISTAR TODOS
        public List<JuntaEscolar> Listar()
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "LISTAR")
            };

            DataTable dt = conexion.EjecutarSP("sp_JuntaEscolar_CRUD", parametros);
            List<JuntaEscolar> lista = new List<JuntaEscolar>();

            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new JuntaEscolar
                {
                    CodJe = Convert.ToInt32(row["codje"]),
                    Codigo = row["codigo"].ToString(),
                    NomJe = row["nomje"].ToString(),
                    ApPaternoJe = row["appaternoje"].ToString(),
                    ApMaternoJe = row["apmaternoje"].ToString(),
                    CiJe = row["cije"].ToString(),
                    ExtJe = row["extje"].ToString(),
                    TelfJe = row["telfje"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["telfje"]),
                    Estado = row["estado"].ToString(),
                    FechaCreacion = Convert.ToDateTime(row["fechacreacion"]),
                    CodCargo = row.Table.Columns.Contains("codcargo") && row["codcargo"] != DBNull.Value
                   ? Convert.ToInt32(row["codcargo"])
                   : 0,
                     NomCargo = row["nomcargo"].ToString()

                });
            }

            return lista;
        }

        // 🔹 BUSCAR POR ID
        public JuntaEscolar Buscar(int codje)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion", "BUSCAR"),
                new SqlParameter("@codje", codje)
            };

            DataTable dt = conexion.EjecutarSP("sp_JuntaEscolar_CRUD", parametros);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new JuntaEscolar
                {
                    CodJe = Convert.ToInt32(row["codje"]),
                    Codigo = row["codigo"].ToString(),
                    NomJe = row["nomje"].ToString(),
                    ApPaternoJe = row["appaternoje"].ToString(),
                    ApMaternoJe = row["apmaternoje"].ToString(),
                    CiJe = row["cije"].ToString(),
                    ExtJe = row["extje"].ToString(),
                    TelfJe = row["telfje"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["telfje"]),
                    Estado = row["estado"].ToString(),
                    FechaCreacion = Convert.ToDateTime(row["fechacreacion"])
                };
            }
            return null;
        }
    }
}


